using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LabReservationApp.Entity;
using LabReservationApp.Service;

namespace LabReservationApp.UC_Admin
{
    public partial class UC_LabUtilization : UserControl
    {
        private readonly ReservationService _reservationService = new ReservationService();
        private List<LabUtilizationStats> _statsData;

        public UC_LabUtilization()
        {
            InitializeComponent();
            InitControls();
            LoadData();
        }

        private void InitControls()
        {
            // 初始化 DataGridView
            dgvLabUtilization.AutoGenerateColumns = false;
            dgvLabUtilization.Columns.AddRange(new DataGridViewTextBoxColumn[] {
                new DataGridViewTextBoxColumn { HeaderText = "实验室ID", DataPropertyName = "LabId", Width = 80 },
                new DataGridViewTextBoxColumn { HeaderText = "实验室名称", DataPropertyName = "LabName", Width = 150 },
                new DataGridViewTextBoxColumn { HeaderText = "预约次数", DataPropertyName = "ReservationCount", Width = 100 },
                new DataGridViewTextBoxColumn { HeaderText = "总预约时长(分钟)", DataPropertyName = "TotalReserveMinutes", Width = 150 },
                new DataGridViewTextBoxColumn { HeaderText = "总使用时长(分钟)", DataPropertyName = "TotalUsedMinutes", Width = 150 },
                new DataGridViewTextBoxColumn { HeaderText = "利用率(%)", DataPropertyName = "UtilizationRate", Width = 120,
                    DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight } }
            });

            // 初始化 Chart
            chartUtilization.Series.Clear();
            var series = chartUtilization.Series.Add("利用率");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            // 绑定按钮事件
            btnQuery.Click += (s, e) => LoadData();
        }

        private void LoadData()
        {
            try
            {
                // 直接调用服务层获取统计数据
                _statsData = _reservationService.GetLabUtilizationStats();

                // 绑定数据到 DataGridView
                dgvLabUtilization.DataSource = _statsData;

                // 更新统计信息
                lblTotalCount.Text = $"共 {_statsData.Count} 个实验室";

                // 渲染图表
                RenderChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载数据失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RenderChart()
        {
            chartUtilization.Series[0].Points.Clear();
            foreach (var item in _statsData)
            {
                chartUtilization.Series[0].Points.AddXY(item.LabName, item.UtilizationRate);
            }
        }
    }
}