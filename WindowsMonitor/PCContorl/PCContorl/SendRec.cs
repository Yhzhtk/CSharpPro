using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace PCContorl
{
    public class SendRec
    {
        /// <summary>
        /// 本地IP
        /// </summary>
        IPAddress localIP;

        /// <summary>
        /// 接收嵌套字
        /// </summary>
        Socket listener;

        /// <summary>
        /// 接收图片嵌套字
        /// </summary>
        Socket listenerPic;

        /// <summary>
        /// 传输文件
        /// </summary>
        public static TcpListener fileListener;

        /// <summary>
        /// 是否已释放
        /// </summary>
        bool dispose;

        /// <summary>
        /// 服务器IP或服务器名
        /// </summary>
        public string server="127.0.0.1";

        /// <summary>
        /// 服务器连接端口
        /// </summary>
        public int serverPort = 8902;

        /// <summary>
        /// 本地（控制端）端口
        /// </summary>
        public int localPort=8901;

        /// <summary>
        /// 本地接收图片端口
        /// </summary>
        public int picPort = 8903;

        /// <summary>
        /// 文件发送端口
        /// </summary>
        public int fOutPort = 8905;

        /// <summary>
        /// 文件接收端口
        /// </summary>
        public int fInPort = 8906;

        /// <summary>
        /// 接收到的字符串
        /// </summary>
        public string recStr;

        /// <summary>
        /// 是否接收到信息并未被取出
        /// </summary>
        public bool recOk;

        /// <summary>
        /// 图片流
        /// </summary>
        public byte[] pic;

        /// <summary>
        /// 图片接受成功
        /// </summary>
        public bool picOK;

        /// <summary>
        /// 下一张是图片
        /// </summary>
        public bool needPic=false;

        public int memSize = 200000;

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public SendRec() { }

        /// <summary>
        /// 发送字符串
        /// </summary>
        /// <param name="str"></param>
        public void sendStr(string str)
        {
            Socket sokt;
            sokt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                 sokt.Connect(server, serverPort);
                 byte[] buffer = Encoding.Default.GetBytes(localIP.ToString() + ":" + localPort.ToString() + "□" + str);
                sokt.Send(buffer);
            }
            catch
            {
                recStr = "服务器连接不成功，可能网络不好或者服务器设置有问题。  时间：" + DateTime.Now.ToString();
                recOk = true;
            }
            sokt.Close();
        }

        /// <summary>
        /// 本地监听服务器信息
        /// </summary>
        public void Listen()
        {
            //获取本地IP
            string HostName = Dns.GetHostName();
            IPHostEntry MyEntry = Dns.GetHostByName(Dns.GetHostName());
            localIP = new IPAddress(MyEntry.AddressList[0].Address);

            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(new IPEndPoint(localIP, localPort));
                listener.Listen(50);


                //传输文件监听初始化
                fileListener = new TcpListener(localIP, fInPort);
                fileListener.Start();

                //启动接收线程
                Control.CheckForIllegalCrossThreadCalls = false;
                Thread thread = new Thread(new ThreadStart(Receive));
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
                MessageBox.Show("端口绑定不成功，可能无法接收消息！");
                recStr = "端口绑定不成功，可能无法接收消息！ 时间：" + DateTime.Now.ToString();
                recOk = true;
            }
        }

        /// <summary>
        /// 接收监听到的消息
        /// </summary>
        private void Receive()
        {
            while (!dispose)
            {
                try
                {
                    Socket accept = listener.Accept();//发送端为重连接，故本语句必须放在while循环里面

                    /*if (needPic)
                    {
                        byte[] rec = new byte[memSize];
                        accept.Receive(rec);
                        pic = rec;
                        picOK = true;
                        needPic = false;
                    }
                    else
                    {
                        byte[] rec = new byte[10000];
                        accept.Receive(rec);
                        string str = Encoding.Default.GetString(rec);
                        recStr = str.Split('\0')[0];
                        recOk = true;
                    }*/

                    byte[] rec = new byte[10000];
                    accept.Receive(rec);
                    string str = Encoding.Default.GetString(rec);
                    recStr = str.Split('\0')[0];
                    recOk = true;
                }
                catch
                {
                    // MessageBox.Show("消息接收出现错误！");
                    recStr = "消息接收出现错误！ 时间" + DateTime.Now.ToString();
                    recOk = true;
                }
            }
        }

        /// <summary>
        /// 本地监听服务器信息
        /// </summary>
        public void ListenPic()
        {
            listenerPic = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenerPic.Bind(new IPEndPoint(localIP, picPort));
                listenerPic.Listen(50);
            }
            catch
            {
                MessageBox.Show("接收图片端口绑定不成功，可能无法发送消息！");
                recStr = "接收图片端口"+picPort+"绑定不成功，可能无法发送消息！ 时间：" + DateTime.Now.ToString();
                recOk = true;
            }

            Thread thread = new Thread(new ThreadStart(ReceivePic));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 接收监听到的消息
        /// </summary>
        private void ReceivePic()
        {
            while (!dispose)
            {
                try
                {
                    Socket accept = listenerPic.Accept();//发送端为重连接，故本语句必须放在while循环里面

                    byte[] rec = new byte[memSize];
                    accept.Receive(rec);
                    pic = rec;
                    picOK = true;
                    needPic = false;
                }
                catch
                {
                    // MessageBox.Show("消息接收出现错误！");
                    recStr = "图片接收出现错误！ 时间" + DateTime.Now.ToString();
                    recOk = true;
                }
            }
        }

        /// <summary>
        /// 关闭监听
        /// </summary>
        public void Close()
        {
            dispose = true;
            if (listener != null)
            {
                listener.Close();
                listenerPic.Close();
            }
            if (fileListener != null)
            {
                fileListener.Stop();
            }
        }
    }
}
