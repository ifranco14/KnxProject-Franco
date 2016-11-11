using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.CONTRACTS
{
    public interface IPerson
    {
        //General contracts
        bool SetRole(int idPerson, int idRole);
        int? GetIDPerson(int idUser);
        PersonModel GetPerson(int? idPerson);
        bool DeletePerson(int idPerson);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPerson">IDPerson of the person type to find</param>
        /// <returns>The correct IDLawyer, IDClient or IDEmployee</returns>
        int GetID(int? IDPerson);
        //Employee contracts
        EmployeeModel DetailsEmployee(int id);
        bool CreateEmployee(EmployeeModel e);
        bool EditEmployee(int id, EmployeeModel e);
        bool DeleteEmployee(int id);
        List<EmployeeModel> GetAllEmployees();
        int LastEmployee();
        void SetIDPersonInUserForEmployee();

        //Client contracts
        bool CreateClient(ClientModel c);
        bool EditClient(int id, ClientModel c);
        bool DeleteClient(int id);
        ClientModel DetailsClient(int id);
        List<ClientModel> GetAllActiveClients();
        List<ClientModel> GetAllInactiveClients();
        List<ClientModel> GetAllClients();
        bool ActiveClient(int id);
        bool DeactivateClient(int id);
        int LastClient();
        void SetIDPersonInUserForClient();
        ClientModel GetClientByIDPerson(int idPerson);
        ClientModel GetClient(int? idClient);


        //Lawyer contracts
        bool CreateLawyer(LawyerModel l);
        bool EditLawyer(int id, LawyerModel c);
        bool DeleteLawyer(int id);
        List<LawyerModel> GetAllLawyers();
        List<LawyerModel> FilterByCourtBranchLawyers(int id);
        int LastLawyer();
        void SetIDPersonInUserForLawyer();
        LawyerModel GetLawyer(int idLawyer);


    }
}
