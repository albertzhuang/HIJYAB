using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Binus.Data;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Binus.Models.AssessmentProcrasiantor;
using Binus.Models.AssessmentIntelligence;
using Binus.Models.AssessmentSensory;
using Binus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Binus.Controllers.Api
{
    public class DashboardController : ApiController
    {


        BinusEntities db = new BinusEntities();

        [HttpGet]
        public HttpResponseMessage getDashboardData()
        {

            //list assessment dari table assessment
            var assessmentlist = (from x in db.Assessments1
                                  select x);
            //list participant dari table transaction //mau tampilin berapa banyak participant, pop up nya view berdasarkan yg status nya yes dan view by assessment id, butuh nama jurusan = seperti DKV nya juga
            var transaction = (from x in db.Transactions1
                               join y in db.Assessments1 on x.AssessmentID equals y.AssessmentID

                               select new
                               {
                                   x.NIM,
                                   x.Status,
                                   x.Jurusan,
                                   y.AssessmentID,
                                   y.AssessmentTitle
                               });
            //list ranking dari table result // no result participant top 5 nama assessment

            var ranking = (from x in db.ResultAssessments1
                           join y in db.Assessments1 on x.AssessmentID equals y.AssessmentID
                           select new
                           {
                               x.NIM ,x.ResultWord,y.AssessmentTitle
                            });
            //    var data = db.Assessments1.Find(id);
            var json = new { assessmentlist, transaction, ranking };

            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(json, new JsonSerializerSettings()
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
        }





    }
}
