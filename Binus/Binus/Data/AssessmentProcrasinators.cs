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
    
    public partial class AssessmentProcrasinators
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AssessmentProcrasinators()
        {
            this.Agreements = new HashSet<Agreements>();
            this.ScoreProcrasinators = new HashSet<ScoreProcrasinators>();
            this.StatementProcrasinators = new HashSet<StatementProcrasinators>();
        }
    
        public int AssessmentProcrasinatorID { get; set; }
        public Nullable<int> AssessmentID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Agreements> Agreements { get; set; }
        public virtual Assessments Assessment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScoreProcrasinators> ScoreProcrasinators { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StatementProcrasinators> StatementProcrasinators { get; set; }
    }
}