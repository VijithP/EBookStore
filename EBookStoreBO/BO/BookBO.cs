using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EBookStoreContracts.Contracts;
using EBookStoreBO.Interface;
using EBookStoreDAL.DAL;
using EBookStoreDAL.Interface;


namespace EBookStoreBO.BO
{
    public class BookBO:IBookBO
    {
        private IBookDAL _bookDAL;
        public BookBO(IBookDAL bookDAL)
        {
            _bookDAL = bookDAL;
        }
             
        public List<Book> GetBookDetails()
        {
            return _bookDAL.GetBookDetails();
        }

        public List<BookPurchase> GetBookPurchaseDetails(BookPurchase bookPurchase)
        {
            return _bookDAL.GetBookPurchaseDetails(bookPurchase);
        }

        public string SaveBookDetails(BookPurchase[] bookPurchase)
        {
            DataTable bookPurchaseDT = GenerateBookPurchaseDt(bookPurchase);
            return _bookDAL.SaveBookDetails(bookPurchaseDT);
        }
        
        public DataTable GenerateBookPurchaseDt(BookPurchase[] bookPurchase)
        {

            try
            {
                DataTable bookPurchaseDt = CreateBookPurchaseDt();
                foreach (var item in bookPurchase)
                {

                    bookPurchaseDt.Rows.Add(
                        item.BookID,
                        item.UserID,
                        item.StatusID,
                        item.Rating,
                        item.Review                     
                        );
                }

                return bookPurchaseDt;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        static DataTable CreateBookPurchaseDt()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("BookID", typeof(int));
            dt.Columns.Add("UserID", typeof(int));
            dt.Columns.Add("StatusID", typeof(int));
            dt.Columns.Add("Rating", typeof(int));
            dt.Columns.Add("Review", typeof(string));

            return dt;
        }



        }
    }
