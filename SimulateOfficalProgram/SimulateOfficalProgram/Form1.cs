using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulateOfficalProgram
{
    public partial class Form1 : Form
    {
        private int SMALLRECT_WIDTH = 100;
        private int SMALLRECT_HEIGHT = 50;
        private int BIGRECT_WIDTH = 174;
        private int BIGRECT_HEIGHT = 116;
        private Image[] imgArr;
        //起始x, y点
        private int ps_x = 200;
        private int ps_y = 200;
        //粗细分割线宽度
        private int thickDivLine = 50;
        private int thinDIvLine = 30;
        //密码个数
        private static int codeNum = 5;
        //密码区域
        private int[] codes;
        //九宫格区域
        private int[] sudokus;
        private HookTool hookTool = new HookTool();

        private Random rm;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;
            this.DoubleBuffered = true;
            hookTool.Hook_Start();
            imgArr = new Image[]{
                Properties.Resources._1,
                Properties.Resources._2,
                Properties.Resources._3,
                Properties.Resources._4,
                Properties.Resources._5,
                Properties.Resources._6,
                Properties.Resources._7,
                Properties.Resources._8,
                Properties.Resources._9
            };
            rm = new Random();
            getCodeRandom();
            getSudokuRandom();
        }
        //获取密码区的随机数 
        private void getCodeRandom()
        {
            codes = new int[codeNum];
            for (int i = 0; i < codeNum; i++)
            {
                codes[i] = rm.Next(1, 10);
            }
        }
        //获取九宫格的随机数
        private void getSudokuRandom()
        {
            HashSet<int> set = new HashSet<int>();
            int count = 0;
            while (true)
            {
                if (set.Add(rm.Next(1, 10))) ++count;
                if (set.Count() == 9) break;
            }
            sudokus = set.ToArray();
        }
        //小矩形
        private Rectangle smallRectangle(int x, int y)
        {
            return new Rectangle(x, y, SMALLRECT_WIDTH, SMALLRECT_HEIGHT);
        }
        //大矩形
        private Rectangle bigRectangle(int x, int y)
        {
            return new Rectangle(x, y, BIGRECT_WIDTH, BIGRECT_HEIGHT);
        }
        //大矩形
        private Rectangle bigRectangle(Point p)
        {
            return new Rectangle(p.X, p.Y, BIGRECT_WIDTH, BIGRECT_HEIGHT);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawAll(e);
        }

        private void drawAll(PaintEventArgs e)
        {
            Brush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(brush);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), ps_x - thinDIvLine, ps_y - thinDIvLine, 990, 480);
            //密码区
            for (int i = 0; i < codeNum; i++)
            {
                //e.Graphics.DrawImage(imgArr[codes[i] - 1], new Rectangle(350 + 40 * i, 90, 40, 80));
                //e.Graphics.DrawString(codes[i - 1], new Rectangle(350 + 40 * i, 90, 40, 80));
                e.Graphics.DrawString(codes[i].ToString(), new Font("黑体", 72), new SolidBrush(Color.Black), 
                    new Point(350 + 80 * i, 70));
            }
            for (int i = 0; i < 5; i++)
            {
                e.Graphics.FillRectangle(brush, smallRectangle(ps_x, ps_y + i * (SMALLRECT_HEIGHT + 40)));
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Point p = new Point(ps_x + thickDivLine + SMALLRECT_WIDTH + (BIGRECT_WIDTH + thickDivLine) * j,
                        ps_y + (BIGRECT_HEIGHT + thinDIvLine) * i);
                    e.Graphics.FillRectangle(brush, bigRectangle(p));
                    e.Graphics.DrawString(sudokus[j + i * 3].ToString(), new Font("黑体", 80),
                        new SolidBrush(Color.Black), p.X + BIGRECT_WIDTH / 4, p.Y);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                e.Graphics.FillRectangle(brush, smallRectangle(ps_x + SMALLRECT_WIDTH + BIGRECT_WIDTH * 3 + thickDivLine * 4,
                    ps_y + i * (SMALLRECT_HEIGHT + 40)));
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                getCodeRandom();
                getSudokuRandom();
                this.Invalidate();
            }
            else if (e.Control & e.KeyCode == Keys.Q) this.Close();
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5)
            {
                if (e.KeyCode == Keys.D1) codeNum = 1;
                else if (e.KeyCode == Keys.D2) codeNum = 2;
                else if (e.KeyCode == Keys.D3) codeNum = 3;
                else if (e.KeyCode == Keys.D4) codeNum = 4;
                else if (e.KeyCode == Keys.D5) codeNum = 5;
                getCodeRandom();
                getSudokuRandom();
                this.Invalidate();
            }
        }

    }

}
