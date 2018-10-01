using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace CheckNewTypeDocumentsFtpEis
{
    public class Ftp
    {
        private const string ConnectString = "Server=localhost;port=3306;Database=tender;User Id=root;password=1234;CharSet=utf8;Convert Zero Datetime=True;default command timeout=3600;Connection Timeout=3600;SslMode=none";

        private MySqlConnection GetDbConnection()
        {
            var conn = new MySqlConnection(ConnectString);

            return conn;
        }
        public DataTable GetRegions()
        {
            var reg = "SELECT * FROM region";
            DataTable dt;
            using (var connect = GetDbConnection())
            {
                connect.Open();
                var adapter = new MySqlDataAdapter(reg, connect);
                var ds = new DataSet();
                adapter.Fill(ds);
                dt = ds.Tables[0];
            }

            return dt;
        }

        public virtual void CheckFtp()
        {
            
        }

        protected  List<string> GetListArchCurr(string pathParse)
        {
            List<string> arch = new List<string>();
            try
            {
                arch = GetListFtp(pathParse);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(pathParse);
            }
            return arch;
        }

        protected virtual List<string> GetListFtp(string pathParse)
        {
            return new List<string>();
        }
        
    }
    
}