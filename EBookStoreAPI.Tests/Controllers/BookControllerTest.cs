using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBookStoreAPI;
using EBookStoreAPI.Controllers;
using EBookStoreContracts.Contracts;
using EBookStoreBO.Interface;
using EBookStoreBO.BO;
using EBookStoreDAL.DAL;
using EBookStoreDAL.Interface;
using System.Net.Http;
using NUnit;
using NUnit.Framework;
using Moq;
using System.Web.Http;
using Assert = NUnit.Framework.Assert;
using System.Web.Http.Results;

namespace EBookStoreAPI.Tests.Controllers
{
    [TestClass]
    public class BookControllerTest
    {
        [TestMethod]
        public void TestStringMethod()
        {
            


            var _bookBO = new Mock<IBookBO>();
            _bookBO.Setup(x => x.GetBookDetails());
            //var controller = new BookDetailsController(_bookBO.Object);
            ////var returnData = controller.GetBookDetails();

            //string actionResult = controller.ReturnResult();
          //  var contentResult = actionResult as OkNegotiatedContentResult<ApiResponse<Book>>;


        }


        [TestMethod]
        public void TestMethod()
        {

            var _bookDAL = new Mock<IBookBO>();
            _bookDAL.Setup(x => x.GetBookDetails());
            var controller = new BookDetailsController(_bookDAL.Object);
            var list = controller.GetBookDetails();

            //BookBO obj = new BookBO();
            //var list = obj.GetBookDetails();

            //BookDAL bk = new BookDAL();
            //var lista = bk.GetBookDetails();


            //var calculator = new Mock<IBookDAL>();
            //var controller = new BookBO(calculator.Object);
            //var list = controller.GetBookDetails();

            //var _bookBO = new Mock<IBookBO>();
            //_bookBO.Setup(x => x.GetBookDetails());


            //var _bookDAL = new Mock<IBookDAL>();
            //_bookDAL.Setup(x => x.GetBookDetails());

            //var controller = new BookDAL();
            //var returnData = controller.GetBookDetails();

            //string actionResult = controller.ReturnResult();
            //  var contentResult = actionResult as OkNegotiatedContentResult<ApiResponse<Book>>;

        }





        [TestMethod]
        public void GetBookDetailsTest()
        {

            //var _bookBO = new Mock<IBookBO>();
            //var controller = new BookDetailsController(_bookBO.Object);


            var _bookBO = new Mock<IBookBO>();
            _bookBO.Setup(x => x.GetBookDetails());
            var controller = new BookDetailsController(_bookBO.Object);
            //var returnData = controller.GetBookDetails();

            IHttpActionResult actionResult = controller.GetBookDetails();
            var contentResult = actionResult as OkNegotiatedContentResult<ApiResponse<Book>>;

            Assert.IsNull(contentResult); 



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

    }
}
