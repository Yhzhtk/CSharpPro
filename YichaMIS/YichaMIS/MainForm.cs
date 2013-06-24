using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace YichaMIS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            logMethod();
           
        }

        private bool logMethod()
        {
            this.Visible = false;
            bool res = LogUtil.logIn();
            if (res)
            {
                this.Text = Const.userName + ",欢迎使用" + Const.sysName + "系统";
                showStatus(Const.info);
            }
            else
            {
                Application.Exit();
            }
            this.Visible = true;

            if (res && Const.userName == "admin")
            {
                manToolStripMenuItem.Visible = true;
            }
            else
            {
                manToolStripMenuItem.Visible = false;
            }
            return res;
        }

        private void showStatus(string info)
        {
            statusLab.Text = info;
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogUtil.logOut();
            logMethod();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("  本软件用作消费信息记录。\r\n  开发时间：2013-03-25", Const.sysName);
        }

        private void timeTxt_Enter(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            monthCalendar.Location = new Point(t.Location.X, t.Location.Y + t.Height * 2);
            monthCalendar.Visible = true;
        }

        private void timeTxt_Leave(object sender, EventArgs e)
        {
            monthCalendar.Visible = false;
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            TextBox t = startTimeTxt;
            if (monthCalendar.Location.X != t.Location.X || monthCalendar.Location.Y != t.Location.Y + t.Height * 2)
            {
                t = endTimeTxt;
            }
            t.Text = monthCalendar.SelectionEnd.ToString();
            monthCalendar.Visible = false;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string sql = "select [id] as 编号,[shop] as 商户,[phone] as 电话,[money] as 金额,[time] as 时间, [mark] as 备注 from yct ";
            if (startTimeTxt.Text != "" || endTimeTxt.Text != "")
            {
                sql += " where ";
                if (startTimeTxt.Text != "")
                {
                    sql += " [time] > #" + startTimeTxt.Text + "#";
                    if (endTimeTxt.Text != "")
                    {
                        sql += " and [time] < #" + endTimeTxt.Text + "#";
                    }
                }
                else if (endTimeTxt.Text != "")
                {
                    sql += " [time] < #" + endTimeTxt.Text + "#";
                }
            }
            
            DataTable dt = YctOrm.getDataTable(sql);
            dataGridView.DataSource = dt;
            showStatus(Const.info);
        }

        private YctMode getModeFromNowRow()
        {
            YctMode mode = new YctMode();
            DataGridViewRow r = dataGridView.SelectedRows[0];

            mode.id = int.Parse( r.Cells[0].Value.ToString());
            mode.shop = r.Cells[1].Value.ToString();
            mode.phone = r.Cells[2].Value.ToString();
            mode.money = r.Cells[3].Value.ToString();
            mode.time = Convert.ToDateTime(r.Cells[4].Value);
            mode.mark = r.Cells[5].Value.ToString();

            return mode;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YctMode mode = new YctMode();
            mode.shop = Const.userName;
            YctForm yf = new YctForm("新增", mode);
            yf.ShowDialog();
            showStatus(Const.info);
            searchBtn_Click(sender, e);
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YctMode mode = getModeFromNowRow();
            if (mode == null)
            {
                MessageBox.Show("请选中一行进行修改操作。");
                return;
            }

            YctForm yf = new YctForm("修改", mode);
            yf.ShowDialog();
            showStatus(Const.info);
            searchBtn_Click(sender, e);
        }

        private void delToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("删除后不可恢复，确定删除？", "删除提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                YctMode mode = getModeFromNowRow();
                if (mode == null)
                {
                    MessageBox.Show("请选中一行进行删除操作。");
                    return;
                }

                string sql = "delete * from yct where id = " + mode.id;
                YctOrm.exeSql(sql);
                showStatus(Const.info);
            }
        }

        private void pwdManToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PwdForm pf = new PwdForm(Const.userName, true);
            pf.ShowDialog();
            showStatus(Const.info);
        }

        private void manToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PwdForm pf = new PwdForm(Const.userName, false);
            pf.ShowDialog();
            showStatus(Const.info);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "dat文件|*.dat|所有文件|*.*";
            sf.AddExtension = true;
            sf.Title = "导出数据";
            sf.FileName = "shop-" + DateTime.Now.ToString("yyyyMMdd-HHmm");
            if (sf.ShowDialog() == DialogResult.OK)
            {
                /*
                List<LogMode> modes = YctOrm.getLogModes("select * from logs");
                string content = "";
                foreach (LogMode l in modes)
                {
                    content += l.getLogStr() + "\r\n";
                }

                FileStream fs = new FileStream(sf.FileName, FileMode.Create);
                byte[] data = new UTF8Encoding().GetBytes(content);
                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
                 * */
                try
                {
                    File.Copy(System.Windows.Forms.Application.StartupPath + "\\config\\db.dat", sf.FileName);
                    MessageBox.Show("导出成功");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("导出失败:" + ex.Message);
                }
            }
        }
    }
}
