using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Binus.Data;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Binus.Models;

namespace Binus.Controllers.Api
{
    public class AssessmentTypeController : ApiController
    {
        BinusEntities db = new BinusEntities();

        [HttpGet]
        public HttpResponseMessage getAll()
        {
            //return new HttpResponseMessage(HttpStatusCode.OK);
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.AssessmentTypes1.ToList(), new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            //try
            //{
            //    var result = new HttpResponseMessage(HttpStatusCode.OK);
            //    //result.Content = new StringContent(JsonConvert.SerializeObject(db.AssessmentTypes1.ToList()));
                
            //    result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //    return result;
            //}
            //catch
            //{
            //    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            //}
        }
    }
}
