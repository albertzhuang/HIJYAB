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
using Binus.Controllers.Filter;
using System.Web;

namespace Binus.Controllers.Api
{
                         
    public class AssessmentController : ApiController
    {
        BinusEntities db = new BinusEntities();
        
        [HttpGet]
        public string getTest()
        {
            return HttpContext.Current.Session["admin"] as string;
        }

        [HttpPost]
        public HttpResponseMessage createCurrentAssessment(Assessment model)
        {
            HttpContext.Current.Session["assessmentID"] = model.assessmentID;
          
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpGet]
        public Assessment getCurrentAssessment()
        {
            int assessmentID = (int)HttpContext.Current.Session["assessmentID"];
            HttpContext.Current.Session.Remove("assessmentID");

            var result = (from assessment in db.Assessments1
                                     join assessmentType in db.AssessmentTypes1 on assessment.AssessmentTypeID equals assessmentType.AssessmentTypeID
                                      where assessment.AssessmentID == assessmentID
                                      select new Assessment
                                      {
                                          assessmentID = assessment.AssessmentID,
                                          assessmentTitle = assessment.AssessmentTitle,
                                          assessmentDescription = assessment.AssessmentDescription,
                                          assessmentType = assessmentType.AssessmentType
                                      }).FirstOrDefault();

            

            return result;
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

   
    }
}
