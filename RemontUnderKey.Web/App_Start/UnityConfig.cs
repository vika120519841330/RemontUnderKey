using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using RemontUnderKey.Web.Identity;
using RemontUnderKey.Web.Models;
using System;
using System.Web;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using RemontUnderKey.DependencyInjection.Interfaces;
using RemontUnderKey.DependencyInjection.Modules;

namespace RemontUnderKey.Web
{
    public static class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<EmailService>();
            container.RegisterType<SmsService>();

            container.RegisterType<IAuthenticationManager>
                (new InjectionFactory
                (c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
            new InjectionConstructor(typeof(ApplicationDbContext)));

            container.RegisterType<UserManager<IdentityUser>>(new HierarchicalLifetimeManager());

            container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(
           new HierarchicalLifetimeManager(), new InjectionConstructor(typeof(ApplicationDbContext)));

            container.RegisterType<RoleManager<IdentityRole>>(new HierarchicalLifetimeManager());

            container.RegisterType<ApplicationDbContext>(new InjectionConstructor());

            // ������������ ������ � ������ ���������� Container
            Registre<DomainModule>(container);
            Registre<InfrastructureModule>(container);
        }

        // �������������� ��������� ������ � �������� ����� Register, ��������� ������� Container 
        // ��� ����������� ������������
        private static void Registre<T>(IUnityContainer container) where T : IModule, new()
        {
            new T().Register(container);
        }
    }
}