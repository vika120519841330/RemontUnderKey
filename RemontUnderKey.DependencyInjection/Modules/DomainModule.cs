﻿using RemontUnderKey.DependencyInjection.Interfaces;
using RemontUnderKey.Domain.Interfaces;
using RemontUnderKey.DomainServices.Services;
using Unity;

namespace RemontUnderKey.DependencyInjection.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IComment, Comment_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IJob, Job_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IKind, Kind_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IObject, Object_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IPhoto, Photo_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IType, Type_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<IUnit, Unit_Service>(
                //new HierarchicalLifetimeManager()
                );
            container.RegisterType<, >(
                //new HierarchicalLifetimeManager()
                );


        }
    }
}