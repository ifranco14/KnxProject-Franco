using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.CONTRACTS
{
    public interface INews
    {
        List<Entities.NewsModel> GetAllNews();
        List<Entities.Scope> GetScopes();
        bool Create(Entities.NewsModel _new);
        Entities.NewsModel Details(int id);
    }
}
