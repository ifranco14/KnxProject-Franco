﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Models
{
    public class CourtCaseDetailModel
    {
        [Key]
        public int ID { get; set; }
        [Key]
        public int CourtCaseID { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name ="Comentario profesional")]
        public string Comment { get; set; }
        [Display(Name ="Consultas")]
        public List<QAModel> QA { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name ="Fecha")]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name ="Estado")]
        public CourtCaseStatusModel Status { get; set; }
    }
}