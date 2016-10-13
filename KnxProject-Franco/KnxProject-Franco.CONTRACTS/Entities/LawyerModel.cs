using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class LawyerModel : PersonModel
    {

        public int IDLawyer { get; set; }
        public int PersonModelID { get; set; }
        [Required(ErrorMessage = "Debe ingresar su número de matrícula.")]
        [Display(Name = "Matrícula")]
        [Editable(true)]
        public int ProfessionalLicense { get; set; }
        public List<CourtCaseModel> CourtCases { get; set; }
        public List<CourtBranchModel> CourtBranchs { get; set; }
        public List<QAModel> Querys { get; set; }
        [Required(ErrorMessage = "Debe ingresar su fecha de contrato.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de contrato")]
        public DateTime ContractDate { get; set; }
    }
}