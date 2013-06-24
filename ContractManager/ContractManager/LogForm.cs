using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContractManager
{
    public partial class LogForm : Form
    {
        List<string[]> userPwds = new List<string[]>();

        public bool logOk = false;

        public string userName = "";

        public LogForm()
        {
            InitializeComponent();
            //初始化密码信息
            userPwds = Util.getUserPwdList(ManUserForm.datFile);
            if (userPwds.Count == 0)
            {
                infoLab.Visible = true;
            }
            else
            {
                infoLab.Visible = false;
            }
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            logOk = false;
            string user = userTxt.Text;
            string pwd = pwdTxt.Text;
            if (userPwds.Count == 0)
            {
                logOk = true;
            }
            else
            {
                foreach (string[] up in userPwds)
                {
                    if (user == up[0] && Util.GetMD5(pwd) == up[1])
                    {
                        logOk = true;
                        userName = user;
                        userTxt.Clear();
                        pwdTxt.Clear();
                        this.Close();
                    }
                }
            }

            if (!logOk)
            {
                MessageBox.Show("用户名或密码错误，请重新输入！");
            }
            else
            {
                this.Close();
            }
        }

        private void canelBtn_Click(object sender, EventArgs e)
        {
            logOk = false;
            this.Close();
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            //初始化密码信息
            userPwds = Util.getUserPwdList(ManUserForm.datFile);
            if (userPwds.Count == 0)
            {
                infoLab.Visible = true;
            }
            else
            {
                infoLab.Visible = false;
            }
        }
    }
}
