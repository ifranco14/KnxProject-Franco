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

        public PersonsServices()
        {
            db = new KnxProject_FrancoDBEntities();
        }
        //Employee implementation
        public bool CreateEmployee(EmployeeModel e)
        {
            try
            {
                People myP = new People()
                {
                    IDPerson = e.IDPerson, // db.People.Last().IDPerson + 1,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    CellPhoneNumber = e.CellPhoneNumber,
                    DateOfBirth = e.DateOfBirth,
                    IDDocumentType = e.IDDocumentType,
                    DocumentNumber = e.DocumentNumber.ToString(),
                    Email = e.Email
                };
                db.People.Add(myP);
                db.SaveChanges();
                Employees myE = new Employees()
                {
                    IDPerson = myP.IDPerson,
                    ContractDate = e.ContractDate,
                    Employment = e.Employment
                };
                db.Employees.Add(myE);
                db.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                db.People.Remove(db.People.FirstOrDefault(z => z.IDPerson == db.Employees.FirstOrDefault(x => x.IDEmployee == id).IDPerson));
                db.Employees.Remove(db.Employees.FirstOrDefault(x => x.IDEmployee == id));
                db.SaveChanges();
                return true;
            }
            catch 
            {

                return true;
            }
        }

        public EmployeeModel DetailsEmployee(int id)
        {
            var P = db.People.Where(x => x.IDPerson == db.Lawyers.Where(z => z.IDLawyer == id).FirstOrDefault().IDPerson).FirstOrDefault();
            Employees E = db.Employees.Where(z => z.IDEmployee == id).FirstOrDefault();
            var myL = new EmployeeModel()
            {
                IDPerson = P.IDPerson,
                FirstName = P.FirstName,
                LastName = P.LastName,
                DateOfBirth = P.DateOfBirth,
                Email = P.Email,
                DocumentNumber = Convert.ToInt32(P.DocumentNumber),
                IDDocumentType = P.IDDocumentType,
                CellPhoneNumber = P.CellPhoneNumber,
                Employment = E.Employment,
                ContractDate = E.ContractDate,
                IDEmployee = E.IDEmployee
            };
            return myL;
        }

        public bool EditEmployee(int id, EmployeeModel e)
        {
            try
            {
                var myP = db.People.FirstOrDefault(z => z.IDPerson == db.Employees.FirstOrDefault(x => x.IDEmployee == id).IDPerson);
                var myE = db.Employees.FirstOrDefault(x => x.IDEmployee == id);
                                
                myP.FirstName = e.FirstName;
                myP.LastName = e.LastName;
                myP.CellPhoneNumber = e.CellPhoneNumber;
                myP.DocumentNumber = e.DocumentNumber.ToString();
                myP.Email = e.Email;
                myE.IDPerson = e.IDPerson;
                myE.IDEmployee = e.IDEmployee;
                myE.Employment = e.Employment;
                myE.ContractDate = e.ContractDate;

                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public List<EmployeeModel> GetAllEmployees()
        {
            List <EmployeeModel> listE = new List<EmployeeModel>();
            foreach (var e in db.Employees.ToList())
            {
                var x = db.People.Where(c => c.IDPerson == e.IDPerson).FirstOrDefault();
                listE.Add(new EmployeeModel
                {
                    IDPerson = x.IDPerson,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    DocumentNumber = Convert.ToInt32(x.DocumentNumber),
                    IDDocumentType = x.IDDocumentType,
                    CellPhoneNumber = x.CellPhoneNumber,
                    Employment = e.Employment,
                    IDEmployee = e.IDEmployee,
                    ContractDate = e.ContractDate,
                });
            }
            return listE;
        }


        //Client implementation
        public bool CreateClient(ClientModel c)
        {
            try
            {
                People myP = new People()
                {
                    IDPerson = c.IDPerson, // db.People.Last().IDPerson + 1,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CellPhoneNumber = c.CellPhoneNumber,
                    DateOfBirth = c.DateOfBirth,
                    IDDocumentType = c.IDDocumentType,
                    DocumentNumber = c.DocumentNumber.ToString(),
                    Email = c.Email
                };
                db.People.Add(myP);
                db.SaveChanges();

                Clients myC = new Clients()
                {
                    IDClient = c.IDClient,
                    IDPerson = c.IDPerson,
                    Active = false
                };
                db.Clients.Add(myC);
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }   
        }

        public bool DeleteClient(int id)
        {
            try
            {
                db.People.Remove(db.People.FirstOrDefault(x => x.IDPerson == db.Clients.FirstOrDefault(z => z.IDClient == id).IDPerson));
                db.Clients.Remove(db.Clients.FirstOrDefault(z => z.IDClient == id));
                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public ClientModel DetailsClient(int id)
        {
            People P = db.People.FirstOrDefault(x => x.IDPerson == db.Clients.FirstOrDefault(z => z.IDClient == id).IDPerson);
            Clients C = db.Clients.FirstOrDefault(z => z.IDClient == id);
            var myC = new ClientModel()
            {
                IDPerson = P.IDPerson,
                FirstName = P.FirstName,
                LastName = P.LastName,
                DateOfBirth = P.DateOfBirth,
                Email = P.Email,
                DocumentNumber = Convert.ToInt32(P.DocumentNumber),
                IDDocumentType = P.IDDocumentType,
                CellPhoneNumber = P.CellPhoneNumber,
                IDClient = C.IDClient,
                CurrentCases = db.CourtCases.AsEnumerable().Where(x => x.IDClient == C.IDClient).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                Active = C.Active
            };
            return myC;
        }

        public bool EditClient(int id, ClientModel c)
        {
            try
            {
                People P = db.People.FirstOrDefault(x => x.IDPerson == db.Clients.FirstOrDefault(z => z.IDClient == id).IDPerson);
                Clients C = db.Clients.FirstOrDefault(z => z.IDClient == id);

                P.Email = c.Email;
                P.FirstName = c.FirstName;
                P.LastName = c.LastName;
                P.CellPhoneNumber = c.CellPhoneNumber;
                P.DocumentNumber = c.DocumentNumber.ToString();
                P.DateOfBirth = c.DateOfBirth;
                C.Active = c.Active;
                C.IDClient = c.IDClient;
                C.IDPerson = c.IDPerson;
                db.SaveChanges();

                return true;
            }
            catch 
            {
                return false;
            }
            
        }

        public List<ClientModel> GetAllClients()
        {
            //obtener solo los activos (los que tienen un caso asignado)
            List<ClientModel> listC = new List<ClientModel>();
            foreach (var c in db.Clients.Where(t => t.Active == true).ToList()) //TODO: add this when "active" property setted -> 
            {
                People x = db.People.First(z => z.IDPerson == c.IDPerson);
                listC.Add(new ClientModel
                {
                    IDPerson = x.IDPerson,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    DocumentNumber = Convert.ToInt32(x.DocumentNumber),
                    IDDocumentType = x.IDDocumentType,
                    CellPhoneNumber = x.CellPhoneNumber,
                    IDClient = c.IDClient,
                    CurrentCases = db.CourtCases.AsEnumerable().Where(a => a.IDClient == c.IDClient).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                    Active = c.Active
                });
            }
            return listC;
        }
        

        //Lawyer implementation
        public bool CreateLawyer(LawyerModel l)
        {
            try
            {

                People myP = new People()
                {
                    IDPerson = l.IDPerson, // db.People.Last().IDPerson + 1,
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
                    IDPerson = myP.IDPerson,
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
            try
            {
                db.People.Remove(db.People.Where(x => x.IDPerson == db.Lawyers.Where(z => z.IDLawyer == id).FirstOrDefault().IDPerson).FirstOrDefault());
                db.Lawyers.Remove(db.Lawyers.Where(x => x.IDLawyer == id).FirstOrDefault());
                db.SaveChanges();
            }
            catch 
            {

                throw;
            }
            return true;
        }

        public LawyerModel DetailsLawyer(int id)
        {
            var P = db.People.Where(x => x.IDPerson == db.Lawyers.Where(z => z.IDLawyer == id).FirstOrDefault().IDPerson).FirstOrDefault();
            var L = db.Lawyers.Where(z => z.IDLawyer == id).FirstOrDefault();
            var myL = new LawyerModel()
            {
                IDPerson = P.IDPerson,
                FirstName = P.FirstName,
                LastName = P.LastName,
                DateOfBirth = P.DateOfBirth,
                Email = P.Email,
                DocumentNumber = Convert.ToInt32(P.DocumentNumber),
                IDDocumentType = P.IDDocumentType,
                CellPhoneNumber = P.CellPhoneNumber,
                IDCourtBranch = L.IDCourtBranch,
                IDLawyer = L.IDLawyer, 
                ContractDate = L.ContractDate,
                CourtCases = db.CourtCases.AsEnumerable().Where(x => x.IDLawyer == L.IDLawyer).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                Querys = db.QAs.AsEnumerable().Where(x => x.IDLawyer == L.IDLawyer).Select(QAs => Mapper.Map<QAs,QAModel>(QAs)).ToList(),
                ProfessionalLicense = L.ProfessionalLicense,
            };
            return myL;
        }

        public bool EditLawyer(int id, LawyerModel l)
        {
            var P = db.People.Where(x => x.IDPerson == db.Lawyers.Where(z => z.IDLawyer == id).FirstOrDefault().IDPerson).FirstOrDefault();
            var L = db.Lawyers.Where(z => z.IDLawyer == id).FirstOrDefault();

            P.Email = l.Email;
            P.FirstName = l.FirstName;
            P.LastName = l.LastName;
            P.CellPhoneNumber = l.CellPhoneNumber;
            P.DocumentNumber = l.DocumentNumber.ToString();
            P.DateOfBirth = l.DateOfBirth;
            L.IDCourtBranch = l.IDCourtBranch;
            L.ProfessionalLicense = l.ProfessionalLicense;

            db.SaveChanges();
            return true;
        }

        public List<LawyerModel> GetAllLawyers()
        {
            var LawyersList = new List<LawyerModel>();

            foreach (var z in db.Lawyers.ToList())
            {
                var x = db.People.Where(c => c.IDPerson == z.IDPerson).FirstOrDefault();
                LawyersList.Add(new LawyerModel
                {
                    IDPerson = x.IDPerson,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    DateOfBirth = x.DateOfBirth,
                    Email = x.Email,
                    DocumentNumber = Convert.ToInt32(x.DocumentNumber),
                    IDDocumentType = x.IDDocumentType,
                    CellPhoneNumber = x.CellPhoneNumber,
                    ContractDate = z.ContractDate,
                    IDCourtBranch = z.IDCourtBranch,
                    IDLawyer = z.IDLawyer,
                    CourtCases = db.CourtCases.AsEnumerable().Where(t => t.IDLawyer == z.IDLawyer).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                    Querys = db.QAs.AsEnumerable().Where(t => t.IDLawyer == z.IDLawyer).Select(QAs => Mapper.Map<QAs, QAModel>(QAs)).ToList(),
                    ProfessionalLicense = z.ProfessionalLicense
                });
            }

            return LawyersList;
        }
    }
}
