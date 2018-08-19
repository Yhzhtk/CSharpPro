using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynBrowser
{
    /// <summary>
    /// 定时控制的行为存储
    /// </summary>
    public class TimerAct
    {
        /// <summary>
        /// 存储定时行为
        /// </summary>
        public List<Act> acts = new List<Act>();

        /// <summary>
        /// 当前执行位置
        /// </summary>
        private int index = 0;

        /// <summary>
        /// 获取一个act，没有了返回为null
        /// </summary>
        /// <returns></returns>
        public Act getNowAct()
        {
            Act act;
            if (index < acts.Count)
            {
                act = acts[index];
            }
            else
            {
                act = null;
            }
            return act;
        }

        /// <summary>
        /// 添加一个act
        /// </summary>
        /// <param name="act"></param>
        public void addAct(Act act)
        {
            acts.Add(act);
        }

        /// <summary>
        /// 重置index
        /// </summary>
        public void resetIndex()
        {
            index = 0;
            foreach (Act a in acts)
            {
                a.isSleep = false;
            }
        }

        /// <summary>
        /// 重置index
        /// </summary>
        public void addIndex()
        {
            index++;
        }

        /// <summary>
        /// 设置index
        /// </summary>
        public void setIndex(int i)
        {
            for (int m = i; m <= index; m++)
            {
                acts[m].isSleep = false;
            }
            index = i;
        }

        /// <summary>
        /// 获取index
        /// </summary>
        public int getIndex()
        {
            return index;
        }

        /// <summary>
        /// 获取默认的timerAct
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="bId"></param>
        /// <returns></returns>
        public static TimerAct getDefaultTimerAct(string searchKey, int bId)
        {
            TimerAct ta = new TimerAct();
            List<string> defaultTask = Util.readListTxt("defaultTask.dat");

            for (int i = 0; i < defaultTask.Count; i++)
            {
                if (defaultTask[i] != "")
                {
                    Act a = new Act(defaultTask[i]);
                    if (a.mainArg.Contains("搜索内容"))
                    {
                       a.viceArg = a.viceArg.Replace("key", searchKey);
                    }
                    if(a.mainArg.Contains("baseId"))
                    {
                        int n = int.Parse(a.mainArg.Replace("baseId","").Replace("+" , "").Trim());
                        n = bId + n;
                        a.mainArg = n + "";
                    }
                    ta.acts.Add(a);
                }
            }
            return ta;
        }
    }
}

