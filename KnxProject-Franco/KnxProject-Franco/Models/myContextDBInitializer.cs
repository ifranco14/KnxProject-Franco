using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Models
{
    public class myContextDBInitializer : System.Data.Entity.DropCreateDatabaseAlways<myContext>
    {
        protected override void Seed(myContext context)
        {
            context.DocumentTypeModels.Add(new DocumentTypeModel { ID = 0, DocumentType = "DNI" });
            context.DocumentTypeModels.Add(new DocumentTypeModel { ID = 1, DocumentType = "Pasaporte" });
            context.DocumentTypeModels.Add(new DocumentTypeModel { ID = 2, DocumentType = "Libreta civica" });
            context.LawyerModels.Add(new LawyerModel
            {
                PersonID = 0,
                FirstName = "Ignacio",
                LastName = "Franco",
                Email = "ign.franco.14@gmail.com",
                CompareEmail = "ign.franco.14@gmail.com",
                CellPhoneNumber = "3492 571726",
                DateOfBirth = Convert.ToDateTime(25 / 08 / 1995),
                DocumentNumber = 39123809,
                DocumentType = context.DocumentTypeModels.Single(b => b.ID == 0),
                ID = 0,
                PersonModelID = 0,
                ProfessionalLicense = 23448,
                ContractDate = Convert.ToDateTime(20 / 10 / 2005)
            });
            context.LawyerModels.Add(new LawyerModel
            {
                PersonID = 1,
                FirstName = "Francisco",
                LastName = "Franco",
                Email = "francisco.franco@hotmail.com",
                CompareEmail = "francisco.franco@hotmail.com",
                CellPhoneNumber = "3492-625844",
                DateOfBirth = Convert.ToDateTime(24 / 05 / 2001),
                DocumentNumber = 43225665,
                DocumentType = context.DocumentTypeModels.Single(a => a.ID == 1),
                ID = 1,
                PersonModelID = 1,
                ProfessionalLicense = 23248,
                ContractDate = Convert.ToDateTime(22 / 10 / 2005)
            });

            var x = new List<int>();
            x.Add(0);
            var y = new List<int>();
            y.Add(1);
            context.CourtBranchModels.Add(new CourtBranchModel
            {
                ID = 0,
                Name = "Derechos empresariales",
                LawyersInIDs = x,
                Description = "Rama de los derechos que se refieren a las empresas"
            });
            context.CourtBranchModels.Add(new CourtBranchModel
            {
                ID = 1,
                Name = "Relaciones domesticas",
                LawyersInIDs = y,
                Description = "No al maltrato familiar"
            });
            base.Seed(context);
        }
    }
}