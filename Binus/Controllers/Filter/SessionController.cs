using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Http.WebHost;

namespace Binus.Controllers.Filter
{
    public class SessionController : HttpControllerHandler, IRequiresSessionState
    {
        public SessionController(RouteData routeData)
            : base(routeData)
        { }
    }
}