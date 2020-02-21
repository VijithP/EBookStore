using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBookStoreAPI.Tests.Controllers
{
    internal class ApiResponse<T>
    {
        internal bool ErrorOccurred;

        internal string ResponseText;

        public object Result { get; set; }
        public object ErrorMessage { get; internal set; }
    }
}