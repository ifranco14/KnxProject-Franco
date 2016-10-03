using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KnxProject_Franco.Web.Models
{
    public class DocumentTypeModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Es necesario un tipo de documento.")]
        [StringLength(160)]
        [Display(Name ="Tipo de documento")]
        public string DocumentType { get; set; }
    }
}