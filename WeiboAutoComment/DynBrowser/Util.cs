using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

using System.Security.Cryptography;

namespace DynBrowser
{
    class Util
    {
        public static string readTxt(string fileName)
        {
            string txt = "";
            try
            {
                StreamReader sr = new StreamReader(fileName, Encoding.Default);
                txt = sr.ReadToEnd();
                sr.Close();
            }
            catch
            { }
            return txt;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string writeTxt(string fileName, string content)
        {
            DirectoryInfo parent = new FileInfo(fileName).Directory;

            if (!parent.Exists)
                parent.Create();

            try
            {
                StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default);
                sw.Write(content);
                sw.Close();
                return "保存文件成功：" + fileName;
            }
            catch (Exception e)
            {
                return "保存文件失败：" + fileName + "   " + e.Message;
            }
        }

        /// <summary>
        /// 附加文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string appendTxt(string fileName, string content)
        {
            DirectoryInfo parent = new FileInfo(fileName).Directory;

            if (!parent.Exists)
                parent.Create();

            try
            {
                StreamWriter sw = new StreamWriter(fileName, true, Encoding.Default);
                sw.Write(content);
                sw.Close();
                return "保存文件成功：" + fileName;
            }
            catch (Exception e)
            {
                return "保存文件失败：" + fileName + "   " + e.Message;
            }
        }

        public static List<string> readListTxt(string fileName)
        {
            List<string> list = new List<string>();
            try
            {
                StreamReader sr = new StreamReader(fileName, Encoding.Default);
                string str = sr.ReadLine();
                while (str != null)
                {
                    list.Add(str);
                    str = sr.ReadLine();
                }
                sr.Close();
            }
            catch
            {
            }
            return list;
        }

        public static List<string[]> getUserPwdList(string fileName)
        {
            List<string[]> userPwds = new List<string[]>();
            if (new FileInfo(fileName).Exists)
            {
                List<string> list = Util.readListTxt(fileName);
                foreach (string l in list)
                {
                    string[] infos = l.Split('\t');
                    if (infos.Length == 2 && infos[0] != null && infos[1] != null)
                    {
                        userPwds.Add(new string[] { infos[0], infos[1] });
                    }
                }
            }
            return userPwds;
        }

        public static string GetMD5(string myString)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = System.Text.Encoding.Unicode.GetBytes(myString);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x");
            }

            return byte2String;
        }
    }
}
