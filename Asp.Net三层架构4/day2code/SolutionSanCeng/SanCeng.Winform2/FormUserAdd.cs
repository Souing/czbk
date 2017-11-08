using SanCeng.BLL;
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
    public partial class FormUserAdd : Form
    {
        private UserBLL userBll = new UserBLL();
        public FormUserAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //todo:判断字段不能为空
            string username = txtUserName.Text;
            string password = txtPwd.Text;
            string phoneNum = txtPhoneNum.Text;
            int age = Convert.ToInt32(txtAge.Text);
            bool exists;
            userBll.Add2(username, password, phoneNum, age, out exists);
            if(exists)
            {
                MessageBox.Show("用户名已经存在");
            }
            else
            {
                this.Close();//窗口关闭
            }
            //userBll.Add(username, password, phoneNum, age);            
        }
    }
}
