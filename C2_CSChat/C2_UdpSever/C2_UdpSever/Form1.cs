using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace C2_UdpSever
{
    public partial class Form1 : Form
    {
        UdpClient Server;//服务器UDP
        IPEndPoint receivePoint;//接收数据时作为返回的发送端IP
        int port = 8080; //定义端口号 
        Thread startServer;//服务器接收信息线程
        string ip = "127.0.0.1";//本地IP
        IPAddress hostip;//对外的本地IP

        int NowChat=-1;//当前聊天朋友索引号
        List<Chat> Friends;//所有聊天朋友

        bool start;//程序是否正常启动

        //以IP寻找聊天朋友索引值
        int SearchFriend(string ipstr)
        {
            for (int i = 0; i < Friends.Count; i++)
            {
                if (ipstr == Friends[i].friendip.ToString())
                    return i;
            }
            return -1;
        }

        //寻找ip是否存在于朋友中
        bool exist(string str)
        {
            for (int i = 0; i < Friends.Count; i++)
                if (str == Friends[i].friendip.ToString())
                    return true;
            return false;
        }

        //接收消息线程，用于接收所有信息
        public void start_Server()
        {
            while (true)
            {
                byte[] Data=null;
                try
                {
                    Data = Server.Receive(ref receivePoint);//获取发送来的信息，没有接收则等待直到接收为止
                }
                catch
                {
                    MessageBox.Show("该客户端已关闭！");
                    textBox1.Text = "该客户端已关闭！";
                    continue;
                } 
                String Read_str = Encoding.Default.GetString(Data); //提取客户端的信息，存放到定义为temp的字符串数组中 
                string[] temp = Read_str.Split('|');//源ip，目标ip，转发聊天内容
                IPAddress To = IPAddress.Parse(temp[1]);//目标IP地址
 
                //重要，给本机发消息，则截取
                if (temp[1] == hostip.ToString())     
                {
                    int Friendindex = SearchFriend(temp[0]);//发送方
                    string shownew = "";

                    if (Friendindex == -1)//发送方不存在与记录中
                    {
                        Chat newfriend = new Chat(temp[0], IPAddress.Parse(temp[0]));
                        Friends.Add(newfriend);
                        NowChat = Friends.Count - 1;
                        shownew += Friends[NowChat].name;
                        shownew += " " + temp[2];
                        Friends[NowChat].chatstr.Add(shownew);//添加接收到的消息

                        listBox1.Items.Add(newfriend.name);
                        listBox1.SelectedIndex = Friends.Count - 1;//添加好友显示
                        listBox1.SelectedIndex = 0;

                        groupBox4.Text = "与 " + Friends[NowChat].name + " 聊天中";
                        textBox1.Text = "";

                        //添加所有聊天记录
                        for (int j = 0; j < Friends[NowChat].chatstr.Count; j++)
                        {
                            textBox1.Text = textBox1.Text + Friends[NowChat].chatstr[j] + "\r\n";
                        }
                    }
                    else if (Friendindex == NowChat)//发送方为正在聊天的好友
                    {
                        shownew += Friends[NowChat].name;
                        shownew += " " + temp[2] + "\r\n";
                        Friends[NowChat].chatstr.Add(shownew);
                        textBox1.Text += shownew;//直接添加
                    }
                    else//其他非正聊天好友
                    {
                        NowChat = Friendindex;
                        shownew += Friends[NowChat].name;
                        shownew += " " + temp[2];
                        Friends[NowChat].chatstr.Add(shownew);//添加聊天记录
                        listBox1.SelectedIndex = NowChat;

                        groupBox4.Text = "与 " + Friends[NowChat].name + " 聊天中";
                        textBox1.Text = "";
                        //添加聊天内容
                        for (int j = 0; j < Friends[NowChat].chatstr.Count; j++)
                        {
                            textBox1.Text = textBox1.Text + Friends[NowChat].chatstr[j];
                        }
                    }

                    textBox1.Select(textBox1.Text.Length, 0);
                    textBox1.ScrollToCaret();//将光标和位置转到最后

                    listBox2.Items.Add(temp[0] + " 发给 我 一条消息");
                    listBox2.SelectedIndex = listBox1.Items.Count - 1;
                  
                    if (!exist(temp[0]))//判断发送方是否在好友中
                    {
                        listBox1.Items.Add(temp[0]);
                        Friends.Add(new Chat(temp[0], IPAddress.Parse(temp[0])));
                    }
                }
                else//转发给其他主机，则执行转发命令
                {
                    if (!exist(temp[1]))
                    {
                        listBox1.Items.Add(temp[1]);
                        Friends.Add(new Chat(temp[0], IPAddress.Parse(temp[0])));
                    }

                    if (temp[0] == hostip.ToString())
                        temp[0] = "我";

                    listBox2.Items.Add(temp[0] + " 发给 " + temp[1] + " 一条消息");//显示发送命令
                    listBox2.SelectedIndex = listBox1.Items.Count - 1;
                    Server.Send(Data, Data.Length, To.ToString(), 8081);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 一些初始化操作
        /// </summary>
        public void run()
        {
            try
            {
                Friends = new List<Chat>();
                //利用本地8080端口号来初始化一个UDP网络服务 
                Server = new UdpClient(port);
                receivePoint = new IPEndPoint(IPAddress.Parse(ip), port);
                //开一个线程 
                Control.CheckForIllegalCrossThreadCalls = false;
                startServer = new Thread(new ThreadStart(start_Server));
                //启动线程 
                startServer.Start();
                start = true;
            }
            catch
            {
                label4.Text = "当前状态： 服务未开启";
                textBox1.Text = "已经开通一个客户端，一个主机只能有一个客户端。请使用已开通客户端发送消息。";
                MessageBox.Show("已经开通一个客户端，一个主机只能有一个客户端。请使用已开通客户端发送消息。");
            }
        } 

        private void Form1_Load(object sender, EventArgs e)
        {
            string HostName = Dns.GetHostName();
            IPHostEntry MyEntry = Dns.GetHostByName(Dns.GetHostName());
            hostip = new IPAddress(MyEntry.AddressList[0].Address);//获取本地IP

            label2.Text = hostip.ToString();//显示本地IP

            run();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Server.Close();//关闭服务
                startServer.Abort();
            }
            catch { }
        }

        /// <summary>
        /// 双击聊天对象，则转到对应聊天好友中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
                return;

            NowChat = listBox1.SelectedIndex;

            for (int i = 0; i < 100; i++)
                ;//让选中稳定，可删除

            groupBox4.Text = "与 " + Friends[NowChat].name + " 聊天中";
            textBox1.Text = "";
            for (int j = 0; j < Friends[NowChat].chatstr.Count; j++)
            {
                textBox1.Text = textBox1.Text + Friends[NowChat].chatstr[j] + "\r\n";
            }
        }

        /// <summary>
        /// 清空消息记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (NowChat != -1)
            {
                Friends[NowChat].chatstr.Clear();
                textBox1.Text = "";
            }
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (NowChat == -1)
            {
                MessageBox.Show("请先选择聊天好友！");
                return;
            }
            //添加消息，包括时间和内容
            Friends[NowChat].chatstr.Add(" " + System.DateTime.Now.ToString() + "\r\n " + textBox2.Text + "\r\n");
            string thisshow = Friends[NowChat].chatstr[Friends[NowChat].chatstr.Count - 1];
            //添加本地IP
            string sendstr = hostip.ToString() + "|" + Friends[NowChat].friendip.ToString() + "|" + thisshow;//本地ip，对方ip，发送内容
            byte[] sendData = Encoding.Default.GetBytes(sendstr);
            //发送消息
            listBox2.Items.Add("我 发给 " + Friends[NowChat].friendip.ToString() + " 一条消息");//显示发送命令
            listBox2.SelectedIndex = listBox1.Items.Count - 1;

            Server.Send(sendData, sendData.Length, ip.ToString(), 8081);
            //本地消息发送消息
            textBox1.Text += thisshow;
            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.ScrollToCaret();

            textBox2.Clear();
            textBox2.Focus();//回退焦点
        }
    }

    //聊天的类
    public class Chat
    {
        public string name;
        public IPAddress friendip;
        public List<string> chatstr;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="na"></param>
        /// <param name="ip"></param>
        public Chat(string na, IPAddress ip)
        {
            name = na;
            friendip = ip;
            chatstr = new List<string>();
        }

        /// <summary>
        /// 更改聊天好友信息
        /// </summary>
        /// <param name="news"></param>
        public void SetNew(Chat news)
        {
            name = news.name;
            friendip = news.friendip;
            for (int i = 0; i < news.chatstr.Count; i++)
            {
                chatstr.Add(news.chatstr[i]);
            }
        }
        /// <summary>
        /// 添加聊天记录
        /// </summary>
        /// <param name="str"></param>
        public void AddStr(string str)
        {
            chatstr.Add(str);
        }
    }
}
