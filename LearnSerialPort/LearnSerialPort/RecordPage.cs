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
    public partial class RecordPage : Form
    {
        public RecordPage()
        {
            InitializeComponent();
            FileStream fs = null;
            BinaryFormatter bf = null;
            try
            {
                /*
                 * 两个线程同时访问一个文件，本文件只用于读取数据。
                 * 这样的情况，不单要与只读方式打开文件，而且，需要共享锁。
                 * 还必须要选择flieShare方式为ReadWrite。因为随时有其他程序对其进行写操作。
                 */
                fs = new FileStream("save/MonitorSite.local", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                bf = new BinaryFormatter();
                for (; ; )
                {
                    LocationData ld = bf.Deserialize(fs) as LocationData;   
                    richTextBox1.Select(richTextBox1.Text.Length, 0);
                    richTextBox1.SelectedText = ld.toString();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("没有记录！", "提示");
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
    }
}
