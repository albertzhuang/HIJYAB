using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using Binus.Models;
using Binus.Data;
using System.Web;

namespace Binus.Controllers.Api
{
    public class LoginController : ApiController
    {
        BinusEntities db = new BinusEntities();

        [HttpPost]
        public HttpResponseMessage getlogin(User model)
        {
            Users user = db.Users1.Where(u => u.Username.Equals(model.username) 
            && u.Password.Equals(model.password)).FirstOrDefault();

            if(user != null)
            {
                FormsAuthentication.SetAuthCookie(model.username, false);
                HttpContext.Current.Session["admin"] = model.username;
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                Students student = db.Students1.Where(u => u.Nim.Equals(model.username)
                && u.Password.Equals(model.password)).FirstOrDefault();                
                
                if(student != null)
                {
                    FormsAuthentication.SetAuthCookie(model.username, false);
                    HttpContext.Current.Session["student"] = model.username;
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }

           

            return new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }
}
