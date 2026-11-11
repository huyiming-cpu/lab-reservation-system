
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using LabReservationApp.Entity;

namespace LabReservationApp.DAO
{
    public class UserDAO
    {
        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";

        // 根据ID查询用户
        public User GetById(long id)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM user WHERE id = @id;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt64("id"),
                                Username = reader.GetString("username"),
                                RealName = reader.GetString("real_name"),
                                Password = reader.GetString("password"),
                                Role = reader.GetInt32("role"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? null : reader.GetString("phone")
                            };
                        }
                        return null;
                    }
                }
            }
        }

        // 根据用户名查询用户（登录用）
        public User GetByUsername(string username)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM user WHERE username = @username;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetInt64("id"),
                                Username = reader.GetString("username"),
                                RealName = reader.GetString("real_name"),
                                Password = reader.GetString("password"),
                                Role = reader.GetInt32("role"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? null : reader.GetString("phone")
                            };
                        }
                        return null;
                    }
                }
            }
        }

        // 分页查询用户（支持按角色筛选）
        public List<User> GetUserList(int role = 0, int pageIndex = 1, int pageSize = 10)
        {
            var users = new List<User>();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM user";
                if (role > 0) sql += " WHERE role = @role";
                sql += " ORDER BY id DESC LIMIT @offset, @pageSize;";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (role > 0) cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@offset", (pageIndex - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = reader.GetInt64("id"),
                                Username = reader.GetString("username"),
                                RealName = reader.GetString("real_name"),
                                Password = reader.GetString("password"),
                                Role = reader.GetInt32("role"),
                                Email = reader.IsDBNull(reader.GetOrdinal("email")) ? null : reader.GetString("email"),
                                Phone = reader.IsDBNull(reader.GetOrdinal("phone")) ? null : reader.GetString("phone")
                            });
                        }
                    }
                }
            }
            return users;
        }

        // 保存用户（新增/更新）
        public bool SaveUser(User user)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = user.Id > 0
                    ? @"UPDATE user 
                       SET username = @username, real_name = @realName, password = @password, 
                           role = @role, email = @email, phone = @phone 
                       WHERE id = @id;"
                    : @"INSERT INTO user (username, real_name, password, role, email, phone)
                       VALUES (@username, @realName, @password, @role, @email, @phone);";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@realName", user.RealName);
                    cmd.Parameters.AddWithValue("@password", user.Password);
                    cmd.Parameters.AddWithValue("@role", user.Role);
                    cmd.Parameters.AddWithValue("@email", user.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@phone", user.Phone ?? (object)DBNull.Value);

                    if (user.Id > 0)
                        cmd.Parameters.AddWithValue("@id", user.Id);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 删除用户
        public bool DeleteUser(long id)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "DELETE FROM user WHERE id = @id;";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 获取用户总数
        public int GetTotalCount(int role = 0)
        {
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM user";
                if (role > 0) sql += " WHERE role = @role";

                using (var cmd = new MySqlCommand(sql, conn))
                {
                    if (role > 0) cmd.Parameters.AddWithValue("@role", role);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }
}