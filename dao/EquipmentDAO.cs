using LabReservationApp.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using YourProjectNamespace.Entity;

namespace YourProjectNamespace.DAO
{
    public class EquipmentDAO
    {
        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";

        // 获取设备列表
        public List<Equipment> GetEquipmentList(int pageIndex, int pageSize)
        {
            var list = new List<Equipment>();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT * FROM equipment 
                    ORDER BY id ASC 
                    LIMIT @offset, @pageSize;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@offset", (pageIndex - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Equipment
                            {
                                Id = reader.GetInt64("id"),
                                LabId = reader.GetInt32("lab_id"),
                                Name = reader.GetString("name"),
                                Model = reader.GetString("model"),
                                PurchaseTime = reader.GetDateTime("purchase_time"),
                                TechnicalParams = reader.GetString("technical_params"),
                                CurrentStatus = reader.GetInt32("current_status"),
                                UsageCount = reader.GetInt32("usage_count"), 
                                FaultCount = reader.GetInt32("fault_count") 
                            });
                        }
                    }
                }
            }
            return list;
        }

        // 获取设备总数
        public int GetTotalCount()
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM equipment;";
                return Convert.ToInt32(new MySqlCommand(sql, conn).ExecuteScalar());
            }
        }

        // 保存设备（新增/更新）
        public bool SaveEquipment(Equipment equipment)
        {
            string sql = @"
        INSERT INTO equipment 
        (lab_id, name, model, purchase_time, technical_params, 
         current_status, fault_count, usage_count)
        VALUES 
        (@LabId, @Name, @Model, @PurchaseTime, @TechnicalParams, 
         @CurrentStatus, @FaultCount, @UsageCount);
    ";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    // 绑定参数
                    cmd.Parameters.AddWithValue("@LabId", equipment.LabId);
                    cmd.Parameters.AddWithValue("@Name", equipment.Name);
                    cmd.Parameters.AddWithValue("@Model", equipment.Model);
                    // 处理可空类型
                    cmd.Parameters.AddWithValue("@PurchaseTime",
                        equipment.PurchaseTime.HasValue ? (object)equipment.PurchaseTime.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TechnicalParams", equipment.TechnicalParams);
                    cmd.Parameters.AddWithValue("@CurrentStatus", equipment.CurrentStatus);
                    cmd.Parameters.AddWithValue("@FaultCount", equipment.FaultCount);
                    cmd.Parameters.AddWithValue("@UsageCount", equipment.UsageCount);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        // 删除设备
        public bool DeleteEquipment(long id)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM equipment WHERE id = @id;";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public string GetEquipmentNamesByLabId(long labId)
        {
            List<string> equipmentNames = new List<string>();

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT name FROM equipment WHERE lab_id = @LabId";

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@LabId", labId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            equipmentNames.Add(reader.GetString("name"));
                        }
                    }
                }
            }

            // 用空格拼接多个设备名称
            return string.Join(" ", equipmentNames);
        }

        public List<Equipment> GetEquipmentsByLabId(long labId, int status)
        {
            var equipments = new List<Equipment>();
            string sql = "SELECT id, name, model, purchase_time, current_status " +
                         "FROM equipment " +
                         "WHERE lab_id = @LabId AND current_status = @Status";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LabId", labId);
                cmd.Parameters.AddWithValue("@Status", status);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        equipments.Add(new Equipment
                        {
                            Id = reader.GetInt64("id"),
                            Name = reader.GetString("name"),
                            Model = reader.GetString("model"),
                            PurchaseTime = reader.GetDateTime("purchase_time"),
                            CurrentStatus = reader.GetInt32("current_status")
                        });
                    }
                }
            }
            return equipments;
        }
        public void UpdateEquipmentStatus(long equipmentId, int newStatus)
        {
            string sql = "UPDATE equipment SET current_status = @NewStatus WHERE id = @EqId";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                cmd.Parameters.AddWithValue("@EqId", equipmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Equipment> GetEquipmentsByLabId1(long labId, int status)
        {
            var equipments = new List<Equipment>();
            string sql = @"
                SELECT id, name, model, purchase_time, current_status 
                FROM equipment 
                WHERE lab_id = @LabId AND current_status = @Status;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LabId", labId);
                cmd.Parameters.AddWithValue("@Status", status);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        equipments.Add(new Equipment
                        {
                            Id = reader.GetInt64("id"),
                            Name = reader.GetString("name"),
                            Model = reader.GetString("model"),
                            PurchaseTime = reader.GetDateTime("purchase_time"),
                            CurrentStatus = reader.GetInt32("current_status")
                        });
                    }
                }
            }
            return equipments;
        }

        // 更新设备状态2
        public void UpdateEquipmentStatus1(long equipmentId, int newStatus)
        {
            string sql = "UPDATE equipment SET current_status = @NewStatus WHERE id = @EqId;";
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NewStatus", newStatus);
                cmd.Parameters.AddWithValue("@EqId", equipmentId);
                cmd.ExecuteNonQuery();
            }
        }

        public Equipment GetEquipmentById(long equipmentId)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
                    SELECT id, lab_id, name, model, purchase_time, technical_params, 
                           current_status, usage_count, fault_count 
                    FROM equipment 
                    WHERE id = @EquipmentId;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@EquipmentId", equipmentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Equipment equipment = new Equipment
                            {
                                Id = reader.GetInt64("id"),
                                LabId = reader.GetInt32("lab_id"),
                                Name = reader.GetString("name"),
                                Model = reader.IsDBNull(reader.GetOrdinal("model"))
                                    ? null
                                    : reader.GetString("model"),
                                PurchaseTime = reader.IsDBNull(reader.GetOrdinal("purchase_time"))
                                    ? (DateTime?)null
                                    : reader.GetDateTime("purchase_time"),
                                TechnicalParams = reader.IsDBNull(reader.GetOrdinal("technical_params"))
                                    ? null
                                    : reader.GetString("technical_params"),
                                CurrentStatus = reader.GetInt32("current_status"),
                                UsageCount = reader.GetInt32("usage_count"),
                                FaultCount = reader.GetInt32("fault_count")
                            };
                            return equipment;
                        }
                        return null;
                    }
                }
            }
        }
        //获取实验室列表
        public List<Laboratory> GetLaboratories()
        {
            var list = new List<Laboratory>();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT id, name FROM laboratory;";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Laboratory
                        {
                            Id = reader.GetInt64("id"),
                            Name = reader.GetString("name")
                        });
                    }
                }
            }
            return list;
        }

       

    }
}


