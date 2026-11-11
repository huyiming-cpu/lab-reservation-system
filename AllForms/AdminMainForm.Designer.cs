namespace LabReservationApp
{
    partial class AdminMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("实验室档案");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("设备管理");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("开放时间设置");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("预约审批");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("实验室管理", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("实验室利用率");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("设备故障率");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("统计分析", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25});
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("用户管理");
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvMenu
            // 
            this.tvMenu.BackColor = System.Drawing.Color.Moccasin;
            this.tvMenu.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvMenu.ItemHeight = 100;
            this.tvMenu.Location = new System.Drawing.Point(3, 87);
            this.tvMenu.Name = "tvMenu";
            treeNode19.Name = "节点1";
            treeNode19.Text = "实验室档案";
            treeNode20.Name = "节点2";
            treeNode20.Text = "设备管理";
            treeNode21.Name = "节点3";
            treeNode21.Text = "开放时间设置";
            treeNode22.Name = "节点4";
            treeNode22.Text = "预约审批";
            treeNode23.Name = "节点0";
            treeNode23.Text = "实验室管理";
            treeNode24.Name = "节点9";
            treeNode24.Text = "实验室利用率";
            treeNode25.Name = "节点10";
            treeNode25.Text = "设备故障率";
            treeNode26.Name = "节点8";
            treeNode26.Text = "统计分析";
            treeNode27.Name = "节点0";
            treeNode27.Text = "用户管理";
            this.tvMenu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode26,
            treeNode27});
            this.tvMenu.Size = new System.Drawing.Size(375, 592);
            this.tvMenu.TabIndex = 0;
            this.tvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterSelect);
            // 
            // pnlContent
            // 
            this.pnlContent.Location = new System.Drawing.Point(384, 12);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1621, 1062);
            this.pnlContent.TabIndex = 1;
            // 
            // btnExit
            // 
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.BackColor = System.Drawing.Color.Yellow;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.Location = new System.Drawing.Point(45, 727);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(214, 70);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "退出登录";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(2017, 1080);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tvMenu);
            this.Name = "AdminMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "管理员";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Button btnExit;
    }
}