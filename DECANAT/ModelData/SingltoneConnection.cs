using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DECANAT.ModelData
{
    public class SingltoneConnection
    {
        private static OracleConnection connection;
        private SingltoneConnection() { }
        public static OracleConnection GetInstance()
        {
            if (connection == null)
            {
                connection = new OracleConnection();
                connection.ConnectionString = WebConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
                connection.Open();
            }
            return connection;
        }
        public static void Disconnect()
        {
            connection.Close();
            connection = null;
        }
    }
}