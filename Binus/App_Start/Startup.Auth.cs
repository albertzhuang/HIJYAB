using Binus.Provider;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static CookieAuthenticationOptions CookieOptions { get; private set; }
        static Startup()
        {
            
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthAppProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true    
            };

            CookieOptions = new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            };

        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(CookieOptions);
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}