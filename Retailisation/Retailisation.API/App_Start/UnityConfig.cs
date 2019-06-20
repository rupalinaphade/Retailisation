using System.Web.Http;
using Unity;
using Unity.WebApi;
using Retailisation.Business;

namespace Retailisation.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IProductBL, ProductBl>();
            container.RegisterType<IProductJsonBl, ProductJsonBl>();
            container.RegisterType<IStoreBL, StoreBl>();
            container.RegisterType<IStoreJsonBl, StoreJsonBl>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            ServiceUnityConfig.RegisterComponents(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}