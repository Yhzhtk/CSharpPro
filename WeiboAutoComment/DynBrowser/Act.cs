using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynBrowser
{
    public class Act
    {
        public bool isSleep = false;

        //编号
        public int id = 0;
        //延时
        public int interval = 1000;
        //操作
        public string act;
        //主参数
        public string mainArg;
        //副参数
        public string viceArg;

        public Act()
        { }

        public Act(string content)
        {
            string[] infos = content.Split('\t');

            try
            {
                id = int.Parse(infos[0]);
                interval = int.Parse(infos[1]);
                act = infos[2];
                mainArg = infos[3];
                viceArg = infos[4];
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Act(int id, int interval, string act, string mainArg,string viceArg)
        {
            this.id = id;
            this.interval = interval;
            this.act = act;
            this.mainArg = mainArg;
            this.viceArg = viceArg;
        }

        /// <summary>
        /// 根据一行内容获取act
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public void parse(string content)
        {
            string[] infos = content.Split('\t');

            try
            {
                id = int.Parse(infos[0]);
                interval = int.Parse(infos[1]);
                act = infos[2];
                mainArg = infos[3];
                viceArg = infos[4];
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// 根据act获取一行内容
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string getContent()
        {
            string content = id + "\t" + interval + "\t" + act + "\t" + mainArg + "\t" + viceArg;
            return content;
        }
    }
}
