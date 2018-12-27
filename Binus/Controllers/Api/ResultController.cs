using Binus.Data;
using Binus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace Binus.Controllers.Api
{
    public class ResultController : ApiController
    {
        BinusEntities db = new BinusEntities();

        [Authorize(Roles = "student")]
        [HttpGet]
        public IEnumerable<ResultAssessment> getCurrentResultAssessment(int id)
        {
            var identity = (ClaimsIdentity)User.Identity;
            
            var result = (from resultAssessment in db.ResultAssessments1 
                          join transaction in db.Transactions1 on resultAssessment.TransactionID equals transaction.TransactionID
                          where resultAssessment.TransactionID == id &&
                          transaction.Username == identity.Name
                          select new ResultAssessment
                          {
                              resultAssessmentID = resultAssessment.ResultAssessmentID,
                              transactionID = resultAssessment.TransactionID,
                              fullname = transaction.Username,
                              resultWord = resultAssessment.ResultWord,
                              resultValue = resultAssessment.ResultValue
                          }).ToList();

            return result;
        }
    }
}
