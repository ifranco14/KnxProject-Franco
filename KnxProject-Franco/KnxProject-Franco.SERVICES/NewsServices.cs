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
           
            Mapper.Initialize(cfg => {
                cfg.CreateMap<News, NewsModel>();
            });

            return db.News.AsEnumerable().Select(News => Mapper.Map<News, NewsModel>(News)).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>all the scopes for a new</returns>
        
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
            var id = _new.ScopeID;

            News myNew = Mapper.Map<NewsModel, News>(_new);
            myNew.Scopes = db.Scopes.FirstOrDefault(x => x.ID == _new.ScopeID);
            myNew.CourtBranches = db.CourtBranches.FirstOrDefault(x => x.ID == _new.CourtBranchId);
            db.News.Add(myNew);
            db.SaveChanges();
            
            return true;
        }

        public NewsModel Details(int id)
        {
            //BD.News.Find(x => x.ID = id)

            //returning a fake new
            return new NewsModel { ID = 2, Title = "Marte ataca!!!", Date = DateTime.Today, CourtBranchId = 1, Place = "Planeta Tierra", ScopeID = 1, Body = "Al parecer, los marcianos se dieron cuenta de nuestras inminentes prueba de bombas a su planeta y buscan impedirlo", LetterHead = "IMAGEN NO ILUSTRATIVA. SI, SON COMO LOS DE LA PELÍCULA." };
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
