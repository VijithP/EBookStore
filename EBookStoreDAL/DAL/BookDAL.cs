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
    public class BookDAL:BaseRepository
    {
        public List<Book> GetBookDetails()
        {
            try
            {
                List<Book> bookList = new List<Book>();
                using (SqlConnection con = GetEBookConnectionObject())
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
                using (SqlConnection con = GetEBookConnectionObject())
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
            try
            {
                using (SqlConnection con = GetEBookConnectionObject())
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand("Usp_EBook_InsertBookPurchase", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter
                    sqlParam = cmd.Parameters.AddWithValue("@BookPurchase_Dt", emp_AppraisalTable);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "Success";

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
