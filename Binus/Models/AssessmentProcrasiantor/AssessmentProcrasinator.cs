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
        public int transactionID { get; set; }
        public int countScore { get; set; }
        public IEnumerable<StatementProcrasinator> statementProcrasinators { get; set; }
        public IEnumerable<ScoreProcrasinator> scoreProcrasinators { get; set; }
        public IEnumerable<Agreement> agreements { get; set; }
    }
}