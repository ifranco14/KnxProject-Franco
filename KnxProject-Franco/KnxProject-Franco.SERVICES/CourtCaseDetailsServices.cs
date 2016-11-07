using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.Data;

namespace KnxProject_Franco.SERVICES
{
    public class CourtCaseDetailsServices: ICourtCaseDetails
    {
        private KnxProject_FrancoDBEntities db;
        public CourtCaseDetailsServices()
        {
            db = new KnxProject_FrancoDBEntities();
        }
        public bool Create(CourtCaseDetailModel ccd)
        {
            try
            {
                CourtCaseDetails myCcd = new CourtCaseDetails
                {
                    IDCourtCase = ccd.IDCourtCase,
                    IDCourtCaseDetail = ccd.IDCourtCaseDetail,
                    IDState = ccd.IDState,
                    Comment = ccd.Comment,
                    Date = ccd.Date
                };
                db.CourtCaseDetails.Add(myCcd);
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
                db.CourtCaseDetails.Remove(db.CourtCaseDetails.Where(x => x.IDCourtCaseDetail == id).FirstOrDefault());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(int id, CourtCaseDetailModel ccd)
        {
            try
            {
                CourtCaseDetails myCcd = db.CourtCaseDetails.Where(x => x.IDCourtCaseDetail == id).FirstOrDefault();
                myCcd.IDCourtCase = ccd.IDCourtCase;
                myCcd.IDCourtCaseDetail = ccd.IDCourtCaseDetail;
                myCcd.IDState = ccd.IDState;
                myCcd.Comment = ccd.Comment;
                myCcd.Date = ccd.Date;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<CourtCaseDetailModel> GetAllOfACase(int id)
        {
            AutoMapper.Mapper.Initialize(a => a.CreateMap<QAs, QAModel>());
            List<CourtCaseDetailModel> listCcd = new List<CourtCaseDetailModel>();
            foreach (var ccd in db.CourtCaseDetails.Where(x => x.IDCourtCase == id).ToList())
            {
                var myCcd = new CourtCaseDetailModel
                {
                    IDCourtCase = ccd.IDCourtCase,
                    IDCourtCaseDetail = ccd.IDCourtCaseDetail,
                    IDState = ccd.IDState,
                    Comment = ccd.Comment,
                    Date = ccd.Date,
                    QA = db.QAs.AsEnumerable().Where(x => x.IDCourtCaseDetail == ccd.IDCourtCaseDetail).Select(QAs => AutoMapper.Mapper.Map<QAs, QAModel>(QAs)).ToList()
                };
                listCcd.Add(myCcd);
            }
            return listCcd;
        }

        public CourtCaseDetailModel GetCourtCaseDetail(int idCourtCase)
        {
            AutoMapper.Mapper.Initialize(a => a.CreateMap<QAs,QAModel>());
            var ccd = db.CourtCaseDetails.FirstOrDefault(x => x.IDCourtCase == idCourtCase);
            var myCcd = new CourtCaseDetailModel
            {
                IDCourtCase = ccd.IDCourtCase,
                IDCourtCaseDetail = ccd.IDCourtCaseDetail,
                IDState = ccd.IDState,
                Comment = ccd.Comment,
                Date = ccd.Date,
                QA = db.QAs.AsEnumerable().Where(x => x.IDCourtCaseDetail == ccd.IDCourtCaseDetail).Select(QAs => AutoMapper.Mapper.Map<QAs, QAModel>(QAs)).ToList()
            };
            return myCcd;
        }
    }
}
