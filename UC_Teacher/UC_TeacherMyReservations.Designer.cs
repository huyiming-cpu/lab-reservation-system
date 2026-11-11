namespace LabReservationApp.UC_Teacher
{
    partial class UC_TeacherMyReservations
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
            System.Windows.Forms.Label 状态选择;
            this.dgvReservations = new System.Windows.Forms.DataGridView();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnSignin = new System.Windows.Forms.Button();
            this.btnSignout = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpSignTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReportFault = new System.Windows.Forms.Button();
            状态选择 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).BeginInit();
            this.SuspendLayout();
            // 
            // 状态选择
            // 
            状态选择.AutoSize = true;
            状态选择.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            状态选择.Location = new System.Drawing.Point(73, 25);
            状态选择.Name = "状态选择";
            状态选择.Size = new System.Drawing.Size(129, 37);
            状态选择.TabIndex = 12;
            状态选择.Text = "状态选择";
            // 
            // dgvReservations
            // 
            this.dgvReservations.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvReservations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReservations.Location = new System.Drawing.Point(33, 110);
            this.dgvReservations.Name = "dgvReservations";
            this.dgvReservations.RowHeadersWidth = 62;
            this.dgvReservations.RowTemplate.Height = 30;
            this.dgvReservations.Size = new System.Drawing.Size(1562, 371);
            this.dgvReservations.TabIndex = 0;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Turquoise;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.Location = new System.Drawing.Point(257, 532);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(133, 46);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "上一页";
            this.btnPrev.UseVisualStyleBackColor = false;
           
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Turquoise;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(796, 534);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(132, 44);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = false;
           
            // 
            // btnSignin
            // 
            this.btnSignin.BackColor = System.Drawing.Color.Turquoise;
            this.btnSignin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignin.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSignin.Location = new System.Drawing.Point(269, 817);
            this.btnSignin.Name = "btnSignin";
            this.btnSignin.Size = new System.Drawing.Size(192, 73);
            this.btnSignin.TabIndex = 3;
            this.btnSignin.Text = "签到";
            this.btnSignin.UseVisualStyleBackColor = false;
            // 
            // btnSignout
            // 
            this.btnSignout.BackColor = System.Drawing.Color.Turquoise;
            this.btnSignout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignout.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSignout.Location = new System.Drawing.Point(636, 817);
            this.btnSignout.Name = "btnSignout";
            this.btnSignout.Size = new System.Drawing.Size(192, 73);
            this.btnSignout.TabIndex = 4;
            this.btnSignout.Text = "签退";
            this.btnSignout.UseVisualStyleBackColor = false;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.Location = new System.Drawing.Point(563, 539);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(55, 31);
            this.lblPageInfo.TabIndex = 5;
            this.lblPageInfo.Text = "1/1";
          
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(1072, 540);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(155, 31);
            this.lblTotalCount.TabIndex = 6;
            this.lblTotalCount.Text = "共100条数据";
            // 
            // cboStatus
            // 
            this.cboStatus.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "全部",
            "待审核",
            "已通过",
            "已驳回",
            "已签到",
            "已签退"});
            this.cboStatus.Location = new System.Drawing.Point(239, 25);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(203, 36);
            this.cboStatus.TabIndex = 7;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Turquoise;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(521, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(136, 51);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dtpSignTime
            // 
            this.dtpSignTime.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpSignTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpSignTime.Location = new System.Drawing.Point(586, 714);
            this.dtpSignTime.Name = "dtpSignTime";
            this.dtpSignTime.Size = new System.Drawing.Size(200, 44);
            this.dtpSignTime.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(217, 714);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = "选择签到/签退时间";
            // 
            // btnReportFault
            // 
            this.btnReportFault.BackColor = System.Drawing.Color.Turquoise;
            this.btnReportFault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportFault.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReportFault.Location = new System.Drawing.Point(1035, 817);
            this.btnReportFault.Name = "btnReportFault";
            this.btnReportFault.Size = new System.Drawing.Size(192, 73);
            this.btnReportFault.TabIndex = 11;
            this.btnReportFault.Text = "申报故障";
            this.btnReportFault.UseVisualStyleBackColor = false;
            this.btnReportFault.Click += new System.EventHandler(this.BtnReportFault_Click);
            // 
            // UC_TeacherMyReservations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(状态选择);
            this.Controls.Add(this.btnReportFault);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpSignTime);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnSignout);
            this.Controls.Add(this.btnSignin);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.dgvReservations);
            this.Name = "UC_TeacherMyReservations";
            this.Size = new System.Drawing.Size(1674, 1038);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReservations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReservations;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSignin;
        private System.Windows.Forms.Button btnSignout;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpSignTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReportFault;
    }
}
