using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using NPOI;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.POIFS;
using NPOI.Util;
using NPOI.SS.UserModel;

namespace ContractManager
{
    class ExcelUtil
    {
        /// <summary>
        /// 需要交互的操作结果
        /// </summary>
        public static string statusLab;

        /// <summary>
        /// 读取的excel文件名
        /// </summary>
        private static string tFileName;

        /// <summary>
        /// 读取文件获取合同信息
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<Contract> getContractsFromExcel(string fileName)
        {
            tFileName = fileName;
            List<Contract> list = new List<Contract>();

            FileStream f = new FileStream(fileName,FileMode.OpenOrCreate);
            Workbook workbook = new HSSFWorkbook(f);

            Sheet sheet = workbook.GetSheet("合同信息表");
            Row headerRow = sheet.GetRow(0);

            //判断是否是正确的协议存储文件
            if (headerRow.GetCell(0).ToString() != "协议类型")
            {
                statusLab = "Excel文件：" + fileName + " 不是正确的合同信息数据文件。";
                return null;
            }

            //读取协议内容
            for (int i = 1; i <= sheet.LastRowNum; i++)
            {
                Row dataRow = sheet.GetRow(i);
                Contract con = getContractFromRow(dataRow);

                if (con != null)
                {
                    list.Add(con);
                }
            }

            f.Close();
            f.Dispose();

            return list;
        }

        /// <summary>
        /// 从一行中获取一个协议内容
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private static Contract getContractFromRow(Row row)
        {
            Contract con = new Contract();
            
            con.proCate = row.GetCell(0).ToString();
            con.proName = row.GetCell(1).ToString();
            con.proId = row.GetCell(2).ToString();
            con.unicomLinkMan = row.GetCell(3).ToString();
            con.linkPhone = row.GetCell(4).ToString();
            con.groupCusManager = row.GetCell(5).ToString();
            con.proSignUnitName = row.GetCell(6).ToString();
            con.unitAdd = row.GetCell(7).ToString();
            con.proSign = row.GetCell(8).ToString();
            con.signUnitLinkMan = row.GetCell(9).ToString();
            con.signUnitLinkPhone = row.GetCell(10).ToString();
            con.payPhone = row.GetCell(11).ToString(); ;
            con.payStand = row.GetCell(12).ToString();
            con.proSignDate = row.GetCell(13).ToString();
            con.proSignExeDate = row.GetCell(14).ToString();
            con.proDeadLine = row.GetCell(15).ToString();
            con.proExpireData = row.GetCell(16).ToString();
            con.proDesc = row.GetCell(17).ToString();
            con.remark = row.GetCell(18).ToString();
            con.dltdh = row.GetCell(19).ToString();
            con.fileName = row.GetCell(20).ToString();
            return con;
        }

        /// <summary>
        /// 将DataGridView的数据写入文件
        /// </summary>
        /// <param name="SourceTable"></param>
        /// <returns></returns>
        public static bool writeExcelFromDataGridView(DataGridView SourceTable, string fileName)
        {
            try
            {
                Workbook workbook = new HSSFWorkbook();
                MemoryStream ms = new MemoryStream();
                Sheet sheet = workbook.CreateSheet("合同信息表");
                Row headerRow = sheet.CreateRow(0);

                // handling header.
                for (int i = 0; i < SourceTable.Columns.Count; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(SourceTable.Columns[i].HeaderText);
                }

                // handling value.
                int rowIndex = 1;

                for (int i = 0; i < SourceTable.Rows.Count; i++)
                {
                    Row dataRow = sheet.CreateRow(rowIndex);

                    for (int j = 0; j < SourceTable.Columns.Count; j++)
                    {
                        dataRow.CreateCell(j).SetCellValue(SourceTable.Rows[i].Cells[j].Value.ToString());
                    }
                    rowIndex++;
                }

                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;

                sheet = null;
                headerRow = null;
                workbook = null;

                FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                byte[] data = ms.ToArray();

                fs.Write(data, 0, data.Length);
                fs.Flush();
                fs.Close();
                fs.Dispose();
                data = null;
                ms.Close();
                statusLab = "将数据写入文件成功！ " + fileName;
                return true;

            }
            catch (Exception ex)
            {
                statusLab = "将数据写入文件错误！ " + fileName  + "  Error:" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 将Contrast的list数据写入excel文件
        /// </summary>
        /// <param name="SourceTable"></param>
        /// <param name="FileName"></param>
        public static void writeExcelFromList(List<Contract> list, string fileName)
        {
            Workbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            Sheet sheet = workbook.CreateSheet("合同信息表");
            Row headerRow = sheet.CreateRow(0);

            for (int i = 0; i < Contract.colNames.Length; i++)
            {
                headerRow.CreateCell(i).SetCellValue(Contract.colNames[i]);
            }

            // handling value.
            int rowIndex = 1;

            foreach (Contract con in list)
            {
                Row dataRow = sheet.CreateRow(rowIndex);

                dataRow.CreateCell(0).SetCellValue(con.proCate);
                dataRow.CreateCell(1).SetCellValue(con.proName);
                dataRow.CreateCell(2).SetCellValue(con.proId);
                dataRow.CreateCell(3).SetCellValue(con.unicomLinkMan);
                dataRow.CreateCell(4).SetCellValue(con.linkPhone);
                dataRow.CreateCell(5).SetCellValue(con.groupCusManager);
                dataRow.CreateCell(6).SetCellValue(con.proSignUnitName);
                dataRow.CreateCell(7).SetCellValue(con.unitAdd);
                dataRow.CreateCell(8).SetCellValue(con.proSign);
                dataRow.CreateCell(9).SetCellValue(con.signUnitLinkMan);
                dataRow.CreateCell(10).SetCellValue(con.signUnitLinkPhone);
                dataRow.CreateCell(11).SetCellValue(con.payPhone); ;
                dataRow.CreateCell(12).SetCellValue(con.payStand);
                dataRow.CreateCell(13).SetCellValue(con.proSignDate);
                dataRow.CreateCell(14).SetCellValue(con.proSignExeDate);
                dataRow.CreateCell(15).SetCellValue(con.proDeadLine);
                dataRow.CreateCell(16).SetCellValue(con.proExpireData);
                dataRow.CreateCell(17).SetCellValue(con.proDesc);
                dataRow.CreateCell(18).SetCellValue(con.remark);

                dataRow.CreateCell(19).SetCellValue(con.dltdh);
                dataRow.CreateCell(20).SetCellValue(con.fileName);
                rowIndex++;
            }

            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;

            sheet = null;
            headerRow = null;
            workbook = null;


            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            byte[] data = ms.ToArray();

            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
            data = null;
            ms.Close();
        }
    }
}
