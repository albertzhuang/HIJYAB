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

namespace Binus.Controllers.Api
{
    public class AssessmentController : ApiController
    {
        BinusEntities db = new BinusEntities();
        
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

        /*[HttpPost]
        public HttpResponseMessage createAssessmentIntelligence(AssessmentIntelligence model)
        {
            AssessmentIntelligences assessmentIntelligence = new AssessmentIntelligences();
            assessmentIntelligence.AssessmentTitle = model.assessmentTitle;
            assessmentIntelligence.AssessmentDescription = model.assessmentDescription;
            db.AssessmentIntelligences1.Add(assessmentIntelligence);
            db.SaveChanges();
            int fk_assessmentIntelligenceID = int.Parse(db.AssessmentIntelligences1
                .OrderByDescending(x => x.AssessmentIntelligenceID)
                .Select(x => x.AssessmentIntelligenceID).First().ToString());


            foreach(var value in model.statementIntelligences)
            {
                StatementIntelligences statementIntelligence = new StatementIntelligences();
                statementIntelligence.AssessmentIntelligenceID = fk_assessmentIntelligenceID;
                statementIntelligence.StatementIntelligence = value.statementIntelligence;

                db.StatementIntelligences1.Add(statementIntelligence);
                db.SaveChanges();

                int fk_statementIntelligenceID = int.Parse(db.StatementIntelligences1
                    .OrderByDescending(x => x.StatementIntelligenceID)
                    .Select(x => x.StatementIntelligenceID).First().ToString());

                foreach (var valueDetail in value.statementDetailIntelligences)
                {
                    StatementDetailIntelligences statementDetailIntelligence = new StatementDetailIntelligences();
                    statementDetailIntelligence.StatementIntelligenceID = fk_statementIntelligenceID;
                    statementDetailIntelligence.StatementDetailIntelligence = valueDetail.statementDetailIntelligence;
                    db.StatementDetailIntelligences1.Add(statementDetailIntelligence);
                    db.SaveChanges();
                }
            }

            foreach (var value in model.scoreIntelligences)
            {
                ScoreIntelligences scoreIntelligence = new ScoreIntelligences();
                scoreIntelligence.AssessmentIntelligenceID = fk_assessmentIntelligenceID;
                scoreIntelligence.ScoreValue = value.scoreValue;
                scoreIntelligence.ScoreWord = value.scoreWord;
                db.ScoreIntelligences1.Add(scoreIntelligence);
                db.SaveChanges();
            }

            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.Accepted);
                result.Content = new StringContent(JsonConvert.SerializeObject(model));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError); 
            }
        }

        [HttpPost]
        public HttpResponseMessage createAssessmentProcrasinator(AssessmentProcrasinator model)
        {
            AssessmentProcrasinators assessmentProcrasinator = new AssessmentProcrasinators();
            assessmentProcrasinator.AssessmentTitle = model.assessmentTitle;
            assessmentProcrasinator.AssessmentDescription = model.assessmentDescription;

            db.AssessmentProcrasinators1.Add(assessmentProcrasinator);
            db.SaveChanges();
            int fk_assessmentProcrasinatorID = int.Parse(db.AssessmentProcrasinators1
                .OrderByDescending(x => x.AssessmentProcrasinatorID)
                .Select(x => x.AssessmentProcrasinatorID).First().ToString());

            foreach(var value in model.agreements)
            {
                Agreements agreement = new Agreements();
                agreement.Agreement = value.agreement;
                agreement.AssessmentProcrasinatorID = fk_assessmentProcrasinatorID;

                db.Agreements1.Add(agreement);
                db.SaveChanges();
            }

            foreach(var value in model.statementProcrasinators)
            {
                StatementProcrasinators statementProcrasinator = new StatementProcrasinators();
                statementProcrasinator.AssessmentProcrasinatorID = fk_assessmentProcrasinatorID;
                statementProcrasinator.StatementProcrasinator = value.statementProcrasinator;

                db.StatementProcrasinators1.Add(statementProcrasinator);
                db.SaveChanges();
            }

            foreach(var value in model.scoreProcrasinators)
            {
                ScoreProcrasinators scoreProcrasinator = new ScoreProcrasinators();
                scoreProcrasinator.AssessmentProcrasinatorID = fk_assessmentProcrasinatorID;
                scoreProcrasinator.ScoreWord = value.scoreWord;
                scoreProcrasinator.StartValue = value.startValue;
                scoreProcrasinator.EndValue = value.endValue;

                db.ScoreProcrasinators1.Add(scoreProcrasinator);
                db.SaveChanges();
            }

            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.Accepted);
                result.Content = new StringContent(JsonConvert.SerializeObject(model));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }*/

        [HttpGet]
        public HttpResponseMessage getAllAssessmentList()
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.Assessments1.ToList(), new JsonSerializerSettings()
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


        [HttpGet]
        public HttpResponseMessage getDetailAssessment(int id = 0)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.Assessments1.Find(id), new JsonSerializerSettings()
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




        [HttpGet]
        public HttpResponseMessage getAssessmentSensory(int id = 0)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.AssessmentSensories1.Find(id), new JsonSerializerSettings()
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



        [HttpGet]
        public HttpResponseMessage getAssessmentProcrastinator(int id = 0)
        {
            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(db.AssessmentProcrasinators1.Find(id), new JsonSerializerSettings()
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




        /*[HttpPost]
        public HttpResponseMessage post(Models.AssessmentIntelligence assessment)
        {

            Assessments ms_assessment = new Assessments();
            ms_assessment.AssessmentTitle = assessment.title;
            ms_assessment.AssessmentDescription = assessment.description;
            ms_assessment.AssessmentTypeID = int.Parse(assessment.type);
            ms_assessment.LastUpdate = DateTime.Now;
            db.Assessments1.Add(ms_assessment);
            db.SaveChanges();

            int fk_assessmentID = int.Parse(db.Assessments1.OrderByDescending(x => x.AssessmentID).Select(x => x.AssessmentID).First().ToString());
            AssessmentIntelligences assessmentIntelligence = new AssessmentIntelligences();
            assessmentIntelligence.AssessmentID = fk_assessmentID;
            db.AssessmentIntelligences1.Add(assessmentIntelligence);
            db.SaveChanges();

            int fk_assessmentIntelligenceID = int.Parse(db.AssessmentIntelligences1.OrderByDescending(x => x.AssessmentIntelligenceID).Select(x => x.AssessmentIntelligenceID).First().ToString());


            foreach (var value in assessment.statements)
            {
                StatementIntelligences statement = new StatementIntelligences();
                statement.AssessmentIntelligenceID = fk_assessmentIntelligenceID;
                statement.StatementIntelligence = value.statement;
                db.StatementIntelligences1.Add(statement);
                db.SaveChanges();

                int fk_statementIntelligenceID = int.Parse(db.StatementIntelligences1.OrderByDescending(x => x.StatementIntelligenceID).Select(x => x.StatementIntelligenceID).First().ToString());
                foreach (var valueDetail in value.statementDetails)
                {
                    StatementDetailIntelligences statementDetail = new StatementDetailIntelligences();
                    statementDetail.StatementIntelligenceID = fk_statementIntelligenceID;
                    statementDetail.StatementDetail = valueDetail.statementDetail;
                    db.StatementDetailIntelligences1.Add(statementDetail);
                    db.SaveChanges();
                }
            }

            foreach (var value in assessment.scores)
            {
                ScoreIntelligences score = new ScoreIntelligences();
                score.AssessmentIntelligenceID = fk_assessmentIntelligenceID;
                score.ScoreValue = value.scoreValue;
                score.ScoreWord = value.scoreWord;
                db.ScoreIntelligences1.Add(score);
                db.SaveChanges();
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
        }*/



        [HttpPost]
        public HttpResponseMessage saveResult(Models.ResultAssessment rt)
        {
            foreach (var value in rt.result)
            {
                string[] words = value.TrimStart('(').Split('(');
                int indexOutOfRange = 2;
                ResultAssessments rts = new ResultAssessments();
                rts.AssessmentID = rt.assessmentid;
                rts.Institution = "dummy";
                rts.AcademikCareer = "dummy";
                rts.Campus = "dummy";
                rts.AcademicGroup = "dummy";
                rts.AcademicOrganization = "dummy";
                rts.AcademicProgram = "dummy";
                rts.AcademicYear = "dummy";
                rts.Status = "dummy";
                rts.BinusianID = rt.binusian_id;

                // masalah juga di view result page
                if (words.Length < indexOutOfRange)
                {
                    rts.Result = words[0];
                    rts.Describe = "-";
                }
                else
                {
                    rts.Result = words[0];
                    rts.Describe = "(" + words[1];
                }




                db.ResultAssessments1.Add(rts);
                db.SaveChanges();
            }




            //     int pk_ResultAssessments = int.Parse(db.ResultAssessments1.OrderByDescending(x => x.ResultAssessmentID).Select(x => x.ResultAssessmentID).First().ToString());


            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.Accepted);
                result.Content = new StringContent(JsonConvert.SerializeObject(rt));
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }






        [HttpGet]
        public HttpResponseMessage getResultAssessment(int id = 0)
        {
            var binusianid = "bn190151515";
            var query = from a in db.ResultAssessments1
                        where a.BinusianID == binusianid && a.AssessmentID == id
                        select a;



            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(query, new JsonSerializerSettings()
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
