//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KnxProject_Franco.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourtCases
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CourtCases()
        {
            this.CourtCaseDetails = new HashSet<CourtCaseDetails>();
        }
    
        public int ID { get; set; }
        public Nullable<int> CurrentStatusId { get; set; }
        public int CourtBranchId { get; set; }
        public int LawyerId { get; set; }
        public System.DateTime Date { get; set; }
        public int ClientId { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual CourtBranches CourtBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourtCaseDetails> CourtCaseDetails { get; set; }
        public virtual Lawyers Lawyers { get; set; }
        public virtual States States { get; set; }
    }
}