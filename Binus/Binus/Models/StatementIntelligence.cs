using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace Binus.Models
{
    public class StatementIntelligence
    {
        public string statement { get; set; }
        public StatementDetailIntelligence[] statementDetails { get; set; }
    }
}