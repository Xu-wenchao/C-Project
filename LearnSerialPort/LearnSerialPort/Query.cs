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
using System.Runtime.Serialization;

namespace LearnSerialPort
{
    partial class Query : Form
    {
        private String tmpDate = null;
        public Query()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyyMMdd";
            this.chart1.ChartAreas[0].AxisY.Minimum = 0;
            this.chart1.ChartAreas[0].AxisY.Maximum = 500;
            this.chart2.ChartAreas[0].AxisY.Minimum = 0;
            this.chart2.ChartAreas[0].AxisY.Maximum = 100000;
            //setValueByDay();
        }
        private String[] getFileName()
        {
            DirectoryInfo dirInfo = new DirectoryInfo("save");
            FileInfo[] fileInfo = dirInfo.GetFiles();
            String[] strs = new String[fileInfo.Count()];
            int index = 0;
            foreach(FileInfo f in fileInfo)
            {
                String fName = f.ToString();
                if(File.Exists("save/" + fName) && fName.Substring(8, 4).Equals(".bat"))
                {
                    strs[index++] = fName.Substring(0, 8);
                }
            }
            return strs;
        }
        //private void openFile(String fileName)
        //{
        //     FileStream fs = null;
        //    BinaryFormatter bf = null;
        //    try
        //    {
        //        fs = new FileStream(fileName + ".bat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        //        bf = new BinaryFormatter();
        //        MemoryCell mc = null;
        //    }
        //    catch (Exception e) //SerializationException
        //    { }
        //    finally
        //    {
        //        try { fs.Close(); }
        //        catch (Exception) { };
        //    }
        //}
        private void setValueByMonth()
        {
            Console.WriteLine("start");
            clearAllChart();
            String[] fss = getFileName();
            foreach(String str in fss)
            {
                Console.WriteLine(str);
            }
            for (int i = 0; i < fss.Count(); i++)
            { 
                if(fss[i] != null && fss[i].Substring(0, 6).Equals(dateTimePicker1.Text.Substring(0, 6)))
                {
                    read(fss[i]);
                }
            }
        }
        private void setValueByYear()
        {
            clearAllChart();
            String[] fss = getFileName();
            for (int i = 0; i < fss.Count(); i++)
            {
                if (fss[i] != null && fss[i].Substring(0, 4).Equals(dateTimePicker1.Text.Substring(0, 4)))
                {
                    read(fss[i]);
                }
            }
        }
        public void read(String fileName)
        {
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                /*
                 * 两个线程同时访问一个文件，本文件只用于读取数据。
                 * 这样的情况，不单要与只读方式打开文件，而且，需要共享锁。
                 * 还必须要选择flieShare方式为ReadWrite。因为随时有其他程序对其进行写操作。
                 */
                fs = new FileStream("save/" + fileName + ".bat", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                bf = new BinaryFormatter();
                for (; ; )
                {
                    this.setChartValue(bf.Deserialize(fs) as MemoryCell);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("没有这个时间点的记录！", "提示");
            }
            catch (Exception e) //SerializationException
            {
                Console.WriteLine(e.StackTrace);
                //Console.WriteLine("读取完毕");
            }
            finally
            {
                try { fs.Close(); }
                catch (Exception) { };
            }
        }
        public void setChartValue(MemoryCell mc)
        {
            //为了给控件继续添加String值
            richTextBox1.Select(richTextBox1.Text.Length, 0);
            richTextBox1.SelectedText = mc.Dt.ToString() + mc.Db.ToString() + "\n";
            //为图表1数据赋值
            this.chart1.Series[0].Points.AddXY(mc.Dt.ToString(), mc.Db.M1_0CF1);
            this.chart1.Series[1].Points.AddXY(mc.Dt.ToString(), mc.Db.M2_5CF1);
            this.chart1.Series[2].Points.AddXY(mc.Dt.ToString(), mc.Db.M10CF1);
            this.chart1.Series[3].Points.AddXY(mc.Dt.ToString(), mc.Db.M1_0);
            this.chart1.Series[4].Points.AddXY(mc.Dt.ToString(), mc.Db.M2_5);
            this.chart1.Series[5].Points.AddXY(mc.Dt.ToString(), mc.Db.M10_0);
            //为图表2数据赋值
            this.chart2.Series[0].Points.AddXY(mc.Dt.ToString(), mc.Db.P0_3);
            this.chart2.Series[1].Points.AddXY(mc.Dt.ToString(), mc.Db.P0_5);
            this.chart2.Series[2].Points.AddXY(mc.Dt.ToString(), mc.Db.P1_0);
            this.chart2.Series[3].Points.AddXY(mc.Dt.ToString(), mc.Db.P2_5);
            this.chart2.Series[4].Points.AddXY(mc.Dt.ToString(), mc.Db.P5_0);
            this.chart2.Series[5].Points.AddXY(mc.Dt.ToString(), mc.Db.P10); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            clearAllChart();
            read(this.dateTimePicker1.Text);
        }

        private void clearAllChart()
        {
            //为图表1数据赋值
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[2].Points.Clear();
            this.chart1.Series[3].Points.Clear();
            this.chart1.Series[4].Points.Clear();
            this.chart1.Series[5].Points.Clear();
            //为图表2数据赋值
            this.chart2.Series[0].Points.Clear();
            this.chart2.Series[1].Points.Clear();
            this.chart2.Series[2].Points.Clear();
            this.chart2.Series[3].Points.Clear();
            this.chart2.Series[4].Points.Clear();
            this.chart2.Series[5].Points.Clear(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //按月查询
            clearAllChart();
            setValueByMonth();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //按年查询
            clearAllChart();
            setValueByYear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //监测记录
            RecordPage rp = new RecordPage();
            rp.ShowDialog();
        }
    }
}
