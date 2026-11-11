using LabManagementSystem.Service;
using LabReservationApp.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using YourProjectNamespace.Entity;

namespace LabManagementSystem
{
    public partial class UC_EquipmentFailureRate : UserControl
    {
        private readonly EquipmentService _equipmentService = new EquipmentService();
        private int _currentPage = 1;
        private int _pageSize = 10;
        private int _totalRecords = 0;
        private int _totalPages = 0;

        public UC_EquipmentFailureRate()
        {
            InitializeComponent();
            InitializeControls();
        }

        private void InitializeControls()
        {
            // 初始化表格
            InitDataGridView();

            // 加载初始数据
            LoadData();
        }

        private void InitDataGridView()
        {
            dgvFailureRate.AutoGenerateColumns = false;
            dgvFailureRate.Columns.Clear();

            dgvFailureRate.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "设备ID",
                DataPropertyName = "Id",
                Width = 50
            });
            dgvFailureRate.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "设备名称",
                DataPropertyName = "Name",
                Width = 150
            });
            
            dgvFailureRate.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "当前状态",
                DataPropertyName = "StatusText", 
                Width = 100
            });
            dgvFailureRate.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "使用次数",
                DataPropertyName = "UsageCount",
                Width = 80,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });
            dgvFailureRate.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "故障次数",
                DataPropertyName = "FaultCount",
                Width = 80,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // 故障率列
            var failureRateColumn = new DataGridViewTextBoxColumn
    {
        HeaderText = "故障率(%)",
        Name = "FailureRate", // 必须设置 Name
        Width = 100,
        DefaultCellStyle = { 
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "0.00" 
        }
    };
            dgvFailureRate.Columns.Add(failureRateColumn);

            // 表格样式
            dgvFailureRate.BackgroundColor = Color.White;
            dgvFailureRate.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFailureRate.ReadOnly = true;

           
            dgvFailureRate.DataBindingComplete += DgvFailureRate_DataBindingComplete;
        }

          private void DgvFailureRate_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
          {
              foreach (DataGridViewRow row in dgvFailureRate.Rows)
      {
          if (row.DataBoundItem is Equipment equipment)
          {
              decimal failureRate = equipment.UsageCount > 0 
                  ? Math.Round((decimal)equipment.FaultCount / equipment.UsageCount * 100, 2) 
                  : 0;
           
              row.Cells["FailureRate"].Value = failureRate;
          }
      }
          }

        private void DrawFailureRateChart(List<Equipment> equipments)
        {
           
            chart1.Series.Clear();          
            chart1.ResetAutoValues();       

          
            Series series = chart1.Series.Add("故障率");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;  // 显示数据标签

            foreach (var equipment in equipments)
            {
                decimal failureRate = equipment.UsageCount > 0
                    ? Math.Round((decimal)equipment.FaultCount / equipment.UsageCount * 100, 2)
                    : 0;

               
                series.Points.AddXY(equipment.Name, failureRate);
            }

           
            if (chart1.ChartAreas.Count == 0)
            {
                chart1.ChartAreas.Add(new ChartArea("MainArea"));
            }
            var chartArea = chart1.ChartAreas[0];

            // 横坐标样式
            chartArea.AxisX.Title = "设备名称";
            chartArea.AxisX.LabelStyle.Angle = 45;        // 保持斜显
            chartArea.AxisX.LabelStyle.IsEndLabelVisible = true; // 显示首尾标签
            chartArea.AxisX.Interval = 1;                // 强制显示每个标签

            // 纵坐标样式
            chartArea.AxisY.Title = "故障率(%)";
            chartArea.AxisY.Minimum = 0;                 
            chartArea.AxisY.Maximum = 20;               // 最大设为 100%

           
            chart1.Invalidate();
            chart1.Update();
        }

        private void LoadData()
        {
            try
            {
                // 获取分页设备列表
                var equipments = _equipmentService.GetEquipmentList(_currentPage, _pageSize);



                _totalRecords = _equipmentService.GetTotalCount();
                _totalPages = (int)Math.Ceiling((double)_totalRecords / _pageSize);

                if (_totalPages == 0) _totalPages = 1;
                if (_currentPage > _totalPages) _currentPage = _totalPages;

                // 绑定到表格
                dgvFailureRate.DataSource = equipments;
                UpdatePagingInfo();
                DrawFailureRateChart(equipments);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"查询失败：{ex.Message}\n{ex.StackTrace}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show($"查询失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void UpdatePagingInfo()
        {
            lblPageInfo.Text = $"第 {_currentPage}/{_totalPages} 页";
            lblTotalCount.Text = $"共 {_totalRecords} 条记录";
            btnPrev.Enabled = _currentPage > 1;
            btnNext.Enabled = _currentPage < _totalPages;
        }

        // 按钮事件
       

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadData();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadData();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
         
            _currentPage = 1;
            LoadData();
        
    }
    }
}