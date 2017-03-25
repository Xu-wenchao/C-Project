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
    public partial class Test_Tmp : Form
    {
        public Test_Tmp()
        {
            InitializeComponent();
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker2.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker2.CustomFormat = "yyyy-MM-dd";
        }
        //添加数据
        private void button1_Click(object sender, EventArgs e)
        {
            byte[] bs = {12,32,43,43,12,43,12,43,67,87,67,91 };
            DataModel dm = new DataModel(bs);
            if(Services.insert(3, DateTime.Now.ToString(), dm))
            {
                MessageBox.Show("添加成功");
            }
        }
        //查询数据
        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            List<Dictionary<String, String>> list = 
                new Services().queryData(1, dateTimePicker1.Text, dateTimePicker2.Text);
            if (list != null)
            { 
                foreach (Dictionary<String, String> dir in list)
                {
                    DataModel dm = new DataModel(ObjectStringSwap.string2Bytes(dir["dataval"]));
                    ListViewItem li = new ListViewItem();
                    li.SubItems.Clear();
                    li.SubItems[0].Text = dir["name"];
                    li.SubItems.Add(dm.Pm25.ToString());
                    li.SubItems.Add(dm.Pm10.ToString());
                    li.SubItems.Add(dm.Temperature.ToString());
                    li.SubItems.Add(dm.Humidity.ToString());
                    li.SubItems.Add(dir["gt"]);
                    listView1.Items.Add(li);
                }
            }
        }
    }
}
