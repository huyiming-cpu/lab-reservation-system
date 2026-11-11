namespace LabReservationApp.UC_Admin
{
    partial class UC_LabUtilization
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgvLabUtilization = new System.Windows.Forms.DataGridView();
            this.chartUtilization = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabUtilization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUtilization)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLabUtilization
            // 
            this.dgvLabUtilization.BackgroundColor = System.Drawing.Color.White;
            this.dgvLabUtilization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabUtilization.Location = new System.Drawing.Point(45, 19);
            this.dgvLabUtilization.Name = "dgvLabUtilization";
            this.dgvLabUtilization.RowHeadersWidth = 62;
            this.dgvLabUtilization.RowTemplate.Height = 30;
            this.dgvLabUtilization.Size = new System.Drawing.Size(1281, 482);
            this.dgvLabUtilization.TabIndex = 6;
            // 
            // chartUtilization
            // 
            chartArea1.Name = "ChartArea1";
            this.chartUtilization.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartUtilization.Legends.Add(legend1);
            this.chartUtilization.Location = new System.Drawing.Point(146, 622);
            this.chartUtilization.Name = "chartUtilization";
            this.chartUtilization.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Fire;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartUtilization.Series.Add(series1);
            this.chartUtilization.Size = new System.Drawing.Size(853, 346);
            this.chartUtilization.TabIndex = 7;
            this.chartUtilization.Text = "chart1";
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Yellow;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.Location = new System.Drawing.Point(223, 520);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(176, 46);
            this.btnPrev.TabIndex = 8;
            this.btnPrev.Text = "上一页";
            this.btnPrev.UseVisualStyleBackColor = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Yellow;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(763, 525);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(176, 46);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = false;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.Location = new System.Drawing.Point(543, 533);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(55, 31);
            this.lblPageInfo.TabIndex = 10;
            this.lblPageInfo.Text = "1/1";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(1066, 540);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(155, 31);
            this.lblTotalCount.TabIndex = 11;
            this.lblTotalCount.Text = "共100条数据";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Yellow;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.Location = new System.Drawing.Point(1072, 749);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(176, 46);
            this.btnQuery.TabIndex = 12;
            this.btnQuery.Text = "刷新";
            this.btnQuery.UseVisualStyleBackColor = false;
            // 
            // UC_LabUtilization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.chartUtilization);
            this.Controls.Add(this.dgvLabUtilization);
            this.Name = "UC_LabUtilization";
            this.Size = new System.Drawing.Size(1508, 1062);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabUtilization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartUtilization)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvLabUtilization;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartUtilization;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnQuery;
    }
}
