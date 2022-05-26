using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace SimFBPLC
{
    public class CUDPServer
    {
        Socket server;
        public event DataReceivedEventHandler UPDDataReceived;

        public delegate void DataReceivedEventHandler(string Data);
        
        int port = 8080;
        public void StartServer(int port)
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));//繫結埠號和IP
            //Console.WriteLine("服務端已經開啟");
            Thread t = new Thread(ReciveMsg);//開啟接收訊息執行緒

            t.Start();
            //Thread t2 = new Thread(sendMsg);//開啟發送訊息執行緒
            //t2.Start();
        }
        /// <summary>
        /// 向特定ip的主機的埠傳送資料報
        /// </summary>
        void sendMsg()
        {
            EndPoint point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6000);
            while (true)
            {
                try
                {
                    string msg = Console.ReadLine();
                    server.SendTo(Encoding.UTF8.GetBytes(msg), point);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
            }
        }
        /// <summary>
        /// 接收發送給本機ip對應埠號的資料報
        /// </summary>
        void ReciveMsg()
        {
            while (true)
            {
                EndPoint point = new IPEndPoint(IPAddress.Any, 0);//用來儲存傳送方的ip和埠號
                byte[] buffer = new byte[1024];
                int length = server.ReceiveFrom(buffer, ref point);//接收資料報
                string message = Encoding.UTF8.GetString(buffer, 0, length);      
                UPDDataReceived?.Invoke(message);//
            }
        }
        
    }
}
