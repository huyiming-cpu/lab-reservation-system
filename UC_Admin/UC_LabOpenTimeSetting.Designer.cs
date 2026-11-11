namespace YourProjectNamespace
{
    partial class UC_LabOpenTimeSetting
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
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpCloseTime = new System.Windows.Forms.DateTimePicker();
            this.lblCloseTime = new System.Windows.Forms.Label();
            this.cboWeekDay = new System.Windows.Forms.ComboBox();
            this.dtpOpenTime = new System.Windows.Forms.DateTimePicker();
            this.lblOpenTime = new System.Windows.Forms.Label();
            this.lblWeekDay = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratories)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLaboratories
            // 
            this.dgvLaboratories.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaboratories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaboratories.Location = new System.Drawing.Point(153, 14);
            this.dgvLaboratories.Name = "dgvLaboratories";
            this.dgvLaboratories.RowHeadersWidth = 62;
            this.dgvLaboratories.RowTemplate.Height = 30;
            this.dgvLaboratories.Size = new System.Drawing.Size(1049, 487);
            this.dgvLaboratories.TabIndex = 0;
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Yellow;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.Location = new System.Drawing.Point(182, 523);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(176, 46);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "上一页";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Yellow;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(762, 523);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(176, 46);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Yellow;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(359, 257);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(176, 46);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Yellow;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(679, 257);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(176, 46);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.groupBox1.Controls.Add(this.dtpCloseTime);
            this.groupBox1.Controls.Add(this.lblCloseTime);
            this.groupBox1.Controls.Add(this.cboWeekDay);
            this.groupBox1.Controls.Add(this.dtpOpenTime);
            this.groupBox1.Controls.Add(this.lblOpenTime);
            this.groupBox1.Controls.Add(this.lblWeekDay);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(64, 603);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1194, 373);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置时间";
            // 
            // dtpCloseTime
            // 
            this.dtpCloseTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCloseTime.Location = new System.Drawing.Point(837, 171);
            this.dtpCloseTime.Name = "dtpCloseTime";
            this.dtpCloseTime.Size = new System.Drawing.Size(200, 39);
            this.dtpCloseTime.TabIndex = 14;
            // 
            // lblCloseTime
            // 
            this.lblCloseTime.AutoSize = true;
            this.lblCloseTime.Location = new System.Drawing.Point(674, 171);
            this.lblCloseTime.Name = "lblCloseTime";
            this.lblCloseTime.Size = new System.Drawing.Size(110, 31);
            this.lblCloseTime.TabIndex = 13;
            this.lblCloseTime.Text = "关闭时间";
            // 
            // cboWeekDay
            // 
            this.cboWeekDay.FormattingEnabled = true;
            this.cboWeekDay.Items.AddRange(new object[] {
            "周一",
            "周二",
            "周三",
            "周四",
            "周五"});
            this.cboWeekDay.Location = new System.Drawing.Point(260, 82);
            this.cboWeekDay.Name = "cboWeekDay";
            this.cboWeekDay.Size = new System.Drawing.Size(121, 39);
            this.cboWeekDay.TabIndex = 10;
            // 
            // dtpOpenTime
            // 
            this.dtpOpenTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpOpenTime.Location = new System.Drawing.Point(260, 171);
            this.dtpOpenTime.Name = "dtpOpenTime";
            this.dtpOpenTime.Size = new System.Drawing.Size(200, 39);
            this.dtpOpenTime.TabIndex = 9;
            // 
            // lblOpenTime
            // 
            this.lblOpenTime.AutoSize = true;
            this.lblOpenTime.Location = new System.Drawing.Point(87, 171);
            this.lblOpenTime.Name = "lblOpenTime";
            this.lblOpenTime.Size = new System.Drawing.Size(110, 31);
            this.lblOpenTime.TabIndex = 8;
            this.lblOpenTime.Text = "开放时间";
            // 
            // lblWeekDay
            // 
            this.lblWeekDay.AutoSize = true;
            this.lblWeekDay.Location = new System.Drawing.Point(87, 82);
            this.lblWeekDay.Name = "lblWeekDay";
            this.lblWeekDay.Size = new System.Drawing.Size(86, 31);
            this.lblWeekDay.TabIndex = 7;
            this.lblWeekDay.Text = "星期：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(65, 126);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(0, 31);
            this.lblName.TabIndex = 6;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.Location = new System.Drawing.Point(521, 531);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(55, 31);
            this.lblPageInfo.TabIndex = 6;
            this.lblPageInfo.Text = "1/1";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(1047, 538);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(155, 31);
            this.lblTotalCount.TabIndex = 7;
            this.lblTotalCount.Text = "共100条数据";
            // 
            // UC_LabOpenTimeSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.dgvLaboratories);
            this.Name = "UC_LabOpenTimeSetting";
            this.Size = new System.Drawing.Size(1591, 1062);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaboratories)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLaboratories;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboWeekDay;
        private System.Windows.Forms.DateTimePicker dtpOpenTime;
        private System.Windows.Forms.Label lblOpenTime;
        private System.Windows.Forms.Label lblWeekDay;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.DateTimePicker dtpCloseTime;
        private System.Windows.Forms.Label lblCloseTime;
    }
}
