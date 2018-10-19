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
    public class AssessmentController : ApiController
    {
        BinusEntities db = new BinusEntities();

        [HttpGet]
        public HttpResponseMessage getAll()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.assessment_types.ToList()));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        //[HttpPost]
        //public IHttpActionResult post(Assessment assessment)
        //{
        //    return Json(assessment);
        //}

        [HttpPost]
        public HttpResponseMessage postData(Assessment assessment)
        {

            //assessment_types test = new assessment_types
            //{
            //    assessment_type_id = 2,
            //    assessment_type = "test ac"
            //};
            assessment_1 assessment_1 = new assessment_1();
            assessment_1.title = assessment.title;
            assessment_1.description = assessment.description;
            db.assessment_1.Add(assessment_1);

            foreach (var value in assessment.statements)
            {
                statements statement = new statements();
                statement.statement_id = 1;
                statement.statement = value.statement;
                db.statements1.Add(statement);

                
                foreach (string val in value.statementDetails)
                {
                    statement_details statement_detail = new statement_details();
                    
                    //statement_detail = val;
                    //db.statement_details.Add(statement_detail);
                }
            }

            try
            {
                db.SaveChanges();
                var result = new HttpResponseMessage(HttpStatusCode.Accepted);

                result.Content = new StringContent(JsonConvert.SerializeObject(assessment));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }


    }
}
