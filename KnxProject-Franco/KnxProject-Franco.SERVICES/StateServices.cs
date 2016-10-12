using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.SERVICES
{
    public class StateServices : IStates
    {
        public List<StateModel> GetAll()
        {
            return new List<StateModel>();
        }
    }
}
