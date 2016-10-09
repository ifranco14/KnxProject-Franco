using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.CONTRACTS
{
    public interface ILawyers
    {
        List<LawyerModel> GetAll();
        LawyerModel Details(int id);
        bool Create(LawyerModel l);
        bool Edit(int id, LawyerModel l);
        bool Delete(int id);
    }
}
