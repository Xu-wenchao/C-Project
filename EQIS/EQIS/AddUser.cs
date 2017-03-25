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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            if(services.UserIsExisted(textBox_name.Text))
            {
                MessageBox.Show("该用户名已存在！", "提示");
            }
            else if(textBox_password.Text.Trim().Equals(""))
            {
                MessageBox.Show("密码不能为空！", "提示");
            }
            else
            {
                if(services.addUser(textBox_name.Text, textBox_password.Text))
                {
                    MessageBox.Show("用户添加成功！","提示");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("用户添加失败！", "提示");
                }
            }
        }
    }
}
