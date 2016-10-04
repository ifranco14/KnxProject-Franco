using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class CourtBranch
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<int> LawyersInIDs { get; set; }
        public string Description { get; set; }
    }
}
