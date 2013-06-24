using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace ImageGroup
{
    class ImageUtil
    {
        /// <summary>  
        /// 高质量缩放图片  
        /// </summary>  
        /// <param name="OriginFilePath">源图的路径</param>  
        /// <param name="TargetFilePath">存储缩略图的路径</param>  
        /// <param name="DestWidth">缩放后图片宽度</param>  
        /// <param name="DestHeight">缩放后图片高度</param>  
        /// <returns>表明此次操作是否成功</returns>  
        public static void GetMicroImage(string OriginFilePath, string TargetFileName)
        {
            int DestWidth = 240;
            int DestHeight = 240;

            DirectoryInfo origin = new DirectoryInfo(OriginFilePath);

            FileInfo[] files = origin.GetFiles();

            Bitmap bt = new Bitmap(DestWidth, DestHeight); //根据指定大小创建Bitmap实例  

            DestWidth = DestWidth / 4;
            DestHeight = DestHeight / 4;

            Graphics g = Graphics.FromImage(bt);
            g.Clear(Color.White);
            //设置画布的描绘质量  
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            for (int i = 0; i < files.Length && i < 4; i++)
            {
                if (!files[i].FullName.EndsWith(".jpg"))
                    continue;

                Image OriginImage = Image.FromFile(files[i].FullName);
                System.Drawing.Imaging.ImageFormat thisFormat = OriginImage.RawFormat;
                //按比例缩放  
                int sW = 0, sH = 0;
                int ImageWidth = OriginImage.Width;
                int ImageHeight = OriginImage.Height;

                if (ImageWidth > DestWidth || ImageHeight > DestHeight)
                {
                    if ((ImageWidth * DestWidth) > (ImageHeight * DestHeight))
                    {
                        sW = DestWidth;
                        sH = (DestHeight * ImageHeight) / ImageWidth;
                    }
                    else
                    {
                        sH = DestHeight;
                        sW = (DestWidth * ImageWidth) / ImageHeight;
                    }
                }
                else
                {
                    sW = ImageWidth;
                    sH = ImageHeight;
                }

                Rectangle rect = new Rectangle(4, 4, 112, 112);
                if (i == 1)
                    rect = new Rectangle(124, 4, 112, 112);
                else if (i == 2)
                    rect = new Rectangle(4, 124, 112, 112);
                else if (i == 3)
                    rect = new Rectangle(124, 124, 112, 112);

                g.DrawImage(OriginImage, rect);
                OriginImage.Dispose();
            }
            g.Dispose();

            new FileInfo(TargetFileName).Directory.Create();
            bt.Save(TargetFileName);
            bt.Dispose();
        }
    }
}
