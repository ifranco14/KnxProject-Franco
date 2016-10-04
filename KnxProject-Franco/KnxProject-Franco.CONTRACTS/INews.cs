using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.CONTRACTS
{
    public interface INews
    {
        List<Entities.News> GetAllNews();                
    }
}
