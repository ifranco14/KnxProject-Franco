using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class AboutModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="El campo {0} es requerido.")]
        [Display(Name ="Misión del estudio")]
        [DataType(DataType.MultilineText)]
        public string Mission { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Visión del estudio")]
        [DataType(DataType.MultilineText)]
        public string Vision { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Dirección del estudio")]
        public string Address { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Ciudad del estudio")]
        public string City { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Teléfono del estudio")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Descripción del estudio")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Funciones del estudio")]
        [DataType(DataType.MultilineText)]
        public string Functions { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Display(Name = "Historia del estudio")]
        [DataType(DataType.MultilineText)]
        public string History { get; set; }
    }
}
