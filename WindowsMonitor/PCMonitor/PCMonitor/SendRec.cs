using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace PCMonitor
{
    public static class SendRec
    {
        /// <summary>
        /// 本地IP
        /// </summary>
        static IPAddress localIP;

        /// <summary>
        /// 接收嵌套字
        /// </summary>
        static Socket listener;

        /// <summary>
        /// 传输文件
        /// </summary>
        public static TcpListener fileListener;

        /// <summary>
        /// 是否已释放
        /// </summary>
        static bool dispose;

        /// <summary>
        /// 客户端IP或客户端名
        /// </summary>
        static public string client;

        /// <summary>
        /// 客户端连接端口
        /// </summary>
        static public int clientPort = 8901;

        ///
        static public int clientPicPort = 8903;

        /// <summary>
        /// 本地(PC机服务)端口
        /// </summary>
        static public int localPort = 8902;

        /// <summary>
        /// 文件发送端口(与control相反)
        /// </summary>
        public static int fOutPort = 8906;

        /// <summary>
        /// 文件接收端口(与control相反)
        /// </summary>
        public static int fInPort = 8905;

        /// <summary>
        /// 接收到的字符串
        /// </summary>
        static public string recStr;

        /// <summary>
        /// 是否接收到信息并未被取出
        /// </summary>
        static public bool recOk;

        /// <summary>
        /// 本机信息
        /// </summary>
        static public string localInfo;

        /// <summary>
        /// 初始化监听成功
        /// </summary>
        static public bool listenOk=false;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        static SendRec() { }

        /// <summary>
        /// 发送字符串
        /// </summary>
        /// <param name="str"></param>
        public static  void sendStr(string str)
        {
            Socket sokt;
            sokt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sokt.Connect(client, clientPort);
                byte[] buffer = Encoding.Default.GetBytes(str);
                sokt.Send(buffer);
            }
            catch
            {
                sokt.Close();
                //MessageBox.Show("服务器连接不成功，可能网络不好或者服务器设置有问题。");
            }
            sokt.Close();
        }

        /// <summary>
        /// 给指定IP发送信息
        /// </summary>
        /// <param name="str">发送内容</param>
        /// <param name="ip">对方IP</param>
        public static void sendStr(string str, string ip)
        {
            Socket sokt;
            sokt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                if (str == "")
                    str = "远程主机打开，IP为：" + localIP.ToString() + "   " + DateTime.Now.ToString();
                sokt.Connect(ip, clientPort);
                byte[] buffer = Encoding.Default.GetBytes(str);
                sokt.Send(buffer);
            }
            catch
            {
                sokt.Close();
                //MessageBox.Show("服务器连接不成功，可能网络不好或者服务器设置有问题。");
            }
            sokt.Close();
        }

        /// <summary>
        /// 发送字节流
        /// </summary>
        /// <param name="bys">字节流</param>
        public static string sendPic(byte[] bys)
        {
            Socket sokt;
            sokt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sokt.Connect(client, clientPicPort);
                Thread.Sleep(15);//等待网络稳定
                sokt.Send(bys);
            }
            catch
            {
                sokt.Close();
                return "服务器连接不成功，可能网络不好或者服务器设置有问题。";
            }
            sokt.Close();
            return "发送图片成功！ 时间：" + System.DateTime.Now.ToString();
        }

        static void FileListen()
        {
            try
            {
                fileListener = new TcpListener(localIP, fInPort);
                fileListener.Start();
            }
            catch
            { }
        }

        /// <summary>
        /// 本地监听服务器信息
        /// </summary>
        public static void Listen()
        {
            //获取本地IP
            string HostName = Dns.GetHostName();
            IPHostEntry MyEntry = Dns.GetHostByName(Dns.GetHostName());
            localIP = new IPAddress(MyEntry.AddressList[0].Address);

            localInfo = "" + HostName + "  IP:";
            for (int i = 0; i < MyEntry.AddressList.Length; i++)
            {
                localInfo += new IPAddress(MyEntry.AddressList[i].Address).ToString() + ";";
            }

            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(new IPEndPoint(localIP, localPort));
                listener.Listen(50);
                FileListen();

                listenOk = true;

                //监听成功后启动接收线程
                Control.CheckForIllegalCrossThreadCalls = false;
                Thread thread = new Thread(new ThreadStart(Receive));
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
                //MessageBox.Show("端口绑定不成功，可能无法发送消息！");
            }
        }

        /// <summary>
        /// 接收监听到的消息
        /// </summary>
        private static void Receive()
        {
            while (!dispose)
            {
                try
                {
                    Socket accept = listener.Accept();//发送端为重连接，故本语句必须放在while循环里面
                    byte[] rec = new byte[4999];
                    accept.Receive(rec);
                    string str = Encoding.Default.GetString(rec);

                    str = str.Split('\0')[0];

                    client = str.Split('□')[0].Split(':')[0];
                    clientPort = int.Parse(str.Split('□')[0].Split(':')[1]);

                    recStr = str.Split('□')[1];
                    recOk = true;
                }
                catch
                {
                    //MessageBox.Show("消息接收出现错误！可能为绑定成功！");
                }
            }
        }

        /// <summary>
        /// 关闭监听
        /// </summary>
        public static void Close()
        {
            dispose = true;
            if (listener!=null)
                listener.Close();
            if (fileListener != null)
                fileListener.Stop();
        }
    }
}
