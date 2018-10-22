using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace Binus.Models
{
    public class Statement
    {
        public string statement { get; set; }
        public StatementDetail[] statementDetails { get; set; }
    }
}