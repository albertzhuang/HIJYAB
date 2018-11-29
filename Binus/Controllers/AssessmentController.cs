using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binus.Controllers
{
    [Authorize]
    public class AssessmentController : Controller
    {
        public ActionResult AddAssessment()
        {
            return View();
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult ShowAssessment()
        {
            return View();
        }

        public ActionResult ResultPage()
        {
            return View();
        }

    }
}