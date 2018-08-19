using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net.Sockets;

namespace PCContorl
{
    public partial class PCControl : Form
    {
        #region 变量定义

        private static SendRec sr = new SendRec();

        private static int imgX = 1366;

        private static int imgY = 768;

        private static double imgP = 5;

        private static int memSize = 200000;

        private static int imgRank = 5;

        //int clearNum = 15;

        private static int cmdTimes = 0;

        private static int curTimes = 0;

        private static List<string> msgs = new List<string>();

        private static int cmdIndex = -1;
        private static List<string> cmds = new List<string>();

        private static Size remoteMaxSize;//远程主机屏幕大小

        private static Size thisSize;//软件当前大小

        private static Point thisLoc;//软件当前位置

        private static Size picBoxSize;//图片显示框当前大小

        private static Point picBoxLoc;//图片显示框当前位置

        private static Point curPos;//鼠标当前位置

        private static Point remotePos;//控制的远程鼠标位置

        private static bool controlMouseKey;//是否控制鼠标键盘

        private static string keyStr;//键盘字符串

        private static List<Task> tasks = new List<Task>();//任务链表

        private static bool taskExcute;//是否开启任务

        private static string fileSize = "0";//文件大小

        private static bool RecOk = true;//接收文件成功
        private static bool SendOk = true;//发送文件成功
        private static int RecSleep = 2;//接收时延时，用于限制发送网速
        private static int SendBytes = 10240;//每次发送字节数
        private static int RecBytes = 10240;//每次接收字节数

        #endregion

        #region 自写方法

        //注册热键的api 
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint control, Keys vk);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public enum KeyModifiers //组合键枚举
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312:    //这个是window消息定义的注册的热键消息 
                    if (m.WParam.ToString().Equals("225"))  //提高音量热键 
                    {
                        this.Visible = !this.Visible;
                        this.TopMost = true;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        int existInCBox(string ip)
        {
            for (int i = 0; i < allIpCBox.Items.Count; i++)
            {
                if (allIpCBox.Items[i].ToString().Contains(ip))
                    return i;
            }
            return -1;
        }

        void dealRec(string str)
        {
            msgs.Add((msgs.Count + 1).ToString() + "、接收信息： " + str);
            msgList.Items.Add(msgs[msgs.Count - 1]);
            if (msgList.SelectedIndex > msgList.Items.Count - 10)
                msgList.SelectedIndex = msgList.Items.Count - 1;

            if (str.Contains("远程主机打开"))
            {
                int i = str.IndexOf(" ");
                int index = existInCBox(str.Substring(11, i - 11));
                if (index != -1)
                {
                    allIpCBox.Items.RemoveAt(index);
                }
                allIpCBox.Items.Add(str.Substring(11, str.Length - 11));
                return;
            }

            recStrLabel.Text = str;
            if (!str.Contains("发送图片成功！"))
            {
                msgTxt.Text = str;
                this.Text = "PCMonitor - " + str;
            }

            //文件操作
            if (str.Contains("文件存在！"))
            {
                fileSize = str.Split(' ')[1];
                if (str.Split(' ')[2] == "K")
                {
                    getProBar.Maximum = int.Parse(fileSize.Replace(",", ""));
                    fileSize += " K";
                }
                else
                {
                    getProBar.Maximum = 1;
                    fileSize += " B";
                }
            }
            else if (str.Contains("文件续传！"))
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(receiveFile), localSaveTxt.Text);
            }
            else if (str.Contains("文件发送完成！"))
            {
                getFileBtn.Enabled = true;
                getStopBtn.Enabled = false;
                Thread.Sleep(1000);//等待接收完成
                RecOk = true;
            }

            if (str.Substring(0, 2) == "文件")//显示出文件操作
            {
                fileOperList.Items.Add(str);
            }
        }

        void dealPicturre(byte[] pic)
        {
            try
            {
                MemoryStream ms = new MemoryStream(pic);
                Image img = Image.FromStream(ms);
                pcImageBox.Image = img;
            }
            catch
            {
                string str = "图片处理出错，网络可能有问题！ 时间：" + DateTime.Now.ToString();
                recStrLabel.Text = str;
                msgs.Add((msgs.Count + 1).ToString() + "、错误信息： " + str);
                msgList.Items.Add(msgs[msgs.Count - 1]);

                if (msgList.SelectedIndex > msgList.Items.Count - 10)
                    msgList.SelectedIndex = msgList.Items.Count - 1;
            }
        }

        void sendFile(object sendPath)
        {
            try
            {
                TcpClient sendClient = new TcpClient(sr.server, sr.fOutPort);
                NetworkStream sendns = sendClient.GetStream();
                FileStream fs = File.Open(sendPath.ToString(), FileMode.Open, FileAccess.Read);
                BinaryReader binRead = new BinaryReader(fs);

                FileInfo f = new FileInfo(sendUrlTxt.Text);
                sendProBar.Maximum = (int)f.Length / 1024;
                string Size = "0 K";
                if (f.Length < 1024)
                {
                    Size = f.Length.ToString() + " B";
                }
                else if (f.Length < 1024000)
                {
                    Size = (f.Length / 1024).ToString() + " K";
                }
                else
                {
                    Size = (f.Length / 1024).ToString().Substring(0, (f.Length / 1024).ToString().Length - 3) + "," +
                        (f.Length / 1024).ToString().Substring((f.Length / 1024).ToString().Length - 3, 3) + " K";
                }

                int allSize = 0;
                string allKb = "0";
                string sizeStr = "0 K";

                byte[] bytes = new byte[SendBytes];
                int byteNum = 0;
                do
                {
                    byteNum = binRead.Read(bytes, 0, SendBytes);
                    allSize += byteNum;
                    allKb = (allSize / 1024).ToString();

                    try
                    {
                        sendns.Write(bytes, 0, byteNum);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("连接"))
                        {
                            sr.sendStr("receiveFile◇" + recUrlTxt.Text);
                            Thread.Sleep(20);
                        }
                        sendns.Write(bytes, 0, byteNum);
                    }

                    if (allSize > 1024000)
                    {
                        sizeStr = allKb.Substring(0, allKb.Length - 3) + "," + allKb.Substring(allKb.Length - 3, 3) + " K";
                        sendSizeLabel.Text = sizeStr + " / " + Size;
                        sendProBar.Value = allSize / 1024;
                    }
                }
                while (byteNum == 10240 && !SendOk);

                SendOk = true;

                sr.sendStr("setAtt◇RecOk◇True");

                binRead.Close();
                fs.Close();
                sendns.Close();

                MessageBox.Show("文件发送成功！共发送 " + allKb + " K");
                sendBtn.Enabled = true;
                stopBtn.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 接收文件
        /// </summary>
        /// <param name="path">文件保存路径</param>
        /// <returns></returns>
        void receiveFile(object recPath)
        {

            try
            {
                TcpClient tcpclient = SendRec.fileListener.AcceptTcpClient();
                FileStream fs = new FileStream(recPath.ToString(), FileMode.Append, FileAccess.Write);

                BinaryWriter binWrite = new BinaryWriter(fs);

                int allSize = 0;
                string sizeStr = "0 K";
                string allKb = "0 K";
                if (tcpclient != null)
                {
                    NetworkStream recns = tcpclient.GetStream();
                    byte[] buf = new byte[RecBytes];
                    int byteNum;
                    do
                    {
                        byteNum = recns.Read(buf, 0, RecBytes);
                        allSize += byteNum;
                        allKb = (allSize / 1024).ToString();
                        binWrite.Write(buf, 0, byteNum);

                        if (allSize > 1024000)
                        {
                            sizeStr = allKb.Substring(0, allKb.Length - 3) + "," + allKb.Substring(allKb.Length - 3, 3) + " K";
                            getSizeLabel.Text = sizeStr + " / " + fileSize;
                            getProBar.Value = allSize / 1024;
                        }
                        Thread.Sleep(RecSleep);
                    }
                    while (!RecOk);

                    recns.Close();
                    binWrite.Close();
                    fs.Close();

                }
                MessageBox.Show("文件接收成功！接收大小为:" + allSize.ToString() + "字节。");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        public PCControl()
        {
            InitializeComponent();

            sr.Listen();
            sr.ListenPic();

            netTimer.Enabled = true;
            picNetTimer.Enabled = true;
        }

        private void PCControl_Load(object sender, EventArgs e)
        {
            //注册热键(窗体句柄,热键ID,辅助键,实键)
            RegisterHotKey(this.Handle, 225, 2 | 1, Keys.Enter);
        }

        #region 各种事件

        private void ctrlBtn_Click(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
            string str = cmdTxt.Text;

            if (str == "")
            {
                MessageBox.Show("输入不能为空！");
                return;
            }

            if (keyBdCheck.Checked)//远程键盘输入
            {
                str = "keyevent#" + keyStr + "#1";
                str = str.Replace("-#", "#");
                keyStr = "";
                cmdTxt.Text = "";
            }
            else
            {
                if (str.Contains("getPic"))
                {
                    sr.needPic = true;
                }

                if (str.Contains("reNewSelf") || str.Contains("closeSelf"))
                {
                    curTimes = 0;
                }
            }
            sr.sendStr(str);
            cmds.Add(str);
            cmdIndex++;
            string te = "发送 " + str + " 等待中……  时间" + DateTime.Now.ToString();
            sendStrLabel.Text = te;
            msgs.Add((msgs.Count + 1).ToString() + "、发送命令： " + str + "        " + te);
            msgList.Items.Add(msgs[msgs.Count - 1]);
            if (msgList.SelectedIndex > msgList.Items.Count - 10)
                msgList.SelectedIndex = msgList.Items.Count - 1;

            cmdTimes++;
            cmdTimeLabel.Text = cmdTimes.ToString();
            curTimes++;
            curTimeLabel.Text = curTimes.ToString();
        }

        private void PCControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注消热键(句柄,热键ID)
            UnregisterHotKey(this.Handle, 225);

            this.Visible = false;
            sr.sendStr("setEnable#connectTimer#true#");
            if (!SendOk)
            {
                sr.sendStr("senAtt#RecOk#True");
                SendOk = true;
            }
            if (!RecOk)
            {
                sr.sendStr("senAtt#SendOk#True");
                RecOk = true;
            }
            sr.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                try
                {
                    IPAddress.Parse(serverTxt.Text);
                }
                catch
                {
                    MessageBox.Show("IP地址错误！");
                    serverTxt.Text = sr.server;
                    serverTxt.ReadOnly = true;
                    return;
                }
                sr.server = serverTxt.Text;
                serverTxt.ReadOnly = true;
            }
            else
            {
                serverTxt.ReadOnly = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                int a, b, d;
                double c;
                try
                {
                    a = int.Parse(imgXTxt.Text);
                    b = int.Parse(imgYTxt.Text);
                    c = double.Parse(imgPTxt.Text);
                    d = int.Parse(memTxt.Text);
                }
                catch
                {
                    MessageBox.Show("设置输入格式错误！");
                    imgXTxt.Text = imgX.ToString();
                    imgYTxt.Text = imgY.ToString();
                    imgPTxt.Text = imgP.ToString();
                    imgRankNum.Value = imgRank;

                    imgXTxt.ReadOnly = true;
                    imgYTxt.ReadOnly = true;
                    imgPTxt.ReadOnly = true;
                    imgRankNum.ReadOnly = true;
                    memTxt.ReadOnly = true;
                    ///clearNumDown.Value = clearNum;
                    return;
                }

                imgX = a;
                imgY = b;
                imgP = c;
                imgRank = (int)imgRankNum.Value;
                //clearNum = (int)clearNumDown.Value;
                memSize = d;
                sr.memSize = memSize;
                pictureTimer.Interval = (int)(imgP * (double)1000);
                imgXTxt.ReadOnly = true;
                imgYTxt.ReadOnly = true;
                imgPTxt.ReadOnly = true;
                imgRankNum.ReadOnly = true;
                memTxt.ReadOnly = true;
                //clearNumDown.ReadOnly = true;
            }
            else
            {
                imgXTxt.ReadOnly = false;
                imgYTxt.ReadOnly = false;
                imgPTxt.ReadOnly = false;
                imgRankNum.ReadOnly = false;
                memTxt.ReadOnly = false;
                //clearNumDown.ReadOnly = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            //开始监控
            if (checkBox3.Checked)
            {
                pictureTimer.Interval = (int)(imgP * (double)1000);
                pictureTimer.Enabled = true;
                pictureTimer_Tick(sender, e);
            }
            else
            {
                pictureTimer.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "AutoSize")
            {
                splitContainer1.Panel2.AutoScrollMinSize = new Size(1366, 768);
                splitContainer1.Panel2.AutoScroll = true;
            }
            else
            {
                splitContainer1.Panel2.AutoScrollMinSize = new Size(0, 0);
                splitContainer1.Panel2.AutoScroll = false;
            }

            int ca = 1;
            switch (comboBox1.Text)
            {
                case "Zoom": ca = 4; break;
                case "StretchImage": ca = 1; break;
                case "Normal": ca = 0; break;
                case "CenterImage": ca = 3; break;
                case "AutoSize": ca = 2; break;
            }

            pcImageBox.SizeMode = (PictureBoxSizeMode)ca;
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.TopMost = true;
            hf.Show();
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.AutoScrollMinSize = new Size(0, 0);
            splitContainer1.Panel2.AutoScroll = false;
            pcImageBox.SizeMode = (PictureBoxSizeMode)4;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.AutoScrollMinSize = new Size(0, 0);
            splitContainer1.Panel2.AutoScroll = false;

            pcImageBox.SizeMode = (PictureBoxSizeMode)1;
        }

        private void normalCenterImageAutoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.AutoScrollMinSize = new Size(0, 0);
            splitContainer1.Panel2.AutoScroll = false;
            pcImageBox.SizeMode = (PictureBoxSizeMode)0;
        }

        private void autoSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.AutoScrollMinSize = new Size(1366, 768);
            splitContainer1.Panel2.AutoScroll = true;
            pcImageBox.SizeMode = (PictureBoxSizeMode)2;
        }

        private void centerImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.AutoScrollMinSize = new Size(0, 0);
            splitContainer1.Panel2.AutoScroll = false;
            pcImageBox.SizeMode = (PictureBoxSizeMode)3;
        }

        private void 更新图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureTimer_Tick(sender, e);
        }

        private void pcImageBox_SizeChanged(object sender, EventArgs e)
        {
            if (pcImageBox.Size.Height < 250)
            {
                msgTab.Visible = true;
                clearMsgBtn.Visible = true;
            }
            else
            {
                msgTab.Visible = false;
                clearMsgBtn.Visible = false;
            }
        }

        private void clearMsgBtn_Click(object sender, EventArgs e)
        {
            msgs.Clear();
            msgList.Items.Clear();
        }

        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pcImageBox.Image == null)
            {
                MessageBox.Show("现在屏幕没有图像！");
                return;
            }
            saveFileDialog1.FileName = DateTime.Now.ToString("yyMM_ddHH_mmss");
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] temps = saveFileDialog1.FileName.Split('.');
                string format = temps[temps.Length - 1];

                System.Drawing.Imaging.ImageFormat iformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                switch (format)
                {
                    case "jpg": iformat = System.Drawing.Imaging.ImageFormat.Jpeg; break;
                    case "bmp": iformat = System.Drawing.Imaging.ImageFormat.Bmp; break;
                    case "png": iformat = System.Drawing.Imaging.ImageFormat.Png; break;
                    case "gif": iformat = System.Drawing.Imaging.ImageFormat.Gif; break;
                    default: break;
                }

                Image sImg = pcImageBox.Image;
                sImg.Save(saveFileDialog1.FileName, iformat);
            }
        }

        private void 全屏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.Size = new Size(923, 713);
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }
            this.Visible = true;
        }

        private void controlCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (controlCheck.Checked)
            {
                controlMouseKey = true;
                pcImageBox.ContextMenuStrip = null;
            }
            else
            {
                controlMouseKey = false;
                pcImageBox.ContextMenuStrip = picConMenuStrip;
            }
        }

        /// <summary>
        /// 是否键盘操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void keyBdCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (keyBdCheck.Checked)
            {
                cmdTxt.Text = "";
            }
        }

        private void allIpCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
                serverTxt.Text = allIpCBox.Text.Split(' ')[0];
        }

        private void cmdTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                if (cmdIndex > 0)
                {
                    cmdIndex--;
                    cmdTxt.Text = cmds[cmdIndex];
                    cmdTxt.SelectionStart = cmdTxt.Text.Length;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                if (cmdIndex < cmds.Count - 1)
                {
                    cmdIndex++;
                    cmdTxt.Text = cmds[cmdIndex];
                    cmdTxt.SelectionStart = cmdTxt.Text.Length;
                }
            }

            if (keyBdCheck.Checked)
            {
                keyStr += e.KeyValue + "-";
            }
            /*
            string[] ss = cmdTxt.Text.Split('#');
            if (ss[0] == "keyevent" && ss.Length == 2 && !e.Shift && !e.Control && !e.Alt)
            {
                e.Handled = true;
                cmdTxt.Text += e.KeyValue.ToString();
                cmdTxt.SelectionStart = cmdTxt.Text.Length;
            }*/
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void msgList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = msgList.SelectedIndex;

            msgTxt.Text = msgList.Items[i].ToString();
            msgTab.SelectedIndex = 0;
        }

        private void imgRankNum_ValueChanged(object sender, EventArgs e)
        {
            int i = (int)imgRankNum.Value;
            imgXTxt.Text = (366 + i * 100).ToString();
            imgYTxt.Text = (208 + i * 56).ToString();
        }

        private void fileOperList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = fileOperList.SelectedIndex;

            msgTxt.Text = fileOperList.Items[i].ToString();
            msgTab.SelectedIndex = 0;
        }

        #endregion

        #region 鼠标远程控制事件

        private void pcImageBox_MouseEnter(object sender, EventArgs e)
        {
            showCurTimer.Enabled = true;
        }

        private void pcImageBox_MouseLeave(object sender, EventArgs e)
        {
            showCurTimer.Enabled = false;
        }

        private void pcImageBox_MouseClick(object sender, MouseEventArgs e)
        {
            string str;
            if (controlMouseKey)
            {
                string i = "0";
                if (cursorMoveCheck.Checked)
                    i = "1";
                if (e.Button == MouseButtons.Left)
                {
                    str = "mouseevent#2#" + curLocLab.Text + "#1#" + i;
                    sr.sendStr(str);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    str = "mouseevent#8#" + curLocLab.Text + "#1#" + i;
                    sr.sendStr(str);
                }
            }
        }

        private void pcImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (cursorMoveCheck.Checked && controlMouseKey)
            {
                string str = "cursor#" + curLocLab.Text;
                sr.sendStr(str);
            }
        }

        private void pcImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (controlMouseKey)
            {
                string i = "0";
                string str;
                if (cursorMoveCheck.Checked)
                    i = "1";
                if (e.Button == MouseButtons.Left)
                {
                    str = "dmouseevent#2#3";// + curLocLab.Text + "#3#" + i;
                    sr.sendStr(str);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    str = "dmouseevent#8#3";// +curLocLab.Text + "#3#" + i;
                    sr.sendStr(str);
                }
            }*/
        }

        private void pcImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            /*if (controlMouseKey)
            {
                string i = "0";
                string str;
                if (cursorMoveCheck.Checked)
                    i = "1";
                if (e.Button == MouseButtons.Left)
                {
                    str = "dmouseevent#2#0";// +curLocLab.Text + "#0#" + i;
                    sr.sendStr(str);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    str = "dmouseevent#8#0";// +curLocLab.Text + "#0#" + i;
                    sr.sendStr(str);
                }
            }*/
        }

        #endregion

        #region 定时器事件

        private void netTimer_Tick(object sender, EventArgs e)
        {
            string resStr = "";
            if (sr.recOk)
            {
                resStr = sr.recStr;
                sr.recOk = false;
                dealRec(resStr);
            }
        }

        private void pictureTimer_Tick(object sender, EventArgs e)
        {
            string str = "getPicNon";
            if (!imgDefCheck.Checked)
            {
                str = "getPic#" + imgX.ToString() + "#" + imgY.ToString() + "#" + imgRank.ToString();
            }

            sr.needPic = true;

            sr.sendStr(str);

            string te = "定时请求图片等待中……  时间" + DateTime.Now.ToString();
            sendStrLabel.Text = te;

            msgs.Add((msgs.Count + 1).ToString() + "、发送命令： " + str + "        " + te);
            msgList.Items.Add(msgs[msgs.Count - 1]);

            if (msgList.SelectedIndex > msgList.Items.Count - 10)
                msgList.SelectedIndex = msgList.Items.Count - 1;

            cmdTimes++;
            cmdTimeLabel.Text = cmdTimes.ToString();
            curTimes++;
            curTimeLabel.Text = curTimes.ToString();

            //内存使用过大而终止重启
            /*if (curTimes == clearNum)
            {
                sr.sendStr("reNewSelf#c://windows//PCMonitor.exe");
                curTimes = 0;
                curTimeLabel.Text = curTimes.ToString();
            }*/
        }

        /// <summary>
        /// 获取鼠标位置定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showCurTimer_Tick(object sender, EventArgs e)
        {
            if (pcImageBox.Image == null)
                return;

            remoteMaxSize = pcImageBox.Image.Size;

            thisSize = this.Size;

            thisLoc = this.Location;

            picBoxSize = new Size(pcImageBox.Width, pcImageBox.Height);

            picBoxLoc.X = thisLoc.X;
            picBoxLoc.Y = thisLoc.Y + thisSize.Height - picBoxSize.Height;

            curPos = Cursor.Position;
            remotePos.X = (curPos.X - picBoxLoc.X) * remoteMaxSize.Width / picBoxSize.Width - 3;
            remotePos.Y = (curPos.Y - picBoxLoc.Y) * remoteMaxSize.Height / picBoxSize.Height + 5;

            curLocLab.Text = remotePos.X.ToString() + "#" + remotePos.Y.ToString();
        }

        /// <summary>
        /// 获取图片定时器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picNetTimer_Tick(object sender, EventArgs e)
        {
            if (sr.picOK)
            {
                dealPicturre(sr.pic);
                sr.picOK = false;
            }
        }

        #endregion

        #region 计划任务部分

        private void taskBtn_Click(object sender, EventArgs e)
        {
            TaskForm tf = new TaskForm(tasks, taskExcute);
            tf.ShowDialog();
            if (tf.isOk)
            {
                tasks.Clear();
                tasks = tf._tasks;
                taskExcute = tf.taskExe;

                taskTimer.Enabled = taskExcute;
            }
        }

        private void taskTimer_Tick(object sender, EventArgs e)
        {
            string nowTime = DateTime.Now.ToString("dd HH-mm-ss");
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].time == nowTime)
                {
                    sr.sendStr(tasks[i].cmd);
                    tasks[i].complete = "已执行";
                }
            }
        }

        #endregion

        #region 文件传输操作部分

        private void scanBtn_Click(object sender, EventArgs e)
        {
            if (sendOpenFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sendUrlTxt.Text = sendOpenFileDialog1.FileName;
            }
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (sendUrlTxt.Text == "")
            {
                MessageBox.Show("请选择发送文件！");
                return;
            }

            if (recUrlTxt.Text == "")
            {
                MessageBox.Show("请输入接收命令文件！");
                return;
            }
            sr.sendStr("setAtt◇RecBytes◇" + sendBytesTxt.Text);
            sr.sendStr("setAtt◇RecSleep◇" + sendRecSleepTxt.Text);
            SendBytes = int.Parse(sendBytesTxt.Text);
            SendOk = false;

            Thread.Sleep(30);
            sr.sendStr("receiveFile◇" + recUrlTxt.Text);
            Thread.Sleep(10);

            ThreadPool.QueueUserWorkItem(new WaitCallback(sendFile), sendUrlTxt.Text);

            sendBtn.Enabled = false;
            stopBtn.Enabled = true;

            fileOperList.Items.Add("发送：  " + sendUrlTxt.Text + "\r\n到  " + sr.server + "  的  " + recUrlTxt.Text + "\r\n" + DateTime.Now.ToString());
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            SendOk = true;
            Thread.Sleep(12);
            sr.sendStr("setAtt#RecOk#True");
            stopBtn.Enabled = false;
            sendBtn.Enabled = true;

            fileOperList.Items.Add("停止发送：  " + sendUrlTxt.Text + "\r\n到  " + sr.server + "  的  " + recUrlTxt.Text + "\r\n" + DateTime.Now.ToString());
        }

        private void scan2Btn_Click(object sender, EventArgs e)
        {
            if (getSaveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                localSaveTxt.Text = getSaveFileDialog2.FileName;
            }
        }

        private void getFileBtn_Click(object sender, EventArgs e)
        {
            if (localSaveTxt.Text == "")
            {
                MessageBox.Show("请选择保存路径！");
                return;
            }

            if (reSendTxt.Text == "")
            {
                MessageBox.Show("请输入要获取的远程文件路径！");
                return;
            }

            sr.sendStr("setAtt◇SendBytes◇" + getBytesTxt.Text);
            sr.sendStr("setAtt◇SendOk◇False");
            RecBytes = int.Parse(getBytesTxt.Text);
            RecSleep = int.Parse(getRecSleepTxt.Text);
            RecOk = false;

            Thread.Sleep(30);
            sr.sendStr("sendFile◇" + reSendTxt.Text);//发送请求文件
            Thread.Sleep(10);

            ThreadPool.QueueUserWorkItem(new WaitCallback(receiveFile), localSaveTxt.Text);

            getStopBtn.Enabled = true;
            getFileBtn.Enabled = false;

            fileOperList.Items.Add("获取：  " + sendUrlTxt.Text + "\r\n到  " + sr.server + "  的  " + recUrlTxt.Text + "\r\n" + DateTime.Now.ToString());
        }

        private void getStopBtn_Click(object sender, EventArgs e)
        {
            sr.sendStr("setAtt#SendOk#True");
            Thread.Sleep(12);
            RecOk = true;
            getStopBtn.Enabled = false;
            getFileBtn.Enabled = true;

            fileOperList.Items.Add("停止获取：  " + sendUrlTxt.Text + "\r\n到  " + sr.server + "  的  " + recUrlTxt.Text + "\r\n" + DateTime.Now.ToString());
        }

        #endregion
    }

    public class Task
    {
        string tno;
        string tname;
        string ttime;
        string tcmd;
        string tremain;
        string tcomplete;

        #region

        public string no
        {
            get { return tno; }
            set { tno = value; }
        }
        public string name
        {
            get { return tname; }
            set { tname = value; }
        }
        public string time
        {
            get { return ttime; }
            set { ttime = value; }
        }
        public string cmd
        {
            get { return tcmd; }
            set { tcmd = value; }
        }
        public string remain
        {
            get { return tremain; }
            set { tremain = value; }
        }
        public string complete
        {
            get { return tcomplete; }
            set { tcomplete = value; }
        }

        public Task(string no, string name, string time, string cmd, string remain, string complete)
        {
            tno = no;
            tname = name;
            ttime = time;
            tcmd = cmd;
            tremain = remain;
            tcomplete = complete;
        }

        public void SetTask(string no, string name, string time, string cmd, string remain, string complete)
        {
            tno = no;
            tname = name;
            ttime = time;
            tcmd = cmd;
            tremain = remain;
            tcomplete = complete;
        }

        #endregion
    }
}
