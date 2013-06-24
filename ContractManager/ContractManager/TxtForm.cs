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
    /// <summary>
    /// 显示内容的窗体
    /// </summary>
    public partial class TxtForm : Form
    {
        public TxtForm(string txtName, string content, bool readOnly)
        {
            InitializeComponent();

            this.Text = txtName;
            this.textBox.Text = content;
            this.textBox.ReadOnly = readOnly;
        }

        public TxtForm(string txtName, Contract con, bool readOnly)
        {
            InitializeComponent();

            this.Text = txtName;
            this.textBox.ReadOnly = readOnly;
            this.textBox.Text = getContractTxt(con);
        }

        public static string getContractTxt(Contract con)
        {
            string content = "\r\n 合同详细信息：\r\n\r\n";

            content += "协议类型：" + con.proCate + "\r\n";
            content += "协议名称：" + con.proName + "\r\n";
            content += "协议编号：" + con.proId + "\r\n";
            content += "联通公司业务联系人：" + con.unicomLinkMan + "\r\n";
            content += "联系电话：" + con.linkPhone + "\r\n";
            content += "集团客户客户经理：" + con.groupCusManager + "\r\n";
            content += "协议签署单位名称：" + con.proSignUnitName + "\r\n";
            content += "单位地址：" + con.unitAdd + "\r\n";
            content += "协议签署：" + con.proSign + "\r\n";
            content += "签署单位联系人：" + con.signUnitLinkMan + "\r\n";
            content += "联系电话：" + con.signUnitLinkPhone + "\r\n";
            content += "付费号码：" + con.payPhone + "\r\n";
            content += "收费标准：" + con.payStand + "\r\n";
            content += "协议签订日期：" + con.proSignDate + "\r\n";
            content += "协议执行日期：" + con.proSignExeDate + "\r\n";
            content += "协议期限：" + con.proDeadLine + "\r\n";
            content += "协议到期日期：" + con.proExpireData + "\r\n";
            content += "协议内容简述：" + con.proDesc + "\r\n";
            content += "备注：" + con.remark + "\r\n";
            content += "电路调单号：" + con.dltdh + "\r\n";
            content += "文件名：" + con.fileName + "\r\n";

            return content;
        }
    }
}
