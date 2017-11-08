using SanCeng.BLL;
using SanCeng.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SanCeng.Winform2
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            /*
            string userName = txtUserName.Text;
            string password = txtPwd.Text;
            User u = new UserBLL().GetByUserName(userName);
            if(u==null)
            {
                MessageBox.Show("用户名不存在！");
            }
            else if(u.Password==password)
            //else if(u.Password.Equals(password,StringComparison.OrdinalIgnoreCase))
            {
                new LogBLL().Add(u.Id,u.UserName+"登录系统");
                this.Close();
            }
            else
            {
                MessageBox.Show("密码错误");
            }*/
            string userName = txtUserName.Text;
            string password = txtPwd.Text;
            if(string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("用户名不能为空");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("密码不能为空");
                return;
            }
            LoginResult result = new UserBLL().Login(userName, password);
            if(result== LoginResult.OK)
            {
                this.Close();
            }
            else if(result== LoginResult.PasswordError)
            {
                this.labelPwdError.Visible = true;
                //MessageBox.Show("密码错误");
            }
            else if(result== LoginResult.UserNameNotFound)
            {
                MessageBox.Show("用户名不存在");
            }
            else
            {
                MessageBox.Show("未知的状态");
            }
        }
    }
}
