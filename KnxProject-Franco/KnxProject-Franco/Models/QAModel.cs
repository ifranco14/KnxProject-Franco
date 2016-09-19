using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Models
{
    public class QAModel //Question&Answer
    {
        [Key]
        public int ID { get; set; }
        [Key]
        public int CourtCaseID { get; set; }
        [Key]
        public int CourtCaseDetailID { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Consulta")]
        public string Query { get; set; }
        [DataType(DataType.DateTime)]
        [ReadOnly(true)]
        [Display(Name ="Fecha")]
        public DateTime SendDate { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name ="Respuesta")]
        public string Answer { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Fecha")]
        public DateTime? AswerDate { get; set; }
    }
}