using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.IO;
using YH;

namespace LuckYicha
{
    public partial class LuckForm : Form
    {
        //窗口高宽
        int pW = 1279;
        int pH = 838;

        Random r = new Random();

        int nowRank = 0;
        RankMode[] ranks = new RankMode[5];

        int nowPhone = 0;
        List<string[]> allPhone = new List<string[]>();

        //给查找区域使用
        string[] areas = new string[] {"北京","上海","华北","华东","华南","西南" };
        public static Hashtable phoneArea = new Hashtable();

        //定义一个布尔型标记，用来指示是否开始播放动画。
        bool isStart = false;

        //第一次时初始监听事件
        bool current = false;

        //音乐播放
        clsMCI iniMp = new clsMCI("sound\\ini.mp3", true);
        clsMCI startMp = new clsMCI("sound\\start.mp3", true);
        clsMCI stopMp = new clsMCI("sound\\stop.mp3", false);

        //恭喜图片，燃烧图片
        Bitmap gongxi = Properties.Resources.gongxi;
        Bitmap gongxix = Properties.Resources.gongxix;

        Bitmap back1 = Properties.Resources.back1;
        Bitmap back2 = Properties.Resources.back2;

        public LuckForm()
        {
            InitializeComponent();

            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.Escape);
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.None, Keys.Space);
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.None, Keys.Enter);
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.None, Keys.Back);
            HotKey.RegisterHotKey(Handle, 104, HotKey.KeyModifiers.None, Keys.F4);
            HotKey.RegisterHotKey(Handle, 105, HotKey.KeyModifiers.None, Keys.C);

            HotKey.RegisterHotKey(Handle, 50, HotKey.KeyModifiers.None, Keys.Up);
            HotKey.RegisterHotKey(Handle, 51, HotKey.KeyModifiers.None, Keys.Down);
        }

        private void LuckForm_Load(object sender, EventArgs e)
        {
            iniMp.play();

            if(File.Exists("back1.png")){
                back1 = new Bitmap("back1.png");
            }
            if (File.Exists("back2.png"))
            {
                back2 = new Bitmap("back2.png");
            }

            this.BackgroundImage = back1;

            List<string> all = Util.readListTxtNoEmpty("phone.txt");
            foreach (string a in all)
            {
                string[] infos = a.Split('\t');
                if (infos.Length == 2)
                {
                    allPhone.Add(infos);
                    phoneArea.Add(infos[0], infos[1]);
                }
            }

            List<string> rankinfos = Util.readListTxt("rank.txt");

            foreach (string rank in rankinfos)
            {
                string[] infos = rank.Split('\t');
                if (infos.Length == 4)
                {
                    ranks[int.Parse(infos[0])] = new RankMode(infos);
                }
            }
            nowRank = 0;

            panel_Click(panel5, null);

            luckPanel.Location = new Point(225, 121);

            Util.writeTxt("res.txt", "\r\n--------------------------------------------------\r\n", true);

            areaLab.Text = "　　";

            luckPanel.BringToFront();
        }

        private void LuckForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
            HotKey.UnregisterHotKey(Handle, 102);
            HotKey.UnregisterHotKey(Handle, 103);
            HotKey.UnregisterHotKey(Handle, 104);
            HotKey.UnregisterHotKey(Handle, 105);
            HotKey.UnregisterHotKey(Handle, 50);
            HotKey.UnregisterHotKey(Handle, 51);
        }

        /// <summary>
        /// 重载WbdProc,实现热键响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            //按快捷键
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 100://按下的是ESC
                        {
                            if (panelChoujian.Visible || startEndLab.Text == "开始")
                            {
                                this.Visible = !this.Visible;
                                if (!this.Visible)
                                {
                                    iniMp.Puase();
                                    this.BackgroundImage = back1;
                                    this.startPanel.Visible = false;
                                    this.panelChoujian.Visible = true;


                                    HotKey.UnregisterHotKey(Handle, 101);
                                    HotKey.UnregisterHotKey(Handle, 102);
                                    HotKey.UnregisterHotKey(Handle, 103);
                                    HotKey.UnregisterHotKey(Handle, 104);
                                    HotKey.UnregisterHotKey(Handle, 105);
                                    HotKey.UnregisterHotKey(Handle, 50);
                                    HotKey.UnregisterHotKey(Handle, 51);
                                }
                                else
                                {
                                    iniMp.play();

                                    HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.None, Keys.Space);
                                    HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.None, Keys.Enter);
                                    HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.None, Keys.Back);
                                    HotKey.RegisterHotKey(Handle, 104, HotKey.KeyModifiers.None, Keys.F4);
                                    HotKey.RegisterHotKey(Handle, 105, HotKey.KeyModifiers.None, Keys.C);
                                    HotKey.RegisterHotKey(Handle, 50, HotKey.KeyModifiers.None, Keys.Up);
                                    HotKey.RegisterHotKey(Handle, 51, HotKey.KeyModifiers.None, Keys.Down);
                                }
                            }
                        }
                        break;
                    case 101://按下的是Space
                        {
                            startEndLab_Click(null, null);
                        }
                        break;
                    case 102://按下的是Enter
                        {
                            if (luckPanel.Visible)
                            {
                                luckOkLab_Click(null, null);
                            }
                            else if (startPanel.Visible)
                            {
                                conStartLab_Click(null, null);
                            }
                            else
                            {
                                panelChoujian_Click(null, null);
                            }
                        }
                        break;
                    case 103://按下的是Back
                        {
                            reStartLab_Click(null, null);
                        }
                        break;
                    case 104://按下的是F4
                        {
                            if (MessageBox.Show("关闭后再次打开数据会重置，但是res.txt文件里面有记录，是否关闭？", "是否关闭", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                this.Close();
                                this.Dispose();
                            }
                        }
                        break;
                    case 105://按下的是C
                        {
                            luckListLab_Click(null, null);
                        }
                        break;
                    case 50://按下的是上
                        {
                            if (startEndLab.Text == "开始" && nowRank > 0)
                            {
                                nowRank--;
                                panel_Click(((Panel)this.Controls.Find("panel" + (nowRank + 1), true)[0]), null);
                            }
                        }
                        break;
                    case 51://按下的是下
                        {
                            if (startEndLab.Text == "开始" && nowRank < 4)
                            {
                                nowRank++;
                                panel_Click(((Panel)this.Controls.Find("panel" + (nowRank + 1), true)[0]), null);
                            }
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 窗口大小改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LuckForm_SizeChanged(object sender, EventArgs e)
        {
            int fW = this.Width;
            int fH = this.Height;

            int picW = 0;
            int picH = 0;
            int picX = 0;
            int picY = 0;

            if (fW / (float)fH > pW / (float)pH)
            {
                picH = fH;
                picW = (int)(picH / (float)pH * pW);
                picX = (fW - picW) / 2;
                picY = 0;
            }
            else
            {
                picW = fW;
                picH = (int)(picW / (float)pW * pH);
                picX = 0;
                picY = (fH - picH) / 2;
            }
            //pictureBox1.SetBounds(picX, picY, picW, picH);
        }

        //重写重绘的代码，以便在重绘发生时能够同时绘制GIF动画。
        protected override void OnPaint(PaintEventArgs e)
        {
            /*
            if (!isStart)
            {
                return;
            }

            //如果函数首次调用，将执行IF语句中的内容，再次调用时，将不再执行IF中的语句,防止第二次调用Animate()方法。
            if (!current)
            {
                ImageAnimator.Animate(gongxi, new EventHandler(this.OnFrameChanged));
                current = true;
            }
            ImageAnimator.UpdateFrames();

            if (isGongxi)
            {
                e.Graphics.DrawImage(this.gongxi, new Point(10, 10));
            }*/
        }

        //将绘图区无效，此方法将引发重绘。
        private void GXOnFrameChanged(object o, EventArgs e)
        {
            gongxiPicBox.Invalidate();
            gongxixPicBox.Invalidate();
        }

        /// <summary>
        /// 画恭喜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gongxiPicBox_Paint(object sender, PaintEventArgs e)
        {
            //如果函数首次调用，将执行IF语句中的内容，再次调用时，将不再执行IF中的语句,防止第二次调用Animate()方法。
            if (!current)
            {
                ImageAnimator.Animate(gongxi, new EventHandler(this.GXOnFrameChanged));
                ImageAnimator.Animate(gongxix, new EventHandler(this.GXOnFrameChanged));
                current = true;
            }
            if (!isStart)
            {
                return;
            }

            //ImageAnimator.StopAnimate(gongxi, new EventHandler(this.OnFrameChanged));//停止
            //ImageAnimator.Animate(gongxi, new EventHandler(this.OnFrameChanged));//播放

            ImageAnimator.UpdateFrames();
            if (e.ClipRectangle.Width == 200)
            {
                e.Graphics.DrawImage(gongxix, new Point(10, 10));
            }
            else
            {
                e.Graphics.DrawImage(gongxi, new Point(10, 10));
            }
        }

        /// <summary>
        /// 点击抽奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelChoujian_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = back2;
            this.panelChoujian.Visible = false;

            this.startPanel.Visible = true;
        }

        /// <summary>
        /// 点击开始结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startEndLab_Click(object sender, EventArgs e)
        {
            if (panelChoujian.Visible || luckPanel.Visible)
            {
                return;
            }

            if (startEndLab.Text == "开始")
            {
                if (ranks[nowRank].rankNow >= ranks[nowRank].rankAll)
                {
                    return;
                }
                timer1.Enabled = true;
                startEndLab.Text = " 停 ";

                startMp.play();

                conStartLab.Enabled = false;
                reStartLab.Enabled = false;
            }
            else if (startEndLab.Text.Trim() == "停")
            {
                timer1.Enabled = false;
                startEndLab.Text = "已停";

                stopMp.play();

                areaLab.Text = allPhone[nowPhone][1];

                isStart = true;

                //gongxiPicBox.Visible = true;
                //gongxixPicBox.Visible = true;

                conStartLab.Enabled = true;
                reStartLab.Enabled = true;
            }
        }

        /// <summary>
        /// 定时器开始转动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (++nowPhone >= allPhone.Count)
            {
                nowPhone = 0;
            }
            if (allPhone.Count <= 0) {
                phoneLab.Text = "没有啦！";
                return;
            }
            nowPhone = r.Next(allPhone.Count);
            phoneLab.Text = allPhone[nowPhone][0];
        }

        /// <summary>
        /// 点击选择抽奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panel_Click(object sender, EventArgs e)
        {
            if (startEndLab.Text != "开始")
            {
                return;
            }

            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;

            String name = ((Panel)sender).Name;
            nowRank = int.Parse(name.Substring(name.Length - 1, 1)) - 1;
            PictureBox p = ((PictureBox)this.Controls.Find("pictureBox" + (nowRank + 1), true)[0]);

            showState(ranks[nowRank]);

            p.Visible = true;

            giftPicBox.BackgroundImage = new Bitmap("gift\\" + nowRank + ".png");

            phoneLab.Text = "祝  你  幸  运!";
        }

        /// <summary>
        /// 显示当前状态
        /// </summary>
        /// <param name="str"></param>
        private void showState(RankMode rank)
        {
            string str = rank.rankName + " 已抽" + rank.rankNow + "人 剩余" + (rank.rankAll - rank.rankNow) + "人";
            stateLab.Text = str;
            str = rank.rankGift;
            giftLab.Text = str;
        }

        /// <summary>
        /// 继续抽奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conStartLab_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled || conStartLab.Enabled == false || phoneLab.Text == "没有啦！")
            {
                return;
            }
            iniMp.play();

            ranks[nowRank].rankPeople.Add(areaLab.Text + " " + phoneLab.Text);

            string content = DateTime.Now + "\t" + ranks[nowRank].rankName + "\t" + phoneLab.Text + "\r\n";
            Util.writeTxt("res.txt", content, true);

            ranks[nowRank].rankNow++;
            showState(ranks[nowRank]);
            allPhone.RemoveAt(nowPhone);

            phoneLab.Text = "祝  你  幸  运 !";

            startEndLab.Text = "开始";
            areaLab.Text = "　　";

            reStartLab.Enabled = false;
            conStartLab.Enabled = false;

            isStart = false;

            //gongxiPicBox.Visible = false;
            //gongxixPicBox.Visible = false;
        }

        /// <summary>
        /// 重新抽奖
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reStartLab_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled || reStartLab.Enabled == false || phoneLab.Text == "没有啦！")
            {
                return;
            }

            iniMp.play();

            startEndLab.Text = "开始";

            phoneLab.Text = "祝  你  幸  运 !";
            areaLab.Text = "　　";

            reStartLab.Enabled = false;
            conStartLab.Enabled = false;

            isStart = false;
            //gongxiPicBox.Visible = false;
            //gongxixPicBox.Visible = false;
        }

        /// <summary>
        /// 显示中奖名单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luckListLab_Click(object sender, EventArgs e)
        {
            if (startEndLab.Text != "开始" || panelChoujian.Visible)
            {
                return;
            }

            luckTitleLab.Text = ranks[nowRank].rankName + "中奖名单";

            string lp = "";
            RankMode now = ranks[nowRank];

            List<string> ps = (List<string>)now.rankPeople;
            if (ps != null || ps.Count != 0)
            {
                int i = 0;
                foreach (string p in ps)
                {
                    if (i == 0)
                    {
                        lp += p;
                    }
                    else if (i % 2 == 0 && i > 0)
                    {
                        lp += "\r\n" + p;
                    }
                    else if (i % 2 == 1)
                    {
                        lp += " | " + p;
                    }
                    i++;
                }
                lp += "\r\n";
            }

            luckPeopleLab.Text = lp;
            luckPanel.Visible = true;
        }

        /// <summary>
        /// 点击确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luckOkLab_Click(object sender, EventArgs e)
        {
            luckPanel.Visible = false;
        }
    }
}
