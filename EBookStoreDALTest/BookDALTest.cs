using System;
using System.Text;
using System.Collections.Generic;
using EBookStoreContracts.Contracts;
using EBookStoreDAL.DAL;
using NUnit.Framework;
using System.Linq;
using System.Data;

namespace EBookStoreDALTest
{
    /// <summary>
    /// Summary description for BookDALTest
    /// </summary>
    //[TestClass]
    [TestFixture]
    public class BookDALTest
    {
      
        [Test]
        public void GetBookDetails_GetBooks_BookDetailsExist()
        {
            //Arrange
            BookDAL bookDAL = new BookDAL();

            //Act
            var listBook = bookDAL.GetBookDetails();

            //Assert 
            Assert.IsTrue(listBook.Count > 0, "Get All returned no items.");

        }

        [Test]
        public void GetBookDetails_GetBooks_BookDetailsChecking()
        {
            //Arrange
            BookDAL bookDAL = new BookDAL();           

            //Act
            List<Book> listBook = bookDAL.GetBookDetails();

            //Assert 
            Assert.IsTrue(listBook.Count ==9, "Get All returned items.");
            Assert.That(listBook.Count(bk => bk.BookName == "The Alchemist"), Is.EqualTo(1));
            Assert.That(listBook, Is.All.InstanceOf(typeof(Book)));            

        }


        [Test]
        public void GetBookPurchaseDetails_AddToCardBooks_AddToCartBooksCount()
        {
            //Arrange
            BookDAL bookDAL = new BookDAL();
            BookPurchase bookPurchase = new BookPurchase();
            bookPurchase.UserID = 1;
            bookPurchase.StatusID = 1;

            //Act
            List<BookPurchase> listBook = bookDAL.GetBookPurchaseDetails(bookPurchase);

            //Assert 
            Assert.IsTrue(listBook.Count >=0, "Get All add to cart  Items.");          
            Assert.That(listBook, Is.All.InstanceOf(typeof(BookPurchase)));

        }


        [Test]
        public void GetBookPurchaseDetails_PurchasedBook_PurchasedBooksCount()
        {
            //Arrange
            BookDAL bookDAL = new BookDAL();
            BookPurchase bookPurchase = new BookPurchase();
            bookPurchase.UserID = 1;
            bookPurchase.StatusID = 2;

            //Act
            List<BookPurchase> listBook = bookDAL.GetBookPurchaseDetails(bookPurchase);

            //Assert 
            Assert.IsTrue(listBook.Count >= 0, "Get All purchased  Items.");
            Assert.That(listBook, Is.All.InstanceOf(typeof(BookPurchase)));

        }

        [Test]
        public void SaveBookDetails_SaveAddToCartBook_AddToCartBooksSave()
        {
            BookDAL bookDAL = new BookDAL();
            BookPurchase bookPurchase = new BookPurchase()
            { BookID = 1, UserID = 1, StatusID = 1, Rating = null, Review = null };
            BookPurchase[] bookPurchaselist = new BookPurchase[1];
            bookPurchaselist[0] = bookPurchase;
            DataTable dt = GenerateBookPurchaseDt(bookPurchaselist);

            //Act
            string result = bookDAL.SaveBookDetails(dt);

            //Assert 
            Assert.IsTrue(result == "Success", "Saved add to cart book details");

        }

        [Test]
        public void SaveBookDetails_SavePurchasedBook_PurchasedBooksSave()
        {
            //Arrange
            BookDAL bookDAL = new BookDAL();
            BookPurchase bookPurchase = new BookPurchase()
            { BookID = 1, UserID = 1, StatusID = 2, Rating = null,Review=null };
            BookPurchase[] bookPurchaselist=new  BookPurchase[1];
            bookPurchaselist[0]=bookPurchase;
            DataTable dt = GenerateBookPurchaseDt(bookPurchaselist);

            //Act
            string result = bookDAL.SaveBookDetails(dt);

            //Assert 
            Assert.IsTrue(result=="Success", "Saved purchase book details");
          
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
