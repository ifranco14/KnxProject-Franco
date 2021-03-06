﻿using KnxProject_Franco.CONTRACTS.Entities.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class CourtCaseDetailModel
    {
        [Key]
        public int IDCourtCaseDetail { get; set; }
        public int IDCourtCase { get; set; }
        [Required(ErrorMessage = "{0} es necesario.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentario profesional")]
        public string Comment { get; set; }
        [Display(Name = "Consultas")]
        public List<QAModel> QA { get; set; }
        [Required(ErrorMessage = "{0} es necesaria.")]
        [DataType(DataType.Date)]
        [CustomDA._DateOfBirth]
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Debe colocarse un {0}.")]
        [Display(Name = "Estado")]
        //CourtCaseStatusModel
        public int IDState { get; set; }
    }
}