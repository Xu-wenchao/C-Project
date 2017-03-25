using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearnSerialPort
{
    partial class LocalPage : Form
    {
        private LocationData ld;
        public LocalPage(LocationData ld)
        {
            InitializeComponent();
            this.ld = ld;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //确定
            if(!textBox1.Text.Equals(""))
            {
                ld.Sdt = DateTime.Now;
                ld.Local = textBox1.Text.Trim();
                ld.IsValid = true;
            }
            this.Close();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //直接监测
            this.Close();
        }
    }
}
