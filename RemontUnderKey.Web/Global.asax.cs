using RemontUnderKey.Web.Identity;
using RemontUnderKey.Web.Initializer;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RemontUnderKey.Web.Models;


namespace RemontUnderKey.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<ApplicationDbContext>(new UserRoleDbInitializer());


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            // Подключение маршрутизации для api-контроллера MessageController
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Вызов первичной инициализации бота
            Bot.Get();
        }
    }
}
