using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EBookStoreContracts.Contracts;
using EBookStoreBO.BO;
using EBookStoreBO.Interface;
using EBookStoreDAL.DAL;
using System.Web.Http.Cors;

namespace EBookStoreAPI.Controllers
{   
    [RoutePrefix("api/BookOperation")]   
    public class BookDetailsController : ApiController
    {

        private readonly IBookBO _bookBO;
                    
        public BookDetailsController(IBookBO bookBO)
        {
            _bookBO = bookBO;
        }

       // [AllowAnonymous]
        [HttpGet]      
        [Route("GetBookDetails")]
        //[Authorize]
        public IHttpActionResult GetBookDetails()
        {
            try
            {
                string errorMessage = string.Empty;
                var bookDetailsList = _bookBO.GetBookDetails();

                if (bookDetailsList.Count == 0)
                {
                    return Ok(new ApiResponse<Book>()
                    {
                        ErrorMessage = errorMessage,
                        ErrorOccurred = false,
                        ResponseText = "No results found.",
                        Result = null
                    });
                }
                return Ok(new ApiResponse<Book>
                {
                    ErrorMessage = errorMessage,
                    ErrorOccurred = false,
                    Result = bookDetailsList
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public string ReturnResult()
        {
            return "Success";
        }



        [HttpPost]
        [AllowAnonymous]
        [Route("GetMyOrders")]
        public IHttpActionResult GetBookPurchaseDetails(BookPurchase bookPurchase)
        {
            try
            {
                string errorMessage = string.Empty;
                var bookDetailsList = _bookBO.GetBookPurchaseDetails(bookPurchase);

                if (bookDetailsList.Count == 0)
                {
                    return Ok(new ApiResponse<Book>()
                    {
                        ErrorMessage = errorMessage,
                        ErrorOccurred = false,
                        ResponseText = "No results found.",
                        Result = null
                    });
                }
                return Ok(new ApiResponse<Book>
                {
                    ErrorMessage = errorMessage,
                    ErrorOccurred = false,
                    Result = bookDetailsList
                });

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [AllowAnonymous]
        [Route("BookBuying")]
        public IHttpActionResult InsertBookPurchase(BookPurchase[] bookPurchases)
        {
            try
            {
                string errorMessage = string.Empty;
                string result = _bookBO.SaveBookDetails(bookPurchases);

                if (result != "success")
                {
                    return Ok(new ApiResponse<Book>()
                    {
                        ErrorMessage = result,
                        ErrorOccurred = false,
                        ResponseText = "No results found.",
                        Result = null
                    });
                }
                return Ok(new ApiResponse<Book>
                {
                    ErrorMessage = errorMessage,
                    ErrorOccurred = false,
                    Result = result
                });

            }
            catch (Exception)
            {
                throw;
            }

        }



    }
}
