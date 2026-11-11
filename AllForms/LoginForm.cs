using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace LabReservationApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            // 初始化角色下拉框（按表结构映射：1-教师、2-管理员、3-维护员）
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[] { "教师", "管理员", "维护员" });
            cboRole.SelectedIndex = 0; // 默认选中教师
            this.KeyPreview = true;
            this.KeyDown += LoginForm_KeyDown;
        }
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // 当按下回车键时触发登录
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e); // 调用登录按钮的点击事件
                e.Handled = true; // 标记事件已处理，防止继续传播
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsername.Focus(); 
            txtPassword.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            cboRole.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. 获取输入值
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string roleText = cboRole.Text;

            // 2. 输入验证
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("请输入用户名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // 3. 转换角色为数字（严格与数据库role字段映射：1-教师、2-管理员、3-维护员）
            int role = 0;
            switch (roleText)
            {
                case "教师": role = 1; break;     // 教师对应 role=1
                case "管理员": role = 2; break;   // 管理员对应 role=2
                case "维护员": role = 3; break;   // 维护员对应 role=3
                default:
                    MessageBox.Show("请选择有效角色！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // 4. 数据库验证（改进：先查询用户信息，再比对密码哈希）
            try
            {
                // 查询用户基本信息（不直接比对密码，避免SQL注入）
                string sql = "SELECT id, username, password, role FROM user WHERE username = @username AND role = @role";

                DataSet ds = DB.MySqlUtil.ExecuteQueryDataSet(sql,
                    new MySqlParameter("@username", username),
                    new MySqlParameter("@role", role)
                );

                // 5. 登录结果判断
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow userRow = ds.Tables[0].Rows[0];
                    long userId = Convert.ToInt64(userRow["id"]);
                    string storedHashedPassword = userRow["password"].ToString();

                    // 比对密码（实际项目中应使用哈希比对，而非明文比较）
                    if (storedHashedPassword == password) // 生产环境需替换为哈希比对
                    {
                        // 根据角色跳转对应主窗体（注意角色值与窗体对应）
                        switch (role)
                        {
                            case 1: // 教师
                                new TeacherMainForm(2).Show();
                                break;
                            case 2: // 管理员
                                new AdminMainForm(userId).Show();
                                break;
                            case 3: // 维护员
                                new WorkerMainForm(userId).Show();
                                break;
                        }

                        this.Hide(); // 隐藏登录页
                    }
                    else
                    {
                        MessageBox.Show("密码错误！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("用户名或角色不存在！", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"登录异常：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}