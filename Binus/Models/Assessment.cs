using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models
{
    public class Assessment
    {
        public int assessmentID { get; set; }
        public int assessmentTypeID { get; set; }
        public int transactionID { get; set; }
        public string assessmentTitle { get; set; }
        public string assessmentDescription { get; set; }
        public string assessmentType { get; set; }
        public string lastUpdate { get; set; }
    }
}