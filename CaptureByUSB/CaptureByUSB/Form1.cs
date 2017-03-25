using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Threading;

namespace CaptureByUSB
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private int flag = 1;
        private string tscbxCameras;
        private VideoSourcePlayer videPlayer;
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            label2.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            videPlayer = new VideoSourcePlayer();

            try
            {
                //枚举所有视频输入设备  
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0)
                    throw new ApplicationException();

                foreach (FilterInfo device in videoDevices)
                {
                    comboBox1.Items.Add(device.Name);
                }
            }
            catch (ApplicationException)
            {
                MessageBox.Show("没有摄像头");
            }               

        }
        /// <summary>  
        /// 连接开启摄像头  
        /// </summary>  
        private void CameraConn()
        {
            videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            //videoSource.DesiredFrameSize = new Size(640, 480);
            videoSource.DesiredFrameSize = new Size(int.Parse(textBox1.Text), int.Parse(textBox2.Text));

            //videoSource.DesiredFrameRate = 10000;
            //videoSource.VideoCapabilities[0].MaxFrameRate = 1;
            videPlayer.VideoSource = videoSource;
            videPlayer.Start();
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);  
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
            //label2.Text = new Random().Next().ToString();
            label2.Text = Thread.CurrentThread.ManagedThreadId.ToString();
            //Thread.Sleep(1000);
            //do processing here  
        } 

        /// <summary>  
        /// 关闭摄像头  
        /// </summary>  
        private void closeCamera()
        {
            videPlayer.SignalToStop();
            videPlayer.WaitForStop();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                Bitmap img = (Bitmap)pictureBox1.Image.Clone();
                string imgPath = "E:\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
                img.Save(imgPath); 
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeCamera();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tscbxCameras = comboBox1.Text;
            CameraConn();
        }
        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            closeCamera();
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //videoSource.DesiredFrameSize = new Size(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
        }

    }
}
