using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnxProject_Franco.Models
{
    public class ClientModel: PersonModel
    {
        public int ID { get; set; }
        public int PersonModelID { get; set; }
        [Display(Name ="Casos actuales")]
        public List<CourtCaseModel> CurrentCases { get; set; }
        [Required(ErrorMessage ="{0} es necesario.")]
        [Display(Name ="Nombre de usuario")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="{0} es necesaria.")]
        [DataType(DataType.Password)]
        //[Remote("CheckUserName", "Account")]
        [Display(Name ="Contraseña")]
        private string Password { get; set; }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;

//namespace KnxProject_Franco.Models
//{
//    public class myContext : DbContext
//    {
//        // You can add custom code to this file. Changes will not be overwritten.
//        // 
//        // If you want Entity Framework to drop and regenerate your database
//        // automatically whenever you change your model schema, please use data migrations.
//        // For more information refer to the documentation:
//        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

//        public myContext() : base("name=myContext")
//        {
//        }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.LawyerModel> LawyerModels { get; set; }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.DocumentTypeModel> DocumentTypeModels { get; set; }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.NewsModel> NewsModels { get; set; }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.EmployeeModel> EmployeeModels { get; set; }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.ClientModel> ClientModels { get; set; }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.CourtBranchModel> CourtBranchModels { get; set; }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.CourtCaseModel> CourtCaseModels { get; set; }

//        public System.Data.Entity.DbSet<KnxProject_Franco.Models.QAModel> QAModels { get; set; }
//    }
//}