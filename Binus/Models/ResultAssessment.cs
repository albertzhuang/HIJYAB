﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models
{
    public class ResultAssessment
    {
        public int resultAssessmentID { get; set; }
        public int transactionID { get; set; }
        public string fullname { get; set; }
        public string resultWord { get; set; }
        public int resultValue { get; set; }
    }
}