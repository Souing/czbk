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

namespace SanCeng.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //UserBLL bll = new UserBLL();
            /*
            //UI调用BLL的Add，Bll的Add调用DAL的Add
            long id = bll.Add("yzk", "123", "18918918189", 33);
            MessageBox.Show(id.ToString());*/
            //bll.Delete(1);
            /*
            User u = bll.GetById(2);
            u.PhoneNum = "110";
            bll.Update(u);*/

            /*
            IEnumerable<User> users = bll.GetAll();
            dataGridView1.DataSource = users;*/

            LogBLL bll = new LogBLL();
            /*
            bll.Add(1, "测试了一下");
            bll.Add(1, "aaaa");
            bll.Add(2, "bbbbbb");*/
            //bll.Delete(1);

            /*
            Log log = bll.GetById(100);
            MessageBox.Show(log==null?"木有":"有");
            Log log2 = bll.GetById(3);
            MessageBox.Show(log2.Message);*/
            foreach (LogDTO log in bll.GetAll())
            {
                MessageBox.Show(log.Message);
            }

            /*
            User u = bll.GetById(3);
            if(u==null)
            {
                MessageBox.Show("木有");
            }
            else
            {
                MessageBox.Show(u.UserName);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            LogBLL bll = new LogBLL();
            /*
            IEnumerable<LogDTO> logs = bll.GetAll();
            dgv2.DataSource = logs;*/
            IEnumerable<LogDTO> logs = bll.Search("新增");
            dgv2.DataSource = logs;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserBLL bll = new UserBLL();
            User u =  bll.GetByUserName("yzk");
            MessageBox.Show(u.PhoneNum);
        }
    }
}
