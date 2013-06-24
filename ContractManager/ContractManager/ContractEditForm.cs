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
    public partial class ContractEditForm : Form
    {
        private string oper; //

        /// <summary>
        /// 操作，添加add，修改update，查看show等
        /// </summary>
        public string Oper
        {
            get { return oper; }
            set { oper = value; }
        }

        /// <summary>
        /// 窗口名称
        /// </summary>
        private string formTxt;

        /// <summary>
        /// 确定按键名称
        /// </summary>
        private string btnTxt;

        private Contract contract;
        
        /// <summary>
        /// 合同信息
        /// </summary>
        internal Contract Contract
        {
            get { return contract; }
            set { contract = value; }
        }

        private bool isCanel = true;

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool IsCanel
        {
            get { return isCanel; }
            set { isCanel = value; }
        }

        private TextBox nowText;

        public ContractEditForm(string oper, string formName, string btnName, Contract contract)
        {
            this.oper = oper;
            this.formTxt = formName;
            this.btnTxt = btnName;
            this.contract = contract;
            InitializeComponent();
        }

        private void ContractEditForm_Load(object sender, EventArgs e)
        {
            this.Text = formTxt + " - 中国联通唐山市曹妃甸区分公司合同管理系统";
            okBtn.Text = btnTxt;

            if (oper == "show")
            {
                //不可编辑
                setEditEnable(false);
            }

            if (contract != null)
            {
                showContractToEdit(contract);
            }
        }

        /// <summary>
        /// 设置是否可编辑
        /// </summary>
        /// <param name="enable"></param>
        void setEditEnable(bool enable)
        {
            groupCusManager.Enabled = enable;
            linkPhone.Enabled = enable;
            payPhone.Enabled = enable;
            payStand.Enabled = enable;
            proCate.Enabled = enable;
            proDeadLine.Enabled = enable;
            proDesc.Enabled = enable;
            proExpireDate.Enabled = enable;
            proId.Enabled = enable;
            proName.Enabled = enable;
            proSign.Enabled = enable;
            proSignDate.Enabled = enable;
            proSignExeDate.Enabled = enable;
            proSignUnitName.Enabled = enable;
            remark.Enabled = enable;
            signUnitLinkMan.Enabled = enable;
            signUnitLinkPhone.Enabled = enable;
            unicomLinkMan.Enabled = enable;
            unitAdd.Enabled = enable;

            dltdh.Enabled = enable;
            fileName.Enabled = enable;

            groupCusManager.BackColor = Color.White;
            linkPhone.BackColor = Color.White;
            payPhone.BackColor = Color.White;
            payStand.BackColor = Color.White;
            proCate.BackColor = Color.White;
            proDeadLine.BackColor = Color.White;
            proDesc.BackColor = Color.White;
            proExpireDate.BackColor = Color.White;
            proId.BackColor = Color.White;
            proName.BackColor = Color.White;
            proSign.BackColor = Color.White;
            proSignDate.BackColor = Color.White;
            proSignExeDate.BackColor = Color.White;
            proSignUnitName.BackColor = Color.White;
            remark.BackColor = Color.White;
            signUnitLinkMan.BackColor = Color.White;
            signUnitLinkPhone.BackColor = Color.White;
            unicomLinkMan.BackColor = Color.White;
            unitAdd.BackColor = Color.White;

            dltdh.BackColor = Color.White;
            fileName.BackColor = Color.White;
        }

        /// <summary>
        /// 显示contract到界面上
        /// </summary>
        /// <param name="contract"></param>
        void showContractToEdit(Contract contract)
        {
            groupCusManager.Text = contract.groupCusManager;
            linkPhone.Text = contract.linkPhone;
            payPhone.Text = contract.payPhone;
            payStand.Text = contract.payStand;
            proCate.Text = contract.proCate;
            proDeadLine.Text = contract.proDeadLine;
            proDesc.Text = contract.proDesc;
            proExpireDate.Text = contract.proExpireData;
            proId.Text = contract.proId;
            proName.Text = contract.proName;
            proSign.Text = contract.proSign;
            proSignDate.Text = contract.proSignDate;
            proSignExeDate.Text = contract.proSignExeDate;
            proSignUnitName.Text = contract.proSignUnitName;
            remark.Text = contract.remark;
            signUnitLinkMan.Text = contract.signUnitLinkMan;
            signUnitLinkPhone.Text = contract.signUnitLinkPhone;
            unicomLinkMan.Text = contract.unicomLinkMan;
            unitAdd.Text = contract.unitAdd;

            dltdh.Text = contract.dltdh;
            fileName.Text = contract.fileName;
        }

        /// <summary>
        /// 显示contract到界面上
        /// </summary>
        /// <param name="contract"></param>
        Contract getContractFromEdit()
        {
            Contract con = new Contract();
            con.groupCusManager = groupCusManager.Text;
            con.linkPhone = linkPhone.Text;
            con.payPhone = payPhone.Text;
            con.payStand = payStand.Text;
            con.proCate = proCate.Text;
            con.proDeadLine = proDeadLine.Text;
            con.proDesc = proDesc.Text;
            con.proExpireData = proExpireDate.Text;
            con.proId = proId.Text;
            con.proName = proName.Text;
            con.proSign = proSign.Text;
            con.proSignDate = proSignDate.Text;
            con.proSignExeDate = proSignExeDate.Text;
            con.proSignUnitName = proSignUnitName.Text;
            con.remark = remark.Text;
            con.signUnitLinkMan = signUnitLinkMan.Text;
            con.signUnitLinkPhone = signUnitLinkPhone.Text;
            con.unicomLinkMan = unicomLinkMan.Text;
            con.unitAdd = unitAdd.Text;

            con.dltdh = dltdh.Text;
            con.fileName = fileName.Text;
            return con;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.contract = getContractFromEdit();
            this.isCanel = false;
            this.Close();
        }

        private void canelBtn_Click(object sender, EventArgs e)
        {
            this.isCanel = true;
        }

        private void proSignDate_Enter(object sender, EventArgs e)
        {
            nowText = (TextBox)sender;

            if (nowText.Name.EndsWith("Date"))
            {
                monthCalendar.Location = new Point(nowText.Location.X + nowText.Size.Width - monthCalendar.Width, nowText.Location.Y + nowText.Size.Height + 5);
                monthCalendar.SetDate((nowText.Text != "") ? DateTime.Parse(nowText.Text) : DateTime.Now);
                monthCalendar.Visible = true;
            }
            else
            {
                monthCalendar.Visible = false;
                if (nowText.Name == "fileName")
                {
                    scanFile_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// 选择日期
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            nowText.Text = monthCalendar.SelectionEnd.ToString("yyyy-MM-dd");
            monthCalendar.Visible = false;
        }

        /// <summary>
        /// 浏览合同文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scanFile_Click(object sender, EventArgs e)
        {
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName.Text = openFileDialog.FileName;
            }
        }
    }
}
