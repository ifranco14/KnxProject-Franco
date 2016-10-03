using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KnxProject_Franco.Web.Models.DataAnnotations;

namespace KnxProject_Franco.Web.Models
{
    public abstract class PersonModel
    {
        [Key]
        public int PersonID { get; set; }
        [Required(ErrorMessage ="{0} requerido.")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        [Compare("Email")]
        public string CompareEmail { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [RegularExpression(@"\d{3,5}(?:-| )\d{6,8}", ErrorMessage ="Número inválido. Ejemplo: '3492 571726'.")]
        [Display(Name ="Teléfono celular")]
        public string CellPhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} requerida.")]
        [CustomDA._BirthOfDate]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime DateOfBirth { get; set; }
        //[Required(ErrorMessage = "{0} requerido.")]
        [RegularExpression(@"\d{6,8}")]
        //[DataType(DataType.)]
        [Display(Name ="Número de documento")]
        public int DocumentNumber { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [Display(Name ="Tipo de documento")]
        public DocumentTypeModel DocumentType { get; set; }
    }
}