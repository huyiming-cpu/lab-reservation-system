using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace LabManagementSystem
{
    public partial class UC_EquipmentStatusStats : UserControl
    {
        private string connStr = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306;";
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalRecords = 0;
        private int totalPages = 0;

        public UC_EquipmentStatusStats()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // 初始化 DataGridView
            InitDataGridView();

            // 加载初始数据
            LoadData();
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

            // 设置表格样式
            dgvStatus.BackgroundColor = Color.White;
            dgvStatus.BorderStyle = BorderStyle.Fixed3D;
            dgvStatus.GridColor = Color.LightGray;
            dgvStatus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStatus.AllowUserToAddRows = false;
            dgvStatus.AllowUserToDeleteRows = false;
            dgvStatus.ReadOnly = true;
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
                        FROM equipment e
                        JOIN laboratory l ON e.lab_id = l.id;
                    ";

                    MySqlCommand countCmd = new MySqlCommand(countSql, conn);
                    totalRecords = Convert.ToInt32(countCmd.ExecuteScalar());

                    // 计算总页数
                    totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                    if (totalPages == 0) totalPages = 1;

                    // 如果当前页大于总页数，调整到最后一页
                    if (currentPage > totalPages) currentPage = totalPages;

                    // 查询当前页数据
                    string dataSql = @"
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
                        ORDER BY 
                            e.current_status, e.id
                        LIMIT @offset, @pageSize;
                    ";

                    MySqlCommand dataCmd = new MySqlCommand(dataSql, conn);
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

     
     
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
               
            LoadData();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
          
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }
   
    }
}