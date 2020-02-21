using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace EBookStoreDAL.DAL
{
    public class BaseRepository
    {

     
        public static SqlConnection GetEBookConnectionObject()
        {
            SqlConnection sqlConnection = new SqlConnection(GetConnectionString());
            return sqlConnection;
        }

        public static string GetConnectionString()
        {
            string connectionString = string.Empty;
            try
            {
                connectionString= System.Configuration.ConfigurationManager.ConnectionStrings["EBookConnection"].ConnectionString;

            }
            catch (Exception)
            {               
                connectionString = @"Server=(localdb)\MSSQLLocalDB;initial catalog=EBookStoreDB;integrated security=True;"; //System.Configuration.ConfigurationManager.AppSettings.Get("EBookConnectionTesting");
            }
            return connectionString;
        }

    }
}
