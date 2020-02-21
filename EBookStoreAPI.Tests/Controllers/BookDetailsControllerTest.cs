using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBookStoreAPI;
using EBookStoreAPI.Controllers;
using EBookStoreContracts.Contracts;
using EBookStoreBO.Interface;
using System.Net.Http;
using NUnit;
using NUnit.Framework;
using Moq;
using System.Web.Http;
using Assert = NUnit.Framework.Assert;
using System.Web.Http.Results;

namespace EBookStoreAPI.Tests.Controllers
{
    // [TestFixture]

    [TestClass]
    public class BookDetailsControllerTest
    {

       //BookDetailsController controller;
       // Mock<IBookBO> _bookBO;
               
        //[SetUp]
        //public void LoadContext(IBookBO bookBO)
        //{
        //    _bookBO = new Mock<IBookBO>();
        //    controller = new BookDetailsController(_bookBO.Object);
        //}


        [TestMethod]
        public void GetBookDetailsTest()
        {

            Mock<IBookBO> _bookBO = new Mock<IBookBO>();

            BookDetailsController controller   = new BookDetailsController(_bookBO.Object);


            //// Act
            //IHttpActionResult ew = controller.GetBookDetails();
            //var nn = ew as OkResult;
            //Assert.IsNotNull(nn);




            //Assert.IsType<okresult>

            //var getResult = controller.GetBookDetails();
            //var getResponse = getResult.ExecuteAsync(cancellationToken.none).Result;


            // HttpResponseMessage e = controller.GetBookDetails();

            // ApiResponse<Book> result = controller.GetBookDetails();



            // ApiResponse   result = controller.GetBookDetails();
            // var res
            //Assert.AreEqual(9, 9);
        }


        //public UnitTest1(IBookBO bookBO)
        //{
        //    _bookBO = bookBO;
        //}



        [TestMethod]
        public void GetBookDetails()
        {
            // Arrange

            controller.Request = new HttpRequestMessage();
            controller.Configuration = new System.Web.Http.HttpConfiguration();


            // Act
            var result = controller.GetBookDetails();

            // Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }
    }
}
