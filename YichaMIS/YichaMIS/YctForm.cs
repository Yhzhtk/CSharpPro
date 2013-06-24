using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YichaMIS
{
    public partial class YctForm : Form
    {
        YctMode mode;
        string act;

        public YctForm(string act, YctMode mode)
        {
            this.act = act;
            this.mode = mode;
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeTxt.Text = DateTime.Now.ToString();
        }

        private void YctForm_Load(object sender, EventArgs e)
        {
            shopTxt.Text = Const.userName;
            this.Text = act + "数据";
            this.okBtn.Text = "确定" + act;

            this.shopTxt.Text = mode.shop;
            this.phoneTxt.Text = mode.phone;
            this.moneyTxt.Text = mode.money;
            this.markTxt.Text = mode.mark;

            timer1.Enabled = true;
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            this.phoneTxt.Clear();
            this.moneyTxt.Clear();
            this.markTxt.Clear();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            mode.shop = shopTxt.Text;
            mode.phone = phoneTxt.Text;
            mode.money = moneyTxt.Text;
            mode.time = DateTime.Parse(timeTxt.Text);
            mode.mark = markTxt.Text;

            if (act == "新增")
            {
                if (YctOrm.insertYctMode(mode) == 1)
                {
                    Const.info = "添加成功！ " + Const.info;
                }
                else
                {
                    Const.info = "添加失败!" + Const.info;
                }
            }
            else
            {
                if (YctOrm.updateYctMode(mode) == 1)
                {
                    Const.info = "修改成功！ " + Const.info;
                }
                else
                {
                    Const.info = "修改失败!" + Const.info;
                }
            }

            this.Close();
            this.Dispose();
        }
    }
}
