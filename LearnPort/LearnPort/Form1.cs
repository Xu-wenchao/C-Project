using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace LearnPort
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
            this.components = new System.ComponentModel.Container();
            serialPort = new SerialPort(this.components);
            this.serialPort.BaudRate = 115200;
            this.serialPort.DataReceived += new SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            serialPort.PortName = "COM2";
            //serialPort.Encoding = Encoding.Unicode;
            //String[] strs = SerialPort.GetPortNames();
            try
            {
                serialPort.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("端口没有打开！");
            }

        }
        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            ////MessageBox.Show(" ");
            //byte[] buffer = new byte[2];
            //int offset = 0;
            //int count = 2;
            //try
            //{
            //    //从串口中获取数据
            //    this.serialPort.Read(buffer, offset, count);
            //    String str = "";
            //    foreach(byte b in buffer)
            //    {
            //        Console.WriteLine(b);
            //    }

            //}
            //catch (Exception) { }
            Console.WriteLine(this.serialPort.ReadByte());
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(serialPort != null)
            {
                serialPort.Close();
            }
        }

    }
}
