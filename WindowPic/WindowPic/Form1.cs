using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowPic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = Properties.Resources.figure_2_1.Width;
            this.Height = Properties.Resources.figure_2_1.Height;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            this.ShowInTaskbar = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.figure_2_1, new Point(0, 0));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show(e.Location.ToString());
            //getPathByPos(e.X, e.Y, e.X + )
        }

        private string getPathByPos(int x, int y, int m, int n)
        {
            if (x > 24 && x < 24 && y > 0 && y < 0 && m > 483 && m < 483 && n > 47 && n < 47) 
            {
                //vs2013
                MessageBox.Show("vs2013");
            }
            if (x > 0 && x < 0 && y > 73 && y < 73 && m > 41 && m < 41 && n > 95 && n < 95) 
            {
                //迅雷
                MessageBox.Show("迅雷");
            }
            if (x > 124 && x < 124 && y > 50 && y < 50 && m > 204 && m < 204 && n > 63 && n < 63) 
            {
                //codeblocks
                MessageBox.Show("codeblocks");
            }
            if (x > 211 && x < 211 && y > 47 && y < 47 && m > 259 && m < 259 && n > 62 && n < 62) 
            {
                //爱奇艺
                MessageBox.Show("爱奇艺");
            }
            if (x > 275 && x < 275 && y > 47 && y < 47 && m > 363 && m < 363 && n > 65 && n < 65) 
            {
                //阿里旺旺
                MessageBox.Show("阿里旺旺");
            }
            if (x > 372 && x < 372 && y > 47 && y < 47 && m > 483 && m < 483 && n > 63 && n < 63) 
            {
                //PowerDesigner
                MessageBox.Show("PowerDesigner");
            }
            if (x > 557 && x < 557 && y > 34 && y < 34 && m > 581 && m < 581 && n > 205 && n < 205) 
            {
                //MySqlCmmand
                MessageBox.Show("MySqlCommand");
            }
            if (x > 508 && x < 508 && y > 0 && y < 0 && m > 543 && m < 543 && n > 183 && n < 183)
            {
                //MySqlClient
                MessageBox.Show("MySqlClient");
            }
            if (x > 352 && x < 352 && y > 113 && y < 113 && m > 488 && m < 488 && n > 125 && n < 125) 
            {
                //VMware
                MessageBox.Show("VMware");
            }
            if (x > 325 && x < 325 && y > 137 && y < 137 && m > 494 && m < 494 && n > 171 && n < 171) 
            {
                //有道
                MessageBox.Show("有道");
            }
            if (x > 12 && x < 12 && y > 168 && y < 168 && m > 135 && m < 135 && n > 205 && n < 205) 
            {
                //qq
                MessageBox.Show("qq");
            }
            if (x > 135 && x < 135 && y > 168 && y < 168 && m > 315 && m < 315 && n > 187 && n < 187)
            {
                //VSC
                MessageBox.Show("VSC");
            }
            if (x > 381 && x < 381 && y > 177 && y < 177 && m > 448 && m < 448 && n > 205 && n < 205) 
            {
                //酷狗
                MessageBox.Show("酷狗");
            }
            if (x > 459 && x < 459 && y > 177 && y < 177 && m > 480 && m < 480 && n > 258 && n < 258) 
            {
                //百度云
                MessageBox.Show("百度云");
            }
            if (x > 54 && x < 54 && y > 205 && y < 205 && m > 135 && m < 135 && n > 221 && n < 221) 
            {
                //谷歌
                MessageBox.Show("谷歌");
            }
            if (x > 10 && x < 10 && y > 221 && y < 221 && m > 41 && m < 41 && n > 233 && n < 233)
            {
                //sublimetext
                MessageBox.Show("sublimetext");
            }
            if (x > 147 && x < 147 && y > 197 && y < 197 && m > 372 && m < 372 && n > 240 && n < 240) 
            {
                //Hbuilder
                MessageBox.Show("Hbuilder");
            }
            if (x > 505 && x < 505 && y > 214 && y < 214 && m > 581 && m < 581 && n > 247 && n < 247)
            {
                //idea 
                MessageBox.Show("idea");
            }
            if (x > 537 && x < 537 && y > 247 && y < 247 && m > 581 && m < 581 && n > 270 && n < 270)
            {
                //weixin
                MessageBox.Show("微信");
            }
            if (x > 128 && x < 128 && y > 243 && y < 243 && m > 408 && m < 408 && n > 277 && n < 277)
            {
                //AS
                MessageBox.Show("AS");
            }
            if (x > 38 && x < 38 && y > 263 && y < 263 && m > 121 && m < 121 && n > 276 && n < 276) 
            {
                //notepad
                MessageBox.Show("NotePad++");
            }
            if (x > 52 && x < 52 && y > 233 && y < 233 && m > 132 && m < 132 && n > 249 && n < 249) 
            {
                //fiddler4
                MessageBox.Show("fiddler4");
            }
            if (x > 71 && x < 71 && y > 71 && y < 71 && m > 459 && m < 459 && n > 113 && n < 113) 
            {
                //PS\
                MessageBox.Show("PS");                
            }
            if (x > 15 && x < 15 && y > 114 && y < 114 && m > 307 && m < 307 && n > 168 && n < 168) 
            {
                //FireFox
                MessageBox.Show("FireFox");
            }
            if (x > 378 && x < 378 && y > 215 && y < 215 && m > 439 && m < 439 && n > 230 && n < 230) 
            {
                //pychorm
                MessageBox.Show("pychorm");
            }
            return "";
        }

    }
}
