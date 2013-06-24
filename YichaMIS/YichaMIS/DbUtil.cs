using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace YichaMIS
{
    class DbUtil
    {
        public static OleDbConnection getConn()
        {
            string connstr = "Data Source='config/db.dat';Jet OLEDB:database password=yh314; Provider='Microsoft.Jet.OLEDB.4.0';User ID=Admin";
            OleDbConnection tempconn = new OleDbConnection(connstr);
            return (tempconn);
        }
    }
}
