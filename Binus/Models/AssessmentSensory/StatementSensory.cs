using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models.AssessmentSensory
{
    public class StatementSensory
    {
        public int sensoryID { get; set; }
        public int statementSensoryID { get; set; }
        public string statementSensory { get; set; }
        public Sensory sensory { get; set; }
    }
}