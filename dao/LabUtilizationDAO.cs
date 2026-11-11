using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using LabReservationApp.Entity;

namespace LabReservationApp.DAO
{
    public class LabUtilizationDAO
    {
        private string _connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";

        // 获取总记录数
        public int GetTotalCount(DateTime startDate, DateTime endDate)
        {
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string countSql = @"
                    SELECT COUNT(DISTINCT l.id)
                    FROM laboratory l
                    LEFT JOIN reservation r ON l.id = r.lab_id 
                    LEFT JOIN `user` u ON r.user_id = u.id 
                    WHERE 
                        DATE(r.start_time) BETWEEN @startDate AND @endDate
                        AND DAYOFWEEK(r.start_time) BETWEEN 2 AND 6
                        AND (r.status = 2 AND u.role = 2 OR r.status IS NULL);
                ";
                using (var cmd = new MySqlCommand(countSql, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@endDate", endDate.Date);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // 获取分页统计数据
        public List<LabUtilizationStats> GetPagedData(DateTime startDate, DateTime endDate, int pageIndex, int pageSize)
        {
            var stats = new List<LabUtilizationStats>();
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT 
                        l.id AS lab_id,
                        l.name AS lab_name,
                        -- 计算开放总时长（小时）
                        TIMESTAMPDIFF(HOUR, l.open_start, l.open_end) * 
                        (SELECT COUNT(*) 
                         FROM (SELECT DATE_ADD(@startDate, INTERVAL n DAY) AS date_val
                               FROM (SELECT 0 n UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8 UNION SELECT 9) t1,
                                    (SELECT 0 n UNION SELECT 10 UNION SELECT 20 UNION SELECT 30 UNION SELECT 40 UNION SELECT 50 UNION SELECT 60 UNION SELECT 70 UNION SELECT 80 UNION SELECT 90) t2
                               WHERE DATE_ADD(@startDate, INTERVAL (t1.n + t2.n) DAY) <= @endDate
                             ) dates
                         WHERE DAYOFWEEK(date_val) BETWEEN 2 AND 6
                        ) AS open_hours,
                        -- 计算教师实际使用总时长（小时）
                        SUM(CASE 
                            WHEN r.status = 2 AND u.role = 2
                            THEN TIMESTAMPDIFF(HOUR, r.start_time, r.end_time) 
                            ELSE 0 
                        END) AS used_hours,
                        -- 计算利用率
                        ROUND(
                            IFNULL(SUM(CASE WHEN r.status = 2 AND u.role = 2 THEN TIMESTAMPDIFF(HOUR, r.start_time, r.end_time) ELSE 0 END), 0) / 
                            (TIMESTAMPDIFF(HOUR, l.open_start, l.open_end) * 
                             (SELECT COUNT(*) FROM (SELECT DATE_ADD(@startDate, INTERVAL n DAY) AS date_val FROM (SELECT 0 n UNION SELECT 1 UNION SELECT 2 UNION SELECT 3 UNION SELECT 4 UNION SELECT 5 UNION SELECT 6 UNION SELECT 7 UNION SELECT 8 UNION SELECT 9) t1, (SELECT 0 n UNION SELECT 10 UNION SELECT 20 UNION SELECT 30 UNION SELECT 40 UNION SELECT 50 UNION SELECT 60 UNION SELECT 70 UNION SELECT 80 UNION SELECT 90) t2 WHERE DATE_ADD(@startDate, INTERVAL (t1.n + t2.n) DAY) <= @endDate) dates WHERE DAYOFWEEK(date_val) BETWEEN 2 AND 6)) * 100, 2
                        ) AS utilization_rate
                    FROM 
                        laboratory l
                    LEFT JOIN reservation r ON l.id = r.lab_id 
                    LEFT JOIN `user` u ON r.user_id = u.id 
                    WHERE 
                        DATE(r.start_time) BETWEEN @startDate AND @endDate
                        AND DAYOFWEEK(r.start_time) BETWEEN 2 AND 6
                    GROUP BY 
                        l.id, l.name
                    ORDER BY 
                        utilization_rate DESC
                    LIMIT @offset, @pageSize;
                ";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@startDate", startDate.Date);
                    cmd.Parameters.AddWithValue("@endDate", endDate.Date);
                    cmd.Parameters.AddWithValue("@offset", (pageIndex - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            stats.Add(new LabUtilizationStats
                            {
                                LabId = reader.GetInt64("lab_id"),
                                LabName = reader.GetString("lab_name"),
                                OpenHours = reader.GetInt32("open_hours"),
                                UsedHours = reader.IsDBNull(reader.GetOrdinal("used_hours")) ? 0 : reader.GetInt32("used_hours"),
                                UtilizationRate = (double)reader.GetDecimal("utilization_rate")
                            });
                        }
                    }
                }
            }
            return stats;
        }
    }
}