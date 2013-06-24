using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace ImageGroup
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
            catch(Exception e)
            {
                return "保存文件失败：" + fileName+"   "+e.Message;
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

        public static List<string[]> getKeys(string fileName)
        {
            List<string[]> ht = new List<string[]>();
            List<string> list = readListTxt(fileName);

            foreach (string ll in list)
            {
                string[] infos = ll.Split('#');
                if (infos.Length == 2)
                {
                    ht.Add(new string[] { infos[0], infos[1] });
                }
                else if (infos.Length == 1 && ll != "")
                {
                    ht.Add(new string[] { getIndexChar(ll), ll });
                }
            }
            return ht;
        }

        public static string getIndexChar(string value)
        {
            return PinYin.GetCharSpellCode(value);
        }
    }
}
