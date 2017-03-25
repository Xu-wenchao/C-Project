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
    public partial class PowerManage : Form
    {
        private String id;
        private List<String> listmid;
        public PowerManage(String id)
        {
            InitializeComponent();
            listmid = new List<String>();
            this.id = id;
            Services services = new Services();
            List<Dictionary<String, String>> listu = services.queryAllu();
            foreach(Dictionary<String, String> map in listu)
            {
                if(map["id"].Equals(id))
                {
                    this.label_name.Text = map["name"]; 
                }
            }
            List<Dictionary<String, String>> list = services.queryAllm();
            int index = 1;
            foreach (Dictionary<String, String> map in list)
            {
                if (services.Listening(id, map["id"]))
                { 
                    if(index == 1)
                    {
                        button1.Text = "取消";
                    }
                    if (index == 2)
                    {
                        button3.Text = "取消";
                    }
                    if (index == 3)
                    {
                        button4.Text = "取消";
                    }
                }
                listmid.Add(map["id"]);
                index++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            if (button1.Text.Equals("监控"))
            {
                services.addManageArea(id, listmid[0]);
            }
            else
            {
                services.delManageArea(id, listmid[0]);
            }
            button1.Text = button1.Text.Equals("监控") ? "取消" : "监控";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            if (button3.Text.Equals("监控"))
            {
                services.addManageArea(id, listmid[1]);
            }
            else
            {
                services.delManageArea(id, listmid[1]);
            }
            button3.Text = button3.Text.Equals("监控") ? "取消" : "监控";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Services services = new Services();
            if (button4.Text.Equals("监控"))
            {
                services.addManageArea(id, listmid[2]);
            }
            else
            {
                services.delManageArea(id, listmid[2]);
            }
            button4.Text = button4.Text.Equals("监控") ? "取消" : "监控";
        }
    }
}
