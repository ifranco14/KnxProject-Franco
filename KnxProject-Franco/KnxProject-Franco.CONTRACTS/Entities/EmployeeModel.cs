using KnxProject_Franco.CONTRACTS.Entities.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class EmployeeModel : PersonModel
    {
        public EmployeeModel()
        {
            PersonType = PersonType.Employee;
        }
        public int IDEmployee { get; set; }
        [Required(ErrorMessage = "El campo '{0}' es necesario")]
        [StringLength(50)]
        [Display(Name = "Puesto")]
        public string Employment { get; set; }
        [Required(ErrorMessage = "El campo '{0}' es necesario")]
        [DataType(DataType.Date)]
        [CustomDA._DateOfBirth]
        [Display(Name = "Fecha de contrato")]
        public DateTime ContractDateE { get; set; }
    }
}