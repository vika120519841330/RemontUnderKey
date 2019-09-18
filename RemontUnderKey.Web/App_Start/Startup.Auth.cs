using System;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using RemontUnderKey.Web.Identity;
using RemontUnderKey.Web.Models;

namespace RemontUnderKey.Web
{
    public partial class Startup
    {
            internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
            public void ConfigureAuth(IAppBuilder app)
            {
                DataProtectionProvider = app.GetDataProtectionProvider();

                // Configure the db context, user manager and signin manager to use a single instance per request
                app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<ApplicationUserManager>());

                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                    Provider = new CookieAuthenticationProvider
                    {
                        OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                    }
                });
                app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

                app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

                app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
            }
        }
}