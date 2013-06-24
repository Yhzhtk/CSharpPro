using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ContractManager
{
    class ContractUtil
    {
        public static string statusLab = "";

        /// <summary>
        /// 添加一个协议，自动判断是否存在Id，若存在Id则不会添加
        /// </summary>
        /// <param name="con"></param>
        /// <returns></returns>
        public static string addContract(DataSet dataSet, Contract con)
        {
            DataRowCollection rows = dataSet.Tables[0].Rows;
            foreach (DataRow r in rows)
            {
                if (r["协议编号"].ToString() == con.proId)
                {
                    return "已包含协议编号为：" + con.proId + " 的协议。不能再添加！";
                }
            }
            DataRow row = dataSet.Tables[0].NewRow();
            row = ContractUtil.getRowFromContract(row, con);
            dataSet.Tables[0].Rows.Add(row);
            return "添加协议：" + con.proId + "  " + con.proName + "   成功！";
        }

        /// <summary>
        /// 给定Id删除协议
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static string removeContract(DataSet dataSet, string proId)
        {

            DataRowCollection rows = dataSet.Tables[0].Rows;
            foreach (DataRow r in rows)
            {
                if (r["协议编号"].ToString() == proId)
                {
                    dataSet.Tables[0].Rows.Remove(r);
                    return "移除协议编号为：" + proId + " 的协议!";
                }
            }
            return "没有编号为：" + proId + " 的协议!";
        }

        /// <summary>
        /// 搜索指定类型的指定内容
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        public static List<DataRow> findContract(DataSet dataSet, string clas, string content)
        {
            List<DataRow> resRows = new List<DataRow>();
            DataRowCollection rows = dataSet.Tables[0].Rows;
            //名称备注实现模糊查找
            if (clas == "协议名称" || clas == "备注")
            {
                foreach (DataRow r in rows)
                {
                    string rContent = r[clas].ToString();
                    int len = 0;
                    foreach (char c in content)
                    {
                        foreach (char rc in rContent)
                        {
                            if (c == rc)
                            {
                                len++;
                                break;
                            }
                        }
                    }
                    if (len == content.Length)
                    {
                        resRows.Add(r);
                    }
                }
            }
            else
            {
                foreach (DataRow r in rows)
                {
                    if (r[clas].ToString() == content)
                    {
                        resRows.Add(r);
                    }
                }
            }
            statusLab = "搜索 " + clas + " 内容 " + content + " 结果有：" + resRows.Count + "条";
            return resRows;
        }

        /// <summary>
        /// 将合同信息加入行中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static DataRow getRowFromContract(DataRow row, Contract con)
        {
            row.SetField(0, con.proCate);
            row.SetField(1, con.proName);
            row.SetField(2, con.proId);
            row.SetField(3, con.unicomLinkMan);
            row.SetField(4, con.linkPhone);
            row.SetField(5, con.groupCusManager);
            row.SetField(6, con.proSignUnitName);
            row.SetField(7, con.unitAdd);
            row.SetField(8, con.proSign);
            row.SetField(9, con.signUnitLinkMan);
            row.SetField(10, con.signUnitLinkPhone);
            row.SetField(11, con.payPhone); ;
            row.SetField(12, con.payStand);
            row.SetField(13, con.proSignDate);
            row.SetField(14, con.proSignExeDate);
            row.SetField(15, con.proDeadLine);
            row.SetField(16, con.proExpireData);
            row.SetField(17, con.proDesc);
            row.SetField(18, con.remark);
            row.SetField(19, con.dltdh);
            row.SetField(20, con.fileName);
            return row;
        }

        /// <summary>
        /// 将合同信息加入行中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="con"></param>
        /// <returns></returns>
        public static Contract getContractFromRow(DataRow row)
        {
            Contract con = new Contract();
            con.proCate = row[0].ToString();
            con.proName = row[1].ToString();
            con.proId = row[2].ToString();
            con.unicomLinkMan = row[3].ToString();
            con.linkPhone = row[4].ToString();
            con.groupCusManager = row[5].ToString();
            con.proSignUnitName = row[6].ToString();
            con.unitAdd = row[7].ToString();
            con.proSign = row[8].ToString();
            con.signUnitLinkMan = row[9].ToString();
            con.signUnitLinkPhone = row[10].ToString();
            con.payPhone = row[11].ToString(); ;
            con.payStand = row[12].ToString();
            con.proSignDate = row[13].ToString();
            con.proSignExeDate = row[14].ToString();
            con.proDeadLine = row[15].ToString();
            con.proExpireData = row[16].ToString();
            con.proDesc = row[17].ToString();
            con.remark = row[18].ToString();
            con.dltdh = row[19].ToString();
            con.fileName = row[20].ToString();
            return con;
        }
    }
}
