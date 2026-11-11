/*using LabReservationApp.Entity;
using LabReservationApp.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabReservationApp.UC_Approval
{
    public partial class UC_ReservationApproval : UserControl
    {
        private readonly ReservationService _resService = new ReservationService();
        private List<Reservation> _cachedReservations;
        private int _currentPage = 1;
        private const int PAGE_SIZE = 10;

        public UC_ReservationApproval()
        {
            InitializeComponent();
            InitializeControls();
            LoadReservations();
        }

        private void InitializeControls()
        {
            // 绑定分页按钮点击事件
            btnPrev.Click += BtnPrevPage_Click;
            btnNext.Click += BtnNextPage_Click;
            // 绑定“同意”“驳回”按钮点击事件
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
        }

        #region 分页逻辑
        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadReservations();
            }
            else
            {
                MessageBox.Show("已经是第 1 页啦～", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            int totalCount = _resService.GetReservationTotalCount();
            int maxPage = totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0);

            if (_currentPage < maxPage)
            {
                _currentPage++;
                LoadReservations();
            }
            else
            {
                MessageBox.Show("已经是最后一页啦～", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 加载预约记录
        private void LoadReservations()
        {
            try
            {
                _cachedReservations = _resService.GetReservations(_currentPage, PAGE_SIZE);
                int totalCount = _resService.GetReservationTotalCount();

                dgvReservations.Columns.Clear();
                dgvReservations.Columns.Add("Id", "预约记录ID");
                dgvReservations.Columns.Add("LabId", "实验室ID");
                dgvReservations.Columns.Add("TeacherId", "教师ID");
                dgvReservations.Columns.Add("ReserveDate", "预约日期");
                dgvReservations.Columns.Add("ReserveStart", "预约开始时间");
                dgvReservations.Columns.Add("ReserveEnd", "预约结束时间");
                dgvReservations.Columns.Add("StatusText", "状态");
                dgvReservations.Columns.Add("SigninTime", "签到时间");
                dgvReservations.Columns.Add("SignoutTime", "签退时间");

                dgvReservations.Rows.Clear();
                foreach (var reservation in _cachedReservations)
                {
                    dgvReservations.Rows.Add(
                        reservation.Id,
                        reservation.LabId,
                        reservation.TeacherId,
                        reservation.ReserveDate.ToString("yyyy-MM-dd"),
                        reservation.ReserveStart.ToString(@"hh\:mm"),
                        reservation.ReserveEnd.ToString(@"hh\:mm"),
                        reservation.StatusText,
                        reservation.SigninTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "未签到",
                        reservation.SignoutTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "未签退"
                    );
                }

                lblPageInfo.Text = $"第 {_currentPage} 页 / 共 {totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0)} 页";
                lblTotalCount.Text = $"共{totalCount}条数据";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 处理“同意”操作
        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中要同意的预约记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long reservationId = (long)dgvReservations.SelectedRows[0].Cells["Id"].Value;
            try
            {
                _resService.UpdateReservationStatus(reservationId, 1); // 1 表示“已通过”
                MessageBox.Show("同意操作成功，状态已更新为‘已通过’", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations(); // 刷新列表
            }
            catch (Exception ex)
            {
                MessageBox.Show($"同意操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 处理“驳回”操作
        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中要驳回的预约记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long reservationId = (long)dgvReservations.SelectedRows[0].Cells["Id"].Value;
            try
            {
                _resService.UpdateReservationStatus(reservationId, 2); // 2 表示“已驳回”
                MessageBox.Show("驳回操作成功，状态已更新为‘已驳回’", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations(); // 刷新列表
            }
            catch (Exception ex)
            {
                MessageBox.Show($"驳回操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}*/
using LabReservationApp.Entity;
using LabReservationApp.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LabReservationApp.UC_Approval
{
    public partial class UC_ReservationApproval : UserControl
    {
        private readonly ReservationService _resService = new ReservationService();
        private List<Reservation> _cachedReservations;
        private int _currentPage = 1;
        private const int PAGE_SIZE = 10;

        public UC_ReservationApproval()
        {
            InitializeComponent();
            InitializeControls();
            LoadReservations();
        }

        private void InitializeControls()
        {
            // 绑定分页按钮点击事件
            btnPrev.Click += BtnPrevPage_Click;
            btnNext.Click += BtnNextPage_Click;
           
            btnApprove.Click += BtnApprove_Click;
            btnReject.Click += BtnReject_Click;
        }

        #region 分页逻辑
        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadReservations();
            }
            else
            {
                MessageBox.Show("已经是第 1 页啦～", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            int totalCount = _resService.GetReservationTotalCount();
            int maxPage = totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0);

            if (_currentPage < maxPage)
            {
                _currentPage++;
                LoadReservations();
            }
            else
            {
                MessageBox.Show("已经是最后一页啦～", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 加载预约记录
        private void LoadReservations()
        {
            try
            {
                _cachedReservations = _resService.GetReservations(_currentPage, PAGE_SIZE);
                int totalCount = _resService.GetReservationTotalCount();

                dgvReservations.Columns.Clear();
                dgvReservations.Columns.Add("Id", "预约记录ID");
                dgvReservations.Columns.Add("LabId", "实验室ID");
                dgvReservations.Columns.Add("TeacherId", "教师ID");
                dgvReservations.Columns.Add("ReserveDate", "预约日期");
                dgvReservations.Columns.Add("ReserveStart", "预约开始时间");
                dgvReservations.Columns.Add("ReserveEnd", "预约结束时间");
                dgvReservations.Columns.Add("StatusText", "状态");
                dgvReservations.Columns.Add("SigninTime", "签到时间");
                dgvReservations.Columns.Add("SignoutTime", "签退时间");

                dgvReservations.Rows.Clear();
                foreach (var reservation in _cachedReservations)
                {
                    dgvReservations.Rows.Add(
                        reservation.Id,
                        reservation.LabId,
                        reservation.TeacherId,
                        reservation.ReserveDate.ToString("yyyy-MM-dd"),
                        reservation.ReserveStart.ToString(@"hh\:mm"),
                        reservation.ReserveEnd.ToString(@"hh\:mm"),
                        reservation.StatusText,
                        reservation.SigninTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "未签到",
                        reservation.SignoutTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? "未签退"
                    );
                }

                lblPageInfo.Text = $"第 {_currentPage} 页 / 共 {totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0)} 页";
                lblTotalCount.Text = $"共{totalCount}条数据";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 处理“同意”操作
        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中要同意的预约记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long reservationId = (long)dgvReservations.SelectedRows[0].Cells["Id"].Value;
            try
            {
                _resService.UpdateReservationStatus(reservationId, 1); // 1 表示“已通过”
                MessageBox.Show("同意操作成功，状态已更新为‘已通过’", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations(); // 刷新列表
            }
            catch (Exception ex)
            {
                MessageBox.Show($"同意操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 处理“驳回”操作
        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选中要驳回的预约记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long reservationId = (long)dgvReservations.SelectedRows[0].Cells["Id"].Value;
            try
            {
                _resService.UpdateReservationStatus(reservationId, 2); // 2 表示“已驳回”
                MessageBox.Show("驳回操作成功，状态已更新为‘已驳回’", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadReservations(); // 刷新列表
            }
            catch (Exception ex)
            {
                MessageBox.Show($"驳回操作失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void lblPageInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }
    }
}