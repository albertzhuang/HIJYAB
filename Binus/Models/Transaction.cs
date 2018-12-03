using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models
{
    public class Transaction
    {
        public int transactionID { get; set; }
        public int assessmentID { get; set; }
        public string nim { get; set; }
        public string status { get; set; }
        public string assessmentType { get; set; }
        public string assessmentTitle { get; set; }
        public string transactionDate { get; set; }
    }
}