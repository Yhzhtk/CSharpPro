using System;
using System.Configuration;
namespace DBUtility
{
    
    public class PubConstant
    {

        static string _connectionString = "Server=localhost;Database=novelmanage;Uid=root;Pwd=root;";

        public static string ConnectionString
        {
            get { return PubConstant._connectionString; }
            set { PubConstant._connectionString = value; }
        }
    }
}
