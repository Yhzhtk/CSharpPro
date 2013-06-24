using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContractManager
{
    public class Contract
    {
        public static string lastPath = "\\data\\";

        public static string relativePath = System.Environment.CurrentDirectory + lastPath;

        public static string[] colNames = new string[]
        {
            "协议类型","协议名称","协议编号","联通公司业务联系人","联系电话","集团客户客户经理",
            "协议签署单位名称","单位地址","协议签署","签署单位联系人","联系电话","付费号码",
            "收费标准","协议签订日期","协议执行日期","协议期限","协议到期日期","协议内容简述","备注","电路调单号","文件名"
        };
        /// <summary>
        /// 协议类型
        /// </summary>
        public int conId;//协议类型

        /// <summary>
        /// 协议名称
        /// </summary>
        public string proCate;//协议名称

        /// <summary>
        /// 协议类型
        /// </summary>
        public string proName;//协议类型
        /// <summary>
        /// 协议编号
        /// </summary>
        public string proId;//协议编号

        /// <summary>
        /// 联通公司业务联系人
        /// </summary>
        public string unicomLinkMan;//联通公司业务联系人
        /// <summary>
        /// 联系电话
        /// </summary>
        public string linkPhone;//联系电话
        /// <summary>
        /// 集团客户客户经理
        /// </summary>
        public string groupCusManager;//集团客户客户经理
        /// <summary>
        /// 协议签署单位名称
        /// </summary>
        public string proSignUnitName;//协议签署单位名称
        /// <summary>
        /// 单位地址
        /// </summary>
        public string unitAdd;//单位地址
        /// <summary>
        /// 协议签署
        /// </summary>
        public string proSign;//协议签署
        /// <summary>
        /// 签署单位联系人
        /// </summary>
        public string signUnitLinkMan;//签署单位联系人
        /// <summary>
        /// 联系电话
        /// </summary>
        public string signUnitLinkPhone;//联系电话
        /// <summary>
        /// 付费号码
        /// </summary>
        public string payPhone;//付费号码
        /// <summary>
        /// 收费标准
        /// </summary>
        public string payStand;//收费标准
        /// <summary>
        /// 协议签订日期
        /// </summary>
        public string proSignDate;//协议签订日期
        /// <summary>
        /// 协议执行日期
        /// </summary>
        public string proSignExeDate;//协议执行日期
        /// <summary>
        /// 协议期限
        /// </summary>
        public string proDeadLine;//协议期限
        /// <summary>
        /// 协议到期日期
        /// </summary>
        public string proExpireData;//协议到期日期
        /// <summary>
        /// 协议内容简述
        /// </summary>
        public string proDesc;//协议内容简述
        /// <summary>
        /// 备注
        /// </summary>
        public string remark;//备注
        /// <summary>
        /// 电路调单号
        /// </summary>
        public string dltdh;
        /// <summary>
        /// 存储的文件名，在相对路径下
        /// </summary>
        public string fileName;
    }
}
