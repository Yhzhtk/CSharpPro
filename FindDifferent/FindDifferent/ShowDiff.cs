using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace FindDifferent
{
    public partial class ShowDiff : Form
    {
        private Boolean selRect;

        /// <summary>
        /// 主画笔
        /// </summary>
        private Graphics mainPainter;
        /// <summary>
        /// 笔
        /// </summary>
        private Pen pen;
        /// <summary>
        /// 判断鼠标是否按下
        /// </summary>
        private bool isDowned;
        /// <summary>
        /// 矩形是否绘制完成
        /// </summary>
        private bool rectReady;
        /// <summary>
        /// 原始画面
        /// </summary>
        private Image baseImage;
        /// <summary>
        /// 要保存的画面
        /// </summary>
        private Rectangle rect1;

        public Rectangle Rect1
        {
            get { return rect1; }
            set { rect1 = value; }
        }

        private Rectangle rect2;

        public Rectangle Rect2
        {
            get { return rect2; }
            set { rect2 = value; }
        }

        /// <summary>
        /// 鼠标按下的点
        /// </summary>
        private Point downPoint;

        /// <summary>
        /// 两个矩形宽相差值
        /// </summary>
        private int rw = 0;

        private int tmpx;
        private int tmpy;

        public ShowDiff(Bitmap bit, Boolean selRect)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = bit;

            this.selRect = selRect;
            if (selRect)
            {
                this.WindowState = FormWindowState.Maximized;
                mainPainter = this.CreateGraphics();
                pen = new Pen(Brushes.Blue);
                isDowned = false;
                baseImage = this.BackgroundImage;
                rect1 = new Rectangle();
                rectReady = false;
            }
        }

        private void ShowDiff_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.BackgroundImage = null;
                this.Close();
                if (!selRect)
                {
                    this.Dispose();
                }
            }

            if (!selRect)
                return;

            if (e.Button == MouseButtons.Left)
            {
                if (e.X < rect1.X)
                {
                    rect1.X = e.X;
                }
                if (e.Y < rect1.Y)
                {
                    rect1.Y = e.Y;
                }
                isDowned = false;
                rectReady = true;
            }
        }

        /// <summary>
        /// 截图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScreenBody_DoubleClick(object sender, EventArgs e)
        {
            if (!selRect)
                return;

            if (((MouseEventArgs)e).Button == MouseButtons.Left && rect1.Contains(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y))
            {
                Image memory = new Bitmap(rect1.Width, rect1.Height);
                Graphics g = Graphics.FromImage(memory);
                g.CopyFromScreen(rect1.X + 1, rect1.Y + 1, 0, 0, rect1.Size);
                Clipboard.SetImage(memory);
                this.Close();
            }
        }


        private void ShowDiff_MouseDown(object sender, MouseEventArgs e)
        {
            if (!selRect)
                return;
            if (e.Button == MouseButtons.Left)
            {
                isDowned = true;
                if (!rectReady)
                {
                    rect1.X = e.X;
                    rect1.Y = e.Y;
                    downPoint = new Point(e.X, e.Y);
                }
                if (rectReady)
                {
                    tmpx = e.X;
                    tmpy = e.Y;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (!rectReady)
                {
                    this.Close();
                    return;
                }
                mainPainter.DrawImage(baseImage, 0, 0);
                rectReady = false;
            }
        }

        private void ShowDiff_MouseMove(object sender, MouseEventArgs e)
        {
            if (!selRect)
                return;
            if (!rectReady && isDowned)
            {
                Image newImage = drawScreen((Image)baseImage.Clone(), e.X, e.Y);
                mainPainter.DrawImage(newImage, 0, 0);
                newImage.Dispose();
            }
            if (rectReady)
            {
                if (rect1.Contains(e.X, e.Y))
                {
                    if (isDowned)
                    {
                        rect1.X = rect1.X + e.X - tmpx;
                        rect1.Y = rect1.Y + e.Y - tmpy;
                        tmpx = e.X;
                        tmpy = e.Y;

                        rect2.X = rect1.X + rw;
                        rect2.Y = rect1.Y;

                        moveRect((Image)baseImage.Clone(), rect1, rect2);
                    }
                }
                else if (rect2.Contains(e.X, e.Y))
                {
                    if (isDowned)
                    {
                        rect2.X = rect2.X + e.X - tmpx;
                        //rect2.Y = rect2.Y + e.Y - tmpy;
                        tmpx = e.X;
                        tmpy = e.Y;

                        rw = rect2.X - rect1.X;

                        moveRect((Image)baseImage.Clone(), rect1, rect2);
                    }
                }
            }
        }

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="Painter"></param>
        /// <param name="mouse_x"></param>
        /// <param name="mouse_y"></param>
        private void drawRect(Graphics Painter, int mouse_x, int mouse_y)
        {
            int width = 0;
            int heigth = 0;
            if (mouse_y < rect1.Y)
            {
                heigth = downPoint.Y - mouse_y;
            }
            else
            {
                heigth = mouse_y - downPoint.Y;
            }
            if (mouse_x < rect1.X)
            {
                width = downPoint.X - mouse_x;
            }
            else
            {
                width = mouse_x - downPoint.X;
            }
            rect1.Location = new Point((int)minOf(mouse_x, downPoint.X), (int)minOf(mouse_y, downPoint.Y));
            rect1.Size = new Size(width, heigth);
            Painter.DrawRectangle(pen, rect1);
            rect2 = new Rectangle((int)minOf(mouse_x, downPoint.X) + width, (int)minOf(mouse_y, downPoint.Y), width, heigth);
            Painter.DrawRectangle(pen, rect2);

            rw = rect2.X - rect1.X;
        }

        /// <summary>
        /// 选区域时画矩形
        /// </summary>
        /// <param name="back"></param>
        /// <param name="mouse_x"></param>
        /// <param name="mouse_y"></param>
        /// <returns></returns>
        private Image drawScreen(Image back, int mouse_x, int mouse_y)
        {
            Graphics painter = Graphics.FromImage(back);
            drawRect(painter, mouse_x, mouse_y);
            return back;
        }

        /// <summary>
        /// 选好区域后移动矩形
        /// </summary>
        /// <param name="image"></param>
        /// <param name="rect1"></param>
        private void moveRect(Image image, Rectangle rect1,Rectangle rect2)
        {
            Graphics painter = Graphics.FromImage(image);
            painter.DrawRectangle(pen, rect1);
            painter.DrawRectangle(pen, rect2);
            mainPainter.DrawImage(image, 0, 0);
            image.Dispose();
        }

        /// <summary>
        /// 返回较小的数
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>
        private float minOf(float f1, float f2)
        {
            if (f1 > f2)
                return f2;
            else
                return f1;
        }

        private void ShowDiff_MouseClick(object sender, MouseEventArgs e)
        {
            if (!selRect && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Visible = false;
                HotKey.mouse_event(HotKey.MOUSEEVENTF_LEFTDOWN | HotKey.MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Thread.Sleep(30);
                this.Visible = true;
                this.TopMost = true;
            }
        }
    }
}
