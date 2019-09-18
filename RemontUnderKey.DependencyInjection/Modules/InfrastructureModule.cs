﻿using Microsoft.EntityFrameworkCore;
using RemontUnderKey.DependencyInjection.Interfaces;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

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

            // если работать с контекстом напрямую без фейк-репозитория - раскомментировать
            container.RegisterType<IClient_Repository, Client_Repository>(
            //new ContainerControlledLifetimeManager()
            );
            container.RegisterType<IBill_Repository, Bill_Repository>(
            //new ContainerControlledLifetimeManager()
            );


            // для работы с  фейк-репозиторием - раскомментировать
            //container.RegisterType<IInitializationService, InitializationService>(
            //    //new HierarchicalLifetimeManager()
            //    );
            //container.RegisterType<IClient_Provider, FakeRepository>(
            //    //new HierarchicalLifetimeManager()
            //    );
            //container.RegisterType<IBill_Provider, FakeRepository>(
            //    //new HierarchicalLifetimeManager()
            //    );
            //container.RegisterType<IClient_Repository, FakeRepository>(
            //    //new HierarchicalLifetimeManager()
            //    );
            //container.RegisterType<IBill_Repository, FakeRepository>(
            //    //new HierarchicalLifetimeManager()
            //    );

        }
    }
}
