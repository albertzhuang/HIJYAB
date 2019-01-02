using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Binus.Models.AssessmentSensory
{
    public class AssessmentSensory
    {
        public string assessmentTitle { get; set; }
        public string assessmentDescription { get; set; }
        public int transactionID { get; set; }
        public int assessmentID { get; set; }
        public IEnumerable<StatementSensory> statementSensories { get; set; }
        public IEnumerable<ScoreSensory> scoreSensories { get; set; }
        public IEnumerable<Sensory> sensories { get; set; }
    }
}