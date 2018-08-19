using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mshtml;
using System.Threading;

namespace DynBrowser
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 定时计划文件
        /// </summary>
        string taskFile = "task.dat";

        /// <summary>
        /// 评论日志文件
        /// </summary>
        string logFile = "cuser.log";

        /// <summary>
        /// 指定来自
        /// </summary>
        string fromFile = "from.txt";

        /// <summary>
        /// 排重过期时间
        /// </summary>
        int dayOut = 7;

        /// <summary>
        /// 已经评论过的，需要排重的用户名
        /// </summary>
        HashSet<string> haveUsers = new HashSet<string>();

        /// <summary>
        /// 发送来自判断包含
        /// </summary>
        List<string> allPassFrom = new List<string>();

        /// <summary>
        /// 评论数据
        /// </summary>
        List<string> comments = new List<string>();

        /// <summary>
        /// 计划任务对象
        /// </summary>
        TimerAct timerAct = new TimerAct();

        public MainForm()
        {
            try
            {
                InitializeComponent();
                webBrowser.Navigate("about:blank");
            }
            catch (Exception ee)
            {
                statusLab.Text = "Err:" + ee.Message;
            }
        }

        /// <summary>
        /// 窗口初始化，读取配置文件，初始化任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            List<string> list = Util.readListTxt(taskFile);
            foreach (string l in list)
            {
                if (l != "")
                {
                    Act act = new Act(l);
                    timerAct.acts.Add(act);
                }
            }

            //初始化需要排重叠数据
            List<string> cUsers = Util.readListTxt(logFile);
            foreach (string c in cUsers)
            {
                string[] infos = c.Split('\t');
                if (infos.Length == 7)
                {
                    try
                    {
                        int y = int.Parse(infos[0].Substring(0, 4));
                        int m = int.Parse(infos[0].Substring(5, 2));
                        int d = int.Parse(infos[0].Substring(8, 2));
                        DateTime t = new DateTime(y, m, d);
                        t = t.AddDays(dayOut);
                        if (t.CompareTo(DateTime.Now) >= 0)
                        {
                            haveUsers.Add(infos[5]);
                        }
                    }
                    catch { }
                }
            }

            //初始化需要指定来自数据
            List<string> froms = Util.readListTxt(fromFile);
            foreach (string c in froms)
            {
                if (c.Trim() != "")
                {
                    allPassFrom.Add(c);
                }
            }

            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// 显示静态栏内容
        /// </summary>
        /// <param name="txt"></param>
        void showStatus(string txt)
        {
            weiboStatusLab.Text = txt;
            this.statusStrip1.Refresh();
        }

        /// <summary>
        /// 显示timer的内容
        /// </summary>
        /// <param name="txt"></param>
        void showTimerStatus(string txt)
        {
            timerStatusLab.Text = noTxt.Text +":" + txt;
            
            if (txt.Contains("不满足条件"))
            {
                timerStatusLab.ForeColor = Color.Red;
            }
            else
            {
                timerStatusLab.ForeColor = Color.Green;
            }
            this.statusStrip1.Refresh();
        }

        #region 浏览器基本事件

        /// <summary>
        /// 前进后退按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void urlBtn_Click(object sender, EventArgs e)
        {
            string act = ((ToolStripButton)sender).Name.Contains("back") ? "back" : "forward";

            if (act == "back" && webBrowser.CanGoBack)
            {
                webBrowser.GoBack();
            }
            else if (act == "front" && webBrowser.CanGoForward)
            {
                webBrowser.GoForward();
            }
        }

        /// <summary>
        /// Go按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void goToolStripButton3_Click(object sender, EventArgs e)
        {
            if (urlTxt.Text != "about:blank" && !urlTxt.Text.StartsWith("http://"))
            {
                urlTxt.Text = "http://" + urlTxt.Text;
            }

            try
            {
                String ua = "User-Agent:Mozilla/4.0(MSIE6.0)";
                //webBrowser.Navigate(urlTxt.Text, "_down", null, ua);
                webBrowser.Navigate(urlTxt.Text, null, null, ua);

                //webBrowser.Navigate(urlTxt.Text);
                statusLab.Text = "正在加载。";
            }
            catch (Exception ee)
            {
                statusLab.Text = "Err:" + ee.Message;
            }
        }

        /// <summary>
        /// 页面完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            statusLab.Text = "完成";
            this.Text = webBrowser.Document.Title + " - DynBrowser";
        }

        /// <summary>
        /// 显示进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            int max = (int)e.MaximumProgress;
            int now = (int)e.CurrentProgress;
            now = (now == -1) ? 0 : now;
            now = (now > max) ? max : now;
            progressBar.Maximum = max;
            progressBar.Value = now;
        }

        /// <summary>
        /// 改变url地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            string newUrl = e.Url.AbsoluteUri;
            if (newUrl.StartsWith("http://") && webBrowser.Url.AbsoluteUri != newUrl)
            {
                urlTxt.Text = e.Url.AbsoluteUri;
            }
        }

        /// <summary>
        /// 新窗口事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            string url = ((WebBrowser)sender).StatusText;
            if (url.Contains("等待"))
            {
                url = url.Replace("等待", "").Trim();
            }
            try
            {
                webBrowser.Navigate(url);
            }
            catch (Exception e1) { statusLab.Text = e1.Message; }
        }

        /// <summary>
        /// 关闭窗口清楚cookie，保存task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (webBrowser != null && webBrowser.Document.Cookie != null)
            {
                webBrowser.Document.Cookie.Remove(0, webBrowser.Document.Cookie.Length);
            }

            string content = "";
            foreach (Act act in timerAct.acts)
            {
                content += act.getContent() + "\r\n";
            }
            Util.writeTxt(taskFile, content);
        }

        #endregion

        #region 微博操作

        /// <summary>
        /// 打开微博页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openWeiboBtn_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser.Navigate("http://weibo.com");
                showStatus("打开微博：" + "http://weibo.com");
            }
            catch (Exception ee)
            {
                statusLab.Text = "Err:" + ee.Message;
            }
        }

        /// <summary>
        /// 设置用户密码并提交
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loginBtn_Click(object sender, EventArgs e)
        {
            HtmlElementCollection inputs = webBrowser.Document.GetElementsByTagName("input");
            foreach (HtmlElement input in inputs)
            {
                if (input.GetAttribute("name") == "loginname")
                {
                    input.InnerText = userTxt.Text;
                }
                else if (input.GetAttribute("name") == "password")
                {
                    input.InnerText = pwdTxt.Text;
                }
            }

            inputs = webBrowser.Document.GetElementsByTagName("a");
            foreach (HtmlElement input in inputs)
            {
                if (input.GetAttribute("node-type") == "submit")
                {
                    input.InvokeMember("click");
                    showStatus("登录微博：" + userTxt.Text);
                    break;
                }
            }
        }

        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchBtn2_Click(object sender, EventArgs e)
        {
            /*
                        HtmlElement input = webBrowser.Document.GetElementFromPoint(new Point(636, 20));
                        input.Focus();
                        Thread.Sleep(500);
                        input.InnerText = searchTxt.Text;

                        input = webBrowser.Document.GetElementFromPoint(new Point(835, 20));
                        input.InvokeMember("click");
                        weiboStatusLab.Text = "搜索微博：" + searchTxt.Text;
                        */

            HtmlElement sDiv = null;

            HtmlElementCollection divs = webBrowser.Document.Body.GetElementsByTagName("div");
            showStatus("查找div中className： gn_search");
            foreach (HtmlElement input in divs)
            {
                string className = input.GetAttribute("className");
                if (className.Contains("gn_search") || className.Trim() == "search")
                {
                    sDiv = input;
                    showStatus("找到div中className： gn_search");
                    break;
                }
            }

            if (sDiv == null)
            {
                statusLab.Text = "获取搜索框出错，请报告开发人员。";
                weiboTimer.Enabled = false;
                return;
            }

            HtmlElementCollection inputs = sDiv.GetElementsByTagName("input");
            showStatus("查找input中node-type： searchInput");
            this.Refresh();
            foreach (HtmlElement input in inputs)
            {
                if (input.GetAttribute("node-type") == "searchInput")
                {
                    showStatus("找到input中node-type： searchInput");
                    input.Focus();
                    Thread.Sleep(500);
                    input.InnerText = searchTxt.Text;
                    break;
                }
            }

            inputs = sDiv.GetElementsByTagName("a");
            showStatus("查找a中node-type： searchSubmit");
            foreach (HtmlElement input in inputs)
            {
                if (input.GetAttribute("node-type") == "searchSubmit")
                {
                    input.InvokeMember("click");
                    showStatus("搜索微博结果：" + searchTxt.Text);
                    break;
                }
            }

            //初始化评论数据
            List<string> cs = Util.readListTxt("comment/" + searchTxt.Text + ".txt");
            comments.Clear();
            foreach (string c in cs)
            {
                if (c.Trim() != "")
                {
                    comments.Add(c);
                }
            }
        }

        /// <summary>
        /// 打开评论
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFeedBtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            HtmlElementCollection tdls = webBrowser.Document.GetElementsByTagName("dl");
            foreach (HtmlElement dl in tdls)
            {
                if (dl.GetAttribute("action-type") == "feed_list_item")
                {
                    if (i++ < int.Parse(noTxt.Text))
                    {
                        continue;
                    }

                    HtmlElementCollection tas = dl.GetElementsByTagName("a");

                    foreach (HtmlElement ta in tas)
                    {
                        if (ta.GetAttribute("action-type") == "feed_list_comment")
                        {
                            ta.InvokeMember("click");
                            showStatus("打开评论：" + i);
                            commentStateLab.Text = "true";
                            return;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 提交评论
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (commentStateLab.Text != "true")
            {
                showStatus("打开状态为false，不评论");
                return;
            }
            commentStateLab.Text = "false";
            
            int i = 0;
            Thread.Sleep(5000);
            HtmlElementCollection tdls = webBrowser.Document.GetElementsByTagName("dl");
            foreach (HtmlElement dl in tdls)
            {
                if (dl.GetAttribute("action-type") == "feed_list_item")
                {
                    if (i++ < int.Parse(noTxt.Text))
                    {
                        continue;
                    }

                    string nickname = "";

                    HtmlElementCollection ps = dl.GetElementsByTagName("p");

                    showStatus("查找a中node-type： feed_list_content");
                    //获取评论的用户名p
                    foreach (HtmlElement p in ps)
                    {
                        if (p.GetAttribute("node-type") == "feed_list_content")
                        {
                            HtmlElementCollection aes = p.GetElementsByTagName("a");
                            //获取评论的用户名nick-name
                            showStatus("获取nick-name");
                            foreach (HtmlElement a in aes)
                            {
                                string nick = a.GetAttribute("nick-name");
                                if (nick != null || nick != "")
                                {
                                    nickname = nick;
                                    break;
                                }
                            }
                            break;
                        }
                    }

                    showStatus("获取评论的用户：" + nickname);
                    //排重最近一评论过的用户
                    if (haveUsers.Contains(nickname))
                    {
                        showStatus("评论的用户在" + dayOut + "天内已经评论过，不再评论：" + nickname);
                        return;
                    }

                    //设置评论内容
                    HtmlElementCollection ttextareas = dl.GetElementsByTagName("textarea");

                    foreach (HtmlElement text in ttextareas)
                    {
                        if (text.GetAttribute("node-type") == "textEl")
                        {
                            text.InnerText = contentTxt.Text;
                            break;
                        }
                    }

                    //点击评论
                    HtmlElementCollection tems = dl.GetElementsByTagName("em");

                    foreach (HtmlElement em in tems)
                    {
                        if (em.GetAttribute("node-type") == "btnText")
                        {
                            em.InvokeMember("click");
                            showStatus("提交评论：" + contentTxt.Text);
                            commentStateLab.Text = "true";
                            break;
                        }
                    }

                    if (commentStateLab.Text == "true")
                    {
                        //添加排重
                        haveUsers.Add(nickname);
                        string log = DateTime.Now.ToString() + "\t" + userTxt.Text + "\t" + searchTxt.Text + "\t" + pageTxt.Text + "\t" + noTxt.Text + "\t" + nickname + "\t" + contentTxt.Text + "\r\n";
                        Util.appendTxt(logFile, log);
                    }

                    break;
                }
            }
        }

        /// <summary>
        /// 改变评论状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noTxt_TextChanged(object sender, EventArgs e)
        {
            commentStateLab.Text = "false";
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pageBtn_Click(object sender, EventArgs e)
        {
            int page = 0;
            try
            {
                page = int.Parse(pageTxt.Text);
            }
            catch
            {
                showStatus("翻页必须为数字！");
                return;
            }

            if (page < 0)
            {
                showStatus("翻页不能小于0" + page);
                return;
            }

            string url = "http://s.weibo.com/weibo/" + searchTxt.Text + "&b=1&page=" + page;

            try
            {
                webBrowser.Navigate(url);
                showStatus("翻页:" + url);
            }
            catch (Exception ee)
            {
                statusLab.Text = "Err:" + ee.Message;
            }
        }

        #endregion

        #region 定时控制

        /// <summary>
        /// 定时控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerClick_Tick(object sender, EventArgs e)
        {
            weiboTimer.Enabled = false;

            weiboProgressBar.Value = Math.Min(weiboProgressBar.Maximum, timerAct.getIndex());

            Act act = timerAct.getNowAct();

            if (act == null)
            {
                showStatus("没有任务可执行了。定时任务结束");
                weiboTimer.Interval = 50;
                onoffTimerToolStripMenuItem.Text = "启动定时";

                return;
            }

            stepLab.Text = act.getContent().Replace("\t", " ");
            this.Refresh();

            //延时一定时间
            if (!act.isSleep)
            {
                weiboTimer.Interval = act.interval;
                act.isSleep = true;
                //showTimerStatus("延时：" + act.interval);
                
                weiboTimer.Enabled = true;
                return;
            }
            else
            {
                if (act.act == "set")//设置内容
                {
                    switch (act.mainArg)
                    {
                        case "用户名": userTxt.Text = act.viceArg; break;
                        case "密码": pwdTxt.Text = act.viceArg; break;
                        case "搜索内容": searchTxt.Text = act.viceArg; break;
                        case "页码":
                            if (act.viceArg == "++")
                            {
                                pageTxt.Text = int.Parse(pageTxt.Text) + 1 + "";
                            }
                            else
                            {
                                pageTxt.Text = act.viceArg;
                            }
                            break;
                        case "评论第几个":
                            if (act.viceArg == "++")
                            {
                                noTxt.Text = int.Parse(noTxt.Text) + 1 + "";
                            }
                            else
                            {
                                noTxt.Text = act.viceArg;
                            }
                            break;
                        case "评论内容":
                            string comment = "";
                            try
                            {
                                if (act.viceArg.Trim() == "随机")
                                {
                                    Random r = new Random();
                                    comment = comments[r.Next(comments.Count)];
                                }
                                else
                                {
                                    comment = comments[int.Parse(act.viceArg)];
                                }
                            }
                            catch(Exception e1)
                            {
                                showStatus("出错了：" + e1.Message);
                                comment = act.viceArg;
                            }
                            contentTxt.Text = comment;
                            break;
                    }
                    showStatus(act.getContent().Replace("\t", " "));
                    timerAct.addIndex();
                }
                else if (act.act == "click")//执行点击
                {
                    switch (act.mainArg)
                    {
                        case "打开微博": openWeiboBtn_Click(sender, e); break;
                        case "登录": loginBtn_Click(sender, e); break;
                        case "搜索": searchBtn2_Click(sender, e); break;
                        case "翻页": pageBtn_Click(sender, e); break;
                        case "打开评论": openFeedBtn_Click(sender, e); break;
                        case "发表评论": submitBtn_Click(sender, e); break;
                    }
                    showStatus(act.getContent().Replace("\t", " "));
                    timerAct.addIndex();
                }
                else if (act.act == "other")
                {
                    timerAct.addIndex();
                }
                else if (act.act == "gostep")
                {
                    //gostep条件判断
                    string condition = act.viceArg;
                    string a = "";
                    if (condition.Contains("页码"))
                    {
                        a = pageTxt.Text;
                        condition = condition.Replace("页码", "");
                    }
                    else if (condition.Contains("评论第几个"))
                    {
                        a = noTxt.Text;
                        condition = condition.Replace("评论第几个", "");
                    }

                    if (condition.Trim() == "已评论过")
                    {
                        haveComment(act);
                    }
                    else if (condition.Trim() == "不是指定来自")
                    {
                        filterFrom(act);
                    }
                    else
                    {
                        bool res = false;
                        if (a == "")
                        {
                            showStatus("gostep 判断A为空，跳过");
                            timerAct.addIndex();
                        }
                        else
                        {
                            if (condition.Contains(">="))
                            {
                                if (int.Parse(a) >= int.Parse(condition.Replace(">=", "").Trim()))
                                {
                                    res = true;
                                }
                            }
                            else if (condition.Contains("<="))
                            {
                                if (int.Parse(a) <= int.Parse(condition.Replace("<=", "").Trim()))
                                {
                                    res = true;
                                }
                            }
                            else if (condition.Contains(">"))
                            {
                                if (int.Parse(a) > int.Parse(condition.Replace(">", "").Trim()))
                                {
                                    res = true;
                                }
                            }
                            else if (condition.Contains("<"))
                            {
                                if (int.Parse(a) < int.Parse(condition.Replace("<", "").Trim()))
                                {
                                    res = true;
                                }
                            }
                            else if (condition.Contains("="))
                            {
                                if (int.Parse(a) == int.Parse(condition.Replace("=", "").Trim()))
                                {
                                    res = true;
                                }
                            }
                            //条件满足，跳转
                            if (res)
                            {
                                int s = 0;
                                try
                                {
                                    s = int.Parse(act.mainArg);
                                    showStatus("满足条件：" + act.viceArg + " 跳转：" + int.Parse(act.mainArg));
                                    timerAct.setIndex(int.Parse(act.mainArg));
                                }
                                catch { showStatus("主参数跳转布编号，需要为数字：" + act.mainArg); }
                            }
                            else
                            {
                                timerAct.addIndex();
                                showStatus("不满足条件，直接下一步");
                            }
                        }
                    }
                }
            }
            weiboTimer.Interval = 50;
            weiboTimer.Enabled = true;
        }

        /// <summary>
        /// 定时控制管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerManToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimerForm tf = new TimerForm(timerAct);
            tf.ShowDialog();

            timerAct.acts.Clear();
            foreach (Act act in tf.getTimerAct().acts)
            {
                Act n = new Act(act.getContent());
                timerAct.acts.Add(n);
            }
            tf.Dispose();
        }

        /// <summary>
        /// 启动暂停定时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onoffTimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onoffTimerToolStripMenuItem.Text == "启动定时")
            {
                weiboTimer.Enabled = true;
                weiboProgressBar.Maximum = timerAct.acts.Count;
                onoffTimerToolStripMenuItem.Text = "暂停定时";
                showStatus(weiboStatusLab.Text = "启动定时");
            }
            else if (onoffTimerToolStripMenuItem.Text == "暂停定时")
            {
                weiboTimer.Enabled = false;
                onoffTimerToolStripMenuItem.Text = "启动定时";
                showStatus(weiboStatusLab.Text = "暂停定时");
            }
        }

        /// <summary>
        /// 重置，从头开始
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerAct.resetIndex();
            weiboTimer.Interval = 50;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("功能：微博自动评论\t\t\r\n\r\n开发：易查数据组\r\n\r\n时间：2012-11-28", "关于本软件");
        }

        #endregion

        #region 方法

        /// <summary>
        /// 处理已评论过
        /// </summary>
        /// <param name="act"></param>
        private void haveComment(Act act)
        {
            HtmlElementCollection tdls = webBrowser.Document.GetElementsByTagName("dl");
            int i = 0;
            foreach (HtmlElement dl in tdls)
            {
                if (dl.GetAttribute("action-type") == "feed_list_item")
                {
                    if (i++ < int.Parse(noTxt.Text))
                    {
                        continue;
                    }

                    string nickname = "";

                    HtmlElementCollection ps = dl.GetElementsByTagName("p");

                    showStatus("查找a中node-type： feed_list_content");
                    //获取评论的用户名p
                    foreach (HtmlElement p in ps)
                    {
                        if (p.GetAttribute("node-type") == "feed_list_content")
                        {
                            HtmlElementCollection aes = p.GetElementsByTagName("a");
                            //获取评论的用户名nick-name
                            showStatus("获取nick-name");
                            foreach (HtmlElement atag in aes)
                            {
                                string nick = atag.GetAttribute("nick-name");
                                if (nick != null || nick != "")
                                {
                                    nickname = nick;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    showStatus("获取评论的用户：" + nickname);
                    //排重最近一评论过的用户
                    if (haveUsers.Contains(nickname))
                    {
                        showStatus("评论的用户在" + dayOut + "天内已经评论过，不再评论：" + nickname);

                        int s = 0;
                        try
                        {
                            s = int.Parse(act.mainArg);
                            showStatus("满足条件：" + act.viceArg + " 跳转：" + int.Parse(act.mainArg));
                            showTimerStatus("满足条件：" + act.viceArg);

                            timerAct.setIndex(int.Parse(act.mainArg));
                        }
                        catch
                        {
                            showStatus("主参数跳转编号，需要为数字：" + act.mainArg);
                            showTimerStatus("不满足条件：" + act.viceArg);
                            timerAct.addIndex();
                        }
                    }
                    else
                    {
                        showStatus("不满足条件：" + act.viceArg);
                        showTimerStatus("不满足条件：" + act.viceArg);
                        timerAct.addIndex();
                    }
                    return;
                }
            }
            showStatus("未找到第几个评论：" + noTxt.Text);
            timerAct.addIndex();
        }

        /// <summary>
        /// 过滤来自
        /// </summary>
        /// <param name="act"></param>
        private void filterFrom(Act act)
        {
            int i = 0;
            HtmlElementCollection tdls = webBrowser.Document.GetElementsByTagName("dl");
            foreach (HtmlElement dl in tdls)
            {
                if (dl.GetAttribute("action-type") == "feed_list_item")
                {
                    if (i++ < int.Parse(noTxt.Text))
                    {
                        continue;
                    }

                    HtmlElementCollection tas = dl.GetElementsByTagName("a");

                    string from = "";
                    foreach (HtmlElement ta in tas)
                    {
                        if (ta.GetAttribute("rel") == "nofollow")
                        {
                            from = ta.InnerText;
                            //break;
                            //不用break，获取最后一个来自。评论的评论可能有多条来自
                        }
                    }

                    showStatus("获取用户来自：" + from);
                    //排重最近一评论过的用户
                    if (!isContain(allPassFrom, from))
                    {
                        showStatus("评论的用户不是指定来自列表：" + from);

                        int s = 0;
                        try
                        {
                            s = int.Parse(act.mainArg);
                            showStatus("满足条件：" + act.viceArg + " 跳转：" + int.Parse(act.mainArg));
                            showTimerStatus("满足条件：" + act.viceArg);
                            timerAct.setIndex(int.Parse(act.mainArg));
                        }
                        catch
                        {
                            showStatus("主参数跳转编号，需要为数字：" + act.mainArg);
                            showTimerStatus("不满足条件：" + act.viceArg);
                            timerAct.addIndex();
                        }
                    }
                    else
                    {
                        showStatus("不满足条件：" + act.viceArg);
                        showTimerStatus("不满足条件：" + act.viceArg);
                        timerAct.addIndex();
                    }
                    return;
                }
            }
            showStatus("未找到第几个评论：" + noTxt.Text);
            timerAct.addIndex();
        }

        /// <summary>
        /// 判断filter中是否有元素包含from
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        private bool isContain(List<string> filter, string from)
        {
            foreach (string f in filter)
            {
                if (from.Contains(f))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}

