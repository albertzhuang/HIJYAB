using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Binus.Controllers.Filter;

namespace Binus.Controllers
{
    [Authorize]
    public class AssessmentController : Controller
    {
        [AuthorizeAdmin]
        public ActionResult AddAssessment()
        {
            return View();
        }

        [AuthorizeStudent]
        public ActionResult Manage()
        {
            return View();
        }

        [AuthorizeStudent]
        public ActionResult ShowAssessment()
        {
            return View();
        }
        
        [AuthorizeStudent]
        public ActionResult ResultPage()
        {
            return View();
        }

    }
}