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
    
    public partial class QAs
    {
        public int ID { get; set; }
        public int CourtCaseDetailID { get; set; }
        public string Query { get; set; }
        public System.DateTime SendDate { get; set; }
        public string Answer { get; set; }
        public Nullable<System.DateTime> AnswerDate { get; set; }
        public int LawyerId { get; set; }
    
        public virtual CourtCaseDetails CourtCaseDetails { get; set; }
        public virtual Lawyers Lawyers { get; set; }
    }
}