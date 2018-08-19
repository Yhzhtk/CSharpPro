using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FindDifferent
{
    class PicUtil
    {
        public static Bitmap bitMap;

        public static Bitmap getScreamImg()
        {
            var size = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
            bitMap = new System.Drawing.Bitmap(size.Width, size.Height);

            var g = System.Drawing.Graphics.FromImage(bitMap);
            g.Clear(System.Drawing.Color.White);
            g.CopyFromScreen(0, 0, 0, 0, size);
            return bitMap;
        }

        public static long[] getSumRgbRect(Bitmap bitMap, int x, int y, int w, int h){
            long allr = 0;
            long allg = 0;
            long allb = 0;
            for (int i = x; i < x + w; i++)
            {
                for (int j = y; j < y + h; j++)
                {
                    Color c = bitMap.GetPixel(i, j);
                    allr += c.R;
                    allg += c.G;
                    allb += c.B;
                }
            }
            return new long[]{allr,allg,allb};
        }

        public static bool compareRect(Bitmap bitMap, long abs, int x1, int y1, int x2, int y2, int w, int h)
        {
            long[] all1 = getSumRgbRect(bitMap, x1, y1, w, h);
            long[] all2 = getSumRgbRect(bitMap, x2, y2, w, h);

            if (Math.Abs(all1[0] - all2[0]) < abs && Math.Abs(all1[1] - all2[1]) < abs && Math.Abs(all1[2] - all2[2]) < abs)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getRgb(Bitmap bitMap, int x, int y)
        {
            try
            {
                string rgb = "";
                Color c = bitMap.GetPixel(x, y);
                rgb += c.R + " ";
                rgb += c.G + " ";
                rgb += c.B + " ";
                return rgb;
            }
            catch{
                return "please f5";
            }
        }
    }
}
