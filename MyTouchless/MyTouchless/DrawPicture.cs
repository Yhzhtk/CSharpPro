using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using TouchlessLib;

namespace MyTouchless
{
    class DrawPicture
    {
        private TouchlessMgr tlmgr;
        private int displayWidth, displayHeight;
        private Bitmap canvas;
        private Graphics canvasGFX;
        //private Point p1;
        private Point p2;
        private Pen pen;

        private Pictures pics;
        private Picture pic;

        private int cameraWidth;
        private int cameraHeight;

        public DrawPicture(TouchlessMgr tlmgr, Rectangle displayBounds, string fileName)
        {
            this.tlmgr = tlmgr;

            // Initialize the display bounds
            displayWidth = displayBounds.Width;
            displayHeight = displayBounds.Height;

            cameraWidth = tlmgr.Cameras[0].CaptureWidth;
            cameraHeight = tlmgr.Cameras[0].CaptureHeight;

            pics = new Pictures(@fileName);
            pic = pics.getPicAutoPlus();

            // Initialize the canvas for drawing and its graphics object
            canvas = new Bitmap(tlmgr.CurrentCamera.CaptureWidth, tlmgr.CurrentCamera.CaptureHeight);
            canvasGFX = Graphics.FromImage(canvas);
            canvasGFX.FillRectangle(new SolidBrush(Color.FromArgb(64, 255, 255, 255)), 0, 0, canvas.Width, canvas.Height);

            // Initialize the points and pen used for drawing segments
            pen = new Pen(Color.Black);
            //p1 = new Point();
            p2 = new Point();

            // Add marker update handling
            foreach (Marker marker in tlmgr.Markers)
            {
                marker.OnChange += new EventHandler<MarkerEventArgs>(updateMarker);
            }

            //开始时间
            pics.setStartTime();
        }

        public void Dispose()
        {
            // Remove marker update handling
            foreach (Marker marker in tlmgr.Markers)
                marker.OnChange -= new EventHandler<MarkerEventArgs>(updateMarker);
        }

        public void drawCanvas(Graphics gfx)
        {
            // Draw our canvas with all the segments
            gfx.DrawImage(canvas, 0, 0, displayWidth, displayHeight);
        }

        public void updateMarker(object sender, MarkerEventArgs args)
        {
            // Do not draw if the marker's wasn't previously found
            if (!args.EventMarker.PreviousData.Present)
                return;

            // Draw a segment on our canvas between the marker and where it was previously found
            MarkerEventData data = args.EventData;
            //pen.Color = Color.FromArgb(128, data.ColorAvg.R, data.ColorAvg.G, data.ColorAvg.B);
            //pen.Width = data.Area / 60;
            //p1.X = (data.X - data.DX);
            //p1.Y = (data.Y - data.DY);
            p2.X = data.X;
            p2.Y = data.Y;

            //p3.X = (int)(data.X / (float)cameraWidth * displayWidth);
            //p3.Y = (int)(data.Y / (float)cameraHeight * displayHeight);
            //canvasGFX.DrawLine(pen, p1, p2);
            canvasGFX.Clear(Color.Transparent);

            if (DateTime.Now.Ticks - pics.sTime.Ticks > pic.Delay)
            {
                pic = pics.getPicAutoPlus();
            }
            canvasGFX.DrawImage(pic.Img, new Rectangle(p2, pic.Img.Size));
        }
    }
}
