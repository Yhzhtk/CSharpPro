using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace YichaMIS
{
    class YctOrm
    {
        static OleDbConnection conn;
        static OleDbCommand cmd;
        static OleDbDataReader reader;

        public static List<YctMode> getYctModes(string sql)
        {
            LogMode l = new LogMode(sql);
            List<YctMode> modes = new List<YctMode>();
            try
            {
                conn = DbUtil.getConn();
                cmd = new OleDbCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    YctMode m = new YctMode();

                    m.id = (int)reader["id"];
                    m.shop = reader["shop"].ToString();
                    m.money = reader["money"].ToString();
                    m.phone = reader["phone"].ToString();
                    m.time = (DateTime)reader["time"];
                    m.mark = reader["mark"].ToString();

                    modes.Add(m);
                }
                l.act = "ok\t" + l.act;
                reader.Close();
                Const.info = "查询：" + modes.Count;
            }
            catch (Exception e)
            {
                Const.info = e.Message;
                l.act = "fail:" + e.Message + "\t" + l.act;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            insertLogMode(l);
            return modes;
        }

        public static int insertYctMode(YctMode m)
        {
            LogMode l = new LogMode(m.getModeStr());
            int i = -1;
            try
            {
                conn = DbUtil.getConn();
                conn.Open();

                string sql = "insert into yct([shop], [phone], [money], [time], [mark]) values('" + m.shop
                    + "','" + m.phone + "','" + m.money + "','" + m.time + "','" + m.mark + "')";
                l = new LogMode(sql);
                cmd = new OleDbCommand(sql, conn);
                i = cmd.ExecuteNonQuery();
                Const.info = "插入：1";
                l.act = "ok\t" + l.act;
            }
            catch (Exception e)
            {
                Const.info = e.Message;
                l.act = "fail:" + e.Message + "\t" + l.act;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            insertLogMode(l);
            return i;
        }

        public static int updateYctMode(YctMode m)
        {
            LogMode l = new LogMode(m.getModeStr());
            int i = -1;
            try
            {
                conn = DbUtil.getConn();
                conn.Open();

                string sql = "update yct set [shop] = '" + m.shop
                    + "', [phone] = '" + m.phone + "', [money] = '" + m.money
                    + "', [time] = '" + m.time + "', [mark] = '" + m.mark
                    + "' where id = " + m.id;
                l = new LogMode(sql);
                cmd = new OleDbCommand(sql, conn);
                i = cmd.ExecuteNonQuery();
                Const.info = "更新：" + i;
                l.act = "ok\t" + l.act;
            }
            catch (Exception e)
            {
                Const.info = e.Message;
                l.act = "fail:" + e.Message + "\t" + l.act;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            insertLogMode(l);
            return i;
        }

        public static int getRsCount(string sql)
        {
            LogMode l = new LogMode(sql);
            int i = -1;
            try
            {
                conn = DbUtil.getConn();
                conn.Open();

                cmd = new OleDbCommand(sql, conn);
                reader = cmd.ExecuteReader();

                i = 0;
                while (reader.Read())
                {
                    i++;
                }
                l.act = "ok\t" + l.act;
                reader.Close();
            }
            catch (Exception e)
            {
                Const.info = e.Message;
                l.act = "fail:" + e.Message + "\t" + l.act;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            insertLogMode(l);
            return i;
        }

        public static int exeSql(string sql)
        {
            LogMode l = new LogMode(sql);
            int i = -1;
            try
            {
                conn = DbUtil.getConn();
                conn.Open();

                cmd = new OleDbCommand(sql, conn);
                i = cmd.ExecuteNonQuery();

                Const.info = "修改：" + i;
                l.act = "ok\t" + l.act;
            }
            catch (Exception e)
            {
                Const.info = e.Message;
                l.act = "fail:" + e.Message + "\t" + l.act;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            insertLogMode(l);
            return i;
        }

        public static DataTable getDataTable(string sql)
        {
            LogMode l = new LogMode(sql);

            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            try
            {
                conn = DbUtil.getConn();
                conn.Open();
                cmd = new OleDbCommand(sql, conn);
                da.SelectCommand = cmd;
                da.Fill(dt);
                Const.info = "查询表";

                l.act = "ok\t" + l.act;
            }
            catch (Exception e)
            {
                Const.info = e.Message;
                l.act = "fail:" + e.Message + "\t" + l.act;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            insertLogMode(l);
            return dt;
        }

        public static int insertLogMode(LogMode m)
        {
            int i = -1;
            try
            {
                conn = DbUtil.getConn();
                conn.Open();

                string sql = "insert into logs([user], [act], [time]) values('" + m.user
                    + "','" + m.act + "','" + m.time + "')";
                cmd = new OleDbCommand(sql, conn);
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Const.info = e.Message;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return i;
        }

        public static List<LogMode> getLogModes(string sql)
        {
            List<LogMode> modes = new List<LogMode>();
            try
            {
                conn = DbUtil.getConn();
                cmd = new OleDbCommand(sql, conn);
                conn.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    LogMode m = new LogMode();

                    m.id = (int)reader["id"];
                    m.user = reader["user"].ToString();
                    m.act = reader["act"].ToString();
                    m.time = Convert.ToDateTime(reader["time"]);

                    modes.Add(m);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Const.info = e.Message;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return modes;
        }
    }
}
