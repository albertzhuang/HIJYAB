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
    
    public partial class Assessments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Assessments()
        {
            this.AssessmentIntelligences = new HashSet<AssessmentIntelligences>();
            this.AssessmentProcrasinators = new HashSet<AssessmentProcrasinators>();
            this.AssessmentSensories = new HashSet<AssessmentSensories>();
            this.ResultAssessments = new HashSet<ResultAssessments>();
            this.Transactions = new HashSet<Transaction>();
        }
    
        public int AssessmentID { get; set; }
        public int AssessmentTypeID { get; set; }
        public string AssessmentTitle { get; set; }
        public string AssessmentDescription { get; set; }
        public System.DateTime LastUpdate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentIntelligences> AssessmentIntelligences { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentProcrasinators> AssessmentProcrasinators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssessmentSensories> AssessmentSensories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ResultAssessments> ResultAssessments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual AssessmentTypes AssessmentType { get; set; }
    }
}