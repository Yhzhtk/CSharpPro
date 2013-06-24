using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CursorOper
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F1);
            timer1.Enabled = true;
        }

        /// <summary>
        /// 重载WbdProc,实现热键响应
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;

            //按快捷键
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 100:
                        {
                            addNowCursor();
                        }
                        break;
                    case 1:
                        {
                            HotKey.UnregisterHotKey(Handle, 100);//注销热键
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }

        private void addNowCursor()
        {
            cursorTxt.Text += nowCurLab.Text+"\r\n";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nowCurLab.Text = Cursor.Position.X + ":" + Cursor.Position.Y;
        }

    }
}
