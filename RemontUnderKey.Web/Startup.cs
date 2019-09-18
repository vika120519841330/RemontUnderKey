using Microsoft.Owin;
using Owin;
using RemontUnderKey.Web;

[assembly: OwinStartupAttribute(typeof(RemontUnderKey.Web.Startup))]
namespace RemontUnderKey.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
