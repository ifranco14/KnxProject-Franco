using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class CourtBranchModel
    {
        [Key]
        public int IDCourtBranch { get; set; }
        [Required(ErrorMessage = "{0} es necesario.")]
        //[DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Nombre de la rama")]
        public string Name { get; set; }
        //[Display(Name = "Abogados en la rama")]
        //public List<LawyerModel> Lawyers { get; set; }
        [Required(ErrorMessage = "{0} es requerida.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}