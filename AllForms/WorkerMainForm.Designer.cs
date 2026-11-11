namespace LabReservationApp
{
    partial class WorkerMainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("个人信息");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("维护工单列表");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("设备状态统计");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("维护管理", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.panelRigt = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.treeView2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panelRigt);
            this.splitContainer2.Size = new System.Drawing.Size(1151, 581);
            this.splitContainer2.SplitterDistance = 383;
            this.splitContainer2.TabIndex = 0;
            // 
            // treeView2
            // 
            this.treeView2.BackColor = System.Drawing.Color.LightPink;
            this.treeView2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView2.ItemHeight = 100;
            this.treeView2.Location = new System.Drawing.Point(0, 0);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "";
            treeNode1.Text = "个人信息";
            treeNode2.Name = "";
            treeNode2.Text = "维护工单列表";
            treeNode3.Name = "";
            treeNode3.Text = "设备状态统计";
            treeNode4.Name = "";
            treeNode4.Text = "维护管理";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4});
            this.treeView2.Size = new System.Drawing.Size(380, 581);
            this.treeView2.TabIndex = 0;
            this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
            // 
            // panelRigt
            // 
            this.panelRigt.Location = new System.Drawing.Point(-1, 0);
            this.panelRigt.Name = "panelRigt";
            this.panelRigt.Size = new System.Drawing.Size(765, 581);
            this.panelRigt.TabIndex = 0;
            this.panelRigt.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRigt_Paint);
            // 
            // WorkerMainForm
            // 
            this.ClientSize = new System.Drawing.Size(1151, 581);
            this.Controls.Add(this.splitContainer2);
            this.Name = "WorkerMainForm";
            this.Text = "维护人员";
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView treeView2;
        private System.Windows.Forms.Panel panelRigt;
    }
}