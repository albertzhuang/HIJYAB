using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models.AssessmentProcrasiantor
{
    public class AssessmentProcrasinator
    {
        public string assessmentTitle { get; set; }
        public string assessmentDescription { get; set; }
        public string assessmentType { get; set; }
        public StatementProcrasinator[] statementProcrasinators { get; set; }
        public ScoreProcrasinator[] scoreProcrasinators { get; set; }
        public Agreement[] agreements { get; set; }
    }
}