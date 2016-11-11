using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using KnxProject_Franco.CONTRACTS.Entities.DataAnnotations;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class PersonModel
    {
        [Key]
        public int IDPerson { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [EmailAddress]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email inválido.")]
        public string Email { get; set; }
        [Compare("Email",ErrorMessage ="Ambos mails ingresados deben ser iguales.")]
        [Display(Name ="Mail nuevamente")]
        public string CompareEmail { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [RegularExpression(@"\d{3,5}(?:-| )\d{6,8}", ErrorMessage = "Número inválido. Ejemplo: '3492 571726'.")]
        [Display(Name = "Teléfono celular")]
        public string CellPhoneNumber { get; set; }
        [Required(ErrorMessage = "{0} requerida.")]
        [CustomDA._DateOfBirth]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime DateOfBirth { get; set; }
        //[Required(ErrorMessage = "{0} requerido.")]
        [RegularExpression(@"\d{6,8}")]
        //[DataType(DataType.)]
        [Display(Name = "Número de documento")]
        public int DocumentNumber { get; set; }
        [Required(ErrorMessage = "{0} requerido.")]
        [Display(Name = "Tipo de documento")]
        public int IDDocumentType { get; set; }
        //public DocumentTypeModel DocumentType { get; set; }
        public string ImageName { get; set; }
        public HttpPostedFileBase Image { get; set; }
        public PersonType PersonType { get; set; }
        public static Type SelectFor(PersonType personType)
        {
            switch (personType)
            {
                case PersonType.Employee:
                    return typeof(EmployeeModel);
                case PersonType.Lawyer:
                    return typeof(LawyerModel);
                case PersonType.Client:
                    return typeof(ClientModel);
                default:
                    throw new Exception();
            }
        }

        //public int CourtBranchID { get; set; }
        //public int ProfessionalLicense { get; set; }
        //public DateTime ContractDate { get; set; }
        public string PersonType2 { get; set; }
    }
    public enum PersonType
    {
        Lawyer,
        Employee,
        Client
    }



}