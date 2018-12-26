using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Filters;
using System.Web.Routing;
using Microsoft.Owin.Security.OAuth;
using System.Configuration;
using System.Web.Http.Cors;

namespace Binus
{
    public class CustomJsonFormatter : JsonMediaTypeFormatter 
    {
        public CustomJsonFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
        }

        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");       
        }
    }

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

            config.Formatters.Add(new CustomJsonFormatter());

            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*","*");
            config.EnableCors(cors);
        }
    }
}