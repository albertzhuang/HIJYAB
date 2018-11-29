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
using System.Data;
using System.Web.Security;

namespace Binus.Controllers.Api
{
    public class AssessmentTypeController : ApiController
    {
        BinusEntities db = new BinusEntities();

        [HttpGet]
        public IEnumerable<AssessmentType> getAll()
        {
            var result = (from a in db.AssessmentTypes1
                          select new AssessmentType { assessmentTypeID = a.AssessmentTypeID, assessmentType = a.AssessmentType }).ToList();
            return result;
        }

        
    }
}
