using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace LabReservationApp
{
    public partial class UC_User : UserControl
    {
        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";
        private int pageSize = 10;        // 每页显示数量
        private int currentPage = 1;      // 当前页码
        private int totalRecords = 0;     // 总记录数

        public UC_User()
        {
            InitializeComponent();
            InitializeControls();
            LoadUserList();
        }

        private void InitializeControls()
        {
            // 初始化角色筛选下拉框
            cboRoleFilter.Items.AddRange(new object[] { "全部", "教师", "管理员", "维护员" });
            cboRoleFilter.SelectedIndex = 0;

            // 初始化角色编辑下拉框
            cboRoleEdit.Items.AddRange(new object[] { "教师", "管理员", "维护员" });
            cboRoleEdit.SelectedIndex = 0;

            // 初始化DataGridView
            dgvUserList.AutoGenerateColumns = false;
            dgvUserList.Columns.Clear();

            dgvUserList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "ID",
                DataPropertyName = "id",
                Width = 60
            });

            dgvUserList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colUsername",
                HeaderText = "用户名",
                DataPropertyName = "username",
                Width = 120
            });

            dgvUserList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRealName",
                HeaderText = "真实姓名",
                DataPropertyName = "real_name",
                Width = 120
            });

            dgvUserList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colRole",
                HeaderText = "角色",
                DataPropertyName = "role_text",
                Width = 100
            });

            dgvUserList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "邮箱",
                DataPropertyName = "email",
                Width = 150
            });

            dgvUserList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhone",
                HeaderText = "电话",
                DataPropertyName = "phone",
                Width = 120
            });
        }

        // 加载用户列表
        private void LoadUserList()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 获取总记录数
                    string countSql = "SELECT COUNT(*) FROM user";
                    string roleFilter = cboRoleFilter.SelectedItem.ToString();

                    if (roleFilter != "全部")
                    {
                        int roleValue = GetRoleValue(roleFilter);
                        countSql += $" WHERE role = {roleValue}";
                    }

                    totalRecords = Convert.ToInt32(new MySqlCommand(countSql, conn).ExecuteScalar());
                    lblTotalCount.Text = $"共有 {totalRecords} 条数据";

                    // 计算分页偏移量
                    int offset = (currentPage - 1) * pageSize;

                    // 查询当前页数据
                    string selectSql = @"
                        SELECT 
                            id, 
                            username, 
                            real_name,
                            role,
                            CASE 
                                WHEN role = 1 THEN '教师'
                                WHEN role = 2 THEN '管理员'
                                WHEN role = 3 THEN '维护员'
                                ELSE '未知'
                            END AS role_text,
                            email,
                            phone
                        FROM user";

                    if (roleFilter != "全部")
                    {
                        int roleValue = GetRoleValue(roleFilter);
                        selectSql += $" WHERE role = {roleValue}";
                    }

                    selectSql += $" ORDER BY id LIMIT {offset}, {pageSize}";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(selectSql, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvUserList.DataSource = dt;
                    UpdatePaginationInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载用户列表失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 更新分页信息显示
        private void UpdatePaginationInfo()
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
            lblPageInfo.Text = $"第 {currentPage}/{totalPages} 页";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        // 将角色文本转换为数据库中的数字值
        private int GetRoleValue(string roleText)
        {
            switch (roleText)
            {
                case "教师": return 1;
                case "管理员": return 2;
                case "维护员": return 3;
                default: return 0;
            }
        }

        // 查询按钮点击事件
       

        // 上一页按钮
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadUserList();
            }
        }

        // 下一页按钮
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling((double)totalRecords / pageSize));
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadUserList();
            }
        }

        // 保存（添加/更新）用户
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 输入验证
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("请输入用户ID", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long userId;
            if (!long.TryParse(txtId.Text.Trim(), out userId))
            {
                MessageBox.Show("用户ID必须是数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("请输入用户名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRealName.Text))
            {
                MessageBox.Show("请输入真实姓名", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("请输入密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 新增：检查用户ID是否已存在
            if (IsUserIdExists(userId))
            {
                MessageBox.Show("该用户ID已存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        string sql;
                        MySqlCommand cmd;
                        int roleValue = GetRoleValue(cboRoleEdit.SelectedItem.ToString());
                        int affectedRows = 0;

                        // 新增
                        if (IsUserIdExists(userId))
                        {
                            // 更新用户
                            sql = @"
                        UPDATE user 
                        SET username = @username, 
                            real_name = @real_name, 
                            password = @password, 
                            role = @role, 
                            email = @email, 
                            phone = @phone
                        WHERE id = @id";

                            cmd = new MySqlCommand(sql, conn, transaction);
                            cmd.Parameters.AddWithValue("@id", userId);
                        }
                        else
                        {
                            // 新增用户
                            sql = @"
                        INSERT INTO user (id, username, real_name, password, role, email, phone)
                        VALUES (@id, @username, @real_name, @password, @role, @email, @phone)";

                            cmd = new MySqlCommand(sql, conn, transaction);
                            cmd.Parameters.AddWithValue("@id", userId);
                        }

                        // 通用参数设置
                        cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                        cmd.Parameters.AddWithValue("@real_name", txtRealName.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                        cmd.Parameters.AddWithValue("@role", roleValue);

                        // 新增：处理可为空的字段
                        cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmail.Text) ? (object)DBNull.Value : txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(txtPhone.Text) ? (object)DBNull.Value : txtPhone.Text.Trim());

                        // 执行并获取受影响行数
                        affectedRows = cmd.ExecuteNonQuery();

                        if (affectedRows > 0)
                        {
                            transaction.Commit();
                            MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnReset_Click(sender, e);
                            LoadUserList();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("未更新任何数据", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (MySqlException ex)
                    {
                        transaction.Rollback();
                        
                        MessageBox.Show($"数据库操作失败: {ex.Message}\n错误代码: {ex.Number}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"保存失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"连接数据库失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 新增：检查用户ID是否存在的方法
        private bool IsUserIdExists(long userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM user WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", userId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
        // 删除用户
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. 检查是否选中了DataGridView中的行
            if (dgvUserList.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的用户（点击表格中的行）", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 获取选中行的ID
            DataGridViewRow selectedRow = dgvUserList.SelectedRows[0];
            string userIdStr = selectedRow.Cells["colId"].Value?.ToString();

            // 3. 校验ID有效性
            if (string.IsNullOrWhiteSpace(userIdStr) || !long.TryParse(userIdStr, out long userId))
            {
                MessageBox.Show("选中的用户ID无效，请重新选择", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. 确认删除
            if (MessageBox.Show($"确定要删除ID为 {userId} 的用户吗？删除后不可恢复！", "确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 5. 执行删除
                    string sql = "DELETE FROM user WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", userId); // 使用选中行的ID

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("删除成功", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnReset_Click(sender, e); // 清空表单
                        LoadUserList(); // 刷新列表
                    }
                    else
                    {
                        MessageBox.Show("未找到该用户，删除失败", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (MySqlException ex)
            {
                // 处理数据库特定错误
                MessageBox.Show($"删除失败：{ex.Message}（错误代码：{ex.Number}）", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 清空表单
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtUsername.Text = "";
            txtRealName.Text = "";
            txtPassword.Text = "";
            cboRoleEdit.SelectedIndex = 0;
            txtEmail.Text = "";
            txtPhone.Text = "";
        }

        // 选中行时填充表单
        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUserList.Rows[e.RowIndex];

                txtId.Text = row.Cells["colId"].Value.ToString();
                txtUsername.Text = row.Cells["colUsername"].Value.ToString();
                txtRealName.Text = row.Cells["colRealName"].Value.ToString();

                // 根据角色文本设置下拉框选中项
                string roleText = row.Cells["colRole"].Value.ToString();
                cboRoleEdit.SelectedItem = roleText;

                txtEmail.Text = row.Cells["colEmail"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["colPhone"].Value?.ToString() ?? "";
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
           
            currentPage = 1; 
            LoadUserList(); 
        
    }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }
    }
}