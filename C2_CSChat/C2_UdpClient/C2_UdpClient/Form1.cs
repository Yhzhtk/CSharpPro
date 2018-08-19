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

namespace C2_UdpClient
{
    public partial class Form1 : Form
    {
        UdpClient Client;//客户端接收消息
        IPEndPoint receivePoint;//接收数据时作为返回的发送端IP
        int port = 8081; //定义端口号，必须和服务器端口相同
        IPAddress ip = IPAddress.Parse("10.2.34.40"); //设定服务器IP地址，这个很重要
        IPAddress hostip;//本机IP
        Thread T_recClient;//接收线程

        int NowChat;//当前聊天朋友索引
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

        //接收消息线程，用于接收所有信息
        public void recClient()
        {
            string shownew = ""; ;
            while (true)
            { //接收从远程主机发送到本地8080端口的数据 

                byte[] recData;
                try
                {
                    recData = Client.Receive(ref receivePoint);//获取发送来的信息，没有接收则等待直到接收为止
                }
                catch
                {
                    MessageBox.Show("关闭客户端程序 或 服务器已关闭！请联系服务器");
                    start = false;
                    NowChat = -1;
                    textBox1.Text = "服务器已关闭！请联系服务器";
                    return;
                }
                String Read_str = Encoding.Default.GetString(recData); //提取客户端的信息，存放到定义为temp的字符串数组中 
                string[] temp = Read_str.Split('|');//对方ip，自己ip，接收内容

                int Friendindex = SearchFriend(temp[0]);
                shownew = "";

                if (Friendindex == -1)//发送方不存在与记录中
                {
                    Chat newfriend = new Chat(temp[0], IPAddress.Parse(temp[0]));
                    Friends.Add(newfriend);//将聊天好友加入Friends保存

                    NowChat = Friends.Count - 1;
                    shownew += Friends[NowChat].name;
                    shownew += " " + temp[2];
                    Friends[NowChat].chatstr.Add(shownew);//添加聊天内容

                    listBox1.Items.Add(newfriend.name);
                    listBox1.SelectedIndex = Friends.Count - 1;//当前聊天对象

                    groupBox1.Text = "与 " + Friends[NowChat].name + " 聊天中";
                    textBox1.Text = "";
                    //添加聊天内容
                    for (int j = 0; j < Friends[NowChat].chatstr.Count; j++)
                    {
                        textBox1.Text = textBox1.Text + Friends[NowChat].chatstr[j];
                    }
                }
                else if (Friendindex == NowChat)//与发送方正在聊天
                {
                    shownew += Friends[NowChat].name;
                    shownew += " " + temp[2];
                    Friends[NowChat].chatstr.Add(shownew);
                    textBox1.Text += shownew;//直接添加聊天内容
                }
                else//其他非正聊天好友
                {
                    NowChat = Friendindex;
                    shownew += Friends[NowChat].name;
                    shownew += " " + temp[2];
                    Friends[NowChat].chatstr.Add(shownew);//添加聊天内容
                    listBox1.SelectedIndex = NowChat;

                    groupBox1.Text = "与 " + Friends[NowChat].name + " 聊天中";
                    textBox1.Text = "";
                    //显示所有聊天记录
                    for (int j = 0; j < Friends[NowChat].chatstr.Count; j++)
                    {
                        textBox1.Text = textBox1.Text + Friends[NowChat].chatstr[j];
                    }
                }
                textBox1.Select(textBox1.Text.Length, 0);
                textBox1.ScrollToCaret();//将光标和位置转到最后
            }
        }

        public Form1()
        {
            Friends = new List<Chat>();
            NowChat=-1;
            InitializeComponent();
        }

        public void run()
        {
            //利用本地8080端口号来初始化一个UDP网络服务 
            try
            {
                Client = new UdpClient(port);
                receivePoint = new IPEndPoint(ip, port);

                //获取本地IP
                string HostName = Dns.GetHostName();
                IPHostEntry MyEntry = Dns.GetHostByName(Dns.GetHostName());
                hostip = new IPAddress(MyEntry.AddressList[0].Address);

                //设置默认服务器为本地IP，由于服务器必须在同一局域网，故在修改服务器的时候方便，只需要该后面几个
                string[] temp = hostip.ToString().Split('.');
                textBox3.Text = temp[0];
                textBox4.Text = temp[1];
                textBox5.Text = temp[2];
                textBox6.Text = temp[3];

                ip = hostip;

                //默认添加服务器好友
                Friends.Add(new Chat("服务器", hostip));
                listBox1.Items.Add("服务器");
                listBox1.SelectedIndex = 0;

                //开线程 
                Control.CheckForIllegalCrossThreadCalls = false;
                T_recClient = new Thread(recClient);
                T_recClient.Start();
                start = true;
            }
            catch
            {
                textBox1.Text = "已经开通一个客户端，一个主机只能有一个客户端。请使用已开通客户端发送消息。";
                MessageBox.Show("已经开通一个客户端，一个主机只能有一个客户端。请使用已开通客户端发送消息。");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            run();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Client.Close();
                T_recClient.Abort();//关闭线程和服务
            }
            catch
            { }
        }

        /// <summary>
        /// 设置服务器IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                ip =IPAddress.Parse( textBox3.Text + "." + textBox4.Text + "." + textBox5.Text + "." + textBox6.Text);
                Friends[0].SetNew(new Chat("服务器",ip));
                MessageBox.Show("修改成功！");
            }
            catch
            {
                MessageBox.Show("输入的IP无法识别，请重新输入！");
            }
        }

        /// <summary>
        /// 添加聊天好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (!start)//未正常启动，不能操作
            {
                return;
            }
            AddFriend add = new AddFriend();
            add.ShowDialog();
            if (add.ok)
            {
                Friends.Add(new Chat(add.name, add.ip));
                listBox1.Items.Add(add.name);
            }
            add.Dispose();
        }

        /// <summary>
        /// 修改聊天好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            int i=listBox1.SelectedIndex;
            if (i == -1)
                return;
            else
            {
                AddFriend add = new AddFriend(Friends[i]);
                add.ShowDialog();
                if (add.ok)
                {
                    Friends[i].SetNew(new Chat(add.name, add.ip));
                    listBox1.Items[i] = add.name;
                }
                add.Dispose();
            }
        }

        /// <summary>
        /// 选中聊天好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.Items.Count == 0)
                return;

            NowChat=listBox1.SelectedIndex;

            for (int i = 0; i < 100; i++)
                ;//让选中稳定

            groupBox1.Text = "与 " + Friends[NowChat].name + " 聊天中";
            textBox1.Text = "";
            for (int j = 0; j <Friends[NowChat].chatstr.Count; j++)
            {
                textBox1.Text = textBox1.Text + Friends[NowChat].chatstr[j] + "\r\n";
            }

            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.ScrollToCaret();//将光标和位置转到最后
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (NowChat == -1)
            {
                MessageBox.Show("请先选择聊天好友！");
                return;
            }
            //添加消息，包括时间和内容
            Friends[NowChat].chatstr.Add("我 "+System.DateTime.Now.ToString()+"\r\n "+textBox2.Text+"\r\n");
            string thisshow=Friends[NowChat].chatstr[Friends[NowChat].chatstr.Count-1];
            //添加本地IP
            string sendstr =hostip.ToString()+"|"+ Friends[NowChat].friendip.ToString() + "|" + thisshow;//本地ip，对方ip，发送内容
            byte[] sendData = Encoding.Default.GetBytes(sendstr);
            textBox1.Text += thisshow;
            //发送消息
            Client.Send(sendData, sendData.Length,ip.ToString(), 8080);
            textBox2.Clear();
            textBox2.Focus();//回退焦点

            textBox1.Select(textBox1.Text.Length, 0);
            textBox1.ScrollToCaret();//将光标和位置转到最后
        }

        /// <summary>
        /// 清空消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (NowChat != -1)
            {
                Friends[NowChat].chatstr.Clear();
                textBox1.Text = "";
            }
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
