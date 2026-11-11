namespace YourProjectNamespace
{
    partial class UC_LabFile
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
            System.Windows.Forms.Button btnSave;
            this.dgvLabList = new System.Windows.Forms.DataGridView();
            this.btnPrev = new System.Windows.Forms.Button();
            this.gbLabInfo = new System.Windows.Forms.GroupBox();
            this.chkIsEnabled = new System.Windows.Forms.CheckBox();
            this.lblIsEnabled = new System.Windows.Forms.Label();
            this.dtpOpenEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpOpenStart = new System.Windows.Forms.DateTimePicker();
            this.lblOpenEnd = new System.Windows.Forms.Label();
            this.lblOpenStart = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtDeviceList = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblDevices = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabList)).BeginInit();
            this.gbLabInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = System.Drawing.Color.Yellow;
            btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSave.Location = new System.Drawing.Point(944, 217);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(145, 54);
            btnSave.TabIndex = 10;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvLabList
            // 
            this.dgvLabList.BackgroundColor = System.Drawing.Color.White;
            this.dgvLabList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLabList.Location = new System.Drawing.Point(41, 54);
            this.dgvLabList.Name = "dgvLabList";
            this.dgvLabList.RowHeadersWidth = 62;
            this.dgvLabList.RowTemplate.Height = 30;
            this.dgvLabList.Size = new System.Drawing.Size(1438, 473);
            this.dgvLabList.TabIndex = 0;
            this.dgvLabList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLabList_CellContentClick);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Yellow;
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPrev.Location = new System.Drawing.Point(256, 550);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(176, 46);
            this.btnPrev.TabIndex = 1;
            this.btnPrev.Text = "上一页";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // gbLabInfo
            // 
            this.gbLabInfo.BackColor = System.Drawing.Color.PeachPuff;
            this.gbLabInfo.Controls.Add(this.chkIsEnabled);
            this.gbLabInfo.Controls.Add(this.lblIsEnabled);
            this.gbLabInfo.Controls.Add(this.dtpOpenEnd);
            this.gbLabInfo.Controls.Add(this.dtpOpenStart);
            this.gbLabInfo.Controls.Add(this.lblOpenEnd);
            this.gbLabInfo.Controls.Add(this.lblOpenStart);
            this.gbLabInfo.Controls.Add(this.btnReset);
            this.gbLabInfo.Controls.Add(this.btnDelete);
            this.gbLabInfo.Controls.Add(btnSave);
            this.gbLabInfo.Controls.Add(this.txtDeviceList);
            this.gbLabInfo.Controls.Add(this.txtArea);
            this.gbLabInfo.Controls.Add(this.txtLocation);
            this.gbLabInfo.Controls.Add(this.txtName);
            this.gbLabInfo.Controls.Add(this.txtId);
            this.gbLabInfo.Controls.Add(this.lblDevices);
            this.gbLabInfo.Controls.Add(this.lblArea);
            this.gbLabInfo.Controls.Add(this.lblLocation);
            this.gbLabInfo.Controls.Add(this.lblName);
            this.gbLabInfo.Controls.Add(this.lblId);
            this.gbLabInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbLabInfo.Location = new System.Drawing.Point(139, 626);
            this.gbLabInfo.Name = "gbLabInfo";
            this.gbLabInfo.Size = new System.Drawing.Size(1198, 321);
            this.gbLabInfo.TabIndex = 2;
            this.gbLabInfo.TabStop = false;
            this.gbLabInfo.Text = "实验室信息";
            // 
            // chkIsEnabled
            // 
            this.chkIsEnabled.AutoSize = true;
            this.chkIsEnabled.Location = new System.Drawing.Point(520, 236);
            this.chkIsEnabled.Name = "chkIsEnabled";
            this.chkIsEnabled.Size = new System.Drawing.Size(88, 35);
            this.chkIsEnabled.TabIndex = 18;
            this.chkIsEnabled.Text = "勾选";
            this.chkIsEnabled.UseVisualStyleBackColor = true;
            // 
            // lblIsEnabled
            // 
            this.lblIsEnabled.AutoSize = true;
            this.lblIsEnabled.Location = new System.Drawing.Point(398, 236);
            this.lblIsEnabled.Name = "lblIsEnabled";
            this.lblIsEnabled.Size = new System.Drawing.Size(110, 31);
            this.lblIsEnabled.TabIndex = 17;
            this.lblIsEnabled.Text = "是否启用";
            // 
            // dtpOpenEnd
            // 
            this.dtpOpenEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpOpenEnd.Location = new System.Drawing.Point(520, 110);
            this.dtpOpenEnd.Name = "dtpOpenEnd";
            this.dtpOpenEnd.Size = new System.Drawing.Size(200, 39);
            this.dtpOpenEnd.TabIndex = 16;
            // 
            // dtpOpenStart
            // 
            this.dtpOpenStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpOpenStart.Location = new System.Drawing.Point(520, 47);
            this.dtpOpenStart.Name = "dtpOpenStart";
            this.dtpOpenStart.Size = new System.Drawing.Size(200, 39);
            this.dtpOpenStart.TabIndex = 15;
            // 
            // lblOpenEnd
            // 
            this.lblOpenEnd.AutoSize = true;
            this.lblOpenEnd.Location = new System.Drawing.Point(396, 110);
            this.lblOpenEnd.Name = "lblOpenEnd";
            this.lblOpenEnd.Size = new System.Drawing.Size(110, 31);
            this.lblOpenEnd.TabIndex = 14;
            this.lblOpenEnd.Text = "关闭时间";
            // 
            // lblOpenStart
            // 
            this.lblOpenStart.AutoSize = true;
            this.lblOpenStart.Location = new System.Drawing.Point(393, 47);
            this.lblOpenStart.Name = "lblOpenStart";
            this.lblOpenStart.Size = new System.Drawing.Size(110, 31);
            this.lblOpenStart.TabIndex = 13;
            this.lblOpenStart.Text = "开放时间";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.Yellow;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Location = new System.Drawing.Point(944, 128);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(145, 57);
            this.btnReset.TabIndex = 12;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Yellow;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(944, 34);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(145, 63);
            this.btnDelete.TabIndex = 11;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtDeviceList
            // 
            this.txtDeviceList.Location = new System.Drawing.Point(181, 228);
            this.txtDeviceList.Name = "txtDeviceList";
            this.txtDeviceList.Size = new System.Drawing.Size(192, 39);
            this.txtDeviceList.TabIndex = 9;
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(520, 170);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(200, 39);
            this.txtArea.TabIndex = 8;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(181, 166);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(192, 39);
            this.txtLocation.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(181, 110);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(192, 39);
            this.txtName.TabIndex = 6;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(181, 47);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(192, 39);
            this.txtId.TabIndex = 5;
            // 
            // lblDevices
            // 
            this.lblDevices.AutoSize = true;
            this.lblDevices.Location = new System.Drawing.Point(45, 236);
            this.lblDevices.Name = "lblDevices";
            this.lblDevices.Size = new System.Drawing.Size(110, 31);
            this.lblDevices.TabIndex = 4;
            this.lblDevices.Text = "设备清单";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(398, 166);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(86, 31);
            this.lblArea.TabIndex = 3;
            this.lblArea.Text = "面积：";
            this.lblArea.Click += new System.EventHandler(this.lblArea_Click);
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(42, 170);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(86, 31);
            this.lblLocation.TabIndex = 2;
            this.lblLocation.Text = "位置：";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(45, 110);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(86, 31);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "名称：";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(42, 50);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(109, 31);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "实验室id";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Yellow;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.Location = new System.Drawing.Point(884, 550);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(176, 46);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "下一页";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPageInfo.Location = new System.Drawing.Point(629, 558);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(55, 31);
            this.lblPageInfo.TabIndex = 4;
            this.lblPageInfo.Text = "1/1";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalCount.Location = new System.Drawing.Point(1207, 558);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(155, 31);
            this.lblTotalCount.TabIndex = 5;
            this.lblTotalCount.Text = "共100条数据";
            // 
            // UC_LabFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.Controls.Add(this.lblTotalCount);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.gbLabInfo);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.dgvLabList);
            this.Name = "UC_LabFile";
            this.Size = new System.Drawing.Size(1621, 1062);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabList)).EndInit();
            this.gbLabInfo.ResumeLayout(false);
            this.gbLabInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLabList;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.GroupBox gbLabInfo;
        private System.Windows.Forms.Label lblDevices;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtDeviceList;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DateTimePicker dtpOpenEnd;
        private System.Windows.Forms.DateTimePicker dtpOpenStart;
        private System.Windows.Forms.Label lblOpenEnd;
        private System.Windows.Forms.Label lblOpenStart;
        private System.Windows.Forms.CheckBox chkIsEnabled;
        private System.Windows.Forms.Label lblIsEnabled;
    }
}
