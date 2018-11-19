using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models.AssessmentSensory
{
    public class AssessmentSensory
    {
        public string assessmentTitle { get; set; }
        public string assessmentDescription { get; set; }
        public StatementSensory[] statementSensories { get; set; }
        public ScoreSensory[] scoreSensories { get; set; }
    }
}