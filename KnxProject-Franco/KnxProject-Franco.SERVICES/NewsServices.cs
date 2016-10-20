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
            Mapper.Initialize(cfg => {
                cfg.CreateMap<News, NewsModel>()
                .ForMember(x => x.Scopes, option => option.Ignore())
                .ForMember(x => x.CourtBranches, option => option.Ignore());
                cfg.CreateMap<NewsModel, News>();
            });
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>All the news</returns>
        public List<NewsModel> GetAllNews()
        {
            Mapper.Initialize(cfg =>
            {
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
                string ImageName = System.IO.Path.GetFileName(_new.Image.FileName);
                
               

                News myNew = new News {
                    IDNew = _new.IDNew,
                    Body = _new.Body,
                    IDScope = _new.IDScope,
                    Date = _new.Date,
                    LetterHead = _new.LetterHead,
                    Place = _new.Place,
                    Title = _new.Title,
                    IDCourtBranch = _new.IDCourtBranch,
                    ImageURL = ImageName
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
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<News, NewsModel>()
                .ForMember(x => x.Scopes, option => option.Ignore())
                .ForMember(x => x.CourtBranches, option => option.Ignore());
            });
                return Mapper.Map<NewsModel>(db.News.Where(x => x.IDNew == id).FirstOrDefault());
        }

        public bool Delete(int id)
        {
            try
            {
                db.News.Remove(db.News.FirstOrDefault(x => x.IDNew == id));
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
                var myNew = db.News.SingleOrDefault(x => x.IDNew == id);
                myNew = Mapper.Map<News>(newsModel);
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
