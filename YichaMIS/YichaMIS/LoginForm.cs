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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void logBtn_Click(object sender, EventArgs e)
        {
            string usr = userTxt.Text;
            string pwd = pwdTxt.Text;

            if (LogUtil.logIn(usr, pwd))
            {
                Const.info = "登录成功！你好：" + usr + " 欢迎使用" + Const.sysName;
                Const.userName = usr;
                this.Close();
                this.Dispose();
            }
            else 
            {
                MessageBox.Show("用户名或密码错误，请重新输入。", "登录失败！");
                this.pwdTxt.Clear();
            }
        }
    }
}
