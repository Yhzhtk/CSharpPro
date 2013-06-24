using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YichaMIS
{
    class LogMode
    {
        public int id;
        public string user;
        public string act;
        public DateTime time;

        public LogMode()
        {
        }

        public LogMode(string act)
        {
            user = Const.userName;
            time = DateTime.Now;
            this.act = act;
        }

        public string getLogStr()
        {
            return id + "\t" + user + "\t" + act + "\t" + time.ToString();
        }
    }
}
