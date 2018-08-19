using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FindDifferent
{
    class HotKey
    {
        //如果函数执行成功，返回值不为0。
        //如果函数执行失败，返回值为0。要得到扩展错误信息，调用GetLastError。
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(
            IntPtr hWnd,                //要定义热键的窗口的句柄
            int id,                     //定义热键ID（不能与其它ID重复）           
            KeyModifiers fsModifiers,   //标识热键是否在按Alt、Ctrl、Shift、Windows等键时才会生效
            Keys vk                     //定义热键的内容
            );

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(
            IntPtr hWnd,                //要取消热键的窗口的句柄
            int id                      //要取消热键的ID
            );

        //定义了辅助键的名称（将数字转变为字符以便于记忆，也可去除此枚举而直接使用数值）
        [Flags()]
        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }


        public const int MOUSEEVENTF_MOVE = 0x0001;// 移动鼠标 
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;// 模拟鼠标左键按下 
        public const int MOUSEEVENTF_LEFTUP = 0x0004;// 模拟鼠标左键抬起 
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下 
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;// 模拟鼠标右键抬起 
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下 
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起 
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标 

        /// <summary>
        /// 参数 意义 
        ///dwFlags Long，下表中标志之一或它们的组合 
        ///dx，dy Long，根据MOUSEEVENTF_ABSOLUTE标志，指定x，y方向的绝对位置或相对位置 
        ///cButtons Long，没有使用 
        ///dwExtraInfo Long，没有使用 
        ///dwFlags常数 意义 MOUSEEVENTF如上常量
        /// </summary>
        /// <param name="dwFlags"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <param name="cButtons"></param>
        /// <param name="dwExtraInfo"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        /// <summary>
        /// 
        /// 移动鼠标
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetCursorPos")]
        public extern static bool SetCursorPos(int x, int y);
    }
}