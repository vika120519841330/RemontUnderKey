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
            container.RegisterType<, >(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<, >(
                //new HierarchicalLifetimeManager()
                );

        }
    }
}