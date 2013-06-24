using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ImageGroup
{
    public partial class MainForm : Form
    {
        string descDirectory = "Config\\DescMode";

        public MainForm()
        {
            InitializeComponent();

            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F1);
        }

        /// <summary>
        /// 启动是加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            DirectoryInfo TheFolder = new DirectoryInfo(descDirectory);

            if (TheFolder.Exists)
            {
                //遍历文件夹
                foreach (FileInfo file in TheFolder.GetFiles())
                {
                    descModeComb.Items.Add(Util.readTxt(file.FullName));
                }
            }

            selectBatDlg.InitialDirectory="ImageRun";
            batPath1Txt.Text = System.Environment.CurrentDirectory + "\\ImageRun\\toXls.bat";
            batPath2Txt.Text = System.Environment.CurrentDirectory + "\\ImageRun\\toJar.bat";
            batPath3Txt.Text = System.Environment.CurrentDirectory + "\\ImageRun\\toXml.bat";
            batPath4Txt.Text = System.Environment.CurrentDirectory + "\\ImageRun\\mergeXls.bat";
            batPath5Txt.Text = System.Environment.CurrentDirectory + "\\ImageRun\\toZoom.bat";
            batPath6Txt.Text = System.Environment.CurrentDirectory + "\\ImageRun\\reName.bat";
        }

        /// <summary>
        /// 打开关键字选择框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showKeyBtn_Click(object sender, EventArgs e)
        {
            KeysForm kForm = new KeysForm(groupKeyTxt.Text);
            kForm.ShowDialog();
            if (kForm.keys != "-1")
            {
                groupKeyTxt.Text = kForm.keys;
            }
            kForm.Dispose();
        }

        /// <summary>
        /// 选择组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (saveBtn.Enabled)
            {
                DialogResult dr = MessageBox.Show("是否保存本条信息并进入下一条？\r\n“是”则保存进入下一条，“否”则不保存进入下一条，“取消”则不进入下一条。", "修改还没有保存提醒！", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    saveBtn_Click(sender, e);
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }

            string path;
            string temp = groupTree.SelectedNode.Text;
            int s = temp.IndexOf('（');
            if (temp.EndsWith("）"))
            {
                path = rootPathTxt.Text + "\\";
                path += groupTree.SelectedNode.Parent.Text + "\\";//分类
                path += temp.Substring(s + 1, temp.Length - s - 2) + "\\";//groupId
                path += temp.Substring(0, s);//txtName
                path += ".txt";
            }
            else
            {
                statusLabel.Text = "加载信息，path:" + temp;
                return;
            }

            showBean(getBean(path));
        }

        /// <summary>
        /// 根据路径获取相应组图信息
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private GroupBean getBean(string path)
        {
            statusLabel.Text = "选择txt路径为：" + path;

            GroupBean gBean = new GroupBean();
            List<string> content = Util.readListTxt(path);
            gBean.GroupPath = path;
            string[] info = path.Split('\\');
            string title = info[info.Length - 1];

            gBean.GroupId = info[info.Length - 2];

            //去除.txt
            gBean.GroupTitle = title.Substring(0, title.Length - 4);
            if (content.Count > 0)
            {
                string[] infos = content[0].Split('\t');
                if (infos.Length == 2)
                {
                    gBean.GroupRank = infos[0];
                    gBean.GroupContent = infos[1];
                }
                else if (infos.Length == 1)
                {
                    gBean.GroupRank = infos[0];
                    gBean.GroupContent = "";
                }
            }
            if (content.Count > 1)
            {
                gBean.GroupKeys = content[1];
            }
            else
            {
                gBean.GroupKeys = "";
            }

            if (content.Count > 2)
            {
                gBean.GroupSrcName = content[2];
            }

            txtPath.Text = path;
            return gBean;
        }

        /// <summary>
        /// 显示组图信息
        /// </summary>
        /// <param name="gBean"></param>
        private void showBean(GroupBean gBean)
        {
            groupNameTxt.Text = gBean.GroupTitle;
            groupDescTxt.Text = gBean.GroupContent;
            groupRankComb.Text = gBean.GroupRank;
            groupKeyTxt.Text = gBean.GroupKeys;
            groupIdTxt.Text = gBean.GroupId;

            groupSrcNameLab.Text = gBean.GroupSrcName;
            descModeComb.Text = "";

            saveBtn.Enabled = false;
        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectPathBtn_Click(object sender, EventArgs e)
        {
            if (selectPathDlg.ShowDialog() == DialogResult.OK)
            {
                refresh(selectPathDlg.SelectedPath);
            }
            else
            {
                statusLabel.Text = "选择目录取消";
            }
        }

        /// <summary>
        /// 刷新处理函数
        /// </summary>
        /// <param name="rootPath"></param>
        private void refresh(string rootPath)
        {
            try
            {
                groupTree.Nodes.Clear();

                //20120409
                DirectoryInfo firsts = new DirectoryInfo(rootPath);
                //car
                foreach (DirectoryInfo first in firsts.GetDirectories())
                {
                    TreeNode cateNode = new TreeNode(first.Name);
                    groupTree.Nodes.Add(cateNode);

                    //豪华汽车
                    foreach (DirectoryInfo second in first.GetDirectories())
                    {
                        string title = "";
                        //txt,获取title
                        foreach (FileInfo third in second.GetFiles())
                        {
                            if (third.Name.EndsWith(".txt"))
                            {
                                title = third.Name;
                                title = title.Substring(0, title.Length - 4);
                            }
                        }

                        if (title == "")
                        {
                            title = second.Name;
                            string path = rootPathTxt.Text + "\\";
                            path += first.Name + "\\";//分类
                            path += title + "\\";//groupId
                            path += title;//txtName
                            path += ".txt";

                            Util.writeTxt(path, "");
                        }

                        TreeNode groupNode = new TreeNode(title + "（" + second.Name + "）");
                        cateNode.Nodes.Add(groupNode);
                    }


                    rootPathTxt.Text = rootPath;
                    statusLabel.Text = "已刷新，目录为：" + rootPath;
                }
            }
            catch
            {
                statusLabel.Text = "刷新目录出错，检查目录是否正确";
            }
        }

        /// <summary>
        /// 下拉框选择组图描述
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void descModeComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupDescTxt.Text = descModeComb.Text;
        }

        /// <summary>
        /// 刷新组图树
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            if (rootPathTxt.Text != "")
                refresh(rootPathTxt.Text);
            else
            {
                statusLabel.Text = "根路径为空，请先导入目录。";
            }
        }

        /// <summary>
        /// 重读
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void readBtn_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == "")
            {
                statusLabel.Text = "请先选择组图再刷新。";
                return;
            }
            showBean(getBean(txtPath.Text));
        }

        /// <summary>
        /// 保存处理函数
        /// </summary>
        /// <param name="bean"></param>
        private void saveGBean(GroupBean bean)
        {
            string content = bean.GroupRank + "\t" + bean.GroupContent + "\r\n" + bean.GroupKeys + "\r\n" + bean.GroupSrcName;

            if (!bean.GroupPath.EndsWith(bean.GroupTitle + ".txt"))
            {
                FileInfo file = new FileInfo(bean.GroupPath);
                string parent = file.DirectoryName;
                bean.GroupPath = parent + "\\" + bean.GroupTitle + ".txt";

                parent = file.Directory.Name;

                groupTree.SelectedNode.Text = bean.GroupTitle + "（" + parent + "）";

                file.Delete();
            }

            if (bean.GroupPath != txtPath.Text)
            {
                FileInfo file = new FileInfo(txtPath.Text);
                if (file.Exists)
                    file.Delete();
            }

            Util.writeTxt(bean.GroupPath, content);

            txtPath.Text = bean.GroupPath;

            DirectoryInfo oldDire = new DirectoryInfo(bean.GroupPath).Parent;
            string newDire = oldDire.Parent.FullName + "\\" + bean.GroupId;

            if (oldDire.FullName != newDire)
            {
                oldDire.MoveTo(newDire);
                bean.GroupPath = newDire + "\\" + bean.GroupTitle + ".txt";

                groupTree.SelectedNode.Text = bean.GroupTitle + "（" + oldDire.Name + "）";
            }

        }

        /// <summary>
        /// 保存txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveBtn_Click(object sender, EventArgs e)
        {
            GroupBean bean = new GroupBean();

            bean.GroupContent = groupDescTxt.Text;
            bean.GroupKeys = groupKeyTxt.Text;
            bean.GroupPath = txtPath.Text;
            bean.GroupRank = groupRankComb.Text;
            bean.GroupTitle = groupNameTxt.Text;
            bean.GroupId = groupIdTxt.Text;
            bean.GroupSrcName = groupSrcNameLab.Text;

            saveGBean(bean);

            saveBtn.Enabled = false;
            statusLabel.Text = "保存成功。路径为：" + bean.GroupPath;
        }

        /// <summary>
        /// 修改后激活保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveTxt_TextChanged(object sender, EventArgs e)
        {
            if (txtPath.Text != "")
                saveBtn.Enabled = true;
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
                    case 100:
                        {
                            groupTree.Select();
                            statusLabel.Text = "按下F1键：焦点移到到选择组区。";
                        }
                        break;
                    case 1:    //按下的是F1，则相应
                        {
                            HotKey.UnregisterHotKey(Handle, 100);//注销热键
                            HotKey.UnregisterHotKey(Handle, 101);
                            HotKey.UnregisterHotKey(Handle, 102);
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 打开txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openTxtBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (new FileInfo(txtPath.Text).Exists)
                {
                    System.Diagnostics.Process pro = new System.Diagnostics.Process();
                    pro.EnableRaisingEvents = false;
                    pro.StartInfo.FileName = txtPath.Text;
                    pro.Start();
                    statusLabel.Text = "打开txt文件，路径为：" + txtPath.Text;
                    return;
                }
            }
            catch { }
            statusLabel.Text = "打开txt文件出错，请检查路径：" + txtPath.Text;
        }

        /// <summary>
        /// 在windows里打开组图目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openGourpPathBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo file = new FileInfo(txtPath.Text).Directory;
                if (file.Exists)
                {
                    System.Diagnostics.Process pro = new System.Diagnostics.Process();
                    pro.EnableRaisingEvents = false;
                    pro.StartInfo.FileName = file.FullName;
                    pro.Start();
                    statusLabel.Text = "windows中打开组图目录，路径为：" + file.FullName;
                    return;
                }
            }
            catch { }
            statusLabel.Text = "windows打开组图目录出错，请选择正确路径。";
        }

        /// <summary>
        /// 打开bat文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openBatBtn_Click(object sender, EventArgs e)
        {
            Button openBat = (Button)(sender);
            string no = openBat.Name.Substring(7, 1);
            if (no == "1")
                selectBatDlg.FileName = "toXls.bat";
            else if (no == "2")
                selectBatDlg.FileName = "toJar.bat";
            else if (no == "3")
                selectBatDlg.FileName = "toXml.bat";
            else if(no=="4")
                selectBatDlg.FileName = "mergeXls.bat";
            else if (no == "5")
                selectBatDlg.FileName = "toZoom.bat";
            else if (no == "6")
                selectBatDlg.FileName = "reName.bat";

            if (selectBatDlg.ShowDialog() == DialogResult.OK)
            {
                TextBox txt = (TextBox)(this.Controls.Find("batPath" + openBat.Name.Substring(7, 1) + "Txt", true)[0]);

                txt.Text = selectBatDlg.FileName;

                statusLabel.Text = txt.Name + "选择路径：" + txt.Text;
            }
            else
            {
                statusLabel.Text = "选择路径取消。";
            }

            selectBatDlg.FileName = "";
        }

        /// <summary>
        /// 打开路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openPathBtn_Click(object sender, EventArgs e)
        {
            Button openPath = (Button)(sender);
            string no = openPath.Name.Substring(4, 2);
            string txtName = "";
            if (no == "12" || no == "23")
            {
                txtName = "inGroupPath" + no[0] + "Txt";
            }
            else if (no == "52")
            {
                txtName = "inGroupPath52Txt";
            }
            else if (no == "53")
            {
                txtName = "outGroupPath53Txt";
            }
            else if (no == "62")
            {
                txtName = "inGroupPath62Txt";
            }
            else if (no == "63")
            {
                txtName = "outGroupPath63Txt";
            }

            if (selectPathDlg.ShowDialog() == DialogResult.OK)
            {
                TextBox txt = (TextBox)(this.Controls.Find(txtName, true)[0]);

                txt.Text = selectPathDlg.SelectedPath;

                statusLabel.Text = txt.Name + "选择路径：" + txt.Text;
            }
            else
            {
                statusLabel.Text = "选择路径取消。";
            }
        }

        /// <summary>
        /// 改变tab时自动加载路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            inGroupPath1Txt.Text = rootPathTxt.Text;
            inGroupPath2Txt.Text = rootPathTxt.Text;
            inGroupPath52Txt.Text = rootPathTxt.Text;
            inGroupPath62Txt.Text = rootPathTxt.Text;
        }

        /// <summary>
        /// 选择打开的xls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openXlsBtn_Click(object sender, EventArgs e)
        {
            Button openXls = (Button)(sender);
            string no = openXls.Name.Substring(4, 2);
            if (selectXlsDlg.ShowDialog() == DialogResult.OK)
            {
                TextBox txt = (TextBox)(this.Controls.Find("xls" + no + "Txt", true)[0]);

                txt.Text = selectXlsDlg.FileName;

                statusLabel.Text = txt.Name + "选择路径：" + txt.Text;
            }
            else
            {
                statusLabel.Text = "选择路径取消。";
            }
        }


        /// <summary>
        /// 保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open24Btn_Click(object sender, EventArgs e)
        {
            if (savePathDlg.ShowDialog() == DialogResult.OK)
            {
                outJarPath2Txt.Text = savePathDlg.SelectedPath;
                statusLabel.Text = "outJarPath2Txt 选择路径：" + outJarPath2Txt.Text;
            }
            else
            {
                statusLabel.Text = "选择路径取消。";
            }
        }

        /// <summary>
        /// 选择输出文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openOutFileBtn_Click(object sender, EventArgs e)
        {
            Button openXls = (Button)(sender);
            string no = openXls.Name.Substring(4, 2);
            if (no == "13")
            {
                saveFileDlg.FileName = "result" + ".xls";
                saveFileDlg.Filter = "Excel文件(*.xls)|*.xls";
            }
            else if (no == "33")
            {
                saveFileDlg.FileName = "key"  + ".xml";
                saveFileDlg.Filter = "Xml文件(*.xml)|*.xml";
            }
            else if (no == "34")
            {
                saveFileDlg.FileName = "image" + ".xml";
                saveFileDlg.Filter = "Xml文件(*.xml)|*.xml";
            }
            else if (no == "44")
            {
                saveFileDlg.FileName = "result" + ".xls";
                saveFileDlg.Filter = "Excel文件(*.xls)|*.xls";
            }
            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {
                TextBox txt = (TextBox)(this.Controls.Find("out" + no + "Txt", true)[0]);

                txt.Text = saveFileDlg.FileName;

                statusLabel.Text = txt.Name + "选择路径：" + txt.Text;
            }
            else
            {
                statusLabel.Text = "选择路径取消。";
            }
        }

        /// <summary>
        /// 开始从路径导出xls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exec1Btn_Click(object sender, EventArgs e)
        {
            string cmd = Util.readTxt(batPath1Txt.Text);

            if (cmd == "" || inGroupPath1Txt.Text == "" || out13Txt.Text=="")
            {
                statusLabel.Text = "请选择正确的bat文件和设置好参数后再执行。";
                return;
            }

            cmd += " \"" + inGroupPath1Txt.Text + "\" \"" + out13Txt.Text + "\" \r\n" + "pause";
            cmd = "cd " + new FileInfo(batPath1Txt.Text).DirectoryName + "\r\n" + cmd;
            cmdTxt.Text = cmd;
            string fileName = new FileInfo(batPath1Txt.Text).DirectoryName + "\\TempBat.bat";
            Util.writeTxt(fileName, cmd);
            try
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.EnableRaisingEvents = false;
                pro.StartInfo.FileName = fileName;
                pro.Start();
                statusLabel.Text = "开始执行导出xls" + txtPath.Text;
            }
            catch { statusLabel.Text = "执行命令错误。"; }
        }

        /// <summary>
        /// 开始打包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exec2Btn_Click(object sender, EventArgs e)
        {
            string cmd = Util.readTxt(batPath2Txt.Text);

            if (cmd == "" || xls22Txt.Text == "" || inGroupPath2Txt.Text == "" || outJarPath2Txt.Text == "")
            {
                statusLabel.Text = "请选择正确的bat文件和设置好参数后再执行。";
                return;
            }

            cmd += " \"" + xls22Txt.Text + "\" \"" + inGroupPath2Txt.Text + "\" \"" + outJarPath2Txt.Text + "\" \r\n" + "pause";

            cmd = "cd " + new FileInfo(batPath2Txt.Text).DirectoryName + "\r\n" + cmd;
            cmdTxt.Text = cmd;
            string fileName = new FileInfo(batPath2Txt.Text).DirectoryName + "\\TempBat.bat";
            Util.writeTxt(fileName, cmd);

            try
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.EnableRaisingEvents = false;
                pro.StartInfo.FileName = fileName;
                pro.Start();
                statusLabel.Text = "开始打包操作" + txtPath.Text;
                return;

            }
            catch { statusLabel.Text = "执行命令错误。"; }

        }

        /// <summary>
        /// 开始生成xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exec3Btn_Click(object sender, EventArgs e)
        {
            string cmd = Util.readTxt(batPath3Txt.Text);

            if (cmd == "" || xls32Txt.Text == "" || out33Txt.Text == "" || out34Txt.Text == "")
            {
                statusLabel.Text = "请选择正确的bat文件和设置好参数后再执行。";
                return;
            }

            if (touchXmlCheck.Checked)//触屏版，四个参数，第四个为任意
            {
                cmd += " \"" + xls32Txt.Text + "\" \"" + out33Txt.Text + "\" \"" + out34Txt.Text + "\" \"\"\r\n" + "pause";
            }
            else//普通版，三个参数
            {
                cmd += " \"" + xls32Txt.Text + "\" \"" + out33Txt.Text + "\" \"" + out34Txt.Text + "\" \r\n" + "pause";
            }
            cmd = "cd " + new FileInfo(batPath3Txt.Text).DirectoryName + "\r\n" + cmd;
            cmdTxt.Text = cmd;

            string fileName = new FileInfo(batPath3Txt.Text).DirectoryName + "\\TempBat.bat";
            Util.writeTxt(fileName, cmd);

            try
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.EnableRaisingEvents = false;
                pro.StartInfo.FileName = fileName;
                pro.Start();
                statusLabel.Text = "开始执行导出xls" + txtPath.Text;
                return;

            }
            catch { statusLabel.Text = "执行命令错误。"; }
        }

        /// <summary>
        /// 合并xls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exec4Btn_Click(object sender, EventArgs e)
        {
            string cmd = Util.readTxt(batPath4Txt.Text);

            if (cmd == "" || xls42Txt.Text == "" || xls43Txt.Text == "" || out44Txt.Text == "")
            {
                statusLabel.Text = "请选择正确的bat文件和设置好参数后再执行。";
                return;
            }

            cmd += " \"" + xls42Txt.Text + "\" \"" + xls43Txt.Text + "\" \"" + out44Txt.Text + "\" \r\n" + "pause";
            cmd = "cd " + new FileInfo(batPath4Txt.Text).DirectoryName + "\r\n" + cmd;
            cmd2Txt.Text = cmd;

            string fileName = new FileInfo(batPath4Txt.Text).DirectoryName + "\\TempBat.bat";
            Util.writeTxt(fileName, cmd);

            try
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.EnableRaisingEvents = false;
                pro.StartInfo.FileName = fileName;
                pro.Start();
                statusLabel.Text = "开始执行导出xls" + txtPath.Text;
                return;

            }
            catch { statusLabel.Text = "执行命令错误。"; }
        }

        /// <summary>
        /// 执行三种尺寸的生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exec5Btn_Click(object sender, EventArgs e)
        {
            string cmd = Util.readTxt(batPath5Txt.Text);

            if (cmd == "" || inGroupPath52Txt.Text == "" || outGroupPath53Txt.Text == "" )
            {
                statusLabel.Text = "请选择正确的bat文件和设置好参数后再执行。";
                return;
            }

            cmd += " \"" + inGroupPath52Txt.Text + "\" \"" + outGroupPath53Txt.Text + "\" \r\n" + "pause";
            cmd = "cd " + new FileInfo(batPath5Txt.Text).DirectoryName + "\r\n" + cmd;
            cmd2Txt.Text = cmd;

            string fileName = new FileInfo(batPath5Txt.Text).DirectoryName + "\\TempBat.bat";
            Util.writeTxt(fileName, cmd);

            try
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.EnableRaisingEvents = false;
                pro.StartInfo.FileName = fileName;
                pro.Start();
                statusLabel.Text = "开始执行生成尺寸" + txtPath.Text;
                return;

            }
            catch { statusLabel.Text = "执行命令错误。"; }
        }

        /// <summary>
        /// 弹出选图对话框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selImageBtn_Click(object sender, EventArgs e)
        {
            SelImageForm sForm = new SelImageForm(rootPathTxt.Text);
            sForm.ShowDialog();
            refreshBtn_Click(sender,e);
        }

        /// <summary>
        /// 执行触屏版两种尺寸的生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exec6Btn_Click(object sender, EventArgs e)
        {
            string cmd = Util.readTxt(batPath6Txt.Text);

            if (cmd == "" || inGroupPath62Txt.Text == "" || outGroupPath63Txt.Text == "")
            {
                statusLabel.Text = "请选择正确的bat文件和设置好参数后再执行。";
                return;
            }

            cmd += " \"" + inGroupPath62Txt.Text + "\" \"" + outGroupPath63Txt.Text + "\" \r\n" + "pause";
            cmd = "cd " + new FileInfo(batPath6Txt.Text).DirectoryName + "\r\n" + cmd;
            cmd2Txt.Text = cmd;

            string fileName = new FileInfo(batPath6Txt.Text).DirectoryName + "\\TempBat.bat";
            Util.writeTxt(fileName, cmd);

            try
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.EnableRaisingEvents = false;
                pro.StartInfo.FileName = fileName;
                pro.Start();
                statusLabel.Text = "开始执行一键编号" + txtPath.Text;
                return;

            }
            catch { statusLabel.Text = "执行命令错误。"; }
        }

        /// <summary>
        /// 判断是否为触屏版的生成尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void touchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (touchCheckBox.Checked)
            {
                batPath5Txt.Text = batPath5Txt.Text.Replace("toZoom.bat", "touchToZoom.bat");
            }
            else
            {
                batPath5Txt.Text = batPath5Txt.Text.Replace("touchToZoom.bat", "toZoom.bat");
            }
        }

        private void groupSrcNameLab_TextChanged(object sender, EventArgs e)
        {
            if (txtPath.Text != "")
                saveBtn.Enabled = true;
        }
    }
}
