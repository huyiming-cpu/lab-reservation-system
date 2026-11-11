using LabManagementSystem.Service;
using LabReservationApp.AllForms;
using LabReservationApp.Entity;
using LabReservationApp.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LabReservationApp.UC_Teacher
{
    public partial class UC_TeacherMyReservations : UserControl
    {
        private readonly ReservationService _resService = new ReservationService();
        private List<Reservation> _cachedReservations;
        private int _currentPage = 1;
        private const int PAGE_SIZE = 10;
        // 记录当前选中的预约（用于签到/签退）
        private Reservation _selectedReservation;
        private object _teacherId;
        private object teacherId;
        private long _selectedLabId = 0; // 记录选中预约的实验室ID
        private readonly EquipmentService _equipmentService = new EquipmentService();

        public UC_TeacherMyReservations()
        {
            InitializeComponent();
            _teacherId = teacherId; // 保存教师ID
            InitializeControls();
            LoadReservations();
        }

        private void InitializeControls()
        {
           
            cboStatus.SelectedIndex = 0;

            // 绑定事件
            btnSearch.Click += BtnSearch_Click;
            btnPrev.Click += BtnPrevPage_Click;
            btnNext.Click += BtnNextPage_Click;
            btnSignin.Click += BtnSignin_Click;
            btnSignout.Click += BtnSignout_Click;
            btnReportFault.Click += BtnReportFault_Click;
            dgvReservations.CellClick += DgvReservations_CellClick;
        }


        private void LoadReservations(string statusFilter = "全部")
        {
            try
            {
                Debug.WriteLine($"开始加载预约数据，状态筛选：{statusFilter}");
                _cachedReservations = _resService.GetReservationsByStatus1(_currentPage, PAGE_SIZE, statusFilter);
                int totalCount = _resService.GetReservationTotalCountByStatus(statusFilter);

                // 验证数据是否存在
                if (_cachedReservations == null || _cachedReservations.Count == 0)
                {
                    Debug.WriteLine("警告：未获取到预约数据");
                    MessageBox.Show("没有找到符合条件的预约记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               

                dgvReservations.Columns.Clear();
                // 添加所有字段列
                dgvReservations.Columns.Add("Id", "预约记录ID");
                dgvReservations.Columns.Add("LabId", "实验室ID");
                dgvReservations.Columns.Add("TeacherId", "教师ID");
                dgvReservations.Columns.Add("ReserveDate", "预约日期");
                dgvReservations.Columns.Add("ReserveStart", "预约开始时间");
                dgvReservations.Columns.Add("ReserveEnd", "预约结束时间");
                dgvReservations.Columns.Add("StatusText", "状态");
                dgvReservations.Columns.Add("SigninTime", "签到时间");
                dgvReservations.Columns.Add("SignoutTime", "签退时间");
                dgvReservations.Columns.Add("EquipmentList", "设备清单"); 

                dgvReservations.Rows.Clear();
           
                foreach (var reservation in _cachedReservations)
                {
                    // 根据实验室ID查询设备名称
                    string equipmentNames = _resService.GetEquipmentNamesByLabId1(reservation.LabId);

                    dgvReservations.Rows.Add(
                        reservation.Id,
                        reservation.LabId,
                        reservation.TeacherId,
                        reservation.ReserveDate.ToString("yyyy-MM-dd"),
                        reservation.ReserveStart.ToString(@"hh\:mm\:ss"),
                        reservation.ReserveEnd.ToString(@"hh\:mm\:ss"),
                        reservation.StatusText,
                        reservation.SigninTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "未签到",
                        reservation.SignoutTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "未签退",
                        equipmentNames // 设备清单列数据
                    );
                }
                dgvReservations.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                lblPageInfo.Text = $"第 {_currentPage} 页 / 共 {totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0)} 页";
                lblTotalCount.Text = $"共{totalCount}条数据";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1; // 搜索时重置页码
            string statusFilter = cboStatus.Text;
            LoadReservations(statusFilter);
        }


        #region 分页逻辑
        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadReservations(cboStatus.Text);
            }
            else
            {
                MessageBox.Show("已经是第 1 页啦～", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            int totalCount = _resService.GetReservationTotalCountByStatus(cboStatus.Text);
            int maxPage = totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0);

            if (_currentPage < maxPage)
            {
                _currentPage++;
                LoadReservations(cboStatus.Text);
            }
            else
            {
                MessageBox.Show("已经是最后一页啦～", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 选中行事件（记录当前预约）
        private void DgvReservations_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                long reservationId = (long)dgvReservations.Rows[e.RowIndex].Cells["Id"].Value;
                _selectedReservation = _resService.GetReservationById(reservationId);
            }
            else
            {
                _selectedReservation = null;
            }
        }
        #endregion

        #region 签到/签退逻辑
        private void BtnSignin_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                MessageBox.Show("请先选中要签到的预约记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 状态判断
            if (_selectedReservation.Status != 1)
            {
                MessageBox.Show("仅状态为「已通过」的预约可签到！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 获取DateTimePicker时间
            DateTime signTime = dtpSignTime.Value;

            try
            {
                _selectedReservation.SigninTime = signTime;
                _selectedReservation.Status = 3; 
                _resService.UpdateReservation(_selectedReservation);

                MessageBox.Show("签到成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations(cboStatus.Text); // 刷新列表
            }
            catch (Exception ex)
            {
                MessageBox.Show($"签到失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnSignout_Click(object sender, EventArgs e)
        {
            if (_selectedReservation == null)
            {
                MessageBox.Show("请先选中要签退的预约记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 签退条件判断
            if (_selectedReservation.Status != 3)
            {
                MessageBox.Show("预约未审批/预约未通过/请先签到", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 获取DateTimePicker时间
            DateTime signoutTime = dtpSignTime.Value;

            try
            {
                _selectedReservation.SignoutTime = signoutTime;
                _selectedReservation.Status = 4; 
                _resService.UpdateReservation(_selectedReservation);

                MessageBox.Show("签退成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations(cboStatus.Text); // 刷新列表
            }
            catch (Exception ex)
            {
                MessageBox.Show($"签退失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReportFault_Click(object sender, EventArgs e)
        {

            if (_selectedReservation == null)
            {
                MessageBox.Show("请先选中一条预约记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            var equipments = _equipmentService.GetEquipmentsByLabId1(_selectedReservation.LabId, 1);
            if (equipments.Count == 0)
            {
                MessageBox.Show("该实验室没有可申报故障的正常设备！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. 弹出设备选择窗体
            using (var eqForm = new EquipmentForm(equipments))
            {
                if (eqForm.ShowDialog() == DialogResult.OK)
                {
                    // 3. 用户确认后，更新设备状态为“故障”（状态=2）
                    _equipmentService.UpdateEquipmentStatus1(eqForm.SelectedEquipmentId, 2);
                    MessageBox.Show("设备状态已更新为「故障」，申报成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadReservations(cboStatus.Text); 
                }
            }
        }

     
    }
}
    #endregion


   