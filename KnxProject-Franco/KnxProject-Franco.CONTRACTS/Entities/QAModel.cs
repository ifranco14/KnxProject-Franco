using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    /// <summary>
    /// IDCourtCase & IDCourtCaseDetails are null when the query is from an anonymus person
    /// Anser & AnserDate are nulls while the query isn't answered
    /// </summary>
    public class QAModel //Question&Answer
    {
        [Key]
        public int IDQA { get; set; }
        public int? IDCourtCase { get; set; }
        public int? IDCourtCaseDetail { get; set; }
        public int IDLawyer { get; set; }
        [Display(Name ="Nombre")]
        public string Name { get; set; }
        [Display(Name = "Email para respuesta")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Debe dejar una consulta.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Consulta")]
        public string Query { get; set; }
        [DataType(DataType.DateTime)]
        [ReadOnly(true)]
        [Display(Name = "Fecha")]
        public DateTime SendDate { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Respuesta")]
        public string Answer { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha")]
        public DateTime? AswerDate { get; set; }

    }
}