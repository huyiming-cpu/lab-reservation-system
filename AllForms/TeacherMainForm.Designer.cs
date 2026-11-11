namespace LabReservationApp
{
    partial class TeacherMainForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("实验室预约");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("我的预约");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("我的信息");
            this.treeViewNav = new System.Windows.Forms.TreeView();
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeViewNav
            // 
            this.treeViewNav.BackColor = System.Drawing.Color.PaleTurquoise;
            this.treeViewNav.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewNav.ItemHeight = 150;
            this.treeViewNav.Location = new System.Drawing.Point(12, 40);
            this.treeViewNav.Name = "treeViewNav";
            treeNode1.BackColor = System.Drawing.Color.PaleTurquoise;
            treeNode1.Name = "节点0";
            treeNode1.Text = "实验室预约";
            treeNode2.BackColor = System.Drawing.Color.PaleTurquoise;
            treeNode2.Name = "节点1";
            treeNode2.Text = "我的预约";
            treeNode3.BackColor = System.Drawing.Color.PaleTurquoise;
            treeNode3.Name = "节点2";
            treeNode3.Text = "我的信息";
            this.treeViewNav.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeViewNav.Size = new System.Drawing.Size(422, 725);
            this.treeViewNav.TabIndex = 0;
            this.treeViewNav.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewNav_AfterSelect);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(482, 40);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1592, 913);
            this.panelMain.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogout.Location = new System.Drawing.Point(92, 807);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(258, 84);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "退出登录";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // TeacherMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(2120, 1013);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.treeViewNav);
            this.Name = "TeacherMainForm";
            this.Text = "登录--教师";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewNav;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnLogout;
    }
}