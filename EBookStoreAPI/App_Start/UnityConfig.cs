using System.Web.Http;
using Unity;
using Unity.WebApi;
using EBookStoreContracts.Contracts;
using EBookStoreBO.BO;
using EBookStoreBO.Interface;

namespace EBookStoreAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
       
            container.RegisterType<EBookStoreBO.Interface.IBookBO, EBookStoreBO.BO.BookBO>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}