using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EBookStoreContracts.Contracts;
using Dapper;


namespace EBookStoreDAL.DAL
{
    public class UserDAL:BaseRepository
    {
        public List<User> GetUserDetails()
        {
            try
            {
                List<User> userlist = new List<User>();
                using (SqlConnection con = GetEBookConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();                  
                    var data = con.Query<User>("Usp_EBook_ValidateLogin", null, commandType: CommandType.StoredProcedure);
                    userlist = data.ToList();
                    return userlist;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
