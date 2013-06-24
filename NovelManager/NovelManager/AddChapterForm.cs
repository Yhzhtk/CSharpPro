using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NovelManager
{
    public partial class AddChapterForm : Form
    {
        public int cid;
        public int isEmpty;

        public string cName;
        public string cContent;

        public bool isOK = false;

        public AddChapterForm(int cid)
        {
            InitializeComponent();
            this.cid = cid;
        }

        private void AddChapter_Load(object sender, EventArgs e)
        {
            cidTxt.Text = cid.ToString();
        }

        /// <summary>
        /// 确定添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (cNameTxt.Text == "")
            {
                MessageBox.Show("请输入章节名！");
                return;
            }

            cid = int.Parse(cidTxt.Text);
            isEmpty = int.Parse(emptyTxt.Text);
            cName = cNameTxt.Text;
            cContent = cContentTxt.Text;

            isOK = true;
            this.Close();
        }

        /// <summary>
        /// 取消返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 自动判定内容是否为空
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cContentTxt_TextChanged(object sender, EventArgs e)
        {
            if (cContentTxt.Text.Trim() == "")
            {
                emptyTxt.Text = "1";
            }
            else
            {
                emptyTxt.Text = "0";
            }
        }
    }
}
