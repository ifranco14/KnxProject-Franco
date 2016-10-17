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
        //Employee contracts
        EmployeeModel DetailsEmployee(int id);
        bool CreateEmployee(EmployeeModel e);
        bool EditEmployee(int id, EmployeeModel e);
        bool DeleteEmployee(int id);
        List<EmployeeModel> GetAllEmployees();


        //Client contracts
        bool CreateClient(ClientModel c);
        bool EditClient(int id, ClientModel c);
        bool DeleteClient(int id);
        List<ClientModel> GetAllClients();

        //Lawyer contracts
        bool CreateLawyer(LawyerModel l);
        bool EditLawyer(int id, LawyerModel c);
        bool DeleteLawyer(int id);
        List<LawyerModel> GetAllLawyers();
    }
}
