﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.Data;
using AutoMapper;
using WebMatrix.WebData;

namespace KnxProject_Franco.SERVICES
{
    public class PersonsServices : IPerson
    {
        private KnxProject_FrancoDBEntities db;

        public PersonsServices()
        {
            db = new KnxProject_FrancoDBEntities();
        }

        //General implementation
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPerson">IDPerson of the person type to find</param>
        /// <returns>The correct IDLawyer, IDClient or IDEmployee</returns>
        public int GetID(int? idPerson)
        {
            var id = -1;
            if (db.Clients.FirstOrDefault(x => x.IDPerson == idPerson) != null)
            {
                id = db.Clients.FirstOrDefault(x => x.IDPerson == idPerson).IDClient;
            }
            else
            {
                if (db.Lawyers.FirstOrDefault(x => x.IDPerson == idPerson) != null)
                {
                    id = db.Lawyers.FirstOrDefault(x => x.IDPerson == idPerson).IDLawyer;
                }
                else
                {
                    if (db.Employees.FirstOrDefault(x => x.IDPerson == idPerson) != null)
                    {
                        id = db.Employees.FirstOrDefault(x => x.IDPerson == idPerson).IDEmployee;
                    }
                }
            }
            return id;
        }

        public bool DeletePerson(int idPerson)
        {
            try
            {
                if (db.Clients.FirstOrDefault(x => x.IDPerson == idPerson) != null)
                {
                    db.Clients.Remove(db.Clients.FirstOrDefault(x => x.IDPerson == idPerson));
                    db.SaveChanges();
                }
                else
                {
                    if (db.Lawyers.FirstOrDefault(x => x.IDPerson == idPerson) != null)
                    {
                        db.Lawyers.Remove(db.Lawyers.FirstOrDefault(x => x.IDPerson == idPerson));
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Employees.Remove(db.Employees.FirstOrDefault(x => x.IDPerson == idPerson));
                        db.SaveChanges();
                    }
                }
                db.People.Remove(db.People.FirstOrDefault(x => x.IDPerson == idPerson));
                db.Users.Remove(db.Users.FirstOrDefault(x => x.IDPerson == idPerson));
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool SetRole(int idPerson, int idRole)
        {
            try
            {
                var myU = db.Users.FirstOrDefault(x => x.IDPerson == idPerson);
                db.webpages_UsersInRoles.Add(new webpages_UsersInRoles { UserId = myU.UserID, RoleId = idRole });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int? GetIDPerson(int idUser)
        {
            return db.Users.FirstOrDefault(x => x.UserID == idUser).IDPerson;
        }

        public PersonModel GetPerson(int? idPerson)
        {
            var p = db.People.FirstOrDefault(x => x.IDPerson == idPerson);
            var myP = new PersonModel
            {
                IDPerson = p.IDPerson,
                DocumentNumber = Convert.ToInt32(p.DocumentNumber),
                DateOfBirth = p.DateOfBirth,
                IDDocumentType = p.IDDocumentType,
                Email = p.Email,
                ImageName = p.ImageName,
                FirstName = p.FirstName,
                LastName = p.LastName,
                CellPhoneNumber = p.CellPhoneNumber,
                PersonType2 = p.PersonType         
            };
            return myP;
        }
        //Employee implementation
        public bool CreateEmployee(EmployeeModel e)
        {
            try
            {
                string ImageName = "";
                try
                {
                    ImageName = System.IO.Path.GetFileName(e.Image.FileName);
                }
                catch { }

                People myP = new People()
                {
                    IDPerson = e.IDPerson,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    CellPhoneNumber = e.CellPhoneNumber,
                    DateOfBirth = e.DateOfBirth,
                    IDDocumentType = e.IDDocumentType,
                    DocumentNumber = e.DocumentNumber.ToString(),
                    Email = e.Email,
                    ImageName = ImageName,
                    PersonType = e.PersonType2
                };
                db.People.Add(myP);
                db.SaveChanges();
                Employees myE = new Employees()
                {
                    IDPerson = myP.IDPerson,
                    ContractDate = e.ContractDateE,
                    Employment = e.Employment
                };
                db.Employees.Add(myE);
                db.SaveChanges();
                WebSecurity.CreateUserAndAccount(e.Email, "kuasociados123");
                SetIDPersonInUserForEmployee();
                if (e.Employment.ToUpper() == "SECRETARIA")
                {
                    SetRole(myE.IDPerson, 5);
                }
                else
                {
                    if (e.Employment.ToUpper() == "ADMIN")
                    {
                        SetRole(myE.IDPerson, 1);
                    }
                    else
                    {
                        SetRole(myE.IDPerson, 4);
                    }
                }

                return true;
            }
            catch (Exception)
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

        public EmployeeModel GetEmployee(int id)
        {
            var P = db.People.Where(x => x.IDPerson == db.Employees.Where(z => z.IDEmployee == id).FirstOrDefault().IDPerson).FirstOrDefault();
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
                PersonType2 = P.PersonType,
                ImageName = P.ImageName,
                Employment = E.Employment,
                ContractDateE = E.ContractDate,
                IDEmployee = E.IDEmployee
            };
            return myL;
        }


        public EmployeeModel DetailsEmployee(int id)
        {
            var P = db.People.Where(x => x.IDPerson == db.Employees.Where(z => z.IDEmployee == id).FirstOrDefault().IDPerson).FirstOrDefault();
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
                PersonType2 = P.PersonType,
                ImageName = P.ImageName,
                Employment = E.Employment,
                ContractDateE = E.ContractDate,
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
                myP.ImageName = e.ImageName;
                myP.PersonType = e.PersonType2;
                myE.IDPerson = e.IDPerson;
                myE.IDEmployee = e.IDEmployee;
                myE.Employment = e.Employment;
                myE.ContractDate = e.ContractDateE;

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
                    ImageName = x.ImageName,
                    PersonType2 = x.PersonType,
                    Employment = e.Employment,
                    IDEmployee = e.IDEmployee,
                    ContractDateE = e.ContractDate,
                });
            }
            return listE;
        }

        public int LastEmployee()
        {
            People last = db.People.FirstOrDefault(z => z.IDPerson == db.Employees.OrderByDescending(x => x.IDEmployee).FirstOrDefault().IDPerson);
            return last.IDPerson;
        }

        public void SetIDPersonInUserForEmployee()
        {
            var myUser = db.Users.OrderByDescending(x => x.UserID).FirstOrDefault();
            myUser.IDPerson = LastEmployee();
            db.SaveChanges();
        }


        //Client implementation
        public bool CreateClient(ClientModel c)
        {
            try
            {
                string ImageName = "";
                if (System.IO.Path.GetFileName(c.Image.FileName) != null)
                {
                    ImageName = System.IO.Path.GetFileName(c.Image.FileName);
                }
                People myP = new People()
                {
                    IDPerson = c.IDPerson,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CellPhoneNumber = c.CellPhoneNumber,
                    DateOfBirth = c.DateOfBirth,
                    IDDocumentType = c.IDDocumentType,
                    DocumentNumber = c.DocumentNumber.ToString(),
                    Email = c.Email,
                    ImageName = ImageName,
                    PersonType = c.PersonType2
                };
                db.People.Add(myP);
                db.SaveChanges();

                Clients myC = new Clients()
                {
                    IDClient = c.IDClient,
                    IDPerson = myP.IDPerson,
                    Active = false
                };
                db.Clients.Add(myC);
                db.SaveChanges();
                WebSecurity.CreateUserAndAccount(c.Email, c.Password);
                SetIDPersonInUserForClient();
                SetRole(myC.IDPerson, 3);
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
                PersonType2 = P.PersonType,
                ImageName = P.ImageName,
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
                P.ImageName = c.ImageName;
                P.PersonType = c.PersonType2;
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

        public List<ClientModel> GetAllActiveClients()
        {
            
            List<ClientModel> listC = new List<ClientModel>();
            foreach (var c in db.Clients.Where(t => t.Active == true).ToList()) 
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
                    PersonType2 = x.PersonType,
                    ImageName = x.ImageName,
                    IDClient = c.IDClient,
                    CurrentCases = db.CourtCases.AsEnumerable().Where(a => a.IDClient == c.IDClient).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                    Active = c.Active
                });
            }
            return listC;
        }

        public List<ClientModel> GetAllInactiveClients()
        {
            //obtener solo los activos (los que tienen un caso asignado)
            List<ClientModel> listC = new List<ClientModel>();
            foreach (var c in db.Clients.Where(t => t.Active != true).ToList())
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
                    ImageName = x.ImageName,
                    PersonType2 = x.PersonType,
                    IDClient = c.IDClient,
                    CurrentCases = db.CourtCases.AsEnumerable().Where(a => a.IDClient == c.IDClient).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                    Active = c.Active
                });
            }
            return listC;
        }
        public List<ClientModel> GetAllClients()
        {
            //obtener solo los activos (los que tienen un caso asignado)
            List<ClientModel> listC = new List<ClientModel>();
            foreach (var c in db.Clients.ToList())
            {
                Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); });
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
                    ImageName = x.ImageName,
                    PersonType2 = x.PersonType,
                    IDClient = c.IDClient,
                    CurrentCases = db.CourtCases.AsEnumerable().Where(a => a.IDClient == c.IDClient).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                    Active = c.Active
                });
            }
            return listC;
        }



        public bool ActiveClient(int id)
        {
            try
            {
                db.Clients.FirstOrDefault(x => x.IDClient == id).Active = true; //VER SI FUNCIONA
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool DeactivateClient(int id)
        {
            try
            {
                db.Clients.FirstOrDefault(x => x.IDClient == id).Active = false; //VER SI FUNCIONA
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public int LastClient()
        {
            People last = db.People.FirstOrDefault(z => z.IDPerson == db.Clients.OrderByDescending(x => x.IDClient).FirstOrDefault().IDPerson);
            return last.IDPerson;
        }

        public void SetIDPersonInUserForClient()
        {
            var myUser = db.Users.OrderByDescending(x => x.UserID).FirstOrDefault();
            myUser.IDPerson = LastClient();
            db.SaveChanges();
        }

        public ClientModel GetClientByIDPerson(int? idPerson)
        {
            Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); });
            People P = db.People.FirstOrDefault(x => x.IDPerson == idPerson);
            Clients C = db.Clients.FirstOrDefault(z => z.IDPerson == idPerson);
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
                ImageName = P.ImageName,
                PersonType2 = P.PersonType,
                IDClient = C.IDClient,
                CurrentCases = db.CourtCases.AsEnumerable().Where(x => x.IDClient == C.IDClient).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                Active = C.Active
            };
            return myC;
        }
        public ClientModel GetClient(int? idClient)
        {
            Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); });
            Clients C = db.Clients.FirstOrDefault(z => z.IDClient == idClient);
            People P = db.People.FirstOrDefault(x => x.IDPerson == C.IDPerson);
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
                ImageName = P.ImageName,
                PersonType2 = P.PersonType,
                IDClient = C.IDClient,
                CurrentCases = db.CourtCases.AsEnumerable().Where(x => x.IDClient == C.IDClient).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                Active = C.Active
            };
            return myC;
        }


        //Lawyer implementation
        public bool CreateLawyer(LawyerModel l)
        {
            try
            {
                string ImageName = "";
                if (System.IO.Path.GetFileName(l.Image.FileName) != null)
                {
                    ImageName = System.IO.Path.GetFileName(l.Image.FileName);
                }
                People myP = new People()
                {
                    IDPerson = l.IDPerson, // db.People.Last().IDPerson + 1,
                    FirstName = l.FirstName,
                    LastName = l.LastName,
                    CellPhoneNumber = l.CellPhoneNumber,
                    DateOfBirth = l.DateOfBirth,
                    IDDocumentType = l.IDDocumentType,
                    DocumentNumber = l.DocumentNumber.ToString(),
                    Email = l.Email,
                    ImageName = ImageName,
                    PersonType = l.PersonType2
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
                WebSecurity.CreateUserAndAccount(l.Email, "kuasociados123");
                SetIDPersonInUserForLawyer();
                SetRole(myLawyer.IDPerson, 2);
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
            Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); a.CreateMap<QAs, QAModel>(); });
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
                ImageName = P.ImageName,
                PersonType2 = P.PersonType,
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
            P.ImageName = l.ImageName;
            L.IDCourtBranch = l.IDCourtBranch;
            L.ProfessionalLicense = l.ProfessionalLicense;

            db.SaveChanges();
            return true;
        }

        public List<LawyerModel> GetAllLawyers()
        {
            var LawyersList = new List<LawyerModel>();
            Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); a.CreateMap<QAs, QAModel>(); });
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
                    ImageName = x.ImageName,
                    PersonType2 = x.PersonType,
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

        public LawyerModel GetLawyer(int idLawyer)
        {
            Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); a.CreateMap<QAs, QAModel>(); });
            var z = db.Lawyers.FirstOrDefault(y => y.IDLawyer == idLawyer);
            var x = db.People.Where(c => c.IDPerson == z.IDPerson).FirstOrDefault();
            var myL = new LawyerModel()
            {
                IDPerson = x.IDPerson,
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                DocumentNumber = Convert.ToInt32(x.DocumentNumber),
                IDDocumentType = x.IDDocumentType,
                CellPhoneNumber = x.CellPhoneNumber,
                ImageName = x.ImageName,
                PersonType2 = x.PersonType,
                ContractDate = z.ContractDate,
                IDCourtBranch = z.IDCourtBranch,
                IDLawyer = z.IDLawyer,
                CourtCases = db.CourtCases.AsEnumerable().Where(t => t.IDLawyer == z.IDLawyer).Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList(),
                Querys = db.QAs.AsEnumerable().Where(t => t.IDLawyer == z.IDLawyer).Select(QAs => Mapper.Map<QAs, QAModel>(QAs)).ToList(),
                ProfessionalLicense = z.ProfessionalLicense
            };
            return myL;
        }
        

        public List<LawyerModel> FilterByCourtBranchLawyers(int id)
        {
            List<LawyerModel> LawyersList = new List<LawyerModel>();

            foreach (var z in db.Lawyers.Where(x => x.IDCourtBranch == id).ToList())
            {
                Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); a.CreateMap<QAs, QAModel>(); });
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
                    ImageName = x.ImageName,
                    PersonType2 = x.PersonType,
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

        public int LastLawyer()
        {
            People last = db.People.FirstOrDefault(z => z.IDPerson == db.Lawyers.OrderByDescending(x => x.IDLawyer).FirstOrDefault().IDPerson);
            return last.IDPerson;
        }

        public void SetIDPersonInUserForLawyer()
        {
            var myUser = db.Users.OrderByDescending(x => x.UserID).FirstOrDefault();
            myUser.IDPerson = LastLawyer();
            db.SaveChanges();
        }

        
    }

    
}
