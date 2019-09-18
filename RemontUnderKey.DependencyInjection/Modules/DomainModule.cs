using RemontUnderKey.DependencyInjection.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace RemontUnderKey.DependencyInjection.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IBill, Bill_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IClient, Client_Service>(
                //new HierarchicalLifetimeManager()
                );

            //для работы с фейк-репозиторием
            container.RegisterType<IDomain_InitializationService, Domain_InitializationService>(
                //new HierarchicalLifetimeManager()
                );
        }
    }
}