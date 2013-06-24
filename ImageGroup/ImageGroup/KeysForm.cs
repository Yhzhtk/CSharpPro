using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ImageGroup
{
    public partial class KeysForm : Form
    {
        string keyTxtPath =System.Environment.CurrentDirectory+"\\Config\\AllKeys.dat";

        List<string[]> allKeys = new List<string[]>();

        string[] indexs = new string[]{
            "High","ABC","DEF","GHI","JKL","MNO","PQR","STU","VWX","YZ","Digit"
        };

        public string keys = "";

        Hashtable ht = new Hashtable();

        public KeysForm(string keys)
        {
            InitializeComponent();
            this.keys = keys;

            string []infos=keys.Split('#');
            foreach (string info in infos)
            {
                if (info != "")
                {
                    selListView.Items.Add(new ListViewItem(info));
                }
            }
        }

        /// <summary>
        /// 选中关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            ListView.SelectedListViewItemCollection defList = lv.SelectedItems;
            foreach (ListViewItem item in defList)
            {
                if (!isExist(selListView, item.Text))
                {
                    selListView.Items.Add(new ListViewItem(item.Text));
                    statusLabel.Text = "添加关键字：" + item.Text;
                }
                else
                {
                    statusLabel.Text = "关键字  "+ item.Text+"  已经添加，不需要在添加." ;
                }
            }

        }

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e)
        {
            getKeyStr();
            this.Close();
        }

        /// <summary>
        /// 
        /// 设为常用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setHighBtn_Click(object sender, EventArgs e)
        {
            string nowPage = tabControl.SelectedTab.Text;
            string str = "";
            if (nowPage != "常用")
            {
                ListView lv = (ListView)(this.Controls.Find(nowPage + "ListView", true)[0]);
                ListView.SelectedListViewItemCollection selList = lv.SelectedItems;
                foreach (ListViewItem item in selList)
                {
                    if (!isExist(HighListView, item.Text))
                    {
                        HighListView.Items.Add(new ListViewItem(item.Text));
                        str += item.Text + " ";
                    }
                }
            }
            if(str!="")
                statusLabel.Text = "将以下关键字设为常用关键字 ：" + str;
            else
                statusLabel.Text = "请选中要设为常用关键字的项。";
        }

        /// <summary>
        /// 添加常用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addHighBtn_Click(object sender, EventArgs e)
        {
            AddHighForm aForm = new AddHighForm();
            aForm.ShowDialog();
            string index = aForm.index;
            string highKey = aForm.highKey;
            aForm.Dispose();
            if (index == "-1"||index==null)
            {
                statusLabel.Text = "索引错误，不能添加。";
                return;
            }

            if (index == "常用")
                index = "High";

            try
            {
                ListView lv = (ListView)(this.Controls.Find(index + "ListView", true)[0]);
                if (!isExist(lv, highKey))
                {
                    lv.Items.Add(new ListViewItem(highKey));
                    statusLabel.Text = "向索引 " + index + " 添加关键字：" + highKey;
                }
                else
                {
                    statusLabel.Text = "索引 " + index + " 中已存在：" + highKey + " ，不需要再次添加。";
                }
            }
            catch
            {
                statusLabel.Text = "索引错误，不能添加。";
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeysForm_Load(object sender, EventArgs e)
        {
            string fileName = keyTxtPath;
            initKeys(fileName);

            foreach (string index in indexs)
            {
                ListView lv = (ListView)(this.Controls.Find(index + "ListView", true)[0]);
                lv.ContextMenuStrip = this.contextMenuStrip2;
                lv.View = View.Tile;
            }

        }


        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            //已取消，不需要更改
            keys = "-1";
            this.Close();
        }

        /// <summary>
        /// 导入关键字文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importKeysBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                initKeys(fileName);
                statusLabel.Text = "导入关键词库成功：" + fileName;
            }
            else
            {
                statusLabel.Text = "导入关键词库取消";
            }
        }

        /// <summary>
        /// 删除选择的关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection defList = selListView.SelectedItems;
            foreach (ListViewItem item in defList)
            {
                 selListView.Items.Remove(item);
            }

            statusLabel.Text = "删除已选关键词成功";
        }


        private void KeysForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveKeys(keyTxtPath);
        }


        /// <summary>
        /// 从文件初始化item
        /// </summary>
        /// <param name="fileName"></param>
        private void initKeys(string fileName)
        {
            allKeys = Util.getKeys(fileName);

            foreach (string[] key in allKeys)
            {
                int index = getIndex(key[0]);
                if (index == -1)
                {
                    continue;
                }
                else
                {
                    string ctrlName = indexs[index] + "ListView";
                    ListView lv = (ListView)(this.Controls.Find(ctrlName, true)[0]);

                    if (!isExist(lv, key[1]))
                    {
                        lv.Items.Add(new ListViewItem(key[1]));
                    }
                }
            }
        }

        private string saveKeys(string fileName)
        {
            string content = "";
            ListView.ListViewItemCollection lvItems;
            for (int i = 0; i < indexs.Length; i++)
            {
                string nowPage = indexs[i];
                string ctrlName = nowPage + "ListView";
                lvItems = ((ListView)(this.Controls.Find(ctrlName, true)[0])).Items;
                foreach (ListViewItem item in lvItems)
                {
                    content += nowPage+ "#" + item.Text + "\r\n";
                }
            }

            return Util.writeTxt(fileName, content);

        }

        /// <summary>
        /// 判断是否存在该item
        /// </summary>
        /// <param name="lv"></param>
        /// <param name="citem"></param>
        /// <returns></returns>
        private bool isExist(ListView lv, string itemTxt)
        {
            ListView.ListViewItemCollection items = lv.Items;
            foreach (ListViewItem item in items)
            {
                if (item.Text == itemTxt)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// 从选择中获取key字符串
        /// </summary>
        /// <returns></returns>
        private string getKeyStr()
        {
            keys = "";
            ListView.ListViewItemCollection items = selListView.Items;
            foreach (ListViewItem item in items)
            {
                keys += "#" + item.Text;
            }
            if (keys != "")
            {
                keys = keys.Substring(1);
            } 
            return keys;
        }

        /// <summary>
        /// 从关键字获取索引位置
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private int getIndex(string key)
        {
            if (key == "High")
                return 0;
            else if (key == "Digit")
                return 10;

            for (int i = 1; i < indexs.Length; i++)
            {
                if (indexs[i].Contains(key))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 删除关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nowPage = tabControl.SelectedTab.Name;

            ListView lv=(ListView)(this.Controls.Find(nowPage+"ListView",true)[0]);
            string str = "";
            ListView.SelectedListViewItemCollection defList = lv.SelectedItems;
            foreach (ListViewItem item in defList)
            {
                str += item.Text + " ";
                lv.Items.Remove(item);
            }

            statusLabel.Text = "删除关键词成功:";
        }

        /// <summary>
        /// 添加选择的关键字到分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection listItems = selListView.SelectedItems;
            string indexStr = ((ToolStripMenuItem)sender).Name.Substring(5, 3);

            if (indexStr == "Hig")
                indexStr = "High";
            else if (indexStr == "Dig")
                indexStr = "Digit";
            else if (indexStr == "YZT")
                indexStr = "YZ";

            ListView lv = (ListView)(this.Controls.Find(indexStr + "ListView", true)[0]);

            string str = "";
            foreach (ListViewItem item in listItems)
            {
                if (!isExist(lv, item.Text))
                {
                    lv.Items.Add(new ListViewItem(item.Text));
                    str += item.Text + "   ";

                }
            }
            statusLabel.Text = "向索引 " + indexStr + " 添加关键字：" + str;
        }

    }
}
