using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.CONTRACTS
{
    public interface ICourtCaseDetails
    {
        bool Create(CourtCaseDetailModel ccd);
        bool Edit(int id, CourtCaseDetailModel ccd);
        bool Delete(int id);
        List<CourtCaseDetailModel> GetAllOfACase(int id);
    }
}
