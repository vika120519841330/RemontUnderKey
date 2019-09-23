using Microsoft.EntityFrameworkCore;
using RemontUnderKey.DependencyInjection.Interfaces;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using RemontUnderKey.InfrastructureServices.Context;

namespace RemontUnderKey.DependencyInjection.Modules
{
    public class InfrastructureModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            // подключение БД
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["RemontConnection"].ConnectionString);

            using (var context = new MyContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
            }

            container.RegisterType<MyContext>(
                //new HierarchicalLifetimeManager(),        
                new InjectionConstructor(optionsBuilder.Options));

            container.RegisterType<, >(
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType<, >(
            //new ContainerControlledLifetimeManager()
            );
        }
    }
}
