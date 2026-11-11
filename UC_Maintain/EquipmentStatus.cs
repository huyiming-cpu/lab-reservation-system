using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace LabReservationApp.UC_Maintain
{
    public partial class EquipmentStatus : UserControl
    {
        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;

        private DataGridView dgvStatus;
        private Button btnPrev;
        private Button btnNext;
        private Button btnRefresh;
        private Label lblPageInfo;
        private Label lblTotalCount;

        // 新增搜索控件
        private TextBox txtSearchName;
        private ComboBox cmbStatus;
        private Button btnSearch;
        public EquipmentStatus()
        {
            InitializeComponent();
            InitializeControls();
            this.BackColor = Color.Pink;
            LoadData();
        }

        private void InitializeControls()
        {
            // 设置用户控件属性
            this.BackColor = Color.Pink;
            this.Padding = new Padding(20);

            // 数据表格
            dgvStatus = new DataGridView
            {
                Location = new Point(20, 60),  // 调整Y坐标，为搜索控件留出空间
                Size = new Size(800, 360),    // 调整高度
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
            // 搜索控件
            Label lblSearchName = new Label
            {
                Text = "设备名称:",
                Location = new Point(20, 25),
                AutoSize = true,
                Font = new Font("微软雅黑", 10)
            };

            txtSearchName = new TextBox
            {
                Location = new Point(100, 20),
                Size = new Size(150, 25),
                Font = new Font("微软雅黑", 10)
            };

            Label lblStatus = new Label
            {
                Text = "状态:",
                Location = new Point(270, 25),
                AutoSize = true,
                Font = new Font("微软雅黑", 10)
            };

            cmbStatus = new ComboBox
            {
                Location = new Point(320, 20),
                Size = new Size(120, 25),
                Font = new Font("微软雅黑", 10),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbStatus.Items.AddRange(new object[] { "全部", "正常", "故障", "维护中" });
            cmbStatus.SelectedIndex = 0;

            btnSearch = new Button
            {
                Text = "搜索",
                Location = new Point(460, 20),
                Size = new Size(80, 25),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat
            };
            btnSearch.Click += BtnSearch_Click;

            // 分页控制
            btnPrev = new Button
            {
                Text = "上一页",
                Location = new Point(20, 440),
                Size = new Size(80, 30),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightPink,
                FlatStyle = FlatStyle.Flat,
                Enabled = false
            };
            btnPrev.Click += BtnPrev_Click;

            btnNext = new Button
            {
                Text = "下一页",
                Location = new Point(120, 440),
                Size = new Size(80, 30),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightPink,
                FlatStyle = FlatStyle.Flat,
                Enabled = false
            };
            btnNext.Click += BtnNext_Click;

            lblPageInfo = new Label
            {
                Location = new Point(220, 445),
                AutoSize = true,
                Font = new Font("微软雅黑", 10)
            };

            lblTotalCount = new Label
            {
                Location = new Point(320, 445),
                AutoSize = true,
                Font = new Font("微软雅黑", 10)
            };

            // 刷新按钮
            btnRefresh = new Button
            {
                Text = "刷新",
                Location = new Point(420, 440),
                Size = new Size(80, 30),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };
            btnRefresh.Click += BtnRefresh_Click;

            // 添加控件到用户控件
            this.Controls.Add(lblSearchName);
            this.Controls.Add(txtSearchName);
            this.Controls.Add(lblStatus);
            this.Controls.Add(cmbStatus);
            this.Controls.Add(btnSearch);
            this.Controls.Add(dgvStatus);
            this.Controls.Add(btnPrev);
            this.Controls.Add(btnNext);
            this.Controls.Add(lblPageInfo);
            this.Controls.Add(lblTotalCount);
            this.Controls.Add(btnRefresh);
        }

        private void InitDataGridView()
        {
            dgvStatus.AutoGenerateColumns = false;
            dgvStatus.Columns.Clear();

            dgvStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEquipmentId",
                HeaderText = "设备ID",
                DataPropertyName = "equipment_id",
                Width = 80
            });

            dgvStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEquipmentName",
                HeaderText = "设备名称",
                DataPropertyName = "equipment_name",
                Width = 150
            });

            dgvStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLabName",
                HeaderText = "所属实验室",
                DataPropertyName = "lab_name",
                Width = 120
            });

            dgvStatus.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "当前状态",
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
                    // 基础查询条件
                    string whereClause = "WHERE 1=1";

                    // 获取搜索条件
                    string searchName = txtSearchName.Text.Trim();
                    string selectedStatus = cmbStatus.SelectedItem.ToString();

                    // 添加设备名称搜索条件
                    if (!string.IsNullOrEmpty(searchName))
                    {
                        whereClause += " AND e.name LIKE @searchName";
                    }

                    // 添加状态搜索条件
                    if (selectedStatus != "全部")
                    {
                        int statusValue = 0;
                        switch (selectedStatus)
                        {
                            case "正常": statusValue = 1; break;
                            case "故障": statusValue = 2; break;
                            case "维护中": statusValue = 3; break;
                        }
                        whereClause += " AND e.current_status = @status";
                    }

                    // 查询总记录数
                    string countSql = @"
                        SELECT COUNT(*)
                        FROM equipment e
                        JOIN laboratory l ON e.lab_id = l.id;
                    ";

                    MySqlCommand countCmd = new MySqlCommand(countSql, conn);
                    // 添加参数
                    if (!string.IsNullOrEmpty(searchName))
                    {
                        countCmd.Parameters.AddWithValue("@searchName", $"%{searchName}%");
                    }
                    if (selectedStatus != "全部")
                    {
                        countCmd.Parameters.AddWithValue("@status",
                            selectedStatus == "正常" ? 1 :
                            selectedStatus == "故障" ? 2 : 3);
                    }
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                    // 计算总页数
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;

                    // 如果当前页大于总页数，调整到最后一页
                    if (currentPage > totalPages) currentPage = totalPages;

                    // 查询当前页数据
                    // 查询当前页数据 - 使用字符串插值正确拼接 WHERE 子句
                    string dataSql = $@"
    SELECT 
        e.id AS equipment_id,
        e.name AS equipment_name,
        l.name AS lab_name,
        e.current_status AS status,
        CASE 
            WHEN e.current_status = 1 THEN '正常'
            WHEN e.current_status = 2 THEN '故障'
            WHEN e.current_status = 3 THEN '维护中'
            ELSE '未知'
        END AS status_text
    FROM 
        equipment e
    JOIN laboratory l ON e.lab_id = l.id
    {whereClause}
    ORDER BY 
        e.current_status, e.id
    LIMIT @offset, @pageSize;
";

                    MySqlCommand dataCmd = new MySqlCommand(dataSql, conn);
                    // 添加搜索参数
                    if (!string.IsNullOrEmpty(searchName))
                    {
                        dataCmd.Parameters.AddWithValue("@searchName", $"%{searchName}%");
                    }
                    if (selectedStatus != "全部")
                    {
                        dataCmd.Parameters.AddWithValue("@status",
                            selectedStatus == "正常" ? 1 :
                            selectedStatus == "故障" ? 2 : 3);
                    }
                    dataCmd.Parameters.AddWithValue("@offset", (currentPage - 1) * pageSize);
                    dataCmd.Parameters.AddWithValue("@pageSize", pageSize);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(dataCmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // 显示数据
                    dgvStatus.DataSource = dt;
                    UpdatePagingInfo();
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

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            // 重置搜索条件
            txtSearchName.Text = "";
            cmbStatus.SelectedIndex = 0;
            currentPage = 1;
            LoadData();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            currentPage = 1; // 搜索时重置到第一页
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
    }
}