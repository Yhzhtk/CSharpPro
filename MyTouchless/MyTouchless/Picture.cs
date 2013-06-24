using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace MyTouchless
{
    class Pictures
    {
        public List<Picture> imgs = new List<Picture>();
        public int now;
        public int length;
        public int times;

        public DateTime sTime;

        public Pictures(string fileName)
        {
            imgs.AddRange(GetFrames(fileName));
            times = 0;
            now = 0;
            length = imgs.Count;
        }

        public void setStartTime()
        {
            this.sTime = DateTime.Now;
        }

        public Picture getPicAutoPlus()
        {
            Picture p = imgs[now++];
            if (now == length)
            {
                now = 0;
                times++;
                setStartTime();
            }
            return p;
        }

        public Picture getPicNotPlus()
        {
            return imgs[now];
        }

        public void reset()
        {
            now = 0;
            times = 0;
        }

        /// <summary>
        /// 获取图片中的各帧
        /// </summary>
        /// <param name="pPath">图片路径</param>
        public static List<Picture> GetFrames(string pPath)
        {
            List<Picture> pics = new List<Picture>();

            Image gif = Image.FromFile(pPath);
            FrameDimension fd = new FrameDimension(gif.FrameDimensionsList[0]);

            //获取帧数(gif图片可能包含多帧，其它格式图片一般仅一帧)
            int count = gif.GetFrameCount(fd);

            //以Jpeg格式保存各帧
            for (int i = 0; i < count; i++)
            {
                gif.SelectActiveFrame(fd, i);
                //gif.Save(pSavedPath + "\\frame_" + i + ".jpg", ImageFormat.Jpeg);
                int delay = 0;
                for (int j = 0; j < gif.PropertyIdList.Length; j++)//遍历帧属性
                {
                    if ((int)gif.PropertyIdList.GetValue(j) == 0x5100)//如果是延迟时间
                    {
                        PropertyItem pItem = (PropertyItem)gif.PropertyItems.GetValue(j);//获取延迟时间属性
                        byte[] delayByte = new byte[4];//延迟时间，以1/100秒为单位
                        delayByte[0] = pItem.Value[i * 4];
                        delayByte[1] = pItem.Value[1 + i * 4];
                        delayByte[2] = pItem.Value[2 + i * 4];
                        delayByte[3] = pItem.Value[3 + i * 4];
                        delay += BitConverter.ToInt32(delayByte, 0) * 10; //乘以10，获取到毫秒
                        break;
                    }
                }
                pics.Add(new Picture((Image)gif.Clone(), delay * 10000));
            }

            return pics;
        }
    }

    class Picture
    {
        public Picture(Image img, int delay)
        {
            this.img = img;
            this.delay = delay;
        }

        private Image img;

        public Image Img
        {
            get { return img; }
            set { img = value; }
        }
        private int delay;

        public int Delay
        {
            get { return delay; }
            set { delay = value; }
        }

        private DateTime time;

        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
