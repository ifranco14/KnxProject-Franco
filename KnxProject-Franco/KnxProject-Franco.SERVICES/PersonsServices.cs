using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.Data;
using AutoMapper;

namespace KnxProject_Franco.SERVICES
{
    public class PersonsServices : IPerson
    {
        private KnxProject_FrancoDBEntities db;
        //Employee implementation
        public bool CreateEmployee(EmployeeModel e)
        {
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            return true;
        }

        public EmployeeModel DetailsEmployee(int id)
        {
            return new EmployeeModel();
        }

        public bool EditEmployee(int id, EmployeeModel e)
        {
            return true;
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            return new List<EmployeeModel>();
        }


        //Employee implementation
        public bool CreateClient(ClientModel c)
        {
            return true;
        }

        public bool DeleteClient(int id)
        {
            return true;
        }

        public ClientModel DetailsClient(int id)
        {
            return new ClientModel();
        }

        public bool EditClient(int id, ClientModel c)
        {
            return true;
        }

        public List<ClientModel> GetAllClients()
        {
            return new List<ClientModel>();
        }
        

        //Lawyer implementation
        public bool CreateLawyer(LawyerModel l)
        {
            try
            {

                People myP = new People
                {
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    CellPhoneNumber = l.CellPhoneNumber,
                    DateOfBirth = l.DateOfBirth,
                    IDDocumentType = l.IDDocumentType,
                    DocumentNumber = l.DocumentNumber.ToString(),
                    Email = l.Email
                };
                db.People.Add(myP);
                db.SaveChanges();

                Lawyers myLawyer = new Lawyers
                {   
                    IDPerson = l.IDPerson,
                    IDCourtBranch = l.IDCourtBranch,
                    ContractDate = l.ContractDate,
                    ProfessionalLicense = l.ProfessionalLicense                            
                };
                db.Lawyers.Add(myLawyer);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteLawyer(int id)
        {
            return true;
        }

        public LawyerModel DetailsLawyer(int id)
        {
            return new LawyerModel();
        }

        public bool EditLawyer(int id, LawyerModel l)
        {
            return true;
        }

        public List<LawyerModel> GetAllLawyers()
        {
            return new List<LawyerModel>();
        }
    }
}
