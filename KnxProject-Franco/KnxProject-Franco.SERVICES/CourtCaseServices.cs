using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.SERVICES
{
    public class CourtCaseServices : ICourtCase
    {
        public bool Create(CourtCaseModel cc)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public CourtCaseModel Details(int id)
        {
            return new CourtCaseModel();
        }

        public bool Edit(int id, CourtCaseModel cc)
        {
            return true;
        }

        public List<CourtCaseModel> GetAll()
        {
            //DB.Where().ToList
            return new List<CourtCaseModel>();
        }
    }
}
