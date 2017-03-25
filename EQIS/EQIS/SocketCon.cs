using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace EQIS
{
    class SocketCon
    {
        public static Socket getSocket(String ip, int port)
        {
            Socket socket = null;
            IPEndPoint ipp = new IPEndPoint(IPAddress.Parse(ip), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(ipp);
            }
            catch (Exception e1)
            {
                MessageBox.Show("连接失败！");
                Application.Exit();
            }
            return socket;
        }
    }
}
