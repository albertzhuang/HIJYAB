using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;


namespace Binus.Controllers.Filter
{
    public class AuthorizeStudent : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["student"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "Controller", "Error"},
                    { "Action", "Unauthorized"}
                });
            }

            base.OnActionExecuting(filterContext);
        }
    }
}