using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Binus.Models
{
    public class AssessmentIntelligence
    {
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public StatementIntelligence[] statements { get; set; }
        public ScoreIntelligence[] scores { get; set; }
    }
}