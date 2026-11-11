using System;
using System.Windows.Forms;
using LabReservationApp.Entity;
using LabManagementSystem.Service;

namespace LabReservationApp
{
    public partial class UC_TeacherProfile : UserControl
    {
        private UserService _userService = new UserService();
        private User _currentUser; 
        public UC_TeacherProfile()
        {
            InitializeComponent();
            LoadCurrentUserInfo();
        }

      
        private void LoadCurrentUserInfo()
        {
            try
            {
                long currentUserId = 2; 
                _currentUser = _userService.GetUserById(currentUserId);

                if (_currentUser != null)
                {
                    txtMyId.Text = _currentUser.Id.ToString();
                    txtUsername.Text = _currentUser.Username;
                    txtRealName.Text = _currentUser.RealName;
                    txtPassword.Text = _currentUser.Password;
                    txtEmail.Text = _currentUser.Email;
                    txtPhone.Text = _currentUser.Phone;
                }
                else
                {
                    MessageBox.Show("未找到当前用户信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载用户信息失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                
                _currentUser.Username = txtUsername.Text.Trim();
                _currentUser.RealName = txtRealName.Text.Trim();
                _currentUser.Password = txtPassword.Text.Trim();
                _currentUser.Email = txtEmail.Text.Trim();
                _currentUser.Phone = txtPhone.Text.Trim();

              
                bool success = _userService.SaveUser(_currentUser);

                if (success)
                {
                    MessageBox.Show("信息修改成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("修改失败，请重试", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"修改失败：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UC_TeacherProfile_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
