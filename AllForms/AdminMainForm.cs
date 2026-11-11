using LabManagementSystem;
using LabReservationApp.UC_Admin;
using LabReservationApp.UC_Approval;
using System;
using System.Windows.Forms;
using YourProjectNamespace;

namespace LabReservationApp
{
    public partial class AdminMainForm : Form
    {
        private Control currentControl; // 记录当前显示的用户控件
        private long _adminId;          // 管理员用户ID

        // 构造函数，接收管理员ID
        public AdminMainForm(long adminId)
        {
            InitializeComponent();
            _adminId = adminId;
            // 初始化左侧菜单
            InitMenuTree();
            // 加载默认页面（可根据需求调整，比如首页）
            LoadUserControl<UC_Dashboard>();
        }

        // 初始化左侧TreeView菜单
        private void InitMenuTree()
        {
            tvMenu.Nodes.Clear(); // 清空原有节点

            // 1. 实验室管理节点
            TreeNode labManagementNode = new TreeNode("实验室管理");
            labManagementNode.Nodes.Add("实验室档案");
            labManagementNode.Nodes.Add("设备管理");
            labManagementNode.Nodes.Add("开放时间设置");
            labManagementNode.Nodes.Add("预约审批");

     

            // 3. 统计分析节点
            TreeNode statsNode = new TreeNode("统计分析");
            statsNode.Nodes.Add("实验室利用率");
            statsNode.Nodes.Add("设备故障率");

            // 4. 用户管理节点
            TreeNode userManagementNode = new TreeNode("用户管理");

            // 将节点添加到TreeView
            tvMenu.Nodes.Add(labManagementNode);
        
            tvMenu.Nodes.Add(statsNode);
            tvMenu.Nodes.Add(userManagementNode);

            // 绑定节点选择事件
            tvMenu.AfterSelect += tvMenu_AfterSelect;
        }

        // TreeView节点选择事件：加载对应用户控件
        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // 清理之前显示的控件
            if (currentControl != null)
            {
                pnlContent.Controls.Remove(currentControl);
                currentControl.Dispose();
                currentControl = null;
            }

            // 根据选中节点的Text加载对应控件
            switch (e.Node.Text)
            {
                // 实验室管理板块
                case "实验室档案":
                    LoadUserControl<UC_LabFile>();
                    break;
                case "设备管理":
                    LoadUserControl<UC_EquipmentManage>();
                    break;
                case "开放时间设置":
                    LoadUserControl<UC_LabOpenTimeSetting>();
                    break;
                case "预约审批":
                    LoadUserControl<UC_ReservationApproval>();
                    break;

         

                // 统计分析板块
                case "实验室利用率":
                    LoadUserControl<UC_LabUtilization>();
                    break;
                case "设备故障率":
                    LoadUserControl<UC_EquipmentFailureRate>();
                    break;

                // 用户管理板块
                case "用户管理":
                    LoadUserControl<UC_User>();
                    break;

                default:
                    break;
            }
        }

        // 通用加载用户控件方法
        private void LoadUserControl<T>() where T : UserControl, new()
        {
            T userControl = new T();
            userControl.Dock = DockStyle.Fill; // 让控件填满pnlContent
            pnlContent.Controls.Add(userControl);
            currentControl = userControl;
        }

        // 退出登录按钮事件（示例，可根据实际需求调整）
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出管理员登录吗？", "退出确认",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new LoginForm().Show(); // 打开登录窗体，实际可根据登录逻辑调整
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "确定要退出登录吗？",
               "退出确认",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           );

            if (result == DialogResult.Yes)
            {
                // 关闭当前窗体
                this.Close();

                // 显示登录窗体（确保登录窗体实例存在或重新创建）
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }
    }
}