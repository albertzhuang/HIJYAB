//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Binus.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class ScoreSensories
    {
        public int ScoreSensoryID { get; set; }
        public int AssessmentSensoryID { get; set; }
        public int ScoreValue { get; set; }
        public string ScoreWord { get; set; }
    
        public virtual AssessmentSensories AssessmentSensory { get; set; }
    }
}
