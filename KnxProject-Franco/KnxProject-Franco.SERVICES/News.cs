using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.SERVICES
{
    public class News: CONTRACTS.INews
    {
        public List<CONTRACTS.Entities.News> GetAllNews()
        {
            //FAKE LIST
            List<CONTRACTS.Entities.News> news = new List<CONTRACTS.Entities.News> { new CONTRACTS.Entities.News { ID = 0, Title = "Primer Noticia", Date = DateTime.Today, CourtBranchId = 0, Place = "Rafaela", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete" },
                                                        new CONTRACTS.Entities.News { ID = 1, Title = "Segunda Noticia", Date = DateTime.Today, CourtBranchId = 1, Place = "Sunchales", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete de la segunda noticia" }};

            return news;
        }
    }
}
