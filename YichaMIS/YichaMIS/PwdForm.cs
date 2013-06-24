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
    public partial class PwdForm : Form
    {
        string usr;
        public PwdForm(string usr, bool gaimi)
        {
            InitializeComponent();
            this.usr = usr;
            this.usrTxt.Text = usr;
            if (usr == "admin" && !gaimi)
            {
                usrTxt.Enabled = true;
                oPwdTxt.Text = "输入新密码可建新用户";
                oPwdTxt.Enabled = false;
            }
            else
            {
                usrTxt.Enabled = false;
            }
        }

        private void canelBtn_Click(object sender, EventArgs e)
        {
            Const.info = "取消修改密码";
            this.Close();
            this.Dispose();
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            string user = usrTxt.Text;
            string opwd = oPwdTxt.Text;
            string npwd = nPwdTxt.Text;
            string n2pwd = n2PwdTxt.Text;

            if (!usrTxt.Enabled)
            {
                if (!LogUtil.logIn(user, opwd))
                {
                    MessageBox.Show("原始密码错误。请重新输入！", "密码错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (npwd != n2pwd)
            {
                MessageBox.Show("两次新密码不一致，请重新输入！", "密码不一致", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!usrTxt.Enabled)
            {
                LogUtil.updatePwd(user, npwd);
            }
            else
            {
                LogUtil.insertPwd(user, npwd);
            }

            this.Close();
            this.Dispose();
        }
    }
}
