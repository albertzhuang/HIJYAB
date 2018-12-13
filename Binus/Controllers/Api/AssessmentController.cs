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
        public IEnumerable<ResultAssessment> getCurrentResultAssessment()
        {
            var studentNIM = HttpContext.Current.Session["student"] as string;
            var assessmentID = (int)HttpContext.Current.Session["assessmentID"];

            var result = (from resultAssessment in db.ResultAssessments1
                          where resultAssessment.AssessmentID == assessmentID &&
                          resultAssessment.NIM == studentNIM
                          select new ResultAssessment {
                              resultAssessmentID = resultAssessment.ResultAssessmentID,
                              assessmentID = resultAssessment.AssessmentID,
                              nim = resultAssessment.NIM,
                              resultWord = resultAssessment.ResultWord,
                              resultValue = resultAssessment.ResultValue
                          }).ToList();

            return result;
        }

        [HttpGet]
        public AssessmentType getCurrentAssessmentType()
        {
            var assessmentID = (int)HttpContext.Current.Session["assessmentID"];

            var result = (from assessment in db.Assessments1
                          join assessmentType in db.AssessmentTypes1 on assessment.AssessmentTypeID equals assessmentType.AssessmentTypeID
                          where assessment.AssessmentID == assessmentID
                          select new AssessmentType {
                            assessmentTypeID = assessmentType.AssessmentTypeID,  
                            assessmentType = assessmentType.AssessmentType
                          }).FirstOrDefault();

            return result;
        }

        [HttpPost]
        public HttpResponseMessage postAssessmentIntelligence(AssessmentIntelligence model)
        {
            var studentNIM = HttpContext.Current.Session["student"] as string;
            var assessmentID = (int)HttpContext.Current.Session["assessmentID"];
            foreach (var value in model.statementIntelligences)
            {
                ResultAssessments resultAssessment = new ResultAssessments();
                resultAssessment.NIM = studentNIM;
                resultAssessment.ResultWord = value.statementIntelligence;
                resultAssessment.ResultValue = value.countStatementIntelligence;
                resultAssessment.AssessmentID = assessmentID;

                db.ResultAssessments1.Add(resultAssessment);
                db.SaveChanges();
            }

            Transactions studentTransaction = (from transaction in db.Transactions1
                                        where transaction.NIM == studentNIM && transaction.AssessmentID == assessmentID
                                        select transaction).FirstOrDefault();
            studentTransaction.Status = "finish";
            db.SaveChanges();
            
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
        

        [HttpGet]
        public AssessmentIntelligence getCurrentAssessmentIntelligence(int assessmentID){
            var result = (from assessment in db.Assessments1
                          join assessmentIntelligence in db.AssessmentIntelligences1 on assessment.AssessmentID equals assessmentIntelligence.AssessmentID
                          where assessment.AssessmentID == assessmentID
                          select new AssessmentIntelligence
                          {
                              assessmentIntelligenceID = assessmentIntelligence.AssessmentIntelligenceID,
                              assessmentTitle = assessment.AssessmentTitle,
                              assessmentDescription = assessment.AssessmentDescription,
                              scoreIntelligences = (from scoreIntelligence in db.ScoreIntelligences1
                                                    where scoreIntelligence.AssessmentIntelligenceID == assessmentIntelligence.AssessmentIntelligenceID
                                                    select new ScoreIntelligence
                                                    {
                                                        scoreIntelligenceID = scoreIntelligence.ScoreIntelligenceID,
                                                        scoreValue = scoreIntelligence.ScoreValue,
                                                        scoreWord = scoreIntelligence.ScoreWord
                                                    }).ToList(),
                              statementIntelligences = (from statementIntelligence in db.StatementIntelligences1
                                                        where statementIntelligence.AssessmentIntelligenceID == assessmentIntelligence.AssessmentIntelligenceID
                                                        select new StatementIntelligence
                                                        {
                                                            statementIntelligenceID = statementIntelligence.StatementIntelligenceID,
                                                            statementIntelligence = statementIntelligence.StatementIntelligence,
                                                            statementDetailIntelligences = (from statementDetailIntelligence in db.StatementDetailIntelligences1
                                                                                            where statementDetailIntelligence.StatementIntelligenceID == statementIntelligence.StatementIntelligenceID
                                                                                            select new StatementDetailIntelligence
                                                                                            {
                                                                                                statementDetailIntelligenceID = statementDetailIntelligence.StatementDetailIntelligenceID,
                                                                                                statementDetailIntelligence =statementDetailIntelligence.StatementDetailIntelligence
                                                                                            }).ToList()
                                                         }).ToList()
                           }).FirstOrDefault();

            return result;
        }

        [HttpGet]
        public AssessmentSensory getCurrentAssessmentSensory(int assessmentID)
        {

            var result = (from assessment in db.Assessments1
                          join assessmentSensory in db.AssessmentSensories1 on assessment.AssessmentID equals assessmentSensory.AssessmentID
                          where assessment.AssessmentID == assessmentID
                          select new AssessmentSensory
                          {
                              assessmentTitle = assessment.AssessmentTitle,
                              assessmentDescription = assessment.AssessmentDescription,
                              statementSensories = (from statementSensory in db.StatementSensories1
                                                    where statementSensory.AssessmentSensoryID == assessmentSensory.AssessmentSensoryID
                                                    select new StatementSensory {
                                                        statementSensoryID = statementSensory.StatementSensoryID,
                                                        statementSensory = statementSensory.StatementSensory,
                                                        sensory = (from sensory in db.Sensories1
                                                                   where statementSensory.SensoryID == sensory.SensoryID
                                                                   select new Sensory {
                                                                       sensoryID = sensory.SensoryID,
                                                                       sensory = sensory.Sensory
                                                                   }).FirstOrDefault()
                                                    }).ToList(),
                              scoreSensories = (from scoreSensory in db.ScoreSensories1
                                                where scoreSensory.AssessmentSensoryID == assessmentSensory.AssessmentSensoryID
                                                select new ScoreSensory
                                                {
                                                    scoreValue = scoreSensory.ScoreValue,
                                                    scoreWord = scoreSensory.ScoreWord
                                             }).ToList(),
                              sensories = (from sensory in db.Sensories1
                                           join statementSensory in db.StatementSensories1 on sensory.SensoryID equals statementSensory.SensoryID
                                           join assessmentSensory in db.AssessmentSensories1 on statementSensory.AssessmentSensoryID equals assessmentSensory.AssessmentSensoryID
                                           where assessmentSensory.AssessmentID == assessmentID
                                           select new Sensory {
                                               sensoryID = sensory.SensoryID,
                                               sensory = sensory.Sensory
                                           }).ToList() 
                          }).FirstOrDefault();

            return result;
        }

        [HttpGet]
        public Assessment getCurrentAssessment()
        {
            int assessmentID = (int)HttpContext.Current.Session["assessmentID"];
 

            var result = (from assessment in db.Assessments1
                                     join assessmentType in db.AssessmentTypes1 on assessment.AssessmentTypeID equals assessmentType.AssessmentTypeID
                                      where assessment.AssessmentID == assessmentID
                                      select new Assessment
                                      {
                                          assessmentID = assessment.AssessmentID,
                                          assessmentTypeID = assessment.AssessmentTypeID,
                                          assessmentTitle = assessment.AssessmentTitle,
                                          assessmentDescription = assessment.AssessmentDescription,
                                          assessmentType = assessmentType.AssessmentType
                                      }).FirstOrDefault();

            return result;
        }

        [HttpGet]
        public AssessmentProcrasinator getCurrentAssessmentProcrasinator(int assessmentID)
        {
            var result = (from assessmentProcrasinator in db.AssessmentProcrasinators1
                          where assessmentProcrasinator.AssessmentID == assessmentID
                          select new AssessmentProcrasinator
                          {
                              statementProcrasinators = (from statementProcrasinator in db.StatementProcrasinators1
                                                         where statementProcrasinator.AssessmentProcrasinatorID == assessmentProcrasinator.AssessmentProcrasinatorID
                                                         select new StatementProcrasinator {
                                                             statementProcrasinator = statementProcrasinator.StatementProcrasinator
                                                         }).ToList(),
                              scoreProcrasinators = (from scoreProcrasinator in db.ScoreProcrasinators1
                                                     where scoreProcrasinator.AssessmentProcrasinatorID == assessmentProcrasinator.AssessmentProcrasinatorID
                                                     select new ScoreProcrasinator
                                                     {
                                                         startValue = scoreProcrasinator.StartValue,
                                                         endValue = scoreProcrasinator.EndValue,
                                                         scoreWord = scoreProcrasinator.ScoreWord
                                                     }).ToList(),
                              agreements = (from agreement in db.Agreements1
                                            where agreement.AssessmentProcrasinatorID == assessmentProcrasinator.AssessmentProcrasinatorID
                                            select new Agreement {
                                                agreement = agreement.Agreement
                                            }).ToList()
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
