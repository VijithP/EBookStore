using System.Web.Http;
using WebActivatorEx;
using EBookStoreAPI;
using Swashbuckle.Application;

//[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace EBookStoreAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {

            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {

                    c.SingleApiVersion("v1", "EBookStoreAPI");
                   

                })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("EBook Store Swagger UI");
                });
        }
    }
}
