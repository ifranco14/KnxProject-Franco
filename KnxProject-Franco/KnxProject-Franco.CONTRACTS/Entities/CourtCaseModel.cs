﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KnxProject_Franco.CONTRACTS.Entities.DataAnnotations;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class CourtCaseModel
    {
        [Key]
        public int ID { get; set; }
        //TODO: viene de arriba?
        [Required]
        public int ClientID { get; set; }
        [Required(ErrorMessage = "{0} es necesario.")]
        [Display(Name = "Estado actual")]
        //CourtCaseStatusModel
        public int CurrentStatusId { get; set; }
        [Required(ErrorMessage = "{0} es necesaria.")]
        [Display(Name = "Rama del caso")]
        //CourtBranchModel
        public int CourtBranchId { get; set; }
        [Required(ErrorMessage = "{0} es necesario.")]
        [Display(Name = "Abogado a cargo")]
        //LawyerModel
        public int LawyerId { get; set; }
        [Required(ErrorMessage = "{0} es necesaria.")]
        [CustomDA._DateOfBirth]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de inicio")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Detalle de instancias alcanzadas")]
        public List<CourtCaseDetailModel> Details { get; set; }

    }
}