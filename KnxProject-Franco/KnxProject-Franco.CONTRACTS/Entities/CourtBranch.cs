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
        public int ID { get; set; }
        [Required(ErrorMessage = "{0} es necesario.")]
        //[DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Nombre de la rama")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} son necesarios.")]
        [Display(Name = "Abogados en la rama")]
        //how to show the lawyers to add in? CheckList with razor?
        public List<int> LawyersInIDs { get; set; }
        [Required(ErrorMessage = "{0} es requerida.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        public string Description { get; set; }
    }
}