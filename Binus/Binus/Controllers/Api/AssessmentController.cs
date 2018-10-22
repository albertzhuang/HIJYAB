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
                result.Content = new StringContent(JsonConvert.SerializeObject(db.AssessmentTypes1.ToList()));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public HttpResponseMessage getAllAssessment()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.AssessmentTypes1.ToList()));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public HttpResponseMessage post(Assessment assessment)
        {
            Assessment_1 assessment_1 = new Assessment_1();
            assessment_1.Title = assessment.title;
            assessment_1.Description = assessment.description;
            db.Assessment_1.Add(assessment_1);
            db.SaveChanges();

            int fk_assessmentID = int.Parse(db.Assessment_1.OrderByDescending(x => x.AssessmentID).Select(x => x.AssessmentID).First().ToString());
            
            foreach(var value in assessment.statements)
            {
                Statements statement = new Statements();
                statement.AssessmentID = fk_assessmentID;
                statement.Statement = value.statement;
                db.Statements1.Add(statement);
                db.SaveChanges();

                int fk_statementID = int.Parse(db.Statements1.OrderByDescending(x => x.StatementID).Select(x => x.StatementID).First().ToString());
                foreach (var valueDetail in value.statementDetails)
                {
                    StatementDetails statementDetail = new StatementDetails();
                    statementDetail.StatementID = fk_statementID;
                    statementDetail.StatementDetail = valueDetail.statementDetail;
                    db.StatementDetails1.Add(statementDetail);
                    db.SaveChanges();
                }
            }

            try
            {
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
