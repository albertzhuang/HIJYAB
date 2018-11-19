using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models
{
    public class ResultAssessment
    {
        public int assessmentid { get; set; }
        public string binusian_id { get; set; }
        public String[] result { get; set; }
        public string description { get; set; }

    }
}