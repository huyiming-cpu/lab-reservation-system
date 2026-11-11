using LabReservationApp.Entity;
using LabReservationApp.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace LabReservationApp.UC_Teacher
{
    public partial class UC_TeacherLabReservation : UserControl
     {
         // 服务层实例
         private readonly LaboratoryService _labService = new LaboratoryService();
         private readonly ReservationService _resService = new ReservationService();

         // 缓存实验室列表、当前选中实验室
         private List<Laboratory> _cachedLabs;
         private Laboratory _selectedLab;

         // 分页相关
         private long _teacherId;
         private int _currentPage = 1;
        private const int PAGE_SIZE = 10;
        public UC_TeacherLabReservation(long teacherId)
        {
            InitializeComponent();
            _teacherId = teacherId;
            Debug.WriteLine($"教师 ID: {_teacherId} 已接收");
            InitializeControls();
            //LoadLaboratories(); // 初始加载实验室数据
            if (_teacherId > 0)
            {
                LoadLaboratories(); // 有效 ID 才加载数据
            }
            else
            {
                MessageBox.Show($"教师 ID 无效（{_teacherId}），请重新登录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 无参构造（设计器兼容）
        public UC_TeacherLabReservation()
        {
            InitializeComponent();
            InitializeControls();
        }

        // 初始化控件事件
        private void InitializeControls()
        {
            // 日期选择器默认 today
            dtpReserveDate.MinDate = DateTime.Today;
            dtpReserveDate.Value = DateTime.Today;

            // 时间选择器格式：HH:mm（仅显示时间）
            dtpReserveStart.Format = DateTimePickerFormat.Time;
            dtpReserveStart.ShowUpDown = true;
            dtpReserveStart.CustomFormat = "HH:mm";

            dtpReserveEnd.Format = DateTimePickerFormat.Time;
            dtpReserveEnd.ShowUpDown = true;
            dtpReserveEnd.CustomFormat = "HH:mm";

            // 绑定按钮事件
            btnSearch.Click += BtnSearch_Click;
            dgvLaboratories.CellClick += DgvLaboratories_CellClick;
            btnReserve.Click += BtnReserve_Click;
            btnPrevPage.Click += BtnPrevPage_Click;
            btnNextPage.Click += BtnNextPage_Click;
        }

        #region 分页逻辑
        private void BtnNextPage_Click(object sender, EventArgs e)
        {
            int totalCount = _labService.GetTotalCount(txtSearch.Text.Trim());
            int maxPage = totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0);

            if (_currentPage < maxPage)
            {
                _currentPage++;
                LoadLaboratories(txtSearch.Text.Trim(), _currentPage);
            }
            else
            {
                MessageBox.Show("已是最后一页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnPrevPage_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadLaboratories(txtSearch.Text.Trim(), _currentPage);
            }
            else
            {
                MessageBox.Show("已是第 1 页", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 搜索逻辑
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            LoadLaboratories(txtSearch.Text.Trim(), _currentPage);
        }
        #endregion

        #region 加载实验室数据
        private void LoadLaboratories(string keyword = "", int pageIndex = 1)
        {
            try
            {
                _currentPage = pageIndex;
                _cachedLabs = _labService.GetLaboratories(keyword, pageIndex, PAGE_SIZE);
                int totalCount = _labService.GetTotalCount(keyword);

                // 清空旧列，重新绑定字段
                dgvLaboratories.Columns.Clear();
                dgvLaboratories.Columns.Add("Id", "ID");
                dgvLaboratories.Columns.Add("Name", "名称");
                dgvLaboratories.Columns.Add("Location", "位置");
                dgvLaboratories.Columns.Add("Area", "面积(㎡)");
                dgvLaboratories.Columns.Add("IsEnabledText", "状态");
                dgvLaboratories.Columns.Add("WeekDay", "开放日");
                dgvLaboratories.Columns.Add("OpenStart", "开放开始时间");
                dgvLaboratories.Columns.Add("OpenEnd", "开放结束时间");
                dgvLaboratories.Columns.Add("EquipmentList", "设备清单");
            
                dgvLaboratories.Rows.Clear();
                foreach (var lab in _cachedLabs)
                {
                    dgvLaboratories.Rows.Add(
                        lab.Id,
                        lab.Name,
                        lab.Location,
                        lab.Area,
                        lab.IsEnabledText, // 显示启用状态文本
                        lab.WeekDay,
                        lab.OpenStart.ToString(@"hh\:mm"),
                        lab.OpenEnd.ToString(@"hh\:mm"),
                        lab.EquipmentList
                    );
                }

                // 更新分页信息
                int totalPages = totalCount / PAGE_SIZE + (totalCount % PAGE_SIZE > 0 ? 1 : 0);
                lblPageInfo.Text = $"第 {pageIndex} 页 / 共 {totalPages} 页";
                lblTotalCount.Text = $"总记录数：{totalCount} 条";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 选择实验室（行点击事件）
        private void DgvLaboratories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine($"教师 ID: {_teacherId} 执行预约操作");

            // 校验教师ID
            if (_teacherId <= 0)
            {
                MessageBox.Show("教师ID无效，请重新登录", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 校验行索引
            if (e.RowIndex < 0 || e.RowIndex >= _cachedLabs.Count) return;
            _selectedLab = _cachedLabs[e.RowIndex];

            // 弹窗提示选择结果
            MessageBox.Show($"已选实验室：{_selectedLab.Name}\n位置：{_selectedLab.Location}",
                "实验室选择", MessageBoxButtons.OK, MessageBoxIcon.Information);

           
            dtpReserveStart.Value = DateTime.Today.Add(_selectedLab.OpenStart);
            dtpReserveEnd.Value = DateTime.Today.AddHours(2).Add(_selectedLab.OpenStart);
        }
        #endregion

        #region 提交预约
        private void BtnReserve_Click(object sender, EventArgs e)
        {
            // 校验是否选择实验室
            if (_selectedLab == null)
            {
                MessageBox.Show("请先选择实验室", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 获取预约时间
            DateTime reserveDate = dtpReserveDate.Value.Date;
            TimeSpan reserveStart = dtpReserveStart.Value.TimeOfDay;
            TimeSpan reserveEnd = dtpReserveEnd.Value.TimeOfDay;

            // 基础时间校验
            if (reserveStart >= reserveEnd)
            {
                MessageBox.Show("结束时间必须晚于开始时间", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 校验是否在实验室开放时间内
            if (reserveStart < _selectedLab.OpenStart || reserveEnd > _selectedLab.OpenEnd)
            {
                MessageBox.Show($"预约时间超出开放范围！\n开放时间：{_selectedLab.OpenStart:hh\\:mm} - {_selectedLab.OpenEnd:hh\\:mm}",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 构造预约实体
            var reservation = new Reservation
            {
                LabId = _selectedLab.Id,
                TeacherId = _teacherId,
                ReserveDate = reserveDate,
                ReserveStart = reserveStart,
                ReserveEnd = reserveEnd,
                Status = 0 // 0=待审核
            };

            // 提交预约
            try
            {
                _resService.AddReservation(reservation);
                MessageBox.Show("预约提交成功！状态：待审核", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLaboratories(txtSearch.Text.Trim()); // 刷新列表
            }
            catch (Exception ex)
            {
                MessageBox.Show($"预约失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void UC_TeacherLabReservation_Load(object sender, EventArgs e)
        {

        }
    }
}