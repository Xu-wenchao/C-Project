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
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
            //timer1.Interval = 3000;
            //timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Welcome_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }
    }
}
