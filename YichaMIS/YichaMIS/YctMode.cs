using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YichaMIS
{
    public class YctMode
    {
        public int id;
        public string shop;
        public string phone;
        public string money;
        public DateTime time;
        public string mark;

        public string getModeStr()
        {
            return id + "\t" + shop + "\t" + phone + "\t" + money + "\t" + time.ToString() + "\t" + mark;
        }
    }
}
