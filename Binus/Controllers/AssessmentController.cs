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
        [Authorize(Roles ="admin")]
        public ActionResult ManageAll()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddAssessment()
        {
            return View();
        }

        [Authorize(Roles = "student")]
        public ActionResult Manage()
        {
            return View();
        }

        [Authorize(Roles = "student")]
        public ActionResult ShowAssessment()
        {
            return View();
        }

        [Authorize(Roles = "student")]
        public ActionResult ResultPage()
        {
            return View();
        }
    }
}