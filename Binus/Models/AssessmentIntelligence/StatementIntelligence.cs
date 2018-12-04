using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Binus.Models.AssessmentIntelligence
{
    public class StatementIntelligence
    {
        public int statementIntelligenceID { get; set; }
        public string statementIntelligence { get; set; }
        public StatementDetailIntelligence[] statementDetailIntelligences { get; set; }
    }
}