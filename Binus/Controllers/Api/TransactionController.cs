using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using Binus.Data;
using Binus.Models;

namespace Binus.Controllers.Api
{
    [Authorize(Roles ="student")]
    public class TransactionController : ApiController
    {
        BinusEntities db = new BinusEntities();

        [Authorize(Roles = "student")]
        [HttpGet]
        public IEnumerable<Transaction> getUserTransaction()
        {
            var identity = (ClaimsIdentity)User.Identity;
           
            var result = (from transaction in db.Transactions1
                          join assessment in db.Assessments1 on transaction.AssessmentID equals assessment.AssessmentID
                          where transaction.Username == identity.Name
                          join assessmentType in db.AssessmentTypes1 on assessment.AssessmentTypeID equals assessmentType.AssessmentTypeID
                          select new Transaction
                          {
                              transactionID = transaction.TransactionID,
                              assessmentID = transaction.AssessmentID,
                              status = transaction.Status,
                              assessmentType = assessmentType.AssessmentType,
                              assessmentTitle = assessment.AssessmentTitle,
                              transactionDate = transaction.TransactionDate.ToString()  
                          }).ToList();

            return result;
        }
    }
}
