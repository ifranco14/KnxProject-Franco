using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.CONTRACTS.Entities
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int CourtBranchId { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public string Scope { get; set; }
        public string Body { get; set; }
        public string LetterHead { get; set; }
    }
}
