using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using YourProjectNamespace.DAO;
using YourProjectNamespace.Entity;

namespace YourProjectNamespace
{
    public partial class UC_EquipmentManage : UserControl
    {
        private readonly EquipmentDAO _equipmentDAO = new EquipmentDAO();
        private int currentPage = 1;
        private int pageSize = 10;
        private int totalCount = 0;
        private long currentLabId = 1;
        public UC_EquipmentManage()
        {
            InitializeComponent();
            InitDataGridView();
            LoadStatusComboBox();
            LoadEquipmentData();
        }

        // 初始化表格
        private void InitDataGridView()
        {
            dgvEquipment.AutoGenerateColumns = false;
            dgvEquipment.Columns.Clear();

            AddTextBoxColumn("colId", "设备ID", "Id", 60);
            AddTextBoxColumn("colName", "设备名称", "Name", 120);
            AddTextBoxColumn("colModel", "型号", "Model", 100);
            AddTextBoxColumn("colPurchaseDate", "购置时间", "PurchaseTime", 120);
            AddTextBoxColumn("colParams", "技术参数", "TechnicalParams", 200);
            AddTextBoxColumn("colStatus", "状态", "StatusText", 80); 
                                                                  
        }

        // 辅助方法：添加表格列
        private void AddTextBoxColumn(string name, string header, string dataProperty, int width)
        {
            dgvEquipment.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                DataPropertyName = dataProperty,
                Width = width
            });
        }

        // 加载设备状态下拉框
        private void LoadStatusComboBox()
        {
            cboStatus.DataSource = new[]
            {
                new { Value = 1, Text = "正常" },
                new { Value = 2, Text = "故障" },
                new { Value = 3, Text = "维护中" }
            };
            cboStatus.DisplayMember = "Text";
            cboStatus.ValueMember = "Value";
            cboStatus.SelectedIndex = 0;
        }

        // 加载设备数据（带分页）
        private void LoadEquipmentData()
        {
            try
            {
                // 获取设备列表和总数
                var equipmentList = _equipmentDAO.GetEquipmentList(currentPage, pageSize);
                totalCount = _equipmentDAO.GetTotalCount();

                // 绑定数据
                dgvEquipment.DataSource = equipmentList;
                UpdatePagingInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载设备列表失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 更新分页信息
        private void UpdatePagingInfo()
        {
            int totalPages = Math.Max(1, (int)Math.Ceiling(totalCount / (double)pageSize));
            lblPageInfo.Text = $"{currentPage}/{totalPages}";
            lblTotalCount.Text = $"共{totalCount}条数据";

            btnPrev.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        // 清空表单
        private void ClearForm()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtLabId.Text ="";
            txtModel.Text = "";
            dtpPurchaseDate.Value = DateTime.Now;
            txtParams.Text = "";
            cboStatus.SelectedIndex = 0;
        }

     
        private void dgvEquipment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var equipment = (Equipment)dgvEquipment.Rows[e.RowIndex].DataBoundItem;
                txtId.Text = equipment.Id.ToString();
                txtName.Text = equipment.Name;
                txtModel.Text = equipment.Model;
                dtpPurchaseDate.Value = (DateTime)equipment.PurchaseTime;
                txtParams.Text = equipment.TechnicalParams;
                cboStatus.SelectedValue = equipment.CurrentStatus;
                currentLabId = equipment.LabId; 
            }
        }

        // 保存按钮：新增/编辑设备
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入设备名称！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 创建设备对象
                var equipment = new Equipment
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : Convert.ToInt64(txtId.Text),
                    LabId = Convert.ToInt64(txtLabId.Text.Trim()),
                    Name = txtName.Text,
                    Model = txtModel.Text,
                    PurchaseTime = dtpPurchaseDate.Value,
                    TechnicalParams = txtParams.Text,
                    CurrentStatus = (int)cboStatus.SelectedValue,

                };
                bool success = _equipmentDAO.SaveEquipment(equipment);

                if (success)
                {
                    MessageBox.Show(string.IsNullOrEmpty(txtId.Text) ? "新增成功！" : "更新成功！",
                        "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEquipmentData();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("操作失败！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (MySqlException mysqlEx)
            {
                MessageBox.Show($"数据库错误: {mysqlEx.Message}\n错误代码: {mysqlEx.Number}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 重置按钮
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // 删除按钮
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEquipment.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的设备！", "提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("确认删除该设备？删除后不可恢复！", "警告",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // 获取选中行的设备ID
                var selectedRow = dgvEquipment.SelectedRows[0];
                long id = Convert.ToInt64(selectedRow.Cells["colId"].Value);

                bool success = _equipmentDAO.DeleteEquipment(id);

                if (success)
                {
                    MessageBox.Show("删除成功！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEquipmentData();  // 刷新数据
                    ClearForm();          // 清空表单
                }
                else
                {
                    MessageBox.Show("设备ID不存在或已被删除！", "提示",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"删除失败：{ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 上一页按钮
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadEquipmentData();
            }
        }

        // 下一页按钮
        private void btnNext_Click(object sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadEquipmentData();
            }
        }

        private void dgvEquipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}