using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FindDifferent
{
    public partial class FindDiff : Form
    {
        static int lastW = 0;
        static int lastH = 0;

        public FindDiff()
        {
            InitializeComponent();
            //添加热键
            HotKey.RegisterHotKey(Handle, 100, HotKey.KeyModifiers.None, Keys.F1);
            HotKey.RegisterHotKey(Handle, 101, HotKey.KeyModifiers.None, Keys.F2);
            HotKey.RegisterHotKey(Handle, 102, HotKey.KeyModifiers.None, Keys.F3);
            HotKey.RegisterHotKey(Handle, 103, HotKey.KeyModifiers.None, Keys.F4);
            HotKey.RegisterHotKey(Handle, 104, HotKey.KeyModifiers.None, Keys.F5);
            HotKey.RegisterHotKey(Handle, 105, HotKey.KeyModifiers.None, Keys.F6);
            HotKey.RegisterHotKey(Handle, 106, HotKey.KeyModifiers.None, Keys.F7);
            HotKey.RegisterHotKey(Handle, 107, HotKey.KeyModifiers.None, Keys.Escape);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0312:    //这个是window消息定义的注册的热键消息 
                    DealHotKey(m.WParam.ToInt32());
                    break;
            }
            base.WndProc(ref m);
        }

        private void DealHotKey(int hotId)
        {
            if (hotId == 100)
            {
                SetLoc1Btn_Click(null, null);
            }
            else if (hotId == 101)
            {
                SetLoc2Btn_Click(null, null);
            }
            else if (hotId == 102)
            {
                SetSizeBtn_Click(null, null);
            }
            else if (hotId == 103)
            {
                GetingMouCheck.Checked = !GetingMouCheck.Checked;
            }
            else if (hotId == 104)
            {
                PicUtil.getScreamImg();
            }
            else if (hotId == 105)
            {
                FindDiffBtn_Click(null, null);
            }
            else if (hotId == 106)
            {
                ClearDiffBtn_Click(null, null);
            }
            else if (hotId == 107)
            {
                HotKey.SetCursorPos(lastW, lastH);
            }
        }

        /// <summary>
        /// 是否实时获取鼠标位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetingMouCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (GetingMouCheck.Checked)
            {
                getMouTimer.Enabled = true;
            }
            else
            {
                getMouTimer.Enabled = false;
            }
        }

        /// <summary>
        /// Timer实时显示位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getMouTimer_Tick(object sender, EventArgs e)
        {
            MouWTxt.Text = Control.MousePosition.X.ToString();
            MouHTxt.Text = Control.MousePosition.Y.ToString();
            MouseRgb.Text = PicUtil.getRgb(PicUtil.bitMap, int.Parse(MouWTxt.Text), int.Parse(MouHTxt.Text));
        }

        private void FindDiff_FormClosing(object sender, FormClosingEventArgs e)
        {
            //注销热键
            HotKey.UnregisterHotKey(Handle, 100);
            HotKey.UnregisterHotKey(Handle, 101);
            HotKey.UnregisterHotKey(Handle, 102);
            HotKey.UnregisterHotKey(Handle, 103);
            HotKey.UnregisterHotKey(Handle, 104);
            HotKey.UnregisterHotKey(Handle, 105);
            HotKey.UnregisterHotKey(Handle, 106);
            HotKey.UnregisterHotKey(Handle, 107);
        }

        private void SetSizeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int x1 = int.Parse(Loc1WidTxt.Text);
                int y1 = int.Parse(Loc1HeiTxt.Text);

                int x2 = int.Parse(Loc2WidTxt.Text);
                int y2 = int.Parse(Loc2HeiTxt.Text);

                int mw = int.Parse(MouWTxt.Text);
                int mh = int.Parse(MouHTxt.Text);

                SizeWidTxt.Text = (mw - x1) + "";
                SizeHeiTxt.Text = (mh - y1) + "";

                string allEndRgb = PicUtil.getRgb(PicUtil.bitMap, int.Parse(Loc1WidTxt.Text) + int.Parse(SizeWidTxt.Text), int.Parse(Loc1HeiTxt.Text) + int.Parse(SizeHeiTxt.Text));
                allEndRgb += "         " + PicUtil.getRgb(PicUtil.bitMap, int.Parse(Loc1WidTxt.Text) + int.Parse(SizeWidTxt.Text), int.Parse(Loc1HeiTxt.Text) + int.Parse(SizeHeiTxt.Text));
                AllEndRgb.Text = allEndRgb;
            }
            catch { }
        }

        private void SetLoc1Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Loc1WidTxt.Text = MouWTxt.Text;
                Loc1HeiTxt.Text = MouHTxt.Text;
                Loc1Rgb.Text = PicUtil.getRgb(PicUtil.bitMap, int.Parse(Loc1WidTxt.Text), int.Parse(Loc1HeiTxt.Text));
            }
            catch { }
        }

        private void SetLoc2Btn_Click(object sender, EventArgs e)
        {
            try
            {
                Loc2WidTxt.Text = MouWTxt.Text;
                Loc2HeiTxt.Text = MouHTxt.Text;
                Loc2Rgb.Text = PicUtil.getRgb(PicUtil.bitMap, int.Parse(Loc2WidTxt.Text), int.Parse(Loc2HeiTxt.Text));
            }
            catch { }
        }

        private void SetMouBtn_Click(object sender, EventArgs e)
        {

        }

        private void FindDiffBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int w = int.Parse(SizeWidTxt.Text);
                int h = int.Parse(SizeHeiTxt.Text);
                int x1 = int.Parse(Loc1WidTxt.Text);
                int y1 = int.Parse(Loc1HeiTxt.Text);
                int x2 = int.Parse(Loc2WidTxt.Text);
                int y2 = int.Parse(Loc2HeiTxt.Text);

                int abs = int.Parse(AbsTxt.Text);
                int pw = int.Parse(PerWidTxt.Text);
                int ph = int.Parse(PerHeiTxt.Text);

                int lx = (w - 1) / pw + 1;
                int ly = (h - 1) / ph + 1;

                ClearDiffBtn_Click(sender, e);

                Bitmap bitMap = PicUtil.getScreamImg();
                for (int j = 0; j < ly; j++)
                {
                    for (int i = 0; i < lx; i++)
                    {
                        int tw = 0;
                        int th = 0;
                        tw = pw * (i + 1) > w ? w - pw * i : pw;
                        th = ph * (j + 1) > h ? h - ph * j : ph;
                        if (!PicUtil.compareRect(bitMap, abs, x1 + pw * i, y1 + ph * j, x2 + pw * i, y2 + ph * j, tw, th))
                        {
                            DiffLocList.Items.Add((x1 + pw * i) + "#" + (y1 + ph * j) + "\t" + (x2 + pw * i) + "#" + (y2 + ph * j));
                        }
                    }
                }
                DiffLocList.Items.Add("ok");

                showDiff(bitMap);
            }
            catch { }
        }

        public void showDiff(Bitmap showPic)
        {
            var g = System.Drawing.Graphics.FromImage(showPic);
            Pen pen1 = new Pen(Brushes.Yellow, 1);
            Pen pen2 = new Pen(Brushes.Red, 1);

            for (int i = 0; i < DiffLocList.Items.Count; i++)
            {
                try
                {
                    string[] xy12 = DiffLocList.Items[i].ToString().Split('\t');
                    string[] xy1 = xy12[0].Split('#');
                    string[] xy2 = xy12[1].Split('#');
                    g.DrawRectangle(pen1, int.Parse(xy1[0]), int.Parse(xy1[1]), int.Parse(PerWidTxt.Text), int.Parse(PerHeiTxt.Text));
                    g.DrawRectangle(pen1, int.Parse(xy2[0]), int.Parse(xy2[1]), int.Parse(PerWidTxt.Text), int.Parse(PerHeiTxt.Text));
                    g.DrawRectangle(pen2, int.Parse(xy1[0]) + pen1.Width, int.Parse(xy1[1]) + pen1.Width, int.Parse(PerWidTxt.Text) - 2 * pen1.Width, int.Parse(PerHeiTxt.Text) - 2 * pen1.Width);
                    g.DrawRectangle(pen2, int.Parse(xy2[0]) + pen1.Width, int.Parse(xy2[1]) + pen1.Width, int.Parse(PerWidTxt.Text) - 2 * pen1.Width, int.Parse(PerHeiTxt.Text) - 2 * pen1.Width);
                }
                catch { }
            }

            ShowDiff s = new ShowDiff(showPic, false);
            s.Show();
        }

        private void ClearDiffBtn_Click(object sender, EventArgs e)
        {
            DiffLocList.Items.Clear();
        }

        //移动鼠标
        private void DiffLocList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (DiffLocList.SelectedItems.Count == 0)
            {
                return;
            }
            string[] xy = (DiffLocList.SelectedItems[0].ToString().Split('\t'))[0].Split('#');

            try
            {
                int x = int.Parse(xy[0]);
                int y = int.Parse(xy[1]);
                lastW = Control.MousePosition.X;
                lastH = Control.MousePosition.Y;
                HotKey.SetCursorPos(x, y);
            }
            catch { }
        }

        private void PerXMinusBtn_Click(object sender, EventArgs e)
        {
            int w = int.Parse(PerWidTxt.Text) - 5;
            w = w > 0 ? w : 1;
            int h = int.Parse(PerHeiTxt.Text) - 5;
            h = h > 0 ? h : 1;
            int abs = int.Parse(AbsTxt.Text) - 2500;
            abs = abs > 0 ? abs : 0;
            PerWidTxt.Text = w.ToString();
            PerHeiTxt.Text = h.ToString();
            AbsTxt.Text = abs.ToString();
        }

        private void PerPlusBtn_Click(object sender, EventArgs e)
        {
            int w = int.Parse(PerWidTxt.Text) + 5;
            int h = int.Parse(PerHeiTxt.Text) + 5;
            int abs = int.Parse(AbsTxt.Text) + 2500;
            PerWidTxt.Text = w.ToString();
            PerHeiTxt.Text = h.ToString();
            AbsTxt.Text = abs.ToString();
        }

        private void PluzzMinusBtn_Click(object sender, EventArgs e)
        {
            int abs = int.Parse(AbsTxt.Text) - 500;
            abs = abs > 0 ? abs : 0;
            AbsTxt.Text = abs.ToString();
        }

        private void PluzzPlusBtn_Click(object sender, EventArgs e)
        {
            int abs = int.Parse(AbsTxt.Text) + 500;
            AbsTxt.Text = abs.ToString();
        }

        private void SelRectBtn_Click(object sender, EventArgs e)
        {
            ShowDiff s = new ShowDiff(PicUtil.getScreamImg(), true);
            try
            {
                s.ShowDialog();
                Loc1WidTxt.Text = s.Rect1.X.ToString();
                Loc1HeiTxt.Text = s.Rect1.Y.ToString();
                Loc2WidTxt.Text = s.Rect2.X.ToString();
                Loc2HeiTxt.Text = s.Rect2.Y.ToString();

                Loc1Rgb.Text = PicUtil.getRgb(PicUtil.bitMap, int.Parse(Loc1WidTxt.Text), int.Parse(Loc1HeiTxt.Text));
                Loc2Rgb.Text = PicUtil.getRgb(PicUtil.bitMap, int.Parse(Loc2WidTxt.Text), int.Parse(Loc2HeiTxt.Text));

                SizeWidTxt.Text = s.Rect1.Width.ToString();
                SizeHeiTxt.Text = s.Rect1.Height.ToString();

                string allEndRgb = PicUtil.getRgb(PicUtil.bitMap, s.Rect1.X + s.Rect1.Width, s.Rect1.Y + s.Rect1.Height);
                allEndRgb += "         " + PicUtil.getRgb(PicUtil.bitMap, s.Rect2.X + s.Rect2.Width, s.Rect2.Y + s.Rect2.Height);
                AllEndRgb.Text = allEndRgb;
            }
            catch { }
            finally { s.Dispose(); }

        }
    }
}