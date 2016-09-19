using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Models
{
    public class CourtBranchModel
    {
        [Key]
        public int ID { get; set; } 
        [Required]
        //[DataType(DataType.Text)]
        [StringLength(50)]
        [Display(Name = "Nombre de la rama")]
        public string Name { get; set; }
        [Required] 
        [Display(Name ="Abogados en la rama")]
        //how to show the lawyers to add in? CheckList with razor?
        public List<LawyerModel> LawyersIn { get; set; }
    }
}