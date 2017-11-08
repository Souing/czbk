using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormTest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
           
            InitializeComponent();
            button1.Text = "hello";
            /*
            string s = null;
            s.ToString();
            MessageBox.Show("1111111111");*/
            dataGridView1.AutoGenerateColumns = false;

            List<Person> list = new List<Person>();
            list.Add(new Person(1,"tom",3));
            list.Add(new Person(2, "jerry", 2));
            list.Add(new Person(3, "熊大", 12));

            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            string s = null;
            s.ToString();
            MessageBox.Show("1111111111");*/
            FormAbout f = new FormAbout();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // MessageBox.Show("hello");
            //afdasdfadsfasfadsf
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我被点了");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Checked)
            { 
            MessageBox.Show(dateTimePicker1.Value.ToString());
            }
            else
            {
                MessageBox.Show("我不想买");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           if( dataGridView1.SelectedRows.Count<=0)
           {
               MessageBox.Show("没有任何行被选中");
           }
           else
           {
               //dataGridView1.SelectedRows[0].DataBoundItem获得选中行所绑定的对象
               Person p = (Person)dataGridView1.SelectedRows[0].DataBoundItem;
               MessageBox.Show(p.Id+","+p.Name);
           }
        }
    }
}
