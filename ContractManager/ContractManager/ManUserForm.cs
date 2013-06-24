using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ContractManager
{
    public partial class ManUserForm : Form
    {
        public static string datFile = "manage.dat";
        public List<string[]> userPwdList;

        public ManUserForm()
        {
            InitializeComponent();
            userPwdList = Util.getUserPwdList(datFile);
        }

        private void ManUserForm_Load(object sender, EventArgs e)
        {
            foreach (string[] l in userPwdList)
            {
                usersList.Items.Add(l[0]);
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cleanBtn_Click(object sender, EventArgs e)
        {
            userTxt.Clear();
            pwdTxt.Clear();
            pwdTxt2.Clear();
        }

        /// <summary>
        /// 添加更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (pwdTxt.Text != pwdTxt2.Text)
            {
                MessageBox.Show("密码确认不一致，请重新输入！");
                pwdTxt.Clear();
                pwdTxt2.Clear();
                return;
            }
            if (pwdTxt.Text == "" || userTxt.Text == "")
            {
                MessageBox.Show("输入不能为空，请输入完整后添加！");
                return;
            }

            if (findUser(userTxt.Text) != null)
            {
                MessageBox.Show("用户：" + userTxt.Text + "已存在！");
                return;
            }
            userPwdList.Add(new string[] { userTxt.Text, Util.GetMD5(pwdTxt.Text) });
            usersList.Items.Add(userTxt.Text);
            statusLab.Text = "添加用户：" + userTxt.Text + "成功！";
            userTxt.Clear();
            pwdTxt.Clear();
            pwdTxt2.Clear();

        }


        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (usersList.SelectedItems.Count == 1)
            {
                string user = usersList.SelectedItems[0].ToString();
                string[] up = delUser(user);
                usersList.Items.Remove(usersList.SelectedItems[0]);
            }
        }

        /// <summary>
        /// 查找用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string[] findUser(string user)
        {
            foreach (string[] l in userPwdList)
            {
                if (l[0] == user)
                {
                    return l;
                }
            }
            return null;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private string[] delUser(string user)
        {
            foreach (string[] l in userPwdList)
            {
                if (l[0] == user)
                {
                    userPwdList.Remove(l);
                    break;
                }
            }
            return null;
        }

        /// <summary>
        /// 保存到文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string content = "";

            foreach (string[] l in userPwdList)
            {
                content += l[0] + "\t" + l[1] + "\r\n";
            }

            Util.writeTxt(datFile, content);
        }
    }
}
