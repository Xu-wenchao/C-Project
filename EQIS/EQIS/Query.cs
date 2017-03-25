using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EQIS
{
    public partial class Query : Form
    {
        private Dictionary<String, String> user;
        public Query(Dictionary<String, String> user)
        {
            InitializeComponent();
            this.user = user;
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            this.tabPage1.Parent = null;
            this.tabPage2.Parent = null;
            this.tabPage3.Parent = null;
            Services s = new Services();
            List<String> list = s.queryGrand(int.Parse(user["id"]));
            if (list.Contains("m1")) this.tabPage1.Parent = this.tabControl1;
            if (list.Contains("m2")) this.tabPage2.Parent = this.tabControl1;
            if (list.Contains("m3")) this.tabPage3.Parent = this.tabControl1;
        }

        //查询区域
        private void button1_Click(object sender, EventArgs e)
        {
            List<Dictionary<String, String>> list = 
                new Services().queryData(int.Parse(user["id"]), dateTimePicker1.Text, dateTimePicker2.Text);
            //foreach(Dictionary<String, String> dir in list)
            //{
            //    foreach(String key in dir.Keys)
            //    {
            //        Console.WriteLine(key + " " + dir[key]);
            //    }
            //}
            if (list != null)
            {
                clearChart(chart1);
                clearChart(chart2);
                clearChart(chart3);

                clearListView();
                foreach (Dictionary<String, String> dy in list)
                {
                    try
                    { 
                        DataModel dm = new DataModel(ObjectStringSwap.string2Bytes(dy["dataval"]));
                        if (dm.Tag)
                        {
                            //Console.WriteLine(dm.ToString());
                            setValueOfListView(dy, dm);
                            if (dy["name"].Equals("m1")) Tools.setAValueOfChartToQuery(chart1, dy["gt"], dm);
                            else if (dy["name"].Equals("m2")) Tools.setAValueOfChartToQuery(chart2, dy["gt"], dm);
                            else if (dy["name"].Equals("m3")) Tools.setAValueOfChartToQuery(chart3, dy["gt"], dm);
                        }
                    }
                    catch(Exception e1)
                    {
                        Console.WriteLine(e1.StackTrace);
                    }
                }
            }
        }
        public void clearChart(Chart chart)
        {
            chart.Series[0].Points.Clear();
            chart.Series[2].Points.Clear();
            chart.Series[3].Points.Clear();
            chart.Series[1].Points.Clear();

        }
        public void clearListView()
        {
            listView1.Items.Clear();
        }
        public void setValueOfListView(Dictionary<String, String> dir, DataModel dm)
        {
            ListViewItem li = new ListViewItem();
            li.SubItems.Clear();
            li.SubItems[0].Text = dir["name"];
            li.SubItems.Add(dm.Pm25.ToString());
            li.SubItems.Add(dm.Pm10.ToString());
            if(dm.Temperature.ToString().Equals("0"))
            {
                li.SubItems.Add("21");
            }
            else
            {
                li.SubItems.Add(dm.Temperature.ToString());
            }
            if(dm.Humidity.ToString().Equals("0"))
            {
                li.SubItems.Add("40");
            }
            else
            {
                li.SubItems.Add(dm.Humidity.ToString());
            }
            li.SubItems.Add(dir["gt"]);
            listView1.Items.Add(li);
        }
    }
}
