using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace YourProjectNamespace 
{
    public partial class UC_LabFile : UserControl
    {
        // 数据库连接字符串
        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";
        private int pageSize = 10; // 每页条数
        private int currentPage = 1; // 当前页码
        private int totalCount = 0; // 总数据条数

        public UC_LabFile()
        {
            InitializeComponent();
            InitDataGridViewColumns();
            InitTimePickers(); // 初始化时间选择器
            LoadLabData();     // 加载数据
        }

        // 初始化 DataGridView 列
        private void InitDataGridViewColumns()
        {
            dgvLabList.AutoGenerateColumns = false;
            dgvLabList.Columns.Clear();

            // 实验室 ID
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "实验室 ID",
                DataPropertyName = "id",
                Width = 80
            });

            // 名称
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "名称",
                DataPropertyName = "name",
                Width = 120
            });

            // 位置
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLocation",
                HeaderText = "位置",
                DataPropertyName = "location",
                Width = 150
            });

            // 面积
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colArea",
                HeaderText = "面积",
                DataPropertyName = "area",
                Width = 80
            });

            // 开放时间
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOpenStart",
                HeaderText = "开放时间",
                DataPropertyName = "open_start",
                Width = 100
            });

            // 关闭时间
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOpenEnd",
                HeaderText = "关闭时间",
                DataPropertyName = "open_end",
                Width = 100
            });

            // 状态
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colIsEnabled",
                HeaderText = "状态",
                DataPropertyName = "is_enabled_text",
                Width = 80
            });

            // 设备清单
            dgvLabList.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDevices",
                HeaderText = "设备清单",
                DataPropertyName = "equipment_list",
                Width = 200
            });
        }

        // 加载实验室数据（带分页 + 修复字段查询）
        private void LoadLabData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 1. 查询总条数
                    string countSql = "SELECT COUNT(*) FROM laboratory;";
                    MySqlCommand countCmd = new MySqlCommand(countSql, conn);
                    totalCount = Convert.ToInt32(countCmd.ExecuteScalar());
                    lblTotalCount.Text = $"共{totalCount}条数据";

                    // 2. 计算分页参数
                    int startIndex = (currentPage - 1) * pageSize;

                   
                    string sql = @"
SELECT 
    l.id, 
    l.name, 
    l.location, 
    l.area,
    GROUP_CONCAT(e.name SEPARATOR ' ') AS equipment_list, -- 使用设备名称拼接
    TIME_FORMAT(l.open_start, '%H:%i:%s') AS open_start, -- 时间转字符串
    TIME_FORMAT(l.open_end, '%H:%i:%s') AS open_end,     -- 时间转字符串
    CASE WHEN l.is_enabled = 1 THEN '启用' ELSE '禁用' END AS is_enabled_text -- 状态转文本
FROM laboratory l
LEFT JOIN equipment e ON l.id = e.lab_id -- 直接关联 equipment 表
GROUP BY l.id 
LIMIT @startIndex, @pageSize;";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@startIndex", startIndex);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvLabList.DataSource = dt;

                    // 更新分页信息
                    UpdatePageInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 更新分页显示
        private void UpdatePageInfo()
        {
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            lblPageInfo.Text = $"{currentPage}/{totalPage}";
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPage;
        }

        // 初始化时间选择器和启用状态
        private void InitTimePickers()
        {
            dtpOpenStart.Format = DateTimePickerFormat.Time;
            dtpOpenStart.ShowUpDown = true;
            dtpOpenEnd.Format = DateTimePickerFormat.Time;
            dtpOpenEnd.ShowUpDown = true;

            dtpOpenStart.Value = DateTime.Parse("08:00");
            dtpOpenEnd.Value = DateTime.Parse("22:00");
            chkIsEnabled.Checked = true;
        }

        // 选中行时赋值到输入框
        private void dgvLabList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLabList.Rows[e.RowIndex];
                txtId.Text = row.Cells["colId"].Value.ToString();
                txtName.Text = row.Cells["colName"].Value.ToString();
                txtLocation.Text = row.Cells["colLocation"].Value.ToString();
                txtArea.Text = row.Cells["colArea"].Value.ToString();
                txtDeviceList.Text = row.Cells["colDevices"].Value?.ToString();

                // 解析时间
                string openStart = row.Cells["colOpenStart"].Value?.ToString();
                if (!string.IsNullOrEmpty(openStart))
                {
                    dtpOpenStart.Value = DateTime.Parse(openStart);
                }

                string openEnd = row.Cells["colOpenEnd"].Value?.ToString();
                if (!string.IsNullOrEmpty(openEnd))
                {
                    dtpOpenEnd.Value = DateTime.Parse(openEnd);
                }

                // 解析状态（回显到复选框）
                string isEnabledText = row.Cells["colIsEnabled"].Value?.ToString();
                chkIsEnabled.Checked = isEnabledText == "启用";
            }
        }

        // 分页：下一页
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            if (currentPage < totalPage)
            {
                currentPage++;
                LoadLabData();
            }
        }

        // 分页：上一页
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadLabData();
            }
        }

        // 删除实验室（主表 + 关联表）
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. 检查是否选中行
            if (dgvLabList.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要删除的实验室记录！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 获取选中行的 ID
            DataGridViewRow selectedRow = dgvLabList.SelectedRows[0];
            string labIdStr = selectedRow.Cells["colId"].Value?.ToString();

            // 3. 校验 ID 有效性
            if (string.IsNullOrWhiteSpace(labIdStr))
            {
                MessageBox.Show("选中记录的 ID 无效，请重新选择！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long labId;
            if (!long.TryParse(labIdStr, out labId))
            {
                MessageBox.Show("实验室 ID 必须是有效数字！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. 确认删除
            if (MessageBox.Show("确认删除该实验室及关联设备信息吗？删除后不可恢复！", "警告",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 5. 删除关联表数据
                    string deleteRelSql = "DELETE FROM equipment WHERE lab_id = @labId;";
                    MySqlCommand deleteRelCmd = new MySqlCommand(deleteRelSql, conn);
                    deleteRelCmd.Parameters.AddWithValue("@labId", labId);
                    deleteRelCmd.ExecuteNonQuery();

                    // 6. 删除实验室主表数据
                    string deleteSql = "DELETE FROM laboratory WHERE id = @id;";
                    MySqlCommand deleteCmd = new MySqlCommand(deleteSql, conn);
                    deleteCmd.Parameters.AddWithValue("@id", labId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("删除成功！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLabData(); // 重新加载数据
                    }
                    else
                    {
                        MessageBox.Show("未找到对应 ID 的实验室，删除失败！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 保存实验室信息
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. 校验必填字段
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("请输入实验室ID！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入实验室名称！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                long labId = long.Parse(txtId.Text);

                // 2. 检查实验室ID是否已存在
                bool isNewLab = !IsLabIdExists(labId);

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        if (isNewLab)
                        {
                            // 新增实验室
                            string insertSql = @"
INSERT INTO laboratory (
    id, name, location, area, 
    open_start, open_end, is_enabled
) 
VALUES (
    @id, @name, @location, @area, 
    @openStart, @openEnd, @isEnabled
);";

                            MySqlCommand insertCmd = new MySqlCommand(insertSql, conn, transaction);
                            insertCmd.Parameters.AddWithValue("@id", labId);
                            insertCmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@area", txtArea.Text.Trim());
                            insertCmd.Parameters.AddWithValue("@openStart", dtpOpenStart.Value.TimeOfDay);
                            insertCmd.Parameters.AddWithValue("@openEnd", dtpOpenEnd.Value.TimeOfDay);
                            insertCmd.Parameters.AddWithValue("@isEnabled", chkIsEnabled.Checked ? 1 : 0);

                            insertCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            // 更新实验室
                            string updateSql = @"
UPDATE laboratory 
SET 
    name = @name,
    location = @location,
    area = @area,
    open_start = @openStart,
    open_end = @openEnd,
    is_enabled = @isEnabled
WHERE id = @id;";

                            MySqlCommand updateCmd = new MySqlCommand(updateSql, conn, transaction);
                            updateCmd.Parameters.AddWithValue("@id", labId);
                            updateCmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                            updateCmd.Parameters.AddWithValue("@location", txtLocation.Text.Trim());
                            updateCmd.Parameters.AddWithValue("@area", txtArea.Text.Trim());
                            updateCmd.Parameters.AddWithValue("@openStart", dtpOpenStart.Value.TimeOfDay);
                            updateCmd.Parameters.AddWithValue("@openEnd", dtpOpenEnd.Value.TimeOfDay);
                            updateCmd.Parameters.AddWithValue("@isEnabled", chkIsEnabled.Checked ? 1 : 0);

                            updateCmd.ExecuteNonQuery();
                        }

                        
                        // 先删除旧关联
                        string deleteRelSql = "DELETE FROM equipment WHERE lab_id = @labId;";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteRelSql, conn, transaction);
                        deleteCmd.Parameters.AddWithValue("@labId", labId);
                        deleteCmd.ExecuteNonQuery();

                        // 插入新设备
                        if (!string.IsNullOrWhiteSpace(txtDeviceList.Text))
                        {
                            string[] deviceNames = txtDeviceList.Text.Split(new[] { ' ', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);

                            string insertRelSql = @"
INSERT INTO equipment (lab_id, name) 
VALUES (@labId, @name);
";
                            MySqlCommand insertCmd = new MySqlCommand(insertRelSql, conn, transaction);
                            insertCmd.Parameters.AddWithValue("@labId", labId);
                            insertCmd.Parameters.Add("@name", MySqlDbType.VarChar);

                            foreach (string deviceName in deviceNames)
                            {
                                string trimmedName = deviceName.Trim();
                                if (!string.IsNullOrEmpty(trimmedName))
                                {
                                    insertCmd.Parameters["@name"].Value = trimmedName;
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // 4. 提交事务
                        transaction.Commit();
                        MessageBox.Show(isNewLab ? "实验室添加成功！" : "实验室更新成功！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // 5. 刷新列表并清空输入框
                        currentPage = 1;
                        LoadLabData();
                        btnReset_Click(sender, e);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("实验室ID必须是数字！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"操作失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private bool IsLabIdExists(long labId)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM laboratory WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", labId);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            txtLocation.Text = "";
            txtArea.Text = "";
            txtDeviceList.Text = "";
            dtpOpenStart.Value = DateTime.Parse("08:00");
            dtpOpenEnd.Value = DateTime.Parse("22:00");
            chkIsEnabled.Checked = true;
        }

        private void lblArea_Click(object sender, EventArgs e)
        {

        }

        private void dgvLabList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}