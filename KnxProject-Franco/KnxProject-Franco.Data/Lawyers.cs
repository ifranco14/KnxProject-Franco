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
    
    public partial class Lawyers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lawyers()
        {
            this.CourtCases = new HashSet<CourtCases>();
            this.QAs = new HashSet<QAs>();
        }
    
        public int IDLawyer { get; set; }
        public int ProfessionalLicense { get; set; }
        public System.DateTime ContractDate { get; set; }
        public int CourtBranchId { get; set; }
    
        public virtual CourtBranches CourtBranches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CourtCases> CourtCases { get; set; }
        public virtual Persons Persons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QAs> QAs { get; set; }
    }
}