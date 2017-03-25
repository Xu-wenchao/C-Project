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
    public partial class AdminForm : Form
    {
        private Dictionary<String, String> user;
        public AdminForm(Dictionary<String, String> dir)
        {
            InitializeComponent();
            this.user = dir;
            button_stop.Enabled = false;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            //
        }

        private void button_queryu_Click(object sender, EventArgs e)
        {
            Services service = new Services();
            //testPrint();
            List<Dictionary<String, String>> list = service.queryAllu();
            int index = 0;
            listView1.Items.Clear();
            foreach(Dictionary<String, String> dir in list)
            {
                ListViewItem li = new ListViewItem();
                li.SubItems[0].Text = (++index).ToString();
                li.SubItems.Add(dir["name"]);
                li.SubItems.Add(dir["password"]);
                String chara = "普通用户";
                if (dir["chara"].Equals("0"))
                {
                    chara = "系统管理员";
                }
                if (dir["chara"].Equals("1"))
                {
                    chara = "系统用户";
                }
                li.SubItems.Add(chara);
                li.SubItems.Add(dir["id"]);
                listView1.Items.Add(li);
            }
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.ShowDialog();
        }

        private void button_querym_Click(object sender, EventArgs e)
        {
            Services service = new Services();
            //testPrint(service.queryAllm());
            List<Dictionary<String, String>> list = service.queryAllm();
            int index = 0;
            listView2.Items.Clear();
            foreach (Dictionary<String, String> dir in list)
            {
                ListViewItem li = new ListViewItem();
                li.SubItems[0].Text = (++index).ToString();
                li.SubItems.Add(dir["name"]);
                String useing = dir["usering"].Equals("1") ? "工作中" : "已禁用";
                li.SubItems.Add(useing);
                li.SubItems.Add(dir["id"]);
                listView2.Items.Add(li);
            }
        }
        private void testPrint(List<Dictionary<String, String>> list)
        { 
            foreach(Dictionary<String, String> dir in list)
            {
                foreach(String k in dir.Keys)
                {
                    Console.WriteLine("Key:" + k + " Value:" + dir[k]);
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lv in listView1.SelectedItems)
                {
                    //user的id
                    Services services = new Services();
                    if (services.delUserById(lv.SubItems[4].Text))
                    {
                        button_queryu_Click(null, null);
                    }
                }
            }
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lv in listView2.SelectedItems)
                {   
                    //machine的id
                    Services services = new Services();
                    String usering = button_stop.Text.Equals("禁用") ? "0" : "1";
                    if (services.updateMachineById(lv.SubItems[3].Text, usering))
                    {
                        button_stop.Enabled = false;
                        button_querym_Click(null, null);
                    }
                }
            }
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listView2.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lv in listView2.SelectedItems)
                { 
                    button_stop.Enabled = true;
                    button_stop.Text = lv.SubItems[2].Text.Equals("已禁用") ? "启用" : "禁用";
                }
            }
        }

        private void msgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                foreach (ListViewItem lv in listView1.SelectedItems)
                {
                    //user的id
                    PowerManage pm = new PowerManage(lv.SubItems[4].Text);
                    pm.ShowDialog();
                }
            }
        }
    }
}
