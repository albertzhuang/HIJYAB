using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Binus.Controllers
{
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

        public ActionResult Index()
        {
            return View();
        }
        

        public ActionResult ShowAssessment(int id = 0)
        {

            return View();
        }

        public ActionResult ResultPage()
        {
            return View();
        }
    }
}