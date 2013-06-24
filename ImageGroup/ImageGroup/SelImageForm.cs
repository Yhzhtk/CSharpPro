using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace ImageGroup
{
    public partial class SelImageForm : Form
    {
        string format = "";

        public string rootPath = "";

        public SelImageForm(string rootPath)
        {
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F1);
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.None, Keys.Delete);

            InitializeComponent();
            this.rootPathTxt.Text = rootPath;
            refresh(rootPath);
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
                    case 101:
                        {
                            toolStripMenuItem1_Click(new object(),new EventArgs());
                            statusLabel.Text = "按下Delete键：删除选中组图。";
                        }
                        break;
                    case 1:    //按下的是F1，则相应
                        {
                            HotKey.UnregisterHotKey(Handle, 100);//注销热键
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 当拖动某项时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListView lv = (ListView)(sender);

            lv.DoDragDrop(lv.SelectedItems, DragDropEffects.Move);
            if (tabControl.SelectedIndex == 0)
                seqNameBtn.Enabled = true;
            else if (tabControl.SelectedIndex == 1)
                seqSave2Btn.Enabled = true;
        }

        /// <summary>
        /// 放下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            ListView lv = (ListView)(sender);

            string src = "";
            string dest = "";

            statusLabel.Text = "拖动结束，开始移动。";
            //判断是否选择拖放的项，

            //选择拖动数为0
            if (lv.SelectedItems.Count == 0)
            {
                return;
            }
            else if (lv.SelectedItems.Count != 1)
            {
                statusLabel.Text = "拖动图片时只能选择一张图片。";
                return;
            }

            //定义项的坐标点并获取目的item
            Point cp = lv.PointToClient(new Point(e.X, e.Y));
            ListViewItem destItem = lv.GetItemAt(cp.X, cp.Y);
            if (destItem == null)
            {
                statusLabel.Text = "拖动目的位置坐标必须在item上，表示移动到该item之前";
                return;
            }
            int destIndex = destItem.Index;

            dest = destItem.Text;

            //不需要移动
            if (destIndex == lv.SelectedItems[0].Index)
            {
                return;
            }

            int appCount = 0;
            //获取需要拖动的item
            ListViewItem selItem = (ListViewItem)lv.SelectedItems[0].Clone();
            src = selItem.Text;
            if (lv.SelectedItems[0].Index < destIndex)
            {
                appCount = lv.Items.Count - destIndex;
                destIndex--;
            }
            else
            {
                appCount = lv.Items.Count - destIndex - 1;
            }
            lv.Items.Remove(lv.SelectedItems[0]);

            //所有最后需附加的item
            ListViewItem[] appendItems = new ListViewItem[appCount];
            for (int i = destIndex; destIndex < lv.Items.Count; i++)
            {
                appendItems[i - destIndex] = (ListViewItem)lv.Items[destIndex].Clone();
                lv.Items.RemoveAt(destIndex);
            }

            lv.Items.Insert(destIndex++, selItem);
            for (int i = 0; i < appendItems.GetLength(0); i++)
            {
                lv.Items.Insert(destIndex++, appendItems[i]);
            }

            statusLabel.Text = "移动    " + src + "   至   " + dest + "    之前。";
        }

        /// <summary>
        /// 开始拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            statusLabel.Text = "选择开始拖动";
            for (int i = 0; i <= e.Data.GetFormats().Length - 1; i++)
            {
                if (e.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
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
        /// 选择组图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void groupTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

            try
            {
                //选图
                if (tabControl.SelectedIndex == 0)
                {
                    if (seqNameBtn.Enabled)
                    {
                        DialogResult dr = MessageBox.Show("是否保存本条信息并进入下一条？\r\n“是”则保存进入下一条，“否”则不保存进入下一条，“取消”则不进入下一条。", "修改还没有保存提醒！", MessageBoxButtons.YesNoCancel);
                        if (dr == DialogResult.Yes)
                        {
                            seqNameBtn_Click(sender, e);
                        }
                        else if (dr == DialogResult.No)
                        {
                            seqNameBtn.Enabled = false;
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
                    }
                    else
                    {
                        statusLabel.Text = "加载信息，path:" + temp;
                        return;
                    }

                    nowPathTxt.Text = path;
                    refreshNow(path);
                    statusLabel.Text = "选择组图路径:" + path;
                }
                else if (tabControl.SelectedIndex == 1)//组图编号
                {
                    string path;
                    string temp = groupTree.SelectedNode.Text;
                    int s = temp.IndexOf('（');
                    if (temp.EndsWith("）"))
                    {
                        path = rootPathTxt.Text + "\\";
                        path += groupTree.SelectedNode.Parent.Text + "\\";//分类
                    }
                    else
                    {
                        path = rootPathTxt.Text + "\\";
                        path += groupTree.SelectedNode.Text + "\\";//分类
                    }

                    if (nowPath2Txt.Text != path)
                    {
                        if (seqSave2Btn.Enabled)
                        {
                            DialogResult dr = MessageBox.Show("是否保存本条信息并进入下一条？\r\n“是”则保存进入下一条，“否”则不保存进入下一条，“取消”则不进入下一条。", "修改还没有保存提醒！", MessageBoxButtons.YesNoCancel);
                            if (dr == DialogResult.Yes)
                            {
                                seqSave2Btn_Click(sender, e);
                            }
                            else if (dr == DialogResult.No)
                            {
                                seqSave2Btn.Enabled = false;
                            }
                            else if (dr == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        nowPath2Txt.Text = path;
                        refreshNow2(path);
                        statusLabel.Text = "选择分类路径:" + path;
                    }
                    else
                    {
                        statusLabel.Text = "已是当前分类，不用再选择:" + path;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 刷新组图缩略图
        /// </summary>
        /// <param name="path"></param>
        private void refreshNow2(string path)
        {
            statusLabel.Text = "正在创建缩略图，请稍候。。。。";
            this.Refresh();
            imageList.Images.Clear();
            listView2.Items.Clear();
            listView2.LargeImageList = imageList;

            DirectoryInfo dire = new DirectoryInfo(path);

            DirectoryInfo[] imageFiles = dire.GetDirectories();
            for (int i = 0; i < imageFiles.Length; i++)
            {
                string tempImage = "TempThumbs\\" + imageFiles[i].Parent.Name + "_" + imageFiles[i].Name + ".jpg";

                int rand = 0;
                while (new FileInfo(tempImage).Exists)
                {
                    tempImage = "TempThumbs\\" + imageFiles[i].Parent.Name + "_" + imageFiles[i].Name + "_" + (rand++).ToString() + ".jpg";
                }

                ImageUtil.GetMicroImage(imageFiles[i].FullName, tempImage);

                imageList.Images.Add(Image.FromFile(tempImage));
                ListViewItem lvItem = new ListViewItem(imageFiles[i].Name, i);
                listView2.Items.Add(lvItem);
            }
            statusLabel.Text = "加载成功：" + nowPath2Txt.Text;
        }


        /// <summary>
        /// 打开当前组图路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openNowPathBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo file = new DirectoryInfo(nowPathTxt.Text);
                if (file.Exists)
                {
                    System.Diagnostics.Process pro = new System.Diagnostics.Process();
                    pro.EnableRaisingEvents = false;
                    pro.StartInfo.FileName = nowPathTxt.Text;
                    pro.Start();
                    statusLabel.Text = "windows中打开组图目录，路径为：" + nowPathTxt.Text;
                    return;
                }
            }
            catch { }
            statusLabel.Text = "windows打开组图目录出错，请选择正确路径。";
        }

        /// <summary>
        /// 邮件删除图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView lv = null;
            if (tabControl.SelectedIndex == 0)
                lv = listView1;
            else if (tabControl.SelectedIndex == 1)
                lv = listView2;

            DialogResult dr = MessageBox.Show("确定删除图片，删除图片后在没有 序列保存 前可刷新恢复！\r\n“确定”则删除，“取消”则不删除。", "删除提醒！", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.Cancel)
            {
                statusLabel.Text = "取消删除图片操作！";
                return;
            }

            try
            {
                ListView.SelectedListViewItemCollection lvItems = lv.SelectedItems;

                string str = " ";
                foreach (ListViewItem item in lvItems)
                {
                    str += item.Text + "  ";
                    lv.Items.Remove(item);
                }

                statusLabel.Text = "删除图片成功：" + str;
                if (tabControl.SelectedIndex == 0)
                    seqNameBtn.Enabled = true;
                else if (tabControl.SelectedIndex == 1)
                    seqSave2Btn.Enabled = true;
            }
            catch (Exception ee)
            {
                statusLabel.Text = "删除图片出现错误！" + ee.Message;
            }
        }

        /// <summary>
        /// 刷新当前显示的图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshNowBtn_Click(object sender, EventArgs e)
        {
            if (nowPathTxt.Text == "")
            {
                statusLabel.Text = "请先选择组图！";
                return;
            }

            refreshNow(nowPathTxt.Text);
        }

        /// <summary>
        /// 刷新当前
        /// </summary>
        /// <param name="path"></param>
        private void refreshNow(string path)
        {
            imageList.Images.Clear();
            listView1.Items.Clear();
            listView1.LargeImageList = imageList;

            DirectoryInfo dire = new DirectoryInfo(path);

            string[] infos = nowPathTxt.Text.Split('\\');
            string cate = infos[infos.Length - 3];
            string groupid = infos[infos.Length - 2];
            string tempImage = "";
            FileInfo[] imageFiles = dire.GetFiles();
            for (int i = 0; i < imageFiles.Length; i++)
            {
                tempImage = "TempImages\\" + cate + "_" + groupid + "_" + imageFiles[i].Name;
                new FileInfo(tempImage).Directory.Create();

                int rand = 0;
                while (new FileInfo(tempImage).Exists)
                {
                    tempImage = "TempImages\\" + cate + "_" + groupid + "_" + (rand++).ToString() + "_" + imageFiles[i].Name;
                }

                imageFiles[i].CopyTo(tempImage);

                int f = imageFiles[i].Name.LastIndexOf('.');
                string lastformat = imageFiles[i].Name.Substring(f);
                if (lastformat == ".jpg" || lastformat == ".jpeg" || lastformat == ".gif" || lastformat == ".png")
                {
                    imageList.Images.Add(Image.FromFile(tempImage));
                    ListViewItem lvItem = new ListViewItem(imageFiles[i].Name, i);
                    listView1.Items.Add(lvItem);
                    format = lastformat;
                }
            }
        }

        /// <summary>
        /// 设置预览大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setSizeBtn_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            try
            {
                width = int.Parse(widthTxt.Text);
                height = int.Parse(heightTxt.Text);

                if (width > 256 || height > 256)
                {
                    statusLabel.Text = "设置大小必须是在1到256之间！";
                    return;
                }
            }
            catch
            {
                statusLabel.Text = "设置大小出错，必须是数字！";
                widthTxt.Text = imageList.ImageSize.Width.ToString();
                heightTxt.Text = imageList.ImageSize.Height.ToString();
                return;
            }
            imageList.ImageSize = new Size(width, height);
            statusLabel.Text = "设置大小成功：" + width + " X " + height;
            if (nowPathTxt.Text != "")
            {
                refreshNow(nowPathTxt.Text);
            }
        }

        /// <summary>
        /// 一键命名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seqNameBtn_Click(object sender, EventArgs e)
        {
            if (formatComb.Text == "")
            {
                statusLabel.Text = "请先选择命名格式。";
                return;
            }

            try
            {

                ListView.ListViewItemCollection lvItems = listView1.Items;

                string fileName = "";

                FileInfo[] needFiles = new FileInfo[lvItems.Count];
                for (int i = 0; i < lvItems.Count; i++)
                {
                    fileName = nowPathTxt.Text + lvItems[i].Text;

                    needFiles[i] = new FileInfo(fileName);
                    if (needFiles[i].Exists)
                    {
                        needFiles[i].MoveTo(nowPathTxt.Text + "\\#@#" + (i + 1).ToString() + formatComb.Text);
                    }
                }

                DirectoryInfo dire = new DirectoryInfo(nowPathTxt.Text);
                FileInfo[] files = dire.GetFiles();
                for (int i = 0; i < files.Length; i++)
                {
                    fileName = files[i].FullName;
                    if (!fileName.EndsWith(format))
                        continue;

                    if (!fileName.Contains("#@#"))
                    {
                        files[i].Delete();
                    }
                }

                for (int i = 0; i < needFiles.Length; i++)
                {
                    fileName = needFiles[i].FullName.Replace("#@#", "");
                    needFiles[i].MoveTo(fileName);
                }

                statusLabel.Text = "序列化一键命名成功！";
                refreshNow(nowPathTxt.Text);

                seqNameBtn.Enabled = false;
            }
            catch (Exception ee)
            {
                statusLabel.Text = "重命名图片出现错误！" + ee.Message;
            }
        }

        /// <summary>
        /// 组图编号保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seqSave2Btn_Click(object sender, EventArgs e)
        {
            int groupId = 0;
            try
            {
                groupId = int.Parse(gourpIdTxt.Text);
            }
            catch
            {
                statusLabel.Text = "请输入正确的初始化Id号。";
                return;
            }

            try
            {
                ListView.ListViewItemCollection lvItems = listView2.Items;

                string fileName = "";

                DirectoryInfo[] needFiles = new DirectoryInfo[lvItems.Count];
                for (int i = 0; i < lvItems.Count; i++)
                {
                    fileName = nowPath2Txt.Text + lvItems[i].Text;

                    needFiles[i] = new DirectoryInfo(fileName);
                    if (needFiles[i].Exists)
                    {
                        needFiles[i].MoveTo(nowPath2Txt.Text + "\\#@#" + (groupId++));
                    }
                }

                DirectoryInfo dire = new DirectoryInfo(nowPath2Txt.Text);
                DirectoryInfo[] files = dire.GetDirectories();
                for (int i = 0; i < files.Length; i++)
                {
                    fileName = files[i].FullName;

                    if (!fileName.Contains("#@#"))
                    {
                        files[i].Delete();
                    }
                }

                for (int i = 0; i < needFiles.Length; i++)
                {
                    fileName = needFiles[i].FullName.Replace("#@#", "");
                    needFiles[i].MoveTo(fileName);
                }

                statusLabel.Text = "组图一键编号命名成功！";
                refreshNow2(nowPath2Txt.Text);

                seqSave2Btn.Enabled = false;
            }
            catch (Exception ee)
            {
                statusLabel.Text = "组图自动编号出现错误！" + ee.Message;
            }
        }

        /// <summary>
        /// tab切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            nowPath2Txt.Text = "";
            groupTree_AfterSelect(sender, null);
        }

        /// <summary>
        /// 设置组图编号大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setSize2Txt_Click(object sender, EventArgs e)
        {
            int width;
            int height;
            try
            {
                width = int.Parse(width2Txt.Text);
                height = int.Parse(height2Txt.Text);

                if (width > 256 || height > 256)
                {
                    statusLabel.Text = "设置大小必须是在1到256之间！";
                    return;
                }
            }
            catch
            {
                statusLabel.Text = "设置大小出错，必须是数字！";
                width2Txt.Text = imageList.ImageSize.Width.ToString();
                height2Txt.Text = imageList.ImageSize.Height.ToString();
                return;
            }
            imageList.ImageSize = new Size(width, height);
            statusLabel.Text = "设置大小成功：" + width + " X " + height;
            if (nowPath2Txt.Text != "")
            {
                refreshNow2(nowPath2Txt.Text);
            }
        }

        /// <summary>
        /// 打开分组目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openNowPath2Btn_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo file = new DirectoryInfo(nowPath2Txt.Text);
                if (file.Exists)
                {
                    System.Diagnostics.Process pro = new System.Diagnostics.Process();
                    pro.EnableRaisingEvents = false;
                    pro.StartInfo.FileName = nowPath2Txt.Text;
                    pro.Start();
                    statusLabel.Text = "windows中打开组图目录，路径为：" + nowPath2Txt.Text;
                    return;
                }
            }
            catch { }
            statusLabel.Text = "windows打开组图目录出错，请选择正确路径。";
        }

        /// <summary>
        /// 刷新缩略图显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void refreshNow2Btn_Click(object sender, EventArgs e)
        {
            refreshNow2(nowPath2Txt.Text);
        }

        private void gourpIdTxt_TextChanged(object sender, EventArgs e)
        {
            seqSave2Btn.Enabled = true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectoryInfo file = null;
            string fileName = "";
            try
            {
                if (tabControl.SelectedIndex == 0)
                {
                    file = new DirectoryInfo(nowPathTxt.Text);
                    fileName = file.FullName + "\\" + listView1.SelectedItems[0].Text;
                }
                else if (tabControl.SelectedIndex == 1)
                {
                    file = new DirectoryInfo(nowPath2Txt.Text);
                    fileName = file.FullName + "\\" + listView2.SelectedItems[0].Text;
                }
                if (file.Exists)
                {
                    System.Diagnostics.Process pro = new System.Diagnostics.Process();
                    pro.EnableRaisingEvents = false;
                    pro.StartInfo.FileName = fileName;
                    pro.Start();
                    statusLabel.Text = "windows中打开组图目录，路径为：" + fileName;
                    return;
                }
            }
            catch
            {
                statusLabel.Text = "windows打开组图目录出错，请选择正确路径。" + fileName;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string path="";
            try
            {
                string temp = groupTree.SelectedNode.Text;
                int s = temp.IndexOf('（');
                if (temp.EndsWith("）"))
                {
                    path = rootPathTxt.Text + "\\";
                    path += groupTree.SelectedNode.Parent.Text + "\\";//分类
                    path += temp.Substring(s + 1, temp.Length - s - 2) + "\\";//groupId
                }
                else
                {
                    statusLabel.Text = "加载信息，path:" + temp;
                    return;
                }

                DirectoryInfo file = new DirectoryInfo(path);

                FileInfo[]files=file.GetFiles();
                foreach (FileInfo f in files)
                {
                    f.Delete();
                }
                file.Delete();
                groupTree.SelectedNode.Remove();
                statusLabel.Text = "删除成功：" + path ;


                //重新加载下一组
                temp = groupTree.SelectedNode.Text;
                s = temp.IndexOf('（');
                if (temp.EndsWith("）"))
                {
                    path = rootPathTxt.Text + "\\";
                    path += groupTree.SelectedNode.Parent.Text + "\\";//分类
                    path += temp.Substring(s + 1, temp.Length - s - 2) + "\\";//groupId
                }
            }
            catch(Exception ee)
            {
                  statusLabel.Text = "删除失败：" + path+"  "+ee.Message.Replace("\r\n","");
            }
        }
    }
}