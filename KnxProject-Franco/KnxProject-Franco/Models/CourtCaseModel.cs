using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnxProject_Franco.Models
{
    public class CourtCaseModel
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }
        //[Key]
        //[Column(Order = 1)] 
        public int ClientID { get; set; }
        [Required(ErrorMessage ="{0} es necesario.")]
        [Display(Name ="Estado actual")]
        public CourtCaseStatusModel CurrentStatus { get; set; }
        [Required(ErrorMessage = "{0} es necesaria.")]
        [Display(Name ="Rama del caso")]
        public CourtBranchModel CourtBranch { get; set; }
        [Required(ErrorMessage = "{0} es necesario.")]
        [Display(Name ="Abogado a cargo")]
        public LawyerModel Lawyer { get; set; }
        [Required(ErrorMessage = "{0} es necesaria.")]
        [DataType(DataType.DateTime)]
        [Display(Name ="Fecha de inicio")]
        public DateTime StartDate { get; set; }
        //[Display(Name ="Detalle de instancias alcanzadas")]
        //public List<CourtCaseDetailModel> Details { get; set; }
        
    }
}