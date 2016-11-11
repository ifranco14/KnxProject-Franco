using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.Data;
using AutoMapper;

namespace KnxProject_Franco.SERVICES
{
    public class AboutServices : IAbout
    {
        private KnxProject_FrancoDBEntities db;
        public AboutServices()
        {
            this.db = new KnxProject_FrancoDBEntities();
        }

        public bool Edit(int id, AboutModel about)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<About, AboutModel>().ReverseMap());
                var myA = db.About.FirstOrDefault(x => x.ID == id);
                Mapper.Map(about, myA, typeof(AboutModel), typeof(About));
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }

        }

        public AboutModel Get(int id)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<About, AboutModel>().ReverseMap());
            return Mapper.Map<AboutModel>(db.About.FirstOrDefault(x => x.ID == id));
        }
    }
}
