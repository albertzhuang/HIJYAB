using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace Binus.Models
{
    public class Assessment
    {
        public string title { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public Statement[] statements { get; set; }
    }
}