using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NovelManager.BLL;

namespace NovelManager
{
    public partial class MainForm : Form
    {
        string nownid;

        int everyPageCount = 20;
        int chapterEveryPageCount = 20;

        int nowNovelCount = 0;
        int allNovelCount = 0;
        int nowPage = 0;
        int allPage = 0;

        novel_base nbase = new novel_base();
        novel_detail ndetail = new novel_detail();

        Model.novel_base baseMode;
        Model.novel_detail detailMode;

        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 连接数据库获取小说基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InitPageAndNovelCount();
            }
            catch
            {
                MessageBox.Show("数据库连接有问题，请检查数据库是否启动，并且连接字符串正确。");
                return;
            }
            DataTable dt = getNovelTable(nowPage);
            setPageAndNovelCount();
            novelGridView.DataSource = dt;
            novelGridView.Columns[2].Width = 60;
            novelGridView.Columns[3].Width = 60;
            novelGridView.Columns[4].Width = 110;
        }

        /// <summary>
        /// 获取小说数，计算页数
        /// </summary>
        private void InitPageAndNovelCount()
        {
            DataSet ds = nbase.GetPartList("select count(*) as c from novel_base");
            allNovelCount = int.Parse(ds.Tables[0].Rows[0]["c"].ToString());
            nowNovelCount = Math.Min(allNovelCount, everyPageCount);
            allPage = (allNovelCount - 1) / everyPageCount + 1;
            nowPage = 1;
        }

        /// <summary>
        /// 获取对应页数的表
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        private DataTable getNovelTable(int page)
        {
            if (allPage < 1)
            {
                statusLabel.Text = "请先连接数据库服务，获取小说总数。";
                return null;
            }

            string order = " order by ";

            if (seqRadio.Checked)
            {
                order = "";
            }
            else if (blankCountRadio.Checked)
            {
                order += "blankchapter_count desc";
            }
            else if (userDefineRadio.Checked)
            {
                order = orderStrTxt.Text;
            }

            DataTable dt = nbase.GetPartList("select Nid,name,blankchapter_count,chaptercount,no_desc,id from novel_base " + order + " limit " + (page - 1) * everyPageCount + "," + everyPageCount).Tables[0];

            dt.Columns[1].ColumnName = "名称";
            dt.Columns[2].ColumnName = "空章";
            dt.Columns[3].ColumnName = "共章";
            dt.Columns[4].ColumnName = "简介(1无0有)";
            dt.Columns[5].ColumnName = "主键id";

            nowNovelCount = dt.Rows.Count;
            resultGroup.Text = "列表显示结果";
            return dt;
        }

        /// <summary>
        /// 设置页数和小说数
        /// </summary>
        private void setPageAndNovelCount()
        {
            novelCountLabel.Text = nowNovelCount + "/" + allNovelCount;
            novelPageLabel.Text = nowPage + "/" + allPage;
        }

        /// <summary>
        /// 打开窗口进行章节操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operChapterBtn_Click(object sender, EventArgs e)
        {
            if (nidTxt.Text == "")
            {
                statusLabel.Text = "请先连接数据库，获取小说基本信息再进行章节操作";
                return;
            }
            ChapterForm cForm = new ChapterForm(int.Parse(baseIdTxt.Text), nidTxt.Text, nameTxt.Text,chapterEveryPageCount);
            cForm.ShowDialog();
        }

        /// <summary>
        /// 选择小说后显示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void novelGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (saveInfoBtn.Enabled)
            {
                DialogResult dr = MessageBox.Show("上条记录已修改但未保存。是否保存进入下一条？\r\n“是”则保存进入下一条，“否”不保存进入下一条，“取消”不进入下一条。", "修改没有保存！", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    saveInfoBtn_Click(sender, e);
                }
                else if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }
            
            if (novelGridView.SelectedRows.Count > 0 && novelGridView.Rows.Count == nowNovelCount)
            {
                nownid = novelGridView.SelectedRows[0].Cells[0].Value.ToString();
                showNidContent(nownid);
            }
        }

        /// <summary>
        /// 显示nid对应的小说信息
        /// </summary>
        /// <param name="nid"></param>
        private void showNidContent(string nid)
        {

            statusLabel.Text = "正在加载小说信息，nid为：" + nownid + "  请稍候。。。。";
            statusStrip1.Refresh();
            try
            {
                baseMode = nbase.GetModelFromNid(nownid);

                detailMode = ndetail.GetModel(nownid);

                nameTxt.Text = baseMode.name;
                baseIdTxt.Text = baseMode.id.ToString();
                nidTxt.Text = nownid;
                urlTxt.Text = detailMode.url;
                blankChapCountTxt.Text = baseMode.blankchapter_count.ToString();
                allChapCountTxt.Text = baseMode.chaptercount.ToString();
                typeTxt.Text = baseMode.type;
                stateTxt.Text = baseMode.novelstate.ToString();
                descTxt.Text = detailMode.description;

                statusLabel.Text = "加载小说信息成功，nid为：" + nownid;
                statusStrip1.Refresh();
            }
            catch (Exception ee)
            {
                statusLabel.Text = "获取小说内容出错：" + ee.Message;
            }

            saveInfoBtn.Enabled = false;
        }

        /// <summary>
        /// 重读信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reReadBtn_Click(object sender, EventArgs e)
        {
            showNidContent(nownid);
        }


        #region 翻页部分代码
        /// <summary>
        /// 翻页至首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void firstNPagelik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nowPage = 1;
            DataTable dt = getNovelTable(nowPage);
            novelGridView.DataSource = dt;
            setPageAndNovelCount();
            statusLabel.Text = "翻页至首页";
        }

        /// <summary>
        /// 翻页至上页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upPageNlik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nowPage = Math.Max(1, nowPage - 1);
            DataTable dt = getNovelTable(nowPage);
            novelGridView.DataSource = dt;
            setPageAndNovelCount();
            statusLabel.Text = "翻页至上页";
        }


        /// <summary>
        /// 翻页至下页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downPageNlik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nowPage = Math.Min(nowPage + 1, allPage);
            DataTable dt = getNovelTable(nowPage);
            novelGridView.DataSource = dt;
            setPageAndNovelCount();
            statusLabel.Text = "翻页至下页";
        }


        /// <summary>
        /// 翻页至尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lastPageNlik_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nowPage = allPage;
            DataTable dt = getNovelTable(nowPage);
            novelGridView.DataSource = dt;
            setPageAndNovelCount();
            statusLabel.Text = "翻页至尾页";
        }


        /// <summary>
        /// 跳转页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gotoPageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int page = int.Parse(pageTxt.Text);
                if (page > 0 && page <= allPage)
                {
                    nowPage = page;
                    DataTable dt = getNovelTable(nowPage);
                    novelGridView.DataSource = dt;
                    setPageAndNovelCount();
                    statusLabel.Text = "翻页至第 " + nowPage + " 页";
                }
                else
                {
                    statusLabel.Text = "设置页数必须在 1 到 " + allPage + " 之间";
                }
            }
            catch
            {
                statusLabel.Text = "输入页数必须是数字";
            }
        }
        #endregion

        /// <summary>
        /// 搜索nid内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchNidBtn_Click(object sender, EventArgs e)
        {
            DataTable dt = nbase.GetPartList("select Nid,name,blankchapter_count,chaptercount,no_desc,id from novel_base where Nid ='" + searchNidTxt.Text.Trim() + "'").Tables[0];
            dt.Columns[1].ColumnName = "名称";
            dt.Columns[2].ColumnName = "空章";
            dt.Columns[3].ColumnName = "共章";
            dt.Columns[4].ColumnName = "简介(1无0有)";
            dt.Columns[5].ColumnName = "主键id";
            nowNovelCount = dt.Rows.Count;

            setPageAndNovelCount();
            novelGridView.DataSource = dt;
            resultGroup.Text = "搜索 Nid：" + searchNidTxt.Text + " 结果内容";
            statusLabel.Text = "搜索 Nid：" + searchNidTxt.Text + " 结果成功";
        }

        /// <summary>
        /// 保存信息事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveInfoBtn_Click(object sender, EventArgs e)
        {
            try
            {
                baseMode.novelstate = int.Parse(stateTxt.Text);
                baseMode.type = typeTxt.Text.Trim();
                detailMode.description = descTxt.Text;

                //更新base表
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update novel_base set ");
                strSql.Append("novelstate=" + baseMode.novelstate + ",");
                if (baseMode.type != null)
                {
                    strSql.Append("type='" + baseMode.type + "'");
                }
                strSql.Append(" where id=" + baseMode.id);
                string updateBase = strSql.ToString();
                nbase.UpdateSome(updateBase);

                //更新detail表的描述
                strSql = new StringBuilder();
                strSql.Append("update novel_detail set ");
                if (baseMode.type != null)
                {
                    strSql.Append("description='" + detailMode.description + "'");
                }
                strSql.Append(" where base_id=" + detailMode.base_id);
                string updateDetail = strSql.ToString();
                ndetail.UpdateSome(updateDetail);

                saveInfoBtn.Enabled = false;
                statusLabel.Text = "更新保存成功";
            }
            catch (Exception ee)
            {
                statusLabel.Text = "保存出现错误：" + ee.Message;
            }
        }

        #region 内容改变，保存按钮激活
        private void typeTxt_TextChanged(object sender, EventArgs e)
        {
            saveInfoBtn.Enabled = true;
        }

        private void stateTxt_TextChanged(object sender, EventArgs e)
        {
            saveInfoBtn.Enabled = true;
        }

        private void descTxt_TextChanged(object sender, EventArgs e)
        {
            saveInfoBtn.Enabled = true;
        }
        #endregion

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigForm cForm = new ConfigForm(DBUtility.PubConstant.ConnectionString, everyPageCount, chapterEveryPageCount);
            cForm.ShowDialog();
            if (cForm.isOK)
            {
                DBUtility.PubConstant.ConnectionString = cForm.dbLinkStr;
                everyPageCount = cForm.novelPageCount;
                chapterEveryPageCount = cForm.chapterPageCount;

                allPage = (allNovelCount - 1) / everyPageCount + 1;
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            string str="  关于本小工具。\r\n";
            str += "    开发人：顾代辉\r\n    公司：北京易查无线技术有限公司\r\n    时间：2012-05-07\r\n\r\n";
            str += "        本工具用于易查小说空章节补充，通过连接使用mysql数据库，\r\n    能完成小说简介的编辑，小说章节的编辑，增加，删除等。";
            MessageBox.Show(str,"本软件信息",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
