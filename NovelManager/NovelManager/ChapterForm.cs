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
    public partial class ChapterForm : Form
    {

        List<Model.Chapter> allChaps;

        List<int> blankReq = new List<int>();//是否空章序列，空在前，非空在后

        int nowChapterCount = 0;
        int allChapterCount = 0;
        int everyPageCount = 10;
        int nowPage = 0;
        int allPage = 0;

        int maxChapId = 0;//当前最大的cid

        int nowChapIndex = -1;//当前显示的chap在allchaps中的index

        novel_base nbase = new novel_base();
        novel_chapter_content nchapCon = new novel_chapter_content();
        novel_detail ndetail = new novel_detail();

        public ChapterForm(int baseId, string nid, string nname, int everyCount)
        {
            InitializeComponent();
            baseIdTxt.Text = baseId.ToString();
            nameTxt.Text = nname;
            nidTxt.Text = nid;
            everyPageCount = everyCount;
        }

        private void ChapterForm_Load(object sender, EventArgs e)
        {
            this.Text = "修改小说  " + nameTxt.Text + "  章节内容";


            if (nidTxt.Text != "")
            {
                allChaps = getChapters(nidTxt.Text);
                if (allChaps.Count > 0)
                {
                    nowPage = 1;
                    showChapters(allChaps, nowPage);
                    setPageAndChapterCount();
                }
            }

            getBlankReq();
        }

        /// <summary>
        /// 获取空章节排序序列
        /// </summary>
        private void getBlankReq()
        {
            blankReq.Clear();
            if (allChaps != null)
            {
                //获取空章节排序序列
                for (int i = 0; i < allChaps.Count; i++)
                {
                    if (allChaps[i].IsEmpty == 1)
                        blankReq.Add(i);
                }
                for (int i = 0; i < allChaps.Count; i++)
                {
                    if (allChaps[i].IsEmpty == 0)
                        blankReq.Add(i);
                }
            }
        }

        /// <summary>
        /// 设置页数和章节数数
        /// </summary>
        private void setPageAndChapterCount()
        {
            novelCountLabel.Text = nowChapterCount + "/" + allChapterCount;
            novelPageLabel.Text = nowPage + "/" + allPage;
        }

        /// <summary>
        /// 根据nid获得并解析为chapter
        /// </summary>
        /// <param name="nid"></param>
        /// <returns></returns>
        private List<Model.Chapter> getChapters(string nid)
        {
            DataSet ds = ndetail.GetList("Nid='" + nid + "'");
            string chapContent = ds.Tables[0].Rows[0][8].ToString();
            string blankChap = ds.Tables[0].Rows[0][9].ToString();
            string[] chapCons = chapContent.Split(new string[] { "$-$" }, StringSplitOptions.None);
            string[] blankChps = blankChap.Split(',');

            List<Model.Chapter> chaps = new List<Model.Chapter>();
            foreach (string chap in chapCons)
            {
                string[] infos = chap.Split(new string[] { "#-#" }, StringSplitOptions.None);

                if (infos.Length != 2)
                    continue;

                Model.Chapter c = new Model.Chapter();
                try
                {
                    c.Cid = int.Parse(infos[0]);
                    maxChapId = Math.Max(maxChapId, c.Cid);
                }
                catch (Exception e)
                {
                    c.Cid = -1;
                    statusLabel.Text = "章节获取错误：" + e.Message;
                }
                c.Name = infos[1];
                c.IsEmpty = getIsBlank(blankChps, c.Cid + "");
                chaps.Add(c);
            }

            allChapterCount = chaps.Count;
            allPage = (allChapterCount - 1) / everyPageCount + 1;
            return chaps;
        }


        /// <summary>
        /// 将小说信息显示在gridview上
        /// </summary>
        /// <param name="chaps"></param>
        private void showChapters(List<Model.Chapter> chaps, int page)
        {
            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("Cid", System.Type.GetType("System.Int16"));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("章节名称", System.Type.GetType("System.String"));
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("是否空章(1空0非)", System.Type.GetType("System.Int16"));
            dt.Columns.Add(dc3);

            int startChap = (page - 1) * everyPageCount;
            int endChap = Math.Min(page * everyPageCount, allChapterCount);

            nowChapterCount = endChap - startChap;
            for (int i = startChap; i < endChap; i++)
            {
                DataRow dr = dt.NewRow();

                if (seqRadio.Checked)//序列排序显示
                {
                    dr[0] = allChaps[i].Cid;
                    dr[1] = allChaps[i].Name;
                    dr[2] = allChaps[i].IsEmpty;
                }
                else if (blankReqRadio.Checked)//按是否为空排序
                {
                    dr[0] = allChaps[blankReq[i]].Cid;
                    dr[1] = allChaps[blankReq[i]].Name;
                    dr[2] = allChaps[blankReq[i]].IsEmpty;
                }
                dt.Rows.Add(dr);
            }

            chapterGridView.DataSource = dt;
            chapterGridView.Columns[1].Width = 360;
        }


        /// <summary>
        /// 判断是否在空章节里
        /// </summary>
        /// <param name="blankChps"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        private int getIsBlank(string[] blankChps, string id)
        {
            foreach (string info in blankChps)
            {
                if (info == id)
                    return 1;
            }
            return 0;
        }

        /// <summary>
        /// 选择章节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chapterGridView_SelectionChanged(object sender, EventArgs e)
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
            
            if (chapterGridView.SelectedRows.Count > 0 && chapterGridView.Rows.Count == nowChapterCount)
            {
                int index = chapterGridView.SelectedRows[0].Index;
                if (seqRadio.Checked)
                {
                    nowChapIndex = (nowPage - 1) * everyPageCount + index;
                }
                else if (blankReqRadio.Checked)
                {
                    nowChapIndex = blankReq[(nowPage - 1) * everyPageCount + index];
                }
                showCidContent(allChaps[nowChapIndex]);
            }
        }

        /// <summary>
        /// 显示nid对应的章节信息
        /// </summary>
        /// <param name="nid"></param>
        private void showCidContent(Model.Chapter chap)
        {
            statusLabel.Text = "正在加载小说信息，cid为：" + allChaps[nowChapIndex].Cid + "  请稍候。。。。";
            statusStrip1.Refresh();
            try
            {
                if (chap.Content == null || chap.Content.content == null || chap.Content.content == "")
                {
                    chap.Content = nchapCon.GetModel(nidTxt.Text, chap.Cid);
                }
                if (chap.Content == null)
                {
                    chap.Content = new Model.novel_chapter_content();
                }

                cidTxt.Text = chap.Cid.ToString();
                cNameTxt.Text = chap.Name;
                emptyTxt.Text = chap.IsEmpty.ToString();

                if (chap.Content != null)
                {
                    cContentTxt.Text = chap.Content.content;
                    statusLabel.Text = "加载章节信息成功，nid为：" + nidTxt.Text + " ,cid为：" + chap.Cid;
                }
                else
                {
                    cContentTxt.Text = "";
                    statusLabel.Text = "章节内容为空，nid为：" + nidTxt.Text + " ,cid为：" + chap.Cid;
                }
                statusStrip1.Refresh();
            }
            catch (Exception ee)
            {
                statusLabel.Text = "获取小说内容出错：" + ee.Message;
            }
            saveInfoBtn.Enabled = false;

            saveInfoBtn.Enabled = false;
        }

        /// <summary>
        /// 重读章节信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reReadBtn_Click(object sender, EventArgs e)
        {
            showCidContent(allChaps[nowChapIndex]);
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
            showChapters(allChaps, nowPage);
            setPageAndChapterCount();
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
            showChapters(allChaps, nowPage);
            setPageAndChapterCount();
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
            showChapters(allChaps, nowPage);
            setPageAndChapterCount();
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
            showChapters(allChaps, nowPage);
            setPageAndChapterCount();
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
                    showChapters(allChaps, nowPage);
                    setPageAndChapterCount();
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
        /// 搜索指定cid的章节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchCidBtn_Click(object sender, EventArgs e)
        {
            int searchCid = -1;
            try
            {
                searchCid = int.Parse(searchCidTxt.Text.Trim());
            }
            catch
            {
                statusLabel.Text = "搜索的 Cid 必须为数字。";
                return;
            }

            int index = -1;
            for (int i = 0; i < allChaps.Count; i++)
            {
                if (allChaps[i].Cid == searchCid)
                {
                    index = i;
                    break;
                }
            }

            DataTable dt = new DataTable();

            DataColumn dc1 = new DataColumn("Cid", System.Type.GetType("System.Int16"));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("章节名称", System.Type.GetType("System.String"));
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("是否空章(1空0非)", System.Type.GetType("System.Int16"));
            dt.Columns.Add(dc3);
            if (index == -1)
            {
                nowChapterCount = 0;
                statusLabel.Text = "搜索 Nid：" + searchCidTxt.Text + " 结果为空";
            }
            else
            {
                nowChapIndex = index;
                nowChapterCount = 0;

                DataRow dr = dt.NewRow();
                dr[0] = allChaps[nowChapIndex].Cid;
                dr[1] = allChaps[nowChapIndex].Name;
                dr[2] = allChaps[nowChapIndex].IsEmpty;
                dt.Rows.Add(dr);

                statusLabel.Text = "搜索 Nid：" + searchCidTxt.Text + " 结果成功";
            }

            setPageAndChapterCount();
            chapterGridView.DataSource = dt;

            showCidContent(allChaps[nowChapIndex]);
            resultGroup.Text = "搜索 Nid：" + searchCidTxt.Text + " 结果内容";
        }

        /// <summary>
        /// 删除章节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delChapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = chapterGridView.SelectedRows[0].Index;

            if (seqRadio.Checked)
            {
                allChaps.RemoveAt((nowPage - 1) * everyPageCount + index);
            }
            else if (blankReqRadio.Checked)
            {
                allChaps.RemoveAt(blankReq[(nowPage - 1) * everyPageCount + index]);
            }
            getBlankReq();
            chapterGridView.Rows.RemoveAt(index);

            //总数和页数改变
            allChapterCount--;
            nowChapterCount--;
            allPage = (allChapterCount - 1) / everyPageCount + 1;
        }

        private void cnameTxt_TextChanged(object sender, EventArgs e)
        {
            saveInfoBtn.Enabled = true;
            submitSqlBtn.Enabled = true;
        }

        private void cContentTxt_TextChanged(object sender, EventArgs e)
        {
            saveInfoBtn.Enabled = true;
            submitSqlBtn.Enabled = true;
        }

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveInfoBtn_Click(object sender, EventArgs e)
        {
            allChaps[nowChapIndex].Name = cNameTxt.Text;
            allChaps[nowChapIndex].Content.content = cContentTxt.Text;
            allChaps[nowChapIndex].Content.cid = int.Parse(cidTxt.Text);

            if (cContentTxt.Text.Trim() != "")
            {
                allChaps[nowChapIndex].IsEmpty = 0;
            }
            else
            {
                allChaps[nowChapIndex].IsEmpty = 1;
            }

            allChaps[nowChapIndex].IsUpdate = true;
            saveInfoBtn.Enabled = false;
        }

        /// <summary>
        /// 将所有修改写入数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitSqlBtn_Click(object sender, EventArgs e)
        {
            string chapterStr = "";
            string blankChapterStr = "";

            int blankCount = 0;

            foreach (Model.Chapter chap in allChaps)
            {
                if (chap.IsUpdate)
                {
                    //为空则新增
                    if (chap.Content.nid == null)
                    {
                        chap.Content.base_id = int.Parse(baseIdTxt.Text);
                        chap.Content.nid = nidTxt.Text;
                        nchapCon.Add(chap.Content);
                    }
                    else//否则则修改
                    {
                        nchapCon.Update(chap.Content);
                    }
                }

                chapterStr += "$-$" + chap.Cid + "#-#" + chap.Name;
                if (chap.IsEmpty == 1)
                {
                    blankChapterStr += "," + chap.Cid;
                    blankCount++;
                }
            }

            chapterStr = chapterStr.Substring(3);
            if (blankChapterStr.StartsWith(","))
            {
                blankChapterStr = blankChapterStr.Substring(1);
            }

            //更新detail表的描述
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update novel_detail set ");
            strSql.Append("chapter='" + chapterStr + "',");
            strSql.Append("blank_chapter='" + blankChapterStr + "'");
            strSql.Append(" where nid='" + nidTxt.Text + "'");
            string updateDetail = strSql.ToString();
            ndetail.UpdateSome(updateDetail);


            string updateBlankCountSql = "update novel_base set blankchapter_count=" + blankCount + " where nid='" + nidTxt.Text + "'";
            nbase.UpdateSome(updateBlankCountSql);

            submitSqlBtn.Enabled = false;
            statusLabel.Text = "更新保存成功";
        }

        /// <summary>
        /// 添加章节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addChapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChapterForm acForm = new AddChapterForm(++maxChapId);
            acForm.ShowDialog();

            if (acForm.isOK)
            {
                Model.Chapter chap = new Model.Chapter();
                chap.Cid = acForm.cid;
                chap.Name = acForm.cName;
                chap.IsEmpty = acForm.isEmpty;
                if (acForm.cContent != "")
                {
                    chap.Content = new Model.novel_chapter_content();
                    chap.Content.cid = chap.Cid;
                    chap.Content.content = acForm.cContent;
                    chap.IsUpdate = true;
                }

                allChaps.Add(chap);
                allChapterCount++;
                allPage = (allChapterCount - 1) / everyPageCount + 1;
                acForm.Dispose();

                statusLabel.Text = "添加成功！请刷新查看";
            }
            else
            {
                statusLabel.Text = "添加已取消";
            }
        }

        private void ChapterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (submitSqlBtn.Enabled)
            {
                MessageBox.Show("未写入数据库，不允许关闭。请先保存数据库");
                e.Cancel = true;
            }
        }
    }
}