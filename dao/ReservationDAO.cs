
using LabReservationApp.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LabReservationApp.DAO
{
    public class ReservationDAO
    {
        // 统一数据库连接字符串
        private string _connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";

        public void AddReservation(Reservation reservation)
        {
            string sql = @"
                INSERT INTO reservation 
                (lab_id, teacher_id, reserve_date, reserve_start, reserve_end, status)
                VALUES 
                (@labId, @teacherId, @reserveDate, @reserveStart, @reserveEnd, @status)";

            using (MySqlConnection conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@labId", reservation.LabId);
                    cmd.Parameters.AddWithValue("@teacherId", reservation.TeacherId);
                    cmd.Parameters.AddWithValue("@reserveDate", reservation.ReserveDate);
                    cmd.Parameters.AddWithValue("@reserveStart", reservation.ReserveStart);
                    cmd.Parameters.AddWithValue("@reserveEnd", reservation.ReserveEnd);
                    cmd.Parameters.AddWithValue("@status", reservation.Status);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Reservation> GetReservations(int pageIndex, int pageSize)
        {
            List<Reservation> reservations = new List<Reservation>();
            int offset = (pageIndex - 1) * pageSize;

            using (MySqlConnection connection = new MySqlConnection(_connStr))
            {
                connection.Open();
                string sql = @"
                    SELECT id, lab_id, teacher_id, reserve_date, reserve_start, reserve_end, 
                           status, signin_time, signout_time
                    FROM reservation
                    ORDER BY id
                    LIMIT @Offset, @PageSize";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reservation reservation = new Reservation
                            {
                                Id = reader.GetInt64("id"),
                                LabId = reader.GetInt64("lab_id"),
                                TeacherId = reader.GetInt64("teacher_id"),
                                ReserveDate = reader.GetDateTime("reserve_date"),
                                ReserveStart = reader.GetTimeSpan("reserve_start"),
                                ReserveEnd = reader.GetTimeSpan("reserve_end"),
                                Status = reader.GetByte("status"),
                            };

                            // 处理 SigninTime
                            int signinTimeOrdinal = reader.GetOrdinal("signin_time");
                            if (reader.IsDBNull(signinTimeOrdinal))
                            {
                                reservation.SigninTime = null;
                            }
                            else
                            {
                                reservation.SigninTime = reader.GetDateTime(signinTimeOrdinal);
                            }

                            // 处理 SignoutTime
                            int signoutTimeOrdinal = reader.GetOrdinal("signout_time");
                            if (reader.IsDBNull(signoutTimeOrdinal))
                            {
                                reservation.SignoutTime = null;
                            }
                            else
                            {
                                reservation.SignoutTime = reader.GetDateTime(signoutTimeOrdinal);
                            }

                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public int GetTotalCount()
        {
            using (MySqlConnection connection = new MySqlConnection(_connStr))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM reservation";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void UpdateReservationStatus(long reservationId, byte newStatus)
        {
            using (MySqlConnection connection = new MySqlConnection(_connStr))
            {
                connection.Open();
                string sql = "UPDATE reservation SET status = @Status WHERE id = @Id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Status", newStatus);
                    command.Parameters.AddWithValue("@Id", reservationId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public int GetTotalCountByStatus(string statusFilter)
        {
            string statusSql = "";
            switch (statusFilter)
            {
                case "待审核": statusSql = "status = 0"; break;
                case "已通过": statusSql = "status = 1"; break;
                case "已驳回": statusSql = "status = 2"; break;
                case "已签到": statusSql = "status = 3"; break;
                case "已签退": statusSql = "status = 4"; break;
                default: statusSql = "1=1"; break; // 全部
            }

            using (MySqlConnection connection = new MySqlConnection(_connStr))
            {
                connection.Open();
                string sql = $"SELECT COUNT(*) FROM reservation WHERE {statusSql}";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void UpdateReservation1(Reservation reservation)
        {
            using (MySqlConnection connection = new MySqlConnection(_connStr))
            {
                connection.Open();
                string sql = @"
                    UPDATE reservation 
                    SET lab_id = @LabId, 
                        teacher_id = @TeacherId, 
                        reserve_date = @ReserveDate, 
                        reserve_start = @ReserveStart, 
                        reserve_end = @ReserveEnd, 
                        status = @Status, 
                        signin_time = @SigninTime, 
                        signout_time = @SignoutTime 
                    WHERE id = @Id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@LabId", reservation.LabId);
                    command.Parameters.AddWithValue("@TeacherId", reservation.TeacherId);
                    command.Parameters.AddWithValue("@ReserveDate", reservation.ReserveDate);
                    command.Parameters.AddWithValue("@ReserveStart", reservation.ReserveStart);
                    command.Parameters.AddWithValue("@ReserveEnd", reservation.ReserveEnd);
                    command.Parameters.AddWithValue("@Status", reservation.Status);

                    // 处理可空时间
                    if (reservation.SigninTime.HasValue)
                    {
                        command.Parameters.AddWithValue("@SigninTime", reservation.SigninTime.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SigninTime", DBNull.Value);
                    }

                    if (reservation.SignoutTime.HasValue)
                    {
                        command.Parameters.AddWithValue("@SignoutTime", reservation.SignoutTime.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SignoutTime", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@Id", reservation.Id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Reservation GetReservationById(long reservationId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connStr))
            {
                connection.Open();
                string sql = @"
                    SELECT id, lab_id, teacher_id, reserve_date, reserve_start, reserve_end, 
                           status, signin_time, signout_time
                    FROM reservation
                    WHERE id = @Id";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Id", reservationId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 同之前的读取逻辑...
                            Reservation reservation = new Reservation
                            {
                                Id = reader.GetInt64("id"),
                                LabId = reader.GetInt64("lab_id"),
                                TeacherId = reader.GetInt64("teacher_id"),
                                ReserveDate = reader.GetDateTime("reserve_date"),
                                ReserveStart = reader.GetTimeSpan("reserve_start"),
                                ReserveEnd = reader.GetTimeSpan("reserve_end"),
                                Status = reader.GetByte("status"),
                            };

                            int signinTimeOrdinal = reader.GetOrdinal("signin_time");
                            if (reader.IsDBNull(signinTimeOrdinal))
                            {
                                reservation.SigninTime = null;
                            }
                            else
                            {
                                reservation.SigninTime = reader.GetDateTime(signinTimeOrdinal);
                            }

                            int signoutTimeOrdinal = reader.GetOrdinal("signout_time");
                            if (reader.IsDBNull(signoutTimeOrdinal))
                            {
                                reservation.SignoutTime = null;
                            }
                            else
                            {
                                reservation.SignoutTime = reader.GetDateTime(signoutTimeOrdinal);
                            }

                            return reservation;
                        }
                        return null;
                    }
                }
            }
        }


        public List<Reservation> GetReservationsByStatus1(int pageIndex, int pageSize, string statusFilter)
        {
            List<Reservation> reservations = new List<Reservation>();
            int offset = (pageIndex - 1) * pageSize;
            string statusSql = "";

            // 处理状态筛选
            switch (statusFilter)
            {
                case "待审核": statusSql = "status = 0"; break;
                case "已通过": statusSql = "status = 1"; break;
                case "已驳回": statusSql = "status = 2"; break;
                case "已签到": statusSql = "status = 3"; break;
                case "已签退": statusSql = "status = 4"; break;
                default: statusSql = "1=1"; break; // 全部
            }

            using (MySqlConnection connection = new MySqlConnection(_connStr))
            {
                connection.Open();
                string sql = $@"
                    SELECT id, lab_id, teacher_id, reserve_date, reserve_start, reserve_end, 
                           status, signin_time, signout_time
                    FROM reservation
                    WHERE {statusSql}
                    ORDER BY id
                    LIMIT @Offset, @PageSize";

                using (MySqlCommand command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 同之前的读取逻辑...
                            Reservation reservation = new Reservation
                            {
                                Id = reader.GetInt64("id"),
                                LabId = reader.GetInt64("lab_id"),
                                TeacherId = reader.GetInt64("teacher_id"),
                                ReserveDate = reader.GetDateTime("reserve_date"),
                                ReserveStart = reader.GetTimeSpan("reserve_start"),
                                ReserveEnd = reader.GetTimeSpan("reserve_end"),
                                Status = reader.GetByte("status"),
                            };

                            int signinTimeOrdinal = reader.GetOrdinal("signin_time");
                            if (reader.IsDBNull(signinTimeOrdinal))
                            {
                                reservation.SigninTime = null;
                            }
                            else
                            {
                                reservation.SigninTime = reader.GetDateTime(signinTimeOrdinal);
                            }

                            int signoutTimeOrdinal = reader.GetOrdinal("signout_time");
                            if (reader.IsDBNull(signoutTimeOrdinal))
                            {
                                reservation.SignoutTime = null;
                            }
                            else
                            {
                                reservation.SignoutTime = reader.GetDateTime(signoutTimeOrdinal);
                            }

                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }
        public List<LabUtilizationStats> GetLabUtilizationStats()
        {
            var result = new List<LabUtilizationStats>();
            using (var conn = new MySqlConnection(_connStr))
            {
                conn.Open();
                string sql = @"
    SELECT 
        r.lab_id AS LabId,
        l.name AS LabName,
        COUNT(r.id) AS ReservationCount,
        
        -- 合并同一实验室的所有预约时长
        SUM(TIMESTAMPDIFF(MINUTE, 
            STR_TO_DATE(CONCAT(r.reserve_date, ' ', r.reserve_start), '%Y-%m-%d %H:%i:%s'), 
            STR_TO_DATE(CONCAT(r.reserve_date, ' ', r.reserve_end), '%Y-%m-%d %H:%i:%s')
        )) AS TotalReserveMinutes,
        
        SUM(IF(r.status = 4, TIMESTAMPDIFF(MINUTE, r.signin_time, r.signout_time), 0)) AS TotalUsedMinutes
    FROM 
        reservation r
    JOIN 
        laboratory l ON r.lab_id = l.id
    WHERE 
        r.status = 4  
    GROUP BY 
        r.lab_id, l.name; -- 按实验室ID和名称分组
";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var stats = new LabUtilizationStats
                            {
                                LabId = reader.GetInt64("LabId"),
                                LabName = reader.GetString("LabName"),
                                ReservationCount = reader.GetInt32("ReservationCount"),
                                TotalReserveMinutes = reader.IsDBNull(reader.GetOrdinal("TotalReserveMinutes")) ? 0 : reader.GetInt32("TotalReserveMinutes"),
                                TotalUsedMinutes = reader.IsDBNull(reader.GetOrdinal("TotalUsedMinutes")) ? 0 : reader.GetInt32("TotalUsedMinutes")
                            };

                            // 计算利用率（避免除以0）
                            if (stats.TotalReserveMinutes <= 0)
                            {
                                stats.UtilizationRate = 0;
                            }
                            else
                            {
                                stats.UtilizationRate = Math.Round(
                                    (double)stats.TotalUsedMinutes / stats.TotalReserveMinutes * 100,
                                    2
                                );
                            }

                            result.Add(stats);
                        }
                    }
                    return result;
                }
            }


        }
    }
}