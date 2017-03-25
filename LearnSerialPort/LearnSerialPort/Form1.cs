using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace LearnSerialPort
{
    partial class Form1 : Form
    {
        private FileStream fs;
        private BinaryFormatter bf;
        private int index = 0;
        private bool start;
        //临时时间变量，用于记录重复分钟
        private String tmpDt;
        private LocationData ld;
        public Form1()
        {
            InitializeComponent();
            Welcome w = new Welcome();
            w.ShowDialog();
            ld = new LocationData();
            LocalPage lp = new LocalPage(ld);
            lp.ShowDialog();
            Control.CheckForIllegalCrossThreadCalls = false;
            start = true;
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum = 500;
            this.chart2.ChartAreas[0].AxisY.Minimum = 0;
            this.chart2.ChartAreas[0].AxisY.Maximum = 100000;
            //打开并初始化端口
            serialPort1.PortName = "COM4";
            serialPort1.BaudRate = 9600;
            /*
             * FileMode.Append : 若存在文件，则打开该文件并查找到文件尾，或者创建一个新文件。
             */
            fs = new FileStream("save/" + DateTime.Now.ToString("yyyyMMdd") + ".bat", FileMode.Append, FileAccess.Write);
            bf = new BinaryFormatter();
            tmpDt = DateTime.Now.Minute.ToString();

            timer1.Start();
            try
            { 
                serialPort1.Open();
            }
            catch(Exception)
            {
                MessageBox.Show("端口没有打开！");
            }


        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            //uint date = (uint) this.serialPort1.ReadByte();
            byte[] buffer = new byte[32];
            int offset = 0;
            int count = 32;
            try
            {
                //从串口中获取数据
                this.serialPort1.Read(buffer, offset, count);
            }
            catch(Exception){ }

            ////解析从串口中获取的数据
            DataBits db = new DataBits(buffer);
            if (db.isValid())
            {
                setValueOfLab(db);
                setValueOfChart(DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString(), db);
                save(db);
            }
        }
        public void save(DataBits szDb)
        {
            //按分钟存储数据进文件中
            if (!tmpDt.Equals(DateTime.Now.Minute.ToString()))
            {
                tmpDt = DateTime.Now.Minute.ToString();
                //存储数据使用序列化打包MemoryCell存储
                bf.Serialize(fs, new MemoryCell(DateTime.Now, szDb));
            }
        }
        public void setValueOfLab(DataBits szDb)
        {
            if(labPM1_0CF1.InvokeRequired)
            {
                Action act = () => this.labPM1_0CF1.Text = szDb.M1_0CF1.ToString() + "ug/m3";
                labPM1_0CF1.BeginInvoke(act);
            }
            if (labPM2_5CF1.InvokeRequired)
            {
                Action act = () => this.labPM2_5CF1.Text = szDb.M2_5CF1.ToString() + "ug/m3";
                labPM2_5CF1.BeginInvoke(act);
            }
            if (labPM10CF1.InvokeRequired)
            {
                Action act = () => this.labPM10CF1.Text = szDb.M10CF1.ToString() + "ug/m3";
                labPM10CF1.BeginInvoke(act);
            }
            if (labPM1_0.InvokeRequired)
            {
                Action act = () => this.labPM1_0.Text = szDb.M1_0.ToString() + "ug/m3";
                labPM1_0.BeginInvoke(act);
            }
            if (labPM2_5.InvokeRequired)
            {
                Action act = () => this.labPM2_5.Text = szDb.M2_5.ToString() + "ug/m3";
                labPM2_5.BeginInvoke(act);
            }
            if (labPM10.InvokeRequired)
            {
                Action act = () => this.labPM10.Text = szDb.M10_0.ToString() + "ug/m3";
                labPM10.BeginInvoke(act);
            }
            if(labKL0_3.InvokeRequired)
            {
                Action act = () => this.labKL0_3.Text = szDb.P0_3.ToString() + "个";
                labKL0_3.BeginInvoke(act);
            }
            if(labKL0_5.InvokeRequired)
            {
                Action act = () => this.labKL0_5.Text = szDb.P0_5.ToString() + "个";
                labKL0_5.BeginInvoke(act);
            }
            if(labKL1_0.InvokeRequired)
            {
                Action act = () => this.labKL1_0.Text = szDb.P1_0.ToString() + "个";
                labKL1_0.BeginInvoke(act);
            }
            if(labKL2_5.InvokeRequired)
            {
                Action act = () => this.labKL2_5.Text = szDb.P2_5.ToString() + "个";
                labKL2_5.BeginInvoke(act);
            }
            if(labKL5_0.InvokeRequired)
            {
                Action act = () => this.labKL5_0.Text = szDb.P5_0.ToString() + "个";
                labKL5_0.BeginInvoke(act);
            }
            if(labKL10.InvokeRequired)
            {
                Action act = () => this.labKL10.Text = szDb.P10.ToString() + "个";
                labKL10.BeginInvoke(act);
            }
        }
        public void setValueOfChart(String szDt, DataBits szDb)
        {
            Console.WriteLine(index++);
            //为图表1数据赋值
            ////为图表2数据赋值

            if(chart1.InvokeRequired && chart2.InvokeRequired)
            {
                //操作图表1
                if (this.chart1.Series[0].Points.Count > 20)
                {
                    Action actd = () =>
                    {
                        this.chart1.Series[0].Points.RemoveAt(0);
                        this.chart1.Series[1].Points.RemoveAt(0);
                        this.chart1.Series[2].Points.RemoveAt(0);
                        this.chart1.Series[3].Points.RemoveAt(0);
                        this.chart1.Series[4].Points.RemoveAt(0);
                        this.chart1.Series[5].Points.RemoveAt(0);
                    };
                    this.chart1.BeginInvoke(actd);
                }
                Action acts0 = () =>
                {
                    this.chart1.Series[0].Points.AddXY(szDt, szDb.M1_0CF1);
                    this.chart1.Series[1].Points.AddXY(szDt, szDb.M2_5CF1);
                    this.chart1.Series[2].Points.AddXY(szDt, szDb.M10CF1);
                    this.chart1.Series[3].Points.AddXY(szDt, szDb.M1_0);
                    this.chart1.Series[4].Points.AddXY(szDt, szDb.M2_5);
                    this.chart1.Series[5].Points.AddXY(szDt, szDb.M10_0);

                };
                chart1.BeginInvoke(acts0);
                //操作图表2
                if (this.chart2.Series[0].Points.Count > 20)
                {
                    Action actd = () =>
                    {
                        this.chart2.Series[0].Points.RemoveAt(0);
                        this.chart2.Series[1].Points.RemoveAt(0);
                        this.chart2.Series[2].Points.RemoveAt(0);
                        this.chart2.Series[3].Points.RemoveAt(0);
                        this.chart2.Series[4].Points.RemoveAt(0);
                        this.chart2.Series[5].Points.RemoveAt(0);
                    };
                    this.chart2.BeginInvoke(actd);
                }
                Action acts1 = () =>
                {
                    this.chart2.Series[0].Points.AddXY(szDt, szDb.P0_3);
                    this.chart2.Series[1].Points.AddXY(szDt, szDb.P0_5);
                    this.chart2.Series[2].Points.AddXY(szDt, szDb.P1_0);
                    this.chart2.Series[3].Points.AddXY(szDt, szDb.P2_5);
                    this.chart2.Series[4].Points.AddXY(szDt, szDb.P5_0);
                    this.chart2.Series[5].Points.AddXY(szDt, szDb.P10);
                };
                chart2.BeginInvoke(acts1);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(ld.IsValid)
            {
                FileStream tfs = new FileStream("save/MonitorSite.local", FileMode.Append, FileAccess.Write);
                BinaryFormatter tbf = new BinaryFormatter();
                ld.Edt = DateTime.Now;
                tbf.Serialize(tfs, ld);
                tfs.Close();
            }
            fs.Close();
            serialPort1.Close();
            System.Environment.Exit(0);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label7.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Query q = new Query();
            q.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //WHO 标准
            WHO who = new WHO();
            who.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //PM2.5质量标准
            PM pm = new PM();
            pm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //停止
            start = serialPort1.IsOpen ? false : true;
            button2.Text = start ? "停止" : "开始";
            if(!start)
            {
                serialPort1.Close();
            }
            else
            {
                try
                {
                    serialPort1.Open();
                }
                catch(Exception)
                {
                    MessageBox.Show("没有发现串口！");
                }
            }
        }

    }
}
