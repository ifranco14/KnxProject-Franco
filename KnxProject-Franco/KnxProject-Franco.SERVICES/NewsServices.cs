using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnxProject_Franco.SERVICES
{
    public class NewsServices : CONTRACTS.INews
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>All the news</returns>
        public List<CONTRACTS.Entities.News> GetAllNews()
        {
            //FAKE LIST
            List<CONTRACTS.Entities.News> news = new List<CONTRACTS.Entities.News> { new CONTRACTS.Entities.News { ID = 0, Title = "Primer Noticia", Date = DateTime.Today, CourtBranchId = 0, Place = "Rafaela", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete" },
                                                        new CONTRACTS.Entities.News { ID = 1, Title = "Segunda Noticia", Date = DateTime.Today, CourtBranchId = 1, Place = "Sunchales", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete de la segunda noticia" },
                                                        new CONTRACTS.Entities.News { ID = 2, Title = "Marte ataca!!!", Date = DateTime.Today, CourtBranchId = 1, Place = "Planeta Tierra", Scope = "Intermundial", Body = "Al parecer, los marcianos se dieron cuenta de nuestras inminentes prueba de bombas a su planeta y buscan impedirlo", LetterHead = "IMAGEN NO ILUSTRATIVA. SI, SON COMO LOS DE LA PELÍCULA." },
                                                        new CONTRACTS.Entities.News { ID = 3, Title = "El mate, ahora considerado ilegal", Date = DateTime.Today, CourtBranchId = 1, Place = "Argentina", Scope = "Nacional", Body = "Lo dictaminó el Ministerio de Salud, por bajada de línea de la Presidencia. Desde mañana será considerada una actividad ilegal. La decisión fue tomada por Antonia, la hija del vigente Presidente, ya que al probarlo no le gustó.", LetterHead = "¡Te vamos a extrañar mate querido!" }};

            return news;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>all the scopes for a new</returns>
        public List<CONTRACTS.Entities.Scope> GetScopes()
        {
            return new List<CONTRACTS.Entities.Scope> { new CONTRACTS.Entities.Scope { ID = 0, Name = "Local" },
                                                        new CONTRACTS.Entities.Scope { ID = 0, Name = "Regional" },
                                                        new CONTRACTS.Entities.Scope { ID = 0, Name = "Nacional" },
                                                        new CONTRACTS.Entities.Scope { ID = 0, Name = "Internacional" },
                                                        new CONTRACTS.Entities.Scope { ID = 0, Name = "InterMundial" },
                                                        new CONTRACTS.Entities.Scope { ID = 0, Name = "InterPlanetaria" } };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_new">New to send to database</param>
        /// <returns>true if create succeed, else false</returns>
        public bool Create(CONTRACTS.Entities.News _new)
        {
            //Create implementation
            return true;
        }

        public CONTRACTS.Entities.News Details(int id)
        {
            //BD.News.Find(x => x.ID = id)

            //returning a fake new
            return new CONTRACTS.Entities.News { ID = 2, Title = "Marte ataca!!!", Date = DateTime.Today, CourtBranchId = 1, Place = "Planeta Tierra", Scope = "Intermundial", Body = "Al parecer, los marcianos se dieron cuenta de nuestras inminentes prueba de bombas a su planeta y buscan impedirlo", LetterHead = "IMAGEN NO ILUSTRATIVA. SI, SON COMO LOS DE LA PELÍCULA." };
        }
        
    }
}
