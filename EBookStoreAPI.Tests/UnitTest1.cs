using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EBookStoreBO.BO;
using EBookStoreBO.Interface;
using System.Net.Http;
using NUnit;
using NUnit.Framework;
using Moq;
using System.Web.Http;
using Assert = NUnit.Framework.Assert;
using System.Web.Http.Results;

namespace EBookStoreAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           // IBookBO bookBO = new BookBO();
           //var list=  bookBO.GetBookDetails();



            //var _bookBO = new Mock<IBookBO>();
            //_bookBO.Setup(x => x.GetBookDetails());
            //var controller = new BookBO(_bookBO.Object);
            //var returnData = controller.GetBookDetails();


            //IHttpActionResult actionResult = controller.GetBookDetails();
            //var contentResult = actionResult as OkNegotiatedContentResult<ApiResponse<Book>>;

            //Assert.IsNull(contentResult);
        }
    }
}
