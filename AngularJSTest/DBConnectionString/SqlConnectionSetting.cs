using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace AngularJSTest.DBConnectionString
{
    public class SqlConnectionSetting
    {
        public static SqlConnection SqlConn
        {
            get
            {
                return new SqlConnection(ConfigurationManager.ConnectionStrings["TestContext"].ConnectionString);
            }
        }

        public string writelog(string msg)
        {
            string logFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }
            string fileName = Path.Combine(logFolder, string.Format("log_{0}.txt", DateTime.Now.ToString("ddMMyyyy")));
            using (StreamWriter w = System.IO.File.AppendText(fileName))
            {
                w.WriteLine("{0}-{1}", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"), msg);
            }

            return "";
        }
    }
}