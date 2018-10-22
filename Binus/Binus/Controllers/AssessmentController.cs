using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binus.Controllers
{
    public class AssessmentController : Controller
    {
        // GET: Assessment
        public ActionResult Index()
        {
            return View();
        }

    

        public ActionResult ViewListAssessment()
        {
            return View();
        }

        public ActionResult ViewIntelligenceAssessment()
        {
            return View();
        }

        public ActionResult ResultAssessment()
        {
            return View();
        }

    }
}