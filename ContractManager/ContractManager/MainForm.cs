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
    public partial class MainForm : Form
    {
        public static string fName = "contracts.db";

        /// <summary>
        /// 是否已修改数据
        /// </summary>
        bool update = false;

        /// <summary>
        /// 登陆界面
        /// </summary>
        LogForm lf = new LogForm();

        /// <summary>
        /// 当前日期txt
        /// </summary>
        ToolStripTextBox nowText;

        public MainForm()
        {
            InitializeComponent();

            if (!Directory.Exists(Contract.relativePath))
            {
                Directory.CreateDirectory(Contract.relativePath);
            }
        }

        /// <summary>
        /// 实现登陆功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;

            lf.ShowDialog();
            if (!lf.logOk)
            {
                MessageBox.Show("对不起，登陆失败！");
                this.Close();
                this.Dispose();
            }
            else
            {
                this.Visible = true;
                welcomLab.Text = "你好！" + lf.userName;

                openToolStripMenuItem_Click(sender, e);
                update = false;
            }
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            lf.ShowDialog();
            if (!lf.logOk)
            {
                MessageBox.Show("对不起，登陆失败！");
                this.Close();
                this.Dispose();
            }
            else
            {
                this.Visible = true;
                welcomLab.Text = "你好！" + lf.userName;
            }
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// 改变大小移动右上角图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            logoPanel.Location = new Point(this.Size.Width - 123, 0);
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\r\n中国联通唐山市曹妃甸区分公司合同管理系统\r\n\r\n时间：2012-11-15\r\n\r\n作者：yh", "关于该软件");
        }

        /// <summary>
        /// 弹出对话框，添加新合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNewContractBtn_Click(object sender, EventArgs e)
        {
            ContractEditForm cef = new ContractEditForm("add", "添加新合同", "确定添加", null);
            cef.ShowDialog();

            if (cef.IsCanel)
            {
                cef.Dispose();
                return;
            }

            Contract con = cef.Contract;
            if (con != null)
            {
                if (con.fileName != "")
                {
                    FileInfo f = new FileInfo(con.fileName);
                    if (new FileInfo(Contract.relativePath + f.Name).Exists)
                    {
                        statusLab.Text = "已经存在文件名为：" + Contract.relativePath + f.Name + " 的文件，请更改文件名再添加";
                        MessageBox.Show(statusLab.Text);
                        return;
                    }
                    f.CopyTo(Contract.relativePath + f.Name);
                    con.fileName = f.Name;
                }

                DataRow row = showDataSet.Tables[0].NewRow();
                row = ContractUtil.getRowFromContract(row, con);

                showDataSet.Tables[0].Rows.Add(row);

                //自动保存数据
                saveToolStripMenuItem_Click(sender, e);
            }
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*string hz = "合同信息文件|*.db";
            saveFileDialog.Filter = hz;
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.FileName = "contracts.db";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog.FileName;
             * }
            */
            ExcelUtil.writeExcelFromDataGridView(showDataGridView, fName);

            statusLab.Text = ExcelUtil.statusLab;
            //MessageBox.Show("信息已保存到Excel表格，谢谢你的工作！", "成功！");

        }

        /// <summary>
        /// 打开合同信息文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*string hz = "合同信息文件|*.db";
            openFileDialog.Filter = hz;
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FileName = "contracts.db";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fName = openFileDialog.FileName;
            */
            FileInfo file = new FileInfo(fName);
            if (!file.Exists)
            {
                return;
            }

            List<Contract> list = ExcelUtil.getContractsFromExcel(fName);
            showDataSet.Tables[0].Rows.Clear();
            foreach (Contract con in list)
            {
                DataRow row = showDataSet.Tables[0].NewRow();
                row = ContractUtil.getRowFromContract(row, con);
                showDataSet.Tables[0].Rows.Add(row);
            }
            statusLab.Text = "打开合同信息文件数据库：" + fName;
        }

        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchStripBtn_Click(object sender, EventArgs e)
        {
            string clas = searchCombo.Text;
            string content = searchTxt.Text;

            if (clas == "" || content == "")
            {
                MessageBox.Show("搜索类型和搜索内容不能为空，请输入完整后再搜索！");
                return;
            }
            clas = clas.Replace("按", "").Replace("查找", "");

            List<DataRow> resRows = ContractUtil.findContract(showDataSet, clas, content);
            searchDataSet.Tables[0].Rows.Clear();
            foreach (DataRow row in resRows)
            {
                Contract con = ContractUtil.getContractFromRow(row);
                DataRow nrow = searchDataSet.Tables[0].NewRow();
                nrow = ContractUtil.getRowFromContract(nrow, con);
                searchDataSet.Tables[0].Rows.Add(nrow);
            }
            statusLab.Text = ContractUtil.statusLab;
        }

        /// <summary>
        /// 查看详细合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showDataGridView_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = null;
            if (tabControl1.SelectedIndex == 0)
            {
                dgv = showDataGridView;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                dgv = searchDataGridView1;
            }

            if (dgv == null || dgv.SelectedRows.Count != 1)
            {
                statusLab.Text = "无法在选择多行时查看合同信息，请双击行头选择一行时查看相应信息！";
                return;
            }

            int i = dgv.SelectedRows[0].Index;

            Contract con = ContractUtil.getContractFromRow(((DataSet)dgv.DataSource).Tables[0].Rows[i]);

            ContractEditForm cef = new ContractEditForm("show", "查看合同详细信息", "确定", con);
            cef.ShowDialog();
            cef.Dispose();
        }

        /// <summary>
        /// 删除合同
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delToolStripButton2_Click(object sender, EventArgs e)
        {
            DataGridView dgv = null;
            if (tabControl1.SelectedIndex == 0)
            {
                dgv = showDataGridView;
            }
            else
            {
                MessageBox.Show("只能在所有页面里面才能删除合同，不能在搜索结果中删除！");
                return;
            }

            if (dgv.SelectedRows.Count != 1)
            {
                MessageBox.Show("无法在选择多行时删除合同信息，请双击行头选择一行时再删除相应信息！");
                return;
            }

            int i = dgv.SelectedRows[0].Index;

            //提示是否删除
            if (MessageBox.Show("删除合同信息后不可恢复，确定删除！", "警告", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }

            //删除对应的文件
            string fileName = ((DataSet)dgv.DataSource).Tables[0].Rows[i][20].ToString();
            fileName = Contract.relativePath + fileName;
            FileInfo f = new FileInfo(fileName);
            if (f.Exists)
            {
                f.Delete();
            }

            string con = dgv.SelectedRows[0].Cells[2] + "   " + dgv.SelectedRows[0].Cells[0];
            showDataSet.Tables[0].Rows.RemoveAt(i);

            //自动保存数据
            saveToolStripMenuItem_Click(sender, e);
            statusLab.Text = "删除成功：" + con;
        }

        /// <summary>
        /// 查看详细合同文本
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showDeatilTxtBtn_Click(object sender, EventArgs e)
        {
            DataGridView dgv = null;
            if (tabControl1.SelectedIndex == 0)
            {
                dgv = showDataGridView;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                dgv = searchDataGridView1;
            }

            if (dgv == null || dgv.SelectedRows.Count != 1)
            {
                statusLab.Text = "无法在选择多行时查看合同文本，请双击行头选择一行时查看相应信息！";
                return;
            }

            int i = dgv.SelectedRows[0].Index;

            Contract con = ContractUtil.getContractFromRow(((DataSet)dgv.DataSource).Tables[0].Rows[i]);

            TxtForm tf = new TxtForm("查看合同文本", con, true);
            tf.Show();
        }

        /// <summary>
        /// 查看合同文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showFileToolStripButton1_Click(object sender, EventArgs e)
        {
            DataGridView dgv = null;
            if (tabControl1.SelectedIndex == 0)
            {
                dgv = showDataGridView;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                dgv = searchDataGridView1;
            }

            if (dgv == null || dgv.SelectedRows.Count != 1)
            {
                statusLab.Text = "无法在选择多行时查看合同文件，请双击行头选择一行时查看相应信息！";
                return;
            }

            int i = dgv.SelectedRows[0].Index;
            string fileName = ((DataSet)dgv.DataSource).Tables[0].Rows[i][20].ToString();
            fileName = Contract.relativePath + fileName;
            try
            {
                if (new FileInfo(fileName).Exists)
                {
                    System.Diagnostics.Process pro = new System.Diagnostics.Process();
                    pro.EnableRaisingEvents = false;
                    pro.StartInfo.FileName = fileName;
                    pro.Start();
                    statusLab.Text = "打开文件，路径为：" + fileName;
                    return;
                }
                else
                {
                    statusLab.Text = "打开文件不存在：" + fileName;
                }
            }
            catch (Exception ee)
            {
                statusLab.Text = "打开文件出错:" + ee.Message + "请检查路径：" + fileName;
            }
        }

        /// <summary>
        /// 离开一行时，保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showDataGridView_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (update)
            {
                saveToolStripMenuItem_Click(sender, null);
                update = false;
            }
        }

        /// <summary>
        /// cell数据改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            update = true;
        }

        /// <summary>
        /// 帮助
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "help.txt";
            if (new FileInfo(fileName).Exists)
            {
                System.Diagnostics.Process pro = new System.Diagnostics.Process();
                pro.EnableRaisingEvents = false;
                pro.StartInfo.FileName = fileName;
                pro.Start();
                statusLab.Text = "打开帮助文件，路径为：" + fileName;
                return;
            }
            else
            {
                statusLab.Text = "帮助文件不存在：" + fileName;
            }
        }

        /// <summary>
        /// 管理用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManUserForm muf = new ManUserForm();
            muf.ShowDialog();
        }

        /// <summary>
        /// 点击日期窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startTxtToolStripTextBox1_Enter(object sender, EventArgs e)
        {
            nowText = (ToolStripTextBox)sender;

            monthCalendar.Location = new Point(nowText.TextBox.Location.X, nowText.TextBox.Location.Y + nowText.Size.Height + 5);
            monthCalendar.SetDate((nowText.Text != "") ? DateTime.Parse(nowText.Text) : DateTime.Now);
            monthCalendar.Visible = true;

        }

        /// <summary>
        /// 鼠标移出日期控件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar_MouseLeave(object sender, EventArgs e)
        {
            //nowText.Text = monthCalendar.SelectionEnd.ToString().Substring(0, 10);
            monthCalendar.Visible = false;
        }

        /// <summary>
        /// 选择日起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            nowText.Text = monthCalendar.SelectionEnd.ToString().Substring(0, 10);
            monthCalendar.Visible = false;
        }

        /// <summary>
        /// 查找排序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchTimeToolStripButton1_Click(object sender, EventArgs e)
        {
            if (startTxtToolStripTextBox1.Text == "" || endTxtToolStripTextBox2.Text == "")
            {
                MessageBox.Show("查询开始时间和结束时间不能为空！");
                return;
            }

            expireDataSet.Tables[0].Rows.Clear();
            for (int i = 0; i < showDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow row = showDataSet.Tables[0].Rows[i];
                Contract con = ContractUtil.getContractFromRow(row);
                DateTime cTime;
                try
                {
                    cTime = DateTime.Parse(con.proExpireData);
                }
                catch { continue; }

                DateTime sTime = DateTime.Parse(startTxtToolStripTextBox1.Text);
                DateTime eTime = DateTime.Parse(endTxtToolStripTextBox2.Text);

                if ((cTime.CompareTo(sTime) >= 0) && (cTime.CompareTo(eTime) <= 0))
                {
                    DataRow nrow = expireDataSet.Tables[0].NewRow();
                    nrow = ContractUtil.getRowFromContract(nrow, con);
                    expireDataSet.Tables[0].Rows.Add(nrow);
                }
            }
            expireDataGridView1.Sort(expireDataGridView1.Columns[16], ListSortDirection.Descending);
        }
    }
}
