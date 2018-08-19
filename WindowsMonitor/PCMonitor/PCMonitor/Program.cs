using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PCMonitor
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            int i = System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length;
            if (i < 3)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            else
            {
                //MessageBox.Show("程序已打开！最右下角图标右键可关闭");
            }
        }
    }
}
