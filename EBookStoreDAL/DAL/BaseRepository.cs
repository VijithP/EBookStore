using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
            return System.Configuration.ConfigurationManager.ConnectionStrings["EBookConnection"].ConnectionString;
        }

    }
}
