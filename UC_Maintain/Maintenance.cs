using LabReservationApp.Entity;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace LabReservationApp.UC_Maintain
{
    public partial class Maintenance : UserControl
    {

        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;
        private int selectedStatus = -1; // -1表示全部状态

        private ComboBox cmbStatus;
        private Button btnQuery;
        private Label label1;
        private Button btnRefresh;
        private DataGridView dgvWorkOrders;
        private Button btnPrev;
        private Button btnNext;
        private Label lblPageInfo;
        private Label lblTotalCount;
        private Button btnProcess;
        private Button btnComplete;
        private object userId;

        public Maintenance()
        {

            InitializeControls();
            LoadData();
        }

        // private void InitializeComponent()
        // {
        // 这个方法可以留空，因为我们在InitializeControls中动态创建控件
        // }

        private void InitializeControls()
        {
            // 设置用户控件属性
            this.BackColor = Color.Pink;
            this.Padding = new Padding(20);

            // 状态选择标签
            label1 = new Label
            {
                Text = "选择状态:",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("微软雅黑", 10)
            };

            // 状态下拉框
            cmbStatus = new ComboBox
            {
                Location = new Point(100, 18),
                Width = 120,
                Font = new Font("微软雅黑", 10)
            };
            cmbStatus.Items.AddRange(new object[] { "全部", "待处理", "处理中", "已完成" });
            cmbStatus.SelectedIndex = 0;
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;

            // 查询按钮
            btnQuery = new Button
            {
                Text = "查询",
                Location = new Point(240, 18),
                Size = new Size(80, 25),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightSkyBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnQuery.Click += BtnQuery_Click;

            // 刷新按钮
            btnRefresh = new Button
            {
                Text = "刷新",
                Location = new Point(340, 18),
                Size = new Size(80, 25),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };
            btnRefresh.Click += BtnRefresh_Click;

            // 数据表格
            dgvWorkOrders = new DataGridView
            {
                Location = new Point(20, 60),
                Size = new Size(800, 400),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.Fixed3D,
                GridColor = Color.LightGray,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            InitDataGridView();

            // 分页控制
            btnPrev = new Button
            {
                Text = "上一页",
                Location = new Point(20, 480),
                Size = new Size(80, 30),
                Font = new Font("微软雅黑", 10),
                Enabled = false
            };
            btnPrev.Click += BtnPrev_Click;

            btnNext = new Button
            {
                Text = "下一页",
                Location = new Point(120, 480),
                Size = new Size(80, 30),
                Font = new Font("微软雅黑", 10),
                Enabled = false
            };
            btnNext.Click += BtnNext_Click;

            lblPageInfo = new Label
            {
                Location = new Point(220, 485),
                AutoSize = true,
                Font = new Font("微软雅黑", 10)
            };

            lblTotalCount = new Label
            {
                Location = new Point(320, 485),
                AutoSize = true,
                Font = new Font("微软雅黑", 10)
            };

            // 操作按钮
            btnProcess = new Button
            {
                Text = "开始处理",
                Location = new Point(500, 480),
                Size = new Size(100, 30),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.Orange,
                FlatStyle = FlatStyle.Flat,
                Enabled = false
            };
            btnProcess.Click += BtnProcess_Click;

            btnComplete = new Button
            {
                Text = "完成处理",
                Location = new Point(620, 480),
                Size = new Size(100, 30),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Enabled = false
            };
            btnComplete.Click += BtnComplete_Click;

            // 添加控件到用户控件
            this.Controls.Add(label1);
            this.Controls.Add(cmbStatus);
            this.Controls.Add(btnQuery);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(dgvWorkOrders);
            this.Controls.Add(btnPrev);
            this.Controls.Add(btnNext);
            this.Controls.Add(lblPageInfo);
            this.Controls.Add(lblTotalCount);
            this.Controls.Add(btnProcess);
            this.Controls.Add(btnComplete);

            // 绑定数据表格选择事件
            dgvWorkOrders.SelectionChanged += DgvWorkOrders_SelectionChanged;
        }

        private void InitDataGridView()
        {
            dgvWorkOrders.AutoGenerateColumns = false;
            dgvWorkOrders.Columns.Clear();

            // 只保留需要的列，移除报修人相关列
            dgvWorkOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colOrderId",
                HeaderText = "工单ID",
                DataPropertyName = "order_id",
                Width = 80
            });

            dgvWorkOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEquipmentName",
                HeaderText = "设备名称",
                DataPropertyName = "equipment_name",
                Width = 150
            });

            dgvWorkOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLabName",
                HeaderText = "实验室",
                DataPropertyName = "lab_name",
                Width = 120
            });


            dgvWorkOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "状态",
                DataPropertyName = "status_text",
                Width = 100
            });


        }

        private void LoadData()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // 查询总记录数
                    string countSql = @"
                SELECT COUNT(*)
                FROM maintenance m
                JOIN equipment e ON m.equipment_id = e.id
                JOIN laboratory l ON e.lab_id = l.id
                WHERE 1=1
                " + (selectedStatus >= 0 ? "AND m.status = @status" : "");

                    MySqlCommand countCmd = new MySqlCommand(countSql, conn);
                    if (selectedStatus >= 0)
                    {
                        countCmd.Parameters.AddWithValue("@status", selectedStatus);
                    }

                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;
                    if (currentPage > totalPages) currentPage = totalPages;

                    // 查询当前页数据
                    string dataSql = @"
SELECT 
    m.id AS order_id,
    e.name AS equipment_name,
    l.name AS lab_name,
    m.status,
    CASE 
        WHEN m.status = 1 THEN '待处理'
        WHEN m.status = 2 THEN '处理中'
        WHEN m.status = 3 THEN '已完成'
        ELSE '未知'
    END AS status_text,
    m.equipment_name AS description
FROM 
    maintenance m
JOIN equipment e ON m.equipment_id = e.id
JOIN laboratory l ON e.lab_id = l.id
WHERE 1=1
" + (selectedStatus >= 0 ? "AND m.status = @status" : "") + @"
ORDER BY 
    m.id DESC
LIMIT @offset, @pageSize;";

                    MySqlCommand dataCmd = new MySqlCommand(dataSql, conn);
                    if (selectedStatus >= 0)
                    {
                        dataCmd.Parameters.AddWithValue("@status", selectedStatus);
                    }
                    dataCmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    dataCmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(dataCmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // 绑定数据到DataGridView
                    dgvWorkOrders.DataSource = dt;
                    UpdatePagingInfo();
                    UpdateButtonStates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePagingInfo()
        {
            lblPageInfo.Text = $"第 {currentPage}/{totalPages} 页";
            lblTotalCount.Text = $"共 {totalRecords} 条记录";

            // 控制分页按钮状态
            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = dgvWorkOrders.SelectedRows.Count > 0;
            btnProcess.Enabled = hasSelection;
            btnComplete.Enabled = hasSelection;

            if (hasSelection)
            {
                var status = dgvWorkOrders.SelectedRows[0].Cells["colStatus"].Value.ToString();
                btnProcess.Enabled = status == "待处理";
                btnComplete.Enabled = status == "处理中";
            }
        }
        private void BtnQuery_Click(object sender, EventArgs e)
        {
            // 根据选择的文本映射到正确的状态值
            switch (cmbStatus.SelectedItem.ToString())
            {
                case "待处理":
                    selectedStatus = 1; // 待处理对应状态1
                    break;
                case "处理中":
                    selectedStatus = 2; // 处理中对应状态2
                    break;
                case "已完成":
                    selectedStatus = 3; // 已完成对应状态3
                    break;
                default:
                    selectedStatus = -1; // "全部"对应-1（不筛选）
                    break;
            }
            currentPage = 1; // 重置到第一页
            LoadData();
        }

        /* private void BtnQuery_Click(object sender, EventArgs e)
         {
             selectedStatus = cmbStatus.SelectedIndex - 1;
             currentPage = 1;
             LoadData();
         }
        */
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void CmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 可以在这里添加即时查询逻辑，如果需要
        }

        private void DgvWorkOrders_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonStates();
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            if (dgvWorkOrders.SelectedRows.Count == 0) return;

            var orderId = Convert.ToInt32(dgvWorkOrders.SelectedRows[0].Cells["colOrderId"].Value);
            UpdateOrderStatus(orderId, 2); // 2表示处理中
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (dgvWorkOrders.SelectedRows.Count == 0) return;

            var orderId = Convert.ToInt32(dgvWorkOrders.SelectedRows[0].Cells["colOrderId"].Value);
            UpdateOrderStatus(orderId, 3); // 3表示已完成
        }

      
        private void UpdateOrderStatus(int orderId, int newStatus)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 1. 获取设备ID
                            string getEquipmentSql = "SELECT equipment_id FROM maintenance WHERE id = @orderId";
                            MySqlCommand getEquipmentCmd = new MySqlCommand(getEquipmentSql, conn, transaction);
                            getEquipmentCmd.Parameters.AddWithValue("@orderId", orderId);
                            long equipmentId = Convert.ToInt64(getEquipmentCmd.ExecuteScalar());

                            // 调试：检查设备ID
                            Debug.WriteLine($"工单ID: {orderId}, 设备ID: {equipmentId}");

                            // 2. 更新工单状态
                            string updateMaintenanceSql = @"
                        UPDATE maintenance 
                        SET status = @status,
                            handler_id = @handlerId
                        WHERE id = @orderId";
                            MySqlCommand updateCmd = new MySqlCommand(updateMaintenanceSql, conn, transaction);
                            updateCmd.Parameters.AddWithValue("@status", newStatus);
                            updateCmd.Parameters.AddWithValue("@handlerId", userId);
                            updateCmd.Parameters.AddWithValue("@orderId", orderId);
                            updateCmd.ExecuteNonQuery();

                            // 3. 更新设备状态
                            int newEquipmentStatus = newStatus == 2 ? 3 : 1;
                            string updateEquipmentSql = "UPDATE equipment SET current_status = @status WHERE id = @equipmentId";
                            MySqlCommand equipmentCmd = new MySqlCommand(updateEquipmentSql, conn, transaction);
                            equipmentCmd.Parameters.AddWithValue("@status", newEquipmentStatus);
                            equipmentCmd.Parameters.AddWithValue("@equipmentId", equipmentId);

                            // 调试：检查设备状态更新
                            int equipmentRowsAffected = equipmentCmd.ExecuteNonQuery();
                            Debug.WriteLine($"更新设备状态: {equipmentRowsAffected} 行受影响");

                            transaction.Commit();
                            MessageBox.Show("操作成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Debug.WriteLine($"事务回滚: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"数据库连接失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"数据库错误: {ex.Message}");
            }
        }
    }
}