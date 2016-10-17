using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using AutoMapper;
using KnxProject_Franco.Data;

namespace KnxProject_Franco.SERVICES
{
    public class CourtCaseServices : ICourtCase
    {
        private KnxProject_FrancoDBEntities db;
        public CourtCaseServices()
        {
            this.db = new KnxProject_FrancoDBEntities();
        }
        public bool Create(CourtCaseModel cc)
        {
            Mapper.Initialize(a => { a.CreateMap<CourtCaseModel, CourtCases>(); });
            var myCc = Mapper.Map<CourtCases>(cc);
            
            db.CourtCases.Add(myCc);
            db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            try
            {
                db.CourtCases.Remove(db.CourtCases.Where(x => x.IDCourtCase == id).FirstOrDefault());
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public CourtCaseModel Details(int id)
        {
            return Mapper.Map<CourtCaseModel>(db.CourtCases.Where(x => x.IDCourtCase == id).FirstOrDefault());
        }

        public bool Edit(int id, CourtCaseModel cc)
        {
            Mapper.Initialize(a => { a.CreateMap<CourtCaseModel, CourtCases>(); });
            try
            {
                var myCc = db.CourtCases.Where(x => x.IDCourtCase == id).FirstOrDefault();
                myCc = Mapper.Map<CourtCases>(cc);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public List<CourtCaseModel> GetAll()
        {
            Mapper.Initialize(a => { a.CreateMap<CourtCases, CourtCaseModel>(); });
            return db.CourtCases.AsEnumerable().Select(CourtCases => Mapper.Map<CourtCases, CourtCaseModel>(CourtCases)).ToList();           
        }
                
    }
}
