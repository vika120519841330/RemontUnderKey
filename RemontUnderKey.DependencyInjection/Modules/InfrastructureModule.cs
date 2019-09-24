using Microsoft.EntityFrameworkCore;
using RemontUnderKey.DependencyInjection.Interfaces;
using System.Configuration;
using Unity;
using Unity.Injection;
using RemontUnderKey.InfrastructureServices.Context;
using RemontUnderKey.InfrastructureServices.Repositories;
using RemontUnderKey.Infrastructure.Interfaces;


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

            container.RegisterType<ICallMee_Repository, CallMee_Repository>(
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType<IComment_Repository, Comment_Repository>(
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType <IJob_Repository, Job_Repository> (
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType <IKind_Repository, Kind_Repository> (
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType <IObject_Repository, Object_Repository> (
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType <IPhoto_Repository, Photo_Repository> (
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType <IType_Repository, Type_Repository> (
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType <IUnit_Repository, Unit_Repository> (
            //new ContainerControlledLifetimeManager()
            );
        }
    }
}
