using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class ClientModel : PersonModel
    {
        public ClientModel()
        {
            PersonType = PersonType.Client;
        }
        public int IDClient { get; set; }
        [Display(Name = "Casos actuales")]
        public List<CourtCaseModel> CurrentCases { get; set; }
        public bool? Active { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}