using System;
using System.Diagnostics;
using System.Windows.Forms;
using LabReservationApp.UC_Teacher;

namespace LabReservationApp
{
    public partial class TeacherMainForm : Form
    {
        private Control currentControl;
       
        private long _teacherId;

        public TeacherMainForm(long teacherId)
        {
            InitializeComponent();
            _teacherId = teacherId;
            //传递id
          // var labUC = new UC_TeacherLabReservation(_teacherId);
           // panelMain.Controls.Add(labUC);
            InitMenuTree();
            LoadUserControl<UC_TeacherLabReservation>(_teacherId);
            
        }

        private void InitMenuTree()
        {
            treeViewNav.Nodes.Clear();

            // 添加节点
            treeViewNav.Nodes.Add("实验室预约");
            treeViewNav.Nodes.Add("我的预约");
            treeViewNav.Nodes.Add("我的信息");

            // 绑定事件（关键！）
            treeViewNav.AfterSelect += treeViewNav_AfterSelect;
           
        
       
        }



         private void LoadUserControl<T>(params object[] args) where T : UserControl, new()
          {
              try
              {
                if (currentControl != null)
                {
                    panelMain.Controls.Remove(currentControl); // 从容器中移除
                    currentControl.Dispose(); // 释放资源
                    currentControl = null; // 清空引用
                }

                // T userControl = new T();
                T userControl = (T)Activator.CreateInstance(typeof(T), args);
                userControl.Dock = DockStyle.Fill;
                  panelMain.Controls.Add(userControl);
                  currentControl = userControl;

                  Debug.WriteLine($"成功加载控件: {typeof(T).FullName}");
              }
              catch (Exception ex)
              {
                  Debug.WriteLine($"加载控件失败: {typeof(T).FullName}, 错误: {ex.Message}");
                  MessageBox.Show($"加载失败: {ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }
          }
       

        private void btnLogout_Click(object sender, EventArgs e)
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

        private void treeViewNav_AfterSelect(object sender, TreeViewEventArgs e)
        {
             

            // 清理旧控件
            if (currentControl != null)
            {
                panelMain.Controls.Remove(currentControl);
                currentControl.Dispose();
                currentControl = null;
            }

            // 根据节点加载控件
            switch (e.Node.Text)
            {
                case "实验室预约":
                    Debug.WriteLine("尝试加载 UC_TeacherLabReservation");
                    LoadUserControl<UC_TeacherLabReservation>(_teacherId);
                    break;
                case "我的预约":
                    Debug.WriteLine("尝试加载 UC_TeacherMyReservations");
                    LoadUserControl<UC_TeacherMyReservations>();
                    break;

                case "我的信息":
                    Debug.WriteLine("尝试加载 UC_TeacherProfile");
                    LoadUserControl<UC_TeacherProfile>();
                    break;
                default:
                    Debug.WriteLine($"未知节点: {e.Node.Text}");
                    break;
            }
        }
    
    }
}