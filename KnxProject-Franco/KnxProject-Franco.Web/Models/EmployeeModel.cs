using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Web.Models
{
    public class EmployeeModel: PersonModel
    {
        public int ID { get; set; }
        public int PersonModelID { get; set; }
        [Required(ErrorMessage ="El campo '{0}' es necesario")]
        [StringLength(50)]
        [Display(Name ="Puesto")]
        public string Employment { get; set; }
        [Required(ErrorMessage = "El campo '{0}' es necesario")]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de contrato")]
        public DateTime ContractDate { get; set; }
    }
}