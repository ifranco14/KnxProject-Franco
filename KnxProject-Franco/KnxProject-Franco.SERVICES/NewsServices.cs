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
            Mapper.Initialize(cfg => {
                cfg.CreateMap<News, NewsModel>()
                .ForMember(x => x.Scopes, option => option.Ignore())
                .ForMember(x => x.CourtBranches, option => option.Ignore());
            });

            return db.News.AsEnumerable().Select(News => Mapper.Map<News, NewsModel>(News)).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_new">New to send to database</param>
        /// <returns>true if create succeed, else false</returns>
        public bool Create(NewsModel _new)
        {
            //Create implementation
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<NewsModel, News>();
                });

                News myNew = new News {
                        ID = _new.ID,
                        Body = _new.Body,
                        ScopeID = _new.ScopeID,
                        Date = _new.Date,
                        LetterHead = _new.LetterHead,
                        Place = _new.Place,
                        Title = _new.Title,
                        Scopes = db.Scopes.SingleOrDefault(x => x.ID == _new.ScopeID),
                        CourtBranches = db.CourtBranches.FirstOrDefault(x => x.ID == _new.CourtBranchId),
                        CourtBranchId =_new.CourtBranchId,
                        };

                db.News.Add(myNew);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public NewsModel Details(int id)
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<News, NewsModel>()
                .ForMember(x => x.Scopes, option => option.Ignore())
                .ForMember(x => x.CourtBranches, option => option.Ignore());
            });
            //var myNew = db.News.Where(x => x.ID == id).FirstOrDefault();
            return Mapper.Map<NewsModel>(db.News.Where(x => x.ID == id).FirstOrDefault());
        }

        public bool Delete(int id)
        {
            try
            {
                db.News.Remove(db.News.FirstOrDefault(x => x.ID == id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(int id, NewsModel newsModel)
        {
            try
            {
                Mapper.Initialize(a => { a.CreateMap<NewsModel, News>(); });
                var myNew = db.News.SingleOrDefault(x => x.ID == id);
                myNew = Mapper.Map<News>(newsModel);
                //realizar el cambio
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
