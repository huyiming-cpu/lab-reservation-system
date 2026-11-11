using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LabReservationApp.UC_Maintain;

namespace LabReservationApp
{
    public partial class WorkerMainForm : Form
    {
        private readonly long userId;


        public WorkerMainForm(long userId)
        {
            InitializeComponent();
            this.userId = userId;
            treeView2.ExpandAll();
            this.Text = $"实验室维护系统 - 维护员({userId})";

            // 确保窗体布局完成后再添加按钮
            this.Load += (s, e) => AddLogoutButton();
        }
         private void AddLogoutButton()
        {
            Button btnLogout = new Button
            {
                Text = "退出登录",              
                Size = new Size(100, 30),
                Font = new Font("微软雅黑", 10),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat,
                Anchor = AnchorStyles.Top | AnchorStyles.Right  // 使按钮随窗体大小改变位置
            };
            // 计算按钮位置 - 底部中央
            btnLogout.Location = new Point(
                (this.ClientSize.Width - btnLogout.Width) / 2,  // 水平居中
                this.ClientSize.Height - btnLogout.Height - 20  // 底部上方20像素
            );

            // 设置Anchor属性使按钮随窗体大小调整位置
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLogout.Click += BtnLogout_Click;
            this.Controls.Add(btnLogout);
            btnLogout.BringToFront();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // 确认退出
            DialogResult result = MessageBox.Show("确定要退出登录吗？", "确认退出", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                // 关闭当前窗体
                this.Close();
                
                // 显示登录窗体
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (panelRigt == null || e.Node == null) return;

            panelRigt.Controls.Clear();

            switch (e.Node.Text)
            {
                case "个人信息":
                    var userInfoCtrl = new UserInfo(userId)
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(10)
                    };
                    panelRigt.Controls.Add(userInfoCtrl);
                    break; ;

                case "维护工单列表":
                    var planCtrl = new Maintenance();
                    planCtrl.Dock = DockStyle.Fill;
                    panelRigt.Controls.Add(planCtrl);
                    break;

                case "设备状态统计":
                    var statusCtrl = new EquipmentStatus();
                    statusCtrl.Dock = DockStyle.Fill;
                    panelRigt.Controls.Add(statusCtrl);
                    break;
            }
        }

        private void panelRigt_Paint(object sender, PaintEventArgs e)
        {
            // 绘制逻辑（如果需要）
        }
    }
}
