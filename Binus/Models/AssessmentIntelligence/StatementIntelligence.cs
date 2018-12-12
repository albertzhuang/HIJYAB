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
        public int countStatementIntelligence { get; set; }
        public string statementIntelligence { get; set; }
        public IEnumerable<StatementDetailIntelligence> statementDetailIntelligences { get; set; }
    }
}