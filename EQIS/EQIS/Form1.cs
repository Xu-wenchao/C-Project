using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EQIS
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //登录
        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> dir = new Services().login(username.Text, password.Text);
            if (dir != null)
            {
                this.Hide();
                if(dir["chara"].Equals("0"))
                {
                    AdminForm adminForm = new AdminForm(dir);
                    adminForm.ShowDialog();
                }
                else
                {
                    SysForm sysForm = new SysForm(dir);
                    sysForm.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名或者密码错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
