using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.CONTRACTS
{
    public interface IAbout
    {
        AboutModel Get(int id);
        bool Edit(int id, AboutModel about);
    }
}
