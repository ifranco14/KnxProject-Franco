using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Web.Models
{
    public class CourtCaseStatusModel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Nombre del estado")]
        public string Name { get; set; }

    }
}
