using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace EQIS
{
    public partial class SysForm : Form
    {
        private Socket socket1 = null;
        private Socket socket2 = null;
        private Socket socket3 = null;
        private Dictionary<String, String> user;
        Thread t1 = null;
        Thread t2 = null;
        Thread t3 = null;

        public SysForm(Dictionary<String, String> user)
        {
            InitializeComponent();
            this.user = user;
            CheckForIllegalCrossThreadCalls = false;
            this.tab1.Parent = null;
            this.tab2.Parent = null;
            this.tab3.Parent = null;
        }
        public void acceptMsg(Object o)
        {
            Socket socket = (Socket)o;
            //socket.RemoteEndPoint;
            NetworkStream nStream = null;
            while (true)
            {
                try
                {
                    nStream = new NetworkStream(socket);
                    byte[] bs = new byte[12];
                    int offset = 0;
                    nStream.Read(bs, offset, 12);
                    for (int i = 0; i < bs.Length; i++)
                    {
                        Console.WriteLine(socket.RemoteEndPoint.ToString() + " " + bs[i]);
                    }
                    //MessageBox.Show("stop");
                    DataModel dm = new DataModel(bs);
                    if (dm.Tag)
                    {
                        if (socket.RemoteEndPoint.ToString().Equals("192.168.1.101:8899"))
                        {
                            CollectionsOfArea(chart1, dm, 1);
                        }
                        else if (socket.RemoteEndPoint.ToString().Equals("192.168.1.102:8899"))
                        {
                            CollectionsOfArea(chart2, dm, 2);
                        }
                        else if (socket.RemoteEndPoint.ToString().Equals("192.168.1.103:8899"))
                        {
                            CollectionsOfArea(chart3, dm, 3);
                        }
                    }
                }
                catch (Exception e1)
                {
                    Console.WriteLine(e1.StackTrace);
                    break;
                }
            }
            try
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception e1)
            {
                Application.Exit();
            }
        }
        /*接受数据后的相关操作
         * i表示不同区域
         */
        public void CollectionsOfArea(Chart chart, DataModel dm, int i)
        {
            //存储数据库
            Services.insert(i, DateTime.Now.ToString(), dm);
            //设置chart显示区域
            Tools.setAValueOfChart(chart, DateTime.Now.ToString(), dm);
            //设置动态显示区
            if (i == 1) setLabValue1(dm);
            else if (i == 2) setLabValue2(dm);
            else if (i == 3) setLabValue3(dm);
        }
        public void setValueOfChart(Chart chart, DataModel dm, int i)
        {
            Tools.setAValueOfChart(chart, DateTime.Now.TimeOfDay.ToString(), i, dm, 1);
            Tools.setAValueOfChart(chart, DateTime.Now.TimeOfDay.ToString(), i, dm, 2);
            Tools.setAValueOfChart(chart, DateTime.Now.TimeOfDay.ToString(), i, dm, 3);
            Tools.setAValueOfChart(chart, DateTime.Now.TimeOfDay.ToString(), i, dm, 4);

        }
        public void setLabValue1(DataModel dm)
        {
            Tools.setPM25(opm25, dm);
            Tools.setPM10(opm10, dm);
            Tools.setTmp(ot, dm);
            Tools.setHumidity(oh, dm);
        }
        public void setLabValue2(DataModel dm)
        {
            Tools.setPM25(tpm25, dm);
            Tools.setPM10(tpm10, dm);
            Tools.setTmp(tt, dm);
            Tools.setHumidity(th, dm);
        }
        public void setLabValue3(DataModel dm)
        {
            Tools.setPM25(spm25, dm);
            Tools.setPM10(spm10, dm);
            Tools.setTmp(st, dm);
            Tools.setHumidity(sh, dm);
        }
        //连接
        private void button1_Click(object sender, EventArgs e)
        {
            Services s = new Services();
            List<String> list = s.queryGrand(int.Parse(user["id"]));
            //获取三个地址的套接字连接
            //创建三个线程实现不同的数据接收机制
            if (list.Contains("m1"))
            {
                Console.WriteLine("m1 connect...");
                socket1 = SocketCon.getSocket("192.168.1.101", 8899);
                t1 = new Thread(new ParameterizedThreadStart(acceptMsg));
                t1.Start(socket1);
                this.tab1.Parent = this.tabControl1;
            }
            if (list.Contains("m2"))
            {
                Console.WriteLine("m2 connect...");
                socket2 = SocketCon.getSocket("192.168.1.102", 8899);
                t2 = new Thread(new ParameterizedThreadStart(acceptMsg));
                t2.Start(socket2);
                this.tab2.Parent = this.tabControl1;
            } 
            if (list.Contains("m3"))
            {
                Console.WriteLine("m3 connect...");
                socket3 = SocketCon.getSocket("192.168.1.103", 8899);
                t3 = new Thread(new ParameterizedThreadStart(acceptMsg));
                t3.Start(socket3);
                this.tab3.Parent = this.tabControl1;
            }
        }
        //历史记录
        private void button2_Click(object sender, EventArgs e)
        {
            Query q = new Query(user);
            q.Show();
        }

        private void SysForm_Load(object sender, EventArgs e)
        {

        }

        private void SysForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine("Close");
            try
            {
                //System.Environment.Exit(0);
            }
            catch (Exception e1)
            { }
        }
        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            sendMsg();
        }
        private void sendMsg()
        {
            try
            {
                if (socket1 != null)
                { 
                    NetworkStream ns = new NetworkStream(socket1);
                    byte[] bs = { 1 };
                    int offset = 0;
                    ns.Write(bs, offset, bs.Count());
                    ns.Flush();
                }
                if (socket2 != null)
                {
                    NetworkStream ns = new NetworkStream(socket2);
                    byte[] bs = { 1 };
                    int offset = 0;
                    ns.Write(bs, offset, bs.Count());
                    ns.Flush();
                }
                if (socket3 != null)
                {
                    NetworkStream ns = new NetworkStream(socket3);
                    byte[] bs = { 1 };
                    int offset = 0;
                    ns.Write(bs, offset, bs.Count());
                    ns.Flush();
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("消息发送失败！");
                Console.WriteLine(e1.StackTrace);
            }
            finally
            { 
            }
        }
    }
}
