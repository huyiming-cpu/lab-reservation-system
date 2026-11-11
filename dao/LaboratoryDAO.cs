using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using LabReservationApp.Entity;

namespace LabReservationApp.DAO
{
    public class LaboratoryDAO
    {
        private readonly string _connectionString = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";

        public List<Laboratory> GetLaboratories(string keyword, int pageIndex, int pageSize)
        {
            var laboratories = new List<Laboratory>();
            int offset = (pageIndex - 1) * pageSize;
            keyword = string.IsNullOrEmpty(keyword) ? "%" : $"%{keyword}%";

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = @"
                    SELECT 
                        id, name, location, area, equipment_list, 
                        open_start, open_end, is_enabled, week_day
                    FROM laboratory
                    WHERE name LIKE @Keyword
                    ORDER BY id
                    LIMIT @Offset, @PageSize";

                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", keyword);
                    command.Parameters.AddWithValue("@Offset", offset);
                    command.Parameters.AddWithValue("@PageSize", pageSize);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            laboratories.Add(new Laboratory
                            {
                                Id = reader.GetInt64("id"),
                                Name = reader.GetString("name"),
                                Location = reader.GetString("location"),
                                Area = reader.GetDecimal("area"),

                                // 安全处理 NULL 字段
                                EquipmentList = reader.IsDBNull(reader.GetOrdinal("equipment_list"))
                                    ? null
                                    : reader.GetString("equipment_list"),

                                // 安全解析 TimeSpan
                                OpenStart = reader.GetTimeSpan("open_start"),
                                OpenEnd = reader.GetTimeSpan("open_end"),

                                IsEnabled = reader.GetBoolean("is_enabled"),

                                // 安全处理 NULL 字段
                                WeekDay = reader.IsDBNull(reader.GetOrdinal("week_day"))
                                    ? null
                                    : reader.GetString("week_day"),
                            });
                        }
                    }
                }
            }

            return laboratories;
        }

        public int GetTotalCount(string keyword)
        {
            keyword = string.IsNullOrEmpty(keyword) ? "%" : $"%{keyword}%";

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "SELECT COUNT(*) FROM laboratory WHERE name LIKE @Keyword";

                using (var command = new MySqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Keyword", keyword);
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        internal string GetLaboratoryNameById(long labId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                string sql = "SELECT name FROM laboratory WHERE id = @LabId;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@LabId", labId);

                    // 执行查询并返回单个结果
                    object result = cmd.ExecuteScalar();

                    // 处理结果（防止 NULL 值）
                    return result != null ? result.ToString() : string.Empty;
                }
            }
        }
    }
}