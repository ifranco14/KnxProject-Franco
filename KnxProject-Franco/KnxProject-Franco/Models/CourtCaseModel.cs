using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace KnxProject_Franco.Models
{
    public class CourtCaseModel
    {
        [Key]
        public int ID { get; set; }
        [Key]
        public int ClientID { get; set; }
        [Required]
        [Display(Name ="Estado actual")]
        public CourtCaseStatusModel CurrentStatus { get; set; }
        [Required]
        [Display(Name ="Rama del caso")]
        public CourtBranchModel CourtBranch { get; set; }
        [Required]
        [Display(Name ="Abogado a cargo")]
        public LawyerModel Lawyer { get; set; } 
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name ="Fecha de inicio")]
        public DateTime StartDate { get; set; }
        [Display(Name ="Detalle de instancias alcanzadas")]
        public List<CourtCaseDetailModel> Details { get; set; }
    }
}