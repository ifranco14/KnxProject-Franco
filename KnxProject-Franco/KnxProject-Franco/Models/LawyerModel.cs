using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Models
{
    public class LawyerModel: PersonModel
    {
        [Key]
        public int ID { get; set; }
        //[Key]
        //public int PersonModelID { get; set; }
        [Required(ErrorMessage ="Debe ingresar su número de matrícula.")]
        [Display(Name ="Matrícula")]
        [Editable(true)]
        public int ProfessionalLicense { get; set; }        
        public List<CourtCaseModel> CourtCases  { get; set; }        
        public List<CourtBranchModel> CourtBranchs { get; set; }        
        public List<QAModel> Querys { get; set; }
        [Required(ErrorMessage ="Debe ingresar su fecha de contrato.")]
        [Display(Name ="Fecha de contrato")]
        [Editable(true)]
        public DateTime ContractDate { get; set; }
        //TODO: preguntar si las usamos asi
        [ScaffoldColumn(false)]
        public string UserName { get; set; }
        [ScaffoldColumn(false)]
        public string Password { get; set; }
    }
}