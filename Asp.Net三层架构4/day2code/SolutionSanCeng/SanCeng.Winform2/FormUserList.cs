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
    public partial class FormUserList : Form
    {
        private UserBLL userBll = new UserBLL();
        public FormUserList()
        {
            InitializeComponent();
            dataGridView1.DataSource = userBll.GetAll();
        }

        private void button4_Click(object sender, EventArgs e)
        {           
            dataGridView1.DataSource = userBll.GetAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count<=0)
            {
                MessageBox.Show("没有选中");
                return;
            }
            else
            {
                if(MessageBox.Show("确认删除？","询问",MessageBoxButtons.YesNo)!= 
                    System.Windows.Forms.DialogResult.Yes)
                {
                    return;
                }
                User user = (User)dataGridView1.SelectedRows[0].DataBoundItem;
                userBll.Delete(user.Id);
                dataGridView1.DataSource = userBll.GetAll();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormUserAdd f = new FormUserAdd();
            f.ShowDialog();
            dataGridView1.DataSource = userBll.GetAll();//刷新一下
        }
    }
}
