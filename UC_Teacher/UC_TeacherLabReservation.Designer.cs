namespace LabReservationApp.UC_Teacher
{
    partial class UC_TeacherLabReservation
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
            this.dgvLaboratories = new System.Windows.Forms.DataGridView();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.dtpReserveDate = new System.Windows.Forms.DateTimePicker();
            this.dtpReserveStart = new System.Windows.Forms.DateTimePicker();
            this.dtpReserveEnd = new System.Windows.Forms.DateTimePicker();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.查询实验室 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratories)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLaboratories
            // 
            this.dgvLaboratories.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaboratories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaboratories.Location = new System.Drawing.Point(28, 109);
            this.dgvLaboratories.Name = "dgvLaboratories";
            this.dgvLaboratories.RowHeadersWidth = 62;
            this.dgvLaboratories.RowTemplate.Height = 30;
            this.dgvLaboratories.Size = new System.Drawing.Size(1285, 377);
            this.dgvLaboratories.TabIndex = 0;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.BackColor = System.Drawing.Color.Turquoise;
            this.btnPrevPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevPage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrevPage.Location = new System.Drawing.Point(120, 510);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(192, 50);
            this.btnPrevPage.TabIndex = 1;
            this.btnPrevPage.Text = "上一页";
            this.btnPrevPage.UseVisualStyleBackColor = false;
            // 
            // btnNextPage
            // 
            this.btnNextPage.BackColor = System.Drawing.Color.Turquoise;
            this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNextPage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNextPage.Location = new System.Drawing.Point(735, 516);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(192, 44);
            this.btnNextPage.TabIndex = 2;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Turquoise;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(672, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(169, 62);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // btnReserve
            // 
            this.btnReserve.BackColor = System.Drawing.Color.Turquoise;
            this.btnReserve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReserve.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReserve.Location = new System.Drawing.Point(672, 707);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(284, 60);
            this.btnReserve.TabIndex = 4;
            this.btnReserve.Text = "预约";
            this.btnReserve.UseVisualStyleBackColor = false;
            // 
            // dtpReserveDate
            // 
            this.dtpReserveDate.CalendarFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReserveDate.CalendarTitleBackColor = System.Drawing.Color.MediumTurquoise;
            this.dtpReserveDate.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReserveDate.Location = new System.Drawing.Point(209, 616);
            this.dtpReserveDate.Name = "dtpReserveDate";
            this.dtpReserveDate.Size = new System.Drawing.Size(222, 39);
            this.dtpReserveDate.TabIndex = 5;
            // 
            // dtpReserveStart
            // 
            this.dtpReserveStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReserveStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpReserveStart.Location = new System.Drawing.Point(700, 616);
            this.dtpReserveStart.Name = "dtpReserveStart";
            this.dtpReserveStart.Size = new System.Drawing.Size(200, 39);
            this.dtpReserveStart.TabIndex = 6;
            // 
            // dtpReserveEnd
            // 
            this.dtpReserveEnd.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpReserveEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpReserveEnd.Location = new System.Drawing.Point(1174, 618);
            this.dtpReserveEnd.Name = "dtpReserveEnd";
            this.dtpReserveEnd.Size = new System.Drawing.Size(200, 39);
            this.dtpReserveEnd.TabIndex = 7;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.Location = new System.Drawing.Point(498, 527);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(55, 31);
            this.lblPageInfo.TabIndex = 8;
            this.lblPageInfo.Text = "1/1";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(1030, 520);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(155, 31);
            this.lblTotalCount.TabIndex = 9;
            this.lblTotalCount.Text = "共100条数据";
            // 
            // 查询实验室
            // 
            this.查询实验室.AutoSize = true;
            this.查询实验室.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.查询实验室.Location = new System.Drawing.Point(98, 35);
            this.查询实验室.Name = "查询实验室";
            this.查询实验室.Size = new System.Drawing.Size(134, 31);
            this.查询实验室.TabIndex = 10;
            this.查询实验室.Text = "选择实验室";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(304, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(260, 28);
            this.txtSearch.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(49, 618);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 31);
            this.label4.TabIndex = 12;
            this.label4.Text = "预约日期";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(480, 618);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 31);
            this.label5.TabIndex = 13;
            this.label5.Text = "开始使用时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(964, 618);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 31);
            this.label6.TabIndex = 14;
            this.label6.Text = "结束使用时间";
            // 
            // UC_TeacherLabReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.查询实验室);
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.dtpReserveEnd);
            this.Controls.Add(this.dtpReserveStart);
            this.Controls.Add(this.dtpReserveDate);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnNextPage);
            this.Controls.Add(this.btnPrevPage);
            this.Controls.Add(this.dgvLaboratories);
            this.Name = "UC_TeacherLabReservation";
            this.Size = new System.Drawing.Size(1501, 936);
            this.Load += new System.EventHandler(this.UC_TeacherLabReservation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLaboratories;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.DateTimePicker dtpReserveDate;
        private System.Windows.Forms.DateTimePicker dtpReserveStart;
        private System.Windows.Forms.DateTimePicker dtpReserveEnd;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label 查询实验室;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
