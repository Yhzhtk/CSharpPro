using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DynBrowser
{
    public partial class TimerForm : Form
    {
        TimerAct timerAct = new TimerAct();

        public TimerAct getTimerAct()
        {
            return timerAct;
        }

        public TimerForm(TimerAct timerAct)
        {
            InitializeComponent();
            this.timerAct = timerAct;
            initListBox(timerAct);
        }

        /// <summary>
        /// 将内容显示到listBox
        /// </summary>
        /// <param name="timerAct"></param>
        private void initListBox(TimerAct timerAct)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < timerAct.acts.Count; i++)
            {
                listBox1.Items.Add(timerAct.acts[i].getContent());
            }
        }

        /// <summary>
        /// 获取listBox中的内容
        /// </summary>
        private TimerAct getTimeAct()
        {
            TimerAct t = new TimerAct();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Act a = new Act(listBox1.Items[i].ToString());
                if (a != null)
                {
                    t.addAct(a);
                }
            }
            return t;
        }

        /// <summary>
        /// 选择操作更改主参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainArgComb.Items.Clear();
            if (actComb.Text.StartsWith("set"))
            {
                mainArgComb.Items.Add("用户名");
                mainArgComb.Items.Add("密码");
                mainArgComb.Items.Add("搜索内容");
                mainArgComb.Items.Add("页码");
                mainArgComb.Items.Add("评论第几个");
                mainArgComb.Items.Add("评论内容");
                statusLab.Text = "请在主参数中，选择需要设置的内容。";
            }
            else if (actComb.Text.StartsWith("click"))
            {
                mainArgComb.Items.Add("打开微博");
                mainArgComb.Items.Add("登录");
                mainArgComb.Items.Add("搜索");
                mainArgComb.Items.Add("翻页");
                mainArgComb.Items.Add("打开评论");
                mainArgComb.Items.Add("发表评论");
                statusLab.Text = "请在主参数中，选择需要点击的内容。";
            }
            else if (actComb.Text.StartsWith("gostep"))
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    mainArgComb.Items.Add(i);
                }
                statusLab.Text = "请在主参数中，选择需要跳转的编号。";
            }
        }

        /// <summary>
        /// 验证延时时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void intervalTxt_Leave(object sender, EventArgs e)
        {
            try
            {
                int.Parse(intervalTxt.Text);
            }
            catch
            {
                MessageBox.Show("延时时间必须是整数。请重新输入！");
                intervalTxt.Text = "";
            }
        }

        /// <summary>
        /// 新增，设置编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            idTxt.Text = listBox1.Items.Count + "";
            statusLab.Text = "新增编号已设置，请填写添加的步骤并保存编辑。";
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateBtn_Click(object sender, EventArgs e)
        {
            Act act = new Act();
            try
            {
                act.id = int.Parse(idTxt.Text);
                act.interval = int.Parse(intervalTxt.Text);

                if (act.act == "" || act.mainArg == "")
                {
                    MessageBox.Show("参数输入不完整！请输入完整后操作");
                }

                act.act = actComb.Text.Split(' ')[0];
                act.mainArg = mainArgComb.Text.Split(' ')[0];
                act.viceArg = otherArgsTxt.Text;
            }
            catch
            {
                MessageBox.Show("保存出错！请检查输入");
                return;
            }

            TimerAct t = getTimeAct();
            bool n = true;
            for (int i = 0; i < t.acts.Count; i++)
            {
                if (t.acts[i].id == act.id)
                {
                    t.acts[i] = act;
                    n = false;
                    break;
                }
            }
            if (n)
            {
                t.acts.Add(act);
            }
            initListBox(t);
            idTxt.Text = "";
            statusLab.Text = "已保存编辑。";
        }

        /// <summary>
        /// 双击选择修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                int index = listBox1.SelectedIndex;
                Act act = new Act(listBox1.Items[index].ToString());

                idTxt.Text = act.id + "";
                intervalTxt.Text = act.interval + "";
                actComb.Text = act.act;
                mainArgComb.Text = act.mainArg;
                otherArgsTxt.Text = act.viceArg;
            }
            statusLab.Text = "已经将选中的内容加载到编辑区。";
        }

        /// <summary>
        /// 关闭窗口时处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerAct = getTimeAct();
        }

        /// <summary>
        /// 删除选中项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int c = listBox1.SelectedItems.Count;
            while (listBox1.SelectedItems.Count > 0)
            {
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
            statusLab.Text = "移除" + c + "步";
        }

        /// <summary>
        /// 主参数选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainArgComb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mainArgComb.Text == "页码" || mainArgComb.Text == "评论第几个")
            {
                otherArgsTxt.Text = "++";
                statusLab.Text = "副参数默认为++，可以指定具体的数字。";
            }
            else if (actComb.Text.StartsWith("gostep"))
            {
                otherArgsTxt.Text = "评论第几个<10 || 页码<50 || 已评论过 || 不是指定来自";
                statusLab.Text = "副参数选择判断条件，只能是 || 中的一个。判断符号可以是 < <= > >= =五个中的一个。";
            }
            else
            {
                otherArgsTxt.Text = "";
                statusLab.Text = "不用设定副参数。";
            }
        }

        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerAct = getTimeAct();
            int c = listBox1.SelectedItems.Count;
            int i = listBox1.SelectedIndex;
            if (listBox1.SelectedItems.Count == 1)
            {
                Act a = new Act(listBox1.Items[i].ToString());
                timerAct.acts.RemoveAt(i);
                timerAct.acts.Insert(i - 1, a);

                initListBox(timerAct);
                statusLab.Text = "上移步骤" + c;
                listBox1.SelectedIndex = i - 1;
            }
            else { statusLab.Text = "选中一个才能移动"; }
        }

        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerAct = getTimeAct();
            int c = listBox1.SelectedItems.Count;
            int i = listBox1.SelectedIndex;
            if (listBox1.SelectedItems.Count == 1)
            {
                Act a = new Act(listBox1.Items[i].ToString());
                timerAct.acts.RemoveAt(i);
                timerAct.acts.Insert(i + 1, a);

                initListBox(timerAct);
                statusLab.Text = "上移步骤" + c;
                listBox1.SelectedIndex = i + 1;
            }
            else
            {
                statusLab.Text = "选中一个才能移动";
            }
        }

        /// <summary>
        /// 移动选定的步骤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Name.Replace("toolStripMenuItem", "").Replace("_","-");
            int step = int.Parse(name);
            timerAct = getTimeAct();
            int c = listBox1.SelectedItems.Count;
            int i = listBox1.SelectedIndex;
            if (listBox1.SelectedItems.Count == 1)
            {
                Act a = new Act(listBox1.Items[i].ToString());
                timerAct.acts.RemoveAt(i);
                timerAct.acts.Insert(i + step, a);

                initListBox(timerAct);
                statusLab.Text = "上移步骤" + c;
                listBox1.SelectedIndex = i + step;
            }
            else
            {
                statusLab.Text = "选中一个才能移动";
            }
        }

        /// <summary>
        /// 编号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seqBtn_Click(object sender, EventArgs e)
        {
            timerAct = getTimeAct();
            for (int i = 0; i < timerAct.acts.Count; i++)
            {
                timerAct.acts[i].id = i;
            }
            initListBox(timerAct);
            statusLab.Text = "序列编号。";
        }

        /// <summary>
        /// 导入搜索关键字表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadKeys_Click(object sender, EventArgs e)
        {
            bool res = false;
            timerAct.acts.Clear();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                List<string> list = Util.readListTxt(openFileDialog.FileName);

                foreach (string key in list)
                {
                    if (key.Trim() == "")
                    {
                        continue;
                    }
                    TimerAct t = TimerAct.getDefaultTimerAct(key, timerAct.acts.Count);
                    timerAct.acts.AddRange(t.acts);
                }
                initListBox(timerAct);
                seqBtn_Click(sender, e);
                res = true;
            }
            this.Refresh();
            if (res)
            {
                statusLab.Text = "导入关键字库成功：" + openFileDialog.FileName;
            }
            else
            {
                statusLab.Text = "取消导入关键字库：" + openFileDialog.FileName;
            }
        }

        /// <summary>
        /// 保存关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
