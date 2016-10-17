﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class QAModel //Question&Answer
    {
        [Key]
        public int IDQA { get; set; }
        public int IDCourtCase { get; set; }
        public int IDCourtCaseDetail { get; set; }
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