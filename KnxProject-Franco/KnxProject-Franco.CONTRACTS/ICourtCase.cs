using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.CONTRACTS
{
    public interface ICourtCase
    {
        CourtCaseModel Details(int id);
        bool Create(CourtCaseModel cc);
        bool Edit(int id, CourtCaseModel cc);
        bool Delete(int id);
        List<CourtCaseModel> GetAll();
        List<CourtCaseModel> GetAllOfALawyer(int idLawyer);
        CourtCaseModel GetCourtCase(int? idCase);
        bool UpdateState(int IdCourtCase, int IdState);
    }
}
