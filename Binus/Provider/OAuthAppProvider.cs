
using Binus.Models.Account;
using Binus.Service; 
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Binus.Provider
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var username = context.UserName;
                var password = context.Password;
                var role = "admin";

                if (!string.IsNullOrEmpty(username))
                {
                    if (username.Contains("@binus.ac.id"))
                    {
                        role = "student";
                    }


                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, username),
                        new Claim("fullname", username),
                        new Claim(ClaimTypes.Role, role)
                    };

                    ClaimsIdentity oAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    ClaimsIdentity cookiesIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationType);
                    context.Validated(new AuthenticationTicket(oAuthIdentity, new AuthenticationProperties() { }));
                    context.Request.Context.Authentication.SignIn(cookiesIdentity);
                }
                else
                {
                    context.SetError("invalid_grant", "Error");
                }
            });
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }
            return Task.FromResult<object>(null);
        }
    }
}