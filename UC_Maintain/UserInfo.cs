using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabReservationApp.UC_Maintain
{
    public partial class UserInfo : UserControl
    {
        private readonly long userId;
        private const string ConnectionString = "server=140.143.121.118;user=labapp;password=Lab@123456;database=lab_reservation_system;port=3306";

        // 添加编辑状态标志
        private bool isEditing = false;
        // 添加文本框引用
        private TextBox txtUsernameValue;
        private TextBox txtRealNameValue;
        private TextBox txtPhoneValue;
        private TextBox txtEmailValue;
        // 添加保存和取消按钮
        private Button btnEditSave;
        private Button btnCancel;

        public UserInfo(long userId)
        {
            InitializeComponent();
            this.userId = userId;
            InitializeUI();
            LoadUserData();
        }

        private void InitializeUI()
        {
            // 设置用户控件背景
            this.BackColor = Color.Pink;
            this.Padding = new Padding(20, 20, 20, 20);
            this.AutoScroll = true;

            // 标题标签
            var lblTitle = new Label
            {
                Text = "个人信息",
                Font = new Font("微软雅黑", 18, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true,
                ForeColor = Color.DarkSlateBlue
            };

            // 信息显示表格布局
            var tableLayout = new TableLayoutPanel
            {
                ColumnCount = 2,
                RowCount = 4,
                Location = new Point(30, 70),
                Size = new Size(500, 280),  // 增大整体尺寸
                CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                AutoSize = true
            };
            // 设置列宽
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); // 标签列
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));  // 值列

            // 设置行高
            for (int i = 0; i < tableLayout.RowCount; i++)
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60)); // 每行高度60px
            }

            // 添加标签和值控件
            AddInfoRow(tableLayout, 0, "用户名:", "lblUsernameValue");
            AddInfoRow(tableLayout, 1, "真实姓名:", "lblRealNameValue");
            AddInfoRow(tableLayout, 2, "电话:", "lblPhoneValue");
            AddInfoRow(tableLayout, 3, "邮箱:", "lblEmailValue");

            // 按钮面板 - 使按钮水平居中
            var buttonPanel = new Panel
            {
                Location = new Point(30, 370),
                Size = new Size(500, 60),
                BackColor = Color.Transparent
            };

            // 编辑/保存按钮
            btnEditSave = new Button
            {
                Text = "编辑信息",
                Font = new Font("微软雅黑", 12, FontStyle.Bold),
                Size = new Size(150, 40),
                Location = new Point(80, 400),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnEditSave.Click += BtnEditSave_Click;

            // 取消按钮 (初始隐藏)
            btnCancel = new Button
            {
                Text = "取消",
                Font = new Font("微软雅黑", 12, FontStyle.Bold),
                Size = new Size(150, 40),
                Location = new Point(270, 400),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Visible = false
            };
            btnCancel.Click += BtnCancel_Click;

            buttonPanel.Controls.Add(btnEditSave);
            buttonPanel.Controls.Add(btnCancel);

            this.Controls.Add(lblTitle);
            this.Controls.Add(tableLayout);
            this.Controls.Add(btnEditSave);
            this.Controls.Add(btnCancel);
        }

        private void AddInfoRow(TableLayoutPanel table, int row, string labelText, string valueName)
        {
            // 标签 - 增大字体和右边距
            var lbl = new Label
            {
                Text = labelText,
                Font = new Font("微软雅黑", 12, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 20, 0),
                ForeColor = Color.DimGray
            };

            // 值显示框 - 增大字体和内边距
            var value = new Label
            {
                Name = valueName,
                Font = new Font("微软雅黑", 12),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.WhiteSmoke,
                Padding = new Padding(10, 5, 10, 5),
                Margin = new Padding(0)
            };

            table.Controls.Add(lbl, 0, row);
            table.Controls.Add(value, 1, row);
        }

        private void LoadUserData()
        {
            try
            {
                string sql = "SELECT username, real_name, phone, email FROM user WHERE id = @userId";

                using (var conn = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // 安全设置控件值
                            SetControlText("lblUsernameValue", reader["username"].ToString());
                            SetControlText("lblRealNameValue", reader["real_name"].ToString());
                            SetControlText("lblPhoneValue",
                                reader.IsDBNull(reader.GetOrdinal("phone")) ? "未设置" : reader["phone"].ToString());
                            SetControlText("lblEmailValue",
                                reader.IsDBNull(reader.GetOrdinal("email")) ? "未设置" : reader["email"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载用户信息失败: {ex.Message}");
            }
        }

        private void SetControlText(string controlName, string text)
        {
            var control = this.Controls.Find(controlName, true);
            if (control.Length > 0 && control[0] is Label lbl)
            {
                lbl.Text = text;
            }
        }

        private void BtnEditSave_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // 进入编辑模式
                EnterEditMode();
            }
            else
            {
                // 保存修改
                SaveChanges();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // 取消编辑
            ExitEditMode();
        }

        private void EnterEditMode()
        {
            isEditing = true;
            btnEditSave.Text = "保存";
            btnCancel.Visible = true;

            // 获取当前显示的标签控件
            var lblUsername = this.Controls.Find("lblUsernameValue", true)[0] as Label;
            var lblRealName = this.Controls.Find("lblRealNameValue", true)[0] as Label;
            var lblPhone = this.Controls.Find("lblPhoneValue", true)[0] as Label;
            var lblEmail = this.Controls.Find("lblEmailValue", true)[0] as Label;

            // 获取父容器(TableLayoutPanel)
            var tableLayout = lblUsername.Parent as TableLayoutPanel;

            // 创建并替换为文本框
            txtUsernameValue = CreateEditTextBox(lblUsername.Text, lblUsername.Bounds);
            txtRealNameValue = CreateEditTextBox(lblRealName.Text, lblRealName.Bounds);
            txtPhoneValue = CreateEditTextBox(lblPhone.Text == "未设置" ? "" : lblPhone.Text, lblPhone.Bounds);
            txtEmailValue = CreateEditTextBox(lblEmail.Text == "未设置" ? "" : lblEmail.Text, lblEmail.Bounds);

            // 用户名不可编辑
            txtUsernameValue.ReadOnly = true;
            txtUsernameValue.BackColor = SystemColors.ControlLight;

            // 替换控件
            tableLayout.Controls.Remove(lblUsername);
            tableLayout.Controls.Remove(lblRealName);
            tableLayout.Controls.Remove(lblPhone);
            tableLayout.Controls.Remove(lblEmail);

            tableLayout.Controls.Add(txtUsernameValue, 1, 0);
            tableLayout.Controls.Add(txtRealNameValue, 1, 1);
            tableLayout.Controls.Add(txtPhoneValue, 1, 2);
            tableLayout.Controls.Add(txtEmailValue, 1, 3);
        }

        private TextBox CreateEditTextBox(string text, Rectangle bounds)
        {
            return new TextBox
            {
                Text = text,
                Font = new Font("微软雅黑", 12),
                BorderStyle = BorderStyle.FixedSingle,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                BackColor = Color.White,
                Multiline = true,  // 允许多行显示
                MinimumSize = new Size(0, 40)  // 设置最小高度
            };
        }

        private void ExitEditMode()
        {
            isEditing = false;
            btnEditSave.Text = "编辑信息";
            btnCancel.Visible = false;

            // 获取父容器(TableLayoutPanel)
            var tableLayout = txtUsernameValue.Parent as TableLayoutPanel;

            // 恢复标签显示
            var lblUsername = new Label
            {
                Name = "lblUsernameValue",
                Text = txtUsernameValue.Text,
                Font = new Font("微软雅黑", 12),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = SystemColors.ControlLight,
                Padding = new Padding(5),
                Margin = new Padding(0, 10, 0, 10)
            };

            var lblRealName = new Label
            {
                Name = "lblRealNameValue",
                Text = txtRealNameValue.Text,
                Font = new Font("微软雅黑", 12),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = SystemColors.ControlLight,
                Padding = new Padding(5),
                Margin = new Padding(0, 10, 0, 10)
            };

            var lblPhone = new Label
            {
                Name = "lblPhoneValue",
                Text = string.IsNullOrEmpty(txtPhoneValue.Text) ? "未设置" : txtPhoneValue.Text,
                Font = new Font("微软雅黑", 12),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = SystemColors.ControlLight,
                Padding = new Padding(5),
                Margin = new Padding(0, 10, 0, 10)
            };

            var lblEmail = new Label
            {
                Name = "lblEmailValue",
                Text = string.IsNullOrEmpty(txtEmailValue.Text) ? "未设置" : txtEmailValue.Text,
                Font = new Font("微软雅黑", 12),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = SystemColors.ControlLight,
                Padding = new Padding(5),
                Margin = new Padding(0, 10, 0, 10)
            };

            // 移除文本框
            tableLayout.Controls.Remove(txtUsernameValue);
            tableLayout.Controls.Remove(txtRealNameValue);
            tableLayout.Controls.Remove(txtPhoneValue);
            tableLayout.Controls.Remove(txtEmailValue);

            // 添加回标签
            tableLayout.Controls.Add(lblUsername, 1, 0);
            tableLayout.Controls.Add(lblRealName, 1, 1);
            tableLayout.Controls.Add(lblPhone, 1, 2);
            tableLayout.Controls.Add(lblEmail, 1, 3);
        }

        private void SaveChanges()
        {
            // 验证输入
            if (string.IsNullOrWhiteSpace(txtRealNameValue.Text))
            {
                MessageBox.Show("真实姓名不能为空");
                return;
            }

            try
            {
                string sql = @"UPDATE user SET 
                             real_name = @realName, 
                             phone = @phone, 
                             email = @email 
                             WHERE id = @userId";

                using (var conn = new MySqlConnection(ConnectionString))
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@realName", txtRealNameValue.Text.Trim());
                    cmd.Parameters.AddWithValue("@phone", string.IsNullOrWhiteSpace(txtPhoneValue.Text) ? (object)DBNull.Value : txtPhoneValue.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", string.IsNullOrWhiteSpace(txtEmailValue.Text) ? (object)DBNull.Value : txtEmailValue.Text.Trim());
                    cmd.Parameters.AddWithValue("@userId", userId);

                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("信息更新成功");
                        ExitEditMode();
                        LoadUserData(); // 重新加载数据确保显示最新
                    }
                    else
                    {
                        MessageBox.Show("信息更新失败");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存信息失败: {ex.Message}");
            }
        }
    }
}