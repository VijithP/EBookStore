using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EBookStoreContracts.Contracts;
using Dapper;
using EBookStoreDAL.Interface;

namespace EBookStoreDAL.DAL
{
    public class BookDAL:IBookDAL
    {
        public List<Book> GetBookDetails()
        {
            try
            {

                //SqlConnection sqlConnection = new SqlConnection(@"Server = (localdb)\MSSQLLocalDB; initial catalog = EBookStoreDB; integrated security = True; ");
                List <Book> bookList = new List<Book>();
                //using (SqlConnection con = sqlConnection)
                using (SqlConnection con = BaseRepository.GetEBookConnectionObject())
                {                                     
                    var data = con.Query<Book>("Usp_EBook_GetBookDetails", null, commandType: CommandType.StoredProcedure);
                    bookList = data.ToList();
                    return bookList;
                }         
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BookPurchase> GetBookPurchaseDetails(BookPurchase bookPurchase)
        {
            try
            {
                List<BookPurchase> bookList = new List<BookPurchase>();
                using (SqlConnection con = BaseRepository.GetEBookConnectionObject())
                {
                    DynamicParameters dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@UserID", Convert.ToInt32(bookPurchase.UserID));
                    dynamicParameters.Add("@StatusID", Convert.ToInt32(bookPurchase.StatusID));
                    var data = con.Query<BookPurchase>("Usp_EBook_GetMyOrders", dynamicParameters, commandType: CommandType.StoredProcedure);
                    bookList = data.ToList();
                    return bookList;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public String SaveBookDetails(DataTable emp_AppraisalTable)
        {
            string result=string.Empty;
            try
            {
                using (SqlConnection con = BaseRepository.GetEBookConnectionObject())
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_EBook_InsertBookPurchase", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter
                    sqlParam = cmd.Parameters.AddWithValue("@BookPurchase_Dt", emp_AppraisalTable);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    result= "Success";

                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
                throw;
            }
            return result;
        }



    }
}
