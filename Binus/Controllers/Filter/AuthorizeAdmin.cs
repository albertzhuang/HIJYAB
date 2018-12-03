using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;


namespace Binus.Controllers.Filter
{
    public class AuthorizeAdmin : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["admin"] == null)
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