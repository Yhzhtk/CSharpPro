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
    public partial class ConfigForm : Form
    {
        public bool isOK = false;

        public string dbLinkStr = "";

        public int novelPageCount = 20;

        public int chapterPageCount = 20;

        public ConfigForm(string dblink,int novelcount,int chaptercount)
        {
            InitializeComponent();

            dbLinkTxt.Text = dblink;
            novelPageCountTxt.Text = novelcount.ToString();
            chapterPageCountTxt.Text = chapterPageCount.ToString();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                dbLinkStr = dbLinkTxt.Text;
                novelPageCount = int.Parse(novelPageCountTxt.Text);
                chapterPageCount = int.Parse(chapterPageCountTxt.Text);

                if (novelPageCount < 1 || novelPageCount < 1)
                {
                    MessageBox.Show("小说或章节每页数必须是整数，且大于0");
                    return;
                }
                isOK = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("小说或章节每页数必须是整数，且大于0");
                return;
            }
        }
    }
}
