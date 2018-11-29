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

namespace Binus.Controllers.Api
{
    [Authorize]
    public class AssessmentController : ApiController
    {

        BinusEntities db = new BinusEntities();
        
        [HttpGet]
        public string getCurrentAssessment(int assessmentId)
        {
            return User.Identity.Name;

        }

        [HttpGet]
        public IEnumerable<Assessment> getAllAssessment()
        {
            var result = (from assessment in db.Assessments1
                          join assessmentType in db.AssessmentTypes1 on assessment.AssessmentTypeID equals assessmentType.AssessmentTypeID
                          select new Assessment {
                              assessmentID = assessment.AssessmentID,
                              assessmentType = assessmentType.AssessmentType,
                              assessmentTitle = assessment.AssessmentTitle,
                              assessmentDescription = assessment.AssessmentDescription,
                              lastUpdate = assessment.LastUpdate.ToString()
                          }).ToList();
            return result;
        }

        [HttpGet]
        public HttpResponseMessage getAll()
        {
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
        }

        

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
        public HttpResponseMessage getLastSensory()
        {

            int fk_sensoryID = int.Parse(db.Sensories1
                    .OrderByDescending(x => x.SensoryID)
                    .Select(x => x.SensoryID).First().ToString());

            try
            {
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(JsonConvert.SerializeObject(fk_sensoryID));
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



        [HttpPost]
        public HttpResponseMessage createAssessmentIntelligence(AssessmentIntelligence model)
        {
            Assessments assessment = new Assessments();
            assessment.AssessmentTypeID = 1;
            assessment.AssessmentTitle = model.assessmentTitle;
            assessment.AssessmentDescription = model.assessmentDescription;
            assessment.LastUpdate = DateTime.Now;
            
            db.Assessments1.Add(assessment);
            db.SaveChanges();


            int fk_assessmentID = int.Parse(db.Assessments1
                    .OrderByDescending(x => x.AssessmentID)
                    .Select(x => x.AssessmentID).First().ToString());

            AssessmentIntelligences assessmentIntelligence = new AssessmentIntelligences();
            assessmentIntelligence.AssessmentID = fk_assessmentID;

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
        public HttpResponseMessage createAssessmentSensory(AssessmentSensory model)
        {
            Assessments assessment = new Assessments();
            assessment.AssessmentTypeID = 2;
            assessment.AssessmentTitle = model.assessmentTitle;
            assessment.AssessmentDescription = model.assessmentDescription;
            assessment.LastUpdate = DateTime.Now;

            db.Assessments1.Add(assessment);
            db.SaveChanges();

            int fk_assessmentID = int.Parse(db.Assessments1
                    .OrderByDescending(x => x.AssessmentID)
                    .Select(x => x.AssessmentID).First().ToString());

            AssessmentSensories assessmentSensory = new AssessmentSensories();
            assessmentSensory.AssessmentID = fk_assessmentID;

            db.AssessmentSensories1.Add(assessmentSensory);
            db.SaveChanges();

            int fk_assessmentSensoryID = int.Parse(db.AssessmentSensories1
                    .OrderByDescending(x => x.AssessmentSensoryID)
                    .Select(x => x.AssessmentSensoryID).First().ToString());


            foreach (var value in model.scoreSensories)
            {
                ScoreSensories scoreSensory = new ScoreSensories();
                scoreSensory.AssessmentSensoryID = fk_assessmentSensoryID;
                scoreSensory.ScoreValue = value.scoreValue;
                scoreSensory.ScoreWord = value.scoreWord;

                db.ScoreSensories1.Add(scoreSensory);
                db.SaveChanges();
            }

            foreach(var value in model.sensories)
            {
                Sensories sensory = new Sensories();
                sensory.Sensory = value.sensory;

                db.Sensories1.Add(sensory);
                db.SaveChanges();
            }

            foreach(var value in model.statementSensories)
            {
                StatementSensories statementSensory = new StatementSensories();
                statementSensory.AssessmentSensoryID = fk_assessmentSensoryID;
                statementSensory.StatementSensory = value.statementSensory;
                statementSensory.SensoryID = value.sensoryID;

                db.StatementSensories1.Add(statementSensory);
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
            Assessments assessment = new Assessments();
            assessment.AssessmentTypeID = 3;
            assessment.AssessmentTitle = model.assessmentTitle;
            assessment.AssessmentDescription = model.assessmentDescription;
            assessment.LastUpdate = DateTime.Now;

            db.Assessments1.Add(assessment);
            db.SaveChanges();

            int fk_assessmentID = int.Parse(db.Assessments1
                    .OrderByDescending(x => x.AssessmentID)
                    .Select(x => x.AssessmentID).First().ToString());

            AssessmentProcrasinators assessmentProcrasinator = new AssessmentProcrasinators();
            assessmentProcrasinator.AssessmentID = fk_assessmentID;

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
        }

        /*[HttpPost]
        public HttpResponseMessage saveResult(ResultAssessment rt)
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
        }*/

        /*[HttpGet]
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
        }*/
    }
}
