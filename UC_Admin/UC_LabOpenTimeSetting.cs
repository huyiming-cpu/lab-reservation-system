using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace YourProjectNamespace
{
    public partial class UC_LabOpenTimeSetting : UserControl
    {
        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalCount = 0;

        public UC_LabOpenTimeSetting()
        {
            InitializeComponent();
            InitDataGridView();
            LoadWeekDayComboBox();
            LoadLaboratories();
        }

        // 初始化表格（新增“周几开放”列）
        private void InitDataGridView()
        {
            dgvLaboratories.AutoGenerateColumns = false;
            dgvLaboratories.Columns.Clear();

            AddTextBoxColumn("colId", "实验室ID", "id", 60);
            AddTextBoxColumn("colName", "实验室名称", "name", 120);
            AddTextBoxColumn("colLastocation", "位置", "location", 150);
            AddTextBoxColumn("colWeekDay", "周几开放", "week_day", 100); 
            AddTextBoxColumn("colLastpenStart", "开放时间", "open_start", 100);
            AddTextBoxColumn("colLastpenEnd", "关闭时间", "open_end", 100);
        }

       
        private void AddTextBoxColumn(string name, string header, string dataProperty, int width)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataProperty,
                Width = width
            };
            dgvLaboratories.Columns.Add(column);
        }

        // 加载星期下拉框
        private void LoadWeekDayComboBox()
        {
            cboWeekDay.Items.Clear();
            cboWeekDay.Items.AddRange(new string[] {
                "周一", "周二", "周三", "周四", "周五"
            });
            cboWeekDay.SelectedIndex = 0;
        }

        // 加载实验室数据
        private void LoadLaboratories()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 查询总记录数
                    string countSql = "SELECT COUNT(*) FROM laboratory;";
                    totalCount = Convert.ToInt32(new MySqlCommand(countSql, conn).ExecuteScalar());

                    // 查询当前页数据
                    string sql = @"
                        SELECT id, name, location, week_day,
                               TIME_FORMAT(open_start, '%H:%i') AS open_start, 
                               TIME_FORMAT(open_end, '%H:%i') AS open_end 
                        FROM laboratory 
                        ORDER BY id DESC 
                        LIMIT @offset, @pageSize;";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    cmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLaboratories.DataSource = dt;

                    // 更新分页信息
                    UpdatePagingInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载实验室列表失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 更新分页信息
        private void UpdatePagingInfo()
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / (double)pageSize));
            lblPageInfo.Text = $"当前页：{currentPage}/{totalPages}";
            lblTotalCount.Text = $"共 {totalCount} 条记录";

            // 控制分页按钮状态
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        
        private void dgvLaboratories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLaboratories.Rows[e.RowIndex];

                // 填充周几
                string weekDay = row.Cells["colWeekDay"].Value?.ToString();
                cboWeekDay.SelectedItem = weekDay ?? "周一";

                // 解析时间并设置选择器
                string openTime = row.Cells["colLastpenStart"].Value?.ToString();
                string closeTime = row.Cells["colLastpenEnd"].Value?.ToString();

                dtpOpenTime.Value = DateTime.ParseExact(openTime, "HH:mm", null);
                dtpCloseTime.Value = DateTime.ParseExact(closeTime, "HH:mm", null);
            }
        }

       
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 1. 检查是否选中行
            if (dgvLaboratories.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择要修改的实验室记录！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. 获取选中行的ID
            DataGridViewRow selectedRow = dgvLaboratories.SelectedRows[0];
            string labIdStr = selectedRow.Cells["colId"].Value?.ToString();

            // 3. 校验ID有效性
            if (string.IsNullOrWhiteSpace(labIdStr) || !long.TryParse(labIdStr, out long labId))
            {
                MessageBox.Show("选中的实验室ID无效，请重新选择！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. 校验开放时间
            if (dtpOpenTime.Value >= dtpCloseTime.Value)
            {
                MessageBox.Show("开放时间必须早于关闭时间！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 5. 执行更新
                    string sql = @"
                        UPDATE laboratory 
                        SET week_day = @week_day,
                            open_start = @open_start, 
                            open_end = @open_end 
                        WHERE id = @id;";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@week_day", cboWeekDay.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@open_start", dtpOpenTime.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@open_end", dtpCloseTime.Value.ToString("HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@id", labId);

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("开放时间（含周几）更新成功！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadLaboratories(); // 刷新当前页数据
                    }
                    else
                    {
                        MessageBox.Show("更新失败，实验室ID不存在！", "提示",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"更新失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 重置按钮
        private void btnReset_Click(object sender, EventArgs e)
        {
            cboWeekDay.SelectedIndex = 0; // 重置周几为“周一”
            dtpOpenTime.Value = DateTime.Parse("08:00"); // 重置开放时间
            dtpCloseTime.Value = DateTime.Parse("22:00"); // 重置关闭时间
        }

        // 上一页按钮
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadLaboratories();
            }
        }

        // 下一页按钮
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadLaboratories();
            }
        }
    }
}