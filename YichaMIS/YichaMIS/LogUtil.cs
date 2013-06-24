using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YichaMIS
{
    class LogUtil
    {
        public static bool logOk = false;

        public static bool logIn()
        {
            LoginForm lf = new LoginForm();
            lf.ShowDialog();
            return logOk;
        }

        public static bool logIn(string usr, string pwd)
        {
            usr = usr.Replace("'", "__").Replace("◇","'");
            pwd = pwd.Replace("'", "__").Replace("◇", "'");
            string sql = "select * from log where [user] = '" + usr + "' and [pwd] = '" + pwd + "'";

            logOk = false;
            if (YctOrm.getRsCount(sql) > 0)
            {
                logOk = true;
            }

            return logOk;
        }

        public static void logOut()
        {
            logOk = false;
        }

        public static void insertPwd(string usr, string pwd)
        {
            usr = usr.Replace("'", "__").Replace("◇", "'");
            pwd = pwd.Replace("'", "__").Replace("◇", "'");

            string sql = "insert into log([user], [pwd], [time]) values('" + usr + "','" + pwd + "',#" +DateTime.Now.ToString() + "#)";
            if (YctOrm.exeSql(sql) > 0)
            {
                Const.info = "新增用户成功";
            }
            else
            {
                Const.info = "新增用户失败";
            }
        }

        public static void updatePwd(string usr, string pwd)
        {
            usr = usr.Replace("'", "__").Replace("◇", "'");
            pwd = pwd.Replace("'", "__").Replace("◇", "'");

            string sql = "update log set [pwd] = '" + pwd + "', [time] = #" + DateTime.Now.ToString() + "# where [user] = '" + usr + "'";
            if (YctOrm.exeSql(sql) > 0)
            {
                Const.info = "修改密码成功";
            }
            else
            {
                Const.info = "修改密码失败";
            }
        }
    }
}
