using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.Data;
using AutoMapper;

namespace KnxProject_Franco.SERVICES
{
    public class CourtBranchServices : CONTRACTS.ICourtBranch
    {
        private KnxProject_FrancoDBEntities db;
        public CourtBranchServices()
        {
            this.db = new KnxProject_FrancoDBEntities();
        }
        public bool Create(CourtBranchModel cb)
        {
            try
            {
                db.CourtBranches.Add(new CourtBranches
                {
                    IDCourtBranch = cb.IDCourtBranch,
                    Description = cb.Description,
                    Name = cb.Name,
                    
                    
                    
                });
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                db.CourtBranches.Remove(db.CourtBranches.FirstOrDefault(x => x.IDCourtBranch == id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }


        }

        public CourtBranchModel Details(int id)
        {
            var myCb = db.CourtBranches.FirstOrDefault(x => x.IDCourtBranch == id);
            CourtBranchModel cb = new CourtBranchModel { IDCourtBranch = myCb.IDCourtBranch, Description = myCb.Description, Name = myCb.Name };
            return cb;
        }

        public bool Edit(int id, CourtBranchModel cb)
        {
            try
            {
                //List<Lawyers> cbLawyers = new List<Lawyers>();
                //foreach (var a in cb.Lawyers)
                //{
                //    var l = db.Lawyers.FirstOrDefault(x => x.IDLawyer == a.IDLawyer);
                //    cbLawyers.Add(l);
                //}

                var myCb = db.CourtBranches.FirstOrDefault(x => x.IDCourtBranch == id);
                myCb.Name = cb.Name;
                //myCb.Lawyers = cbLawyers;
                myCb.Description = cb.Description;

                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<CourtBranchModel> GetAllCourtBranches()
        {
            var myCb = db.CourtBranches.ToList();
            List<CourtBranchModel> list = new List<CourtBranchModel>();
            foreach (var n in myCb)
            {
                CourtBranchModel cb = new CourtBranchModel();
                cb.IDCourtBranch = n.IDCourtBranch;
                cb.Name = n.Name;
                cb.Description = n.Description;
                list.Add(cb);
            }

            return list;
        }
    }
}
