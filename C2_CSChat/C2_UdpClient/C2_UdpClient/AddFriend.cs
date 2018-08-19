using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace C2_UdpClient
{
    public partial class AddFriend : Form
    {
        public string name;//输入的名字
        public IPAddress ip;//获取输入的IP
        public IPAddress hostip;//本地ip
        public bool ok;//判断是否按ok键

        public AddFriend()
        {
            InitializeComponent();

            string HostName = Dns.GetHostName();
            IPHostEntry MyEntry = Dns.GetHostByName(Dns.GetHostName());
            hostip = new IPAddress(MyEntry.AddressList[0].Address);

            string[] temp = hostip.ToString().Split('.');
            textBox3.Text = temp[0];
            textBox4.Text = temp[1];
            textBox5.Text = temp[2];
            textBox6.Text = temp[3];
            textBox1.Text = hostip.ToString();
        }

        public AddFriend(Chat X)
        {
            InitializeComponent();
            string[] temp = X.friendip.ToString().Split('.');
            textBox3.Text = temp[0];
            textBox4.Text = temp[1];
            textBox5.Text = temp[2];
            textBox6.Text = temp[3];
            textBox1.Text = X.name;
            button1.Text = "确定";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("信息不完整！请输入完整后添加");
                return;
            }
            try
            {
                name = textBox1.Text;
                ip = IPAddress.Parse(textBox3.Text + "." + textBox4.Text + "." + textBox5.Text + "." + textBox6.Text);
                ok = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("输入的IP无法识别，请重新输入！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
