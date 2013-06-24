using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Runtime.InteropServices;
   using System.IO;
   using System.Windows.Forms;

namespace YH
{
    /// <summary>
    /// clsMci 的摘要说明。
    /// </summary>
    public class clsMCI
    {
        public clsMCI(string fileName, bool repeat)
        {
            this.FileName = fileName;
            this.repeat = repeat;
        }

        //定义API函数使用的字符串变量 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        private string Name = "";
        [MarshalAs(UnmanagedType.LPTStr, SizeConst = 128)]
        private string TemStr = "";
        int ilong;
        //定义播放状态枚举变量
        public enum State
        {
            mPlaying = 1,
            mPuase = 2,
            mStop = 3
        };
        //结构变量
        public struct structMCI
        {
            public bool bMut;
            public int iDur;
            public int iPos;
            public int iVol;
            public int iBal;
            public string iName;
            public State state;
        };

        public structMCI mc = new structMCI();

        public bool repeat;

        public string FileName;

        //播放
        public void play()
        {
            try
            {
                ilong = APIClass.mciSendString("close all", TemStr, TemStr.Length, 0);
                Name = "open " + Convert.ToChar(34) + FileName + Convert.ToChar(34) + " alias media";
                ilong = APIClass.mciSendString(Name, TemStr, TemStr.Length, 0);
                APIClass.mciSendString("play media" + (repeat ? " repeat" : ""), TemStr, TemStr.Length, 0);
            }
            catch { }
        }
        //停止
        public void StopT()
        {
            try
            {
                ilong = APIClass.mciSendString("close media", TemStr, 128, 0);
            }
            catch { }
        }

        public void Puase()
        {
            try
            {
                ilong = APIClass.mciSendString("pause media", TemStr, TemStr.Length, 0);
            }
            catch { }
        }
    }

    public class APIClass
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
        string lpszLongPath,
        string shortFile,
        int cchBuffer
        );

        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
        string lpstrCommand,
        string lpstrReturnString,
        int uReturnLength,
        int hwndCallback
        );
    }
}
