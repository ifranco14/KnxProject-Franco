﻿using System;
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
        public int ID { get; set; }
        public int PersonModelID { get; set; }
        [Display(Name = "Casos actuales")]
        public List<CourtCaseModel> CurrentCases { get; set; }
        [Required(ErrorMessage = "{0} es necesario.")]
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "{0} es necesaria.")]
        [DataType(DataType.Password)]
        //[Remote("CheckUserName", "Account")]
        [Display(Name = "Contraseña")]
        private string Password { get; set; }
    }
}