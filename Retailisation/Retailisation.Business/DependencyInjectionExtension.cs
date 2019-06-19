using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.Practices.Unity;
using Unity.Extension;
using Retailisation.DAL;
using Unity;

namespace Retailisation.Business
{
    public class DependencyInjectionExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            
        }
    }
    public static class ServiceUnityConfig
    {
        public static void RegisterComponents(UnityContainer container)
        {
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IStoreRepository, StoreRepository>();
        }
    }
}
