using System;
using System.Collections.Generic;
using System.Linq;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.Data;
using AutoMapper;

namespace KnxProject_Franco.SERVICES
{
    public class NewsServices : INews
    {
        private KnxProject_FrancoDBEntities db;
        
        public NewsServices()
        {
            this.db = new KnxProject_FrancoDBEntities();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>All the news</returns>
        public List<NewsModel> GetAllNews()
        {
            //FAKE LIST
            List<CONTRACTS.Entities.NewsModel> _news = new List<NewsModel> { new CONTRACTS.Entities.NewsModel { ID = 0, Title = "Primer Noticia", Date = DateTime.Today, CourtBranchId = 0, Place = "Rafaela", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete" },
                                                        new NewsModel { ID = 1, Title = "Segunda Noticia", Date = DateTime.Today, CourtBranchId = 1, Place = "Sunchales", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete de la segunda noticia" },
                                                        new NewsModel { ID = 2, Title = "Marte ataca!!!", Date = DateTime.Today, CourtBranchId = 1, Place = "Planeta Tierra", Scope = "Intermundial", Body = "Al parecer, los marcianos se dieron cuenta de nuestras inminentes prueba de bombas a su planeta y buscan impedirlo", LetterHead = "IMAGEN NO ILUSTRATIVA. SI, SON COMO LOS DE LA PELÍCULA." },
                                                        new NewsModel { ID = 3, Title = "El mate, ahora considerado ilegal", Date = DateTime.Today, CourtBranchId = 1, Place = "Argentina", Scope = "Nacional", Body = "Lo dictaminó el Ministerio de Salud, por bajada de línea de la Presidencia. Desde mañana será considerada una actividad ilegal. La decisión fue tomada por Antonia, la hija del vigente Presidente, ya que al probarlo no le gustó.", LetterHead = "¡Te vamos a extrañar mate querido!" }};

            Mapper.Initialize(cfg => {
                cfg.CreateMap<News, NewsModel>();
            });
            return db.News.AsEnumerable().Select(News => Mapper.Map<News, NewsModel>(News)).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>all the scopes for a new</returns>
        public List<ScopeModel> GetScopes()
        {
            return new List<CONTRACTS.Entities.ScopeModel> { new CONTRACTS.Entities.ScopeModel { ID = 0, Name = "Local" },
                                                        new CONTRACTS.Entities.ScopeModel { ID = 0, Name = "Regional" },
                                                        new CONTRACTS.Entities.ScopeModel { ID = 0, Name = "Nacional" },
                                                        new CONTRACTS.Entities.ScopeModel { ID = 0, Name = "Internacional" },
                                                        new CONTRACTS.Entities.ScopeModel { ID = 0, Name = "InterMundial" },
                                                        new CONTRACTS.Entities.ScopeModel { ID = 0, Name = "InterPlanetaria" } };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_new">New to send to database</param>
        /// <returns>true if create succeed, else false</returns>
        public bool Create(NewsModel _new)
        {
            //Create implementation
            
            Mapper.Initialize(cfg => {
                cfg.CreateMap<NewsModel, News>();
            });

            var myNew = Mapper.Map<NewsModel, News>(_new);
            db.News.Add(myNew);
            return true;
        }

        public NewsModel Details(int id)
        {
            //BD.News.Find(x => x.ID = id)

            //returning a fake new
            return new NewsModel { ID = 2, Title = "Marte ataca!!!", Date = DateTime.Today, CourtBranchId = 1, Place = "Planeta Tierra", Scope = "Intermundial", Body = "Al parecer, los marcianos se dieron cuenta de nuestras inminentes prueba de bombas a su planeta y buscan impedirlo", LetterHead = "IMAGEN NO ILUSTRATIVA. SI, SON COMO LOS DE LA PELÍCULA." };
        }
        
        public bool Delete(int id)
        {
            //db.where.select.singleordefault

            return true;
        }

        public bool Edit(int id, NewsModel newsModel)
        {
            return true;
        }

    }
}
