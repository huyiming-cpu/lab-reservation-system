using LabManagementSystem.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YourProjectNamespace.Entity;

namespace LabReservationApp.AllForms
{
    public partial class EquipmentForm : Form
    {
        public EquipmentForm()
        {
            InitializeComponent();
        }
        private EquipmentService _equipmentService = new EquipmentService();
        private long equipmentId;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            if (dgvEquipment.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中一台设备再确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 从选中行取设备ID
            SelectedEquipmentId = Convert.ToInt64(dgvEquipment.SelectedRows[0].Cells["Id"].Value);

            DialogResult = DialogResult.OK; // 关闭窗体并返回确认状态
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           
           // DialogResult = DialogResult.Cancel;
           this.Close();
        }
    
    }
    }



namespace LabReservationApp.AllForms
{
    public partial class EquipmentForm : Form
    {
        private List<Equipment> _equipments; // 接收实验室下的设备列表
        public long SelectedEquipmentId { get; private set; } // 供外部获取选中的设备ID

        // 构造函数：接收“该实验室下的设备列表”
        public EquipmentForm(List<Equipment> equipments)
        {
            InitializeComponent();
            _equipments = equipments;
            LoadEquipmentData();
        }

        // 加载设备数据到 DataGridView
        private void LoadEquipmentData()
        {
            dgvEquipment.Columns.Clear();
            // 添加列（根据需求调整，这里示例常用字段）
            dgvEquipment.Columns.Add("Id", "设备ID");
            dgvEquipment.Columns.Add("Name", "设备名称");
            dgvEquipment.Columns.Add("Model", "设备型号");
            dgvEquipment.Columns.Add("PurchaseTime", "购置时间");
            dgvEquipment.Columns.Add("StatusText", "当前状态");

            // 遍历设备，填充行数据
            foreach (var eq in _equipments)
            {
                dgvEquipment.Rows.Add(
                    eq.Id,
                    eq.Name,
                    eq.Model,
                   // eq.PurchaseTime.ToString("yyyy-MM-dd"),
                   eq.PurchaseTime.HasValue
        ? eq.PurchaseTime.Value.ToString("yyyy-MM-dd")
        : "",
                    eq.StatusText // 利用 Entity 里的状态文本属性
                );
            }
        }

        
    }
}

