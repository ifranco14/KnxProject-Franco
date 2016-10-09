using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.SERVICES
{
    public class LawyerServices : CONTRACTS.ILawyers
    {
        public bool Create(LawyerModel l)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public LawyerModel Details(int id)
        {
            return new LawyerModel();
        }

        public bool Edit(int id, LawyerModel l)
        {
            return true; 
        }

        public List<LawyerModel> GetAll()
        {
            return new List<LawyerModel>();
        }
    }
}
