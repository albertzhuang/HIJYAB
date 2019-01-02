using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Binus.Models.AssessmentIntelligence
{
    public class AssessmentIntelligence
    {
        public int assessmentIntelligenceID { get; set; }
        public int assessmentID { get; set; }
        public int transactionID { get; set; }
        public string assessmentTitle { get; set; }
        public string assessmentDescription { get; set; }
        public string assessmentType { get; set; }
        public IEnumerable<StatementIntelligence> statementIntelligences { get; set; }
        public IEnumerable<ScoreIntelligence> scoreIntelligences { get; set; }
    }
}