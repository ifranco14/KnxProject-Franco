using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.Data;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.CONTRACTS;
using AutoMapper;

namespace KnxProject_Franco.SERVICES
{
    public class QAServices : IQA
    {
        private KnxProject_FrancoDBEntities db;
        public QAServices()
        {
            db = new KnxProject_FrancoDBEntities();
            
        }

        public bool AnswerQuestion(int id, QAModel qa)
        {
            try
            {
                var myQ = db.QAs.FirstOrDefault(x => x.IDQA == id);
                myQ.Answer = qa.Answer;
                myQ.AnswerDate = DateTime.Today;
                db.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Create(QAModel qa)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<QAModel, QAs>().ReverseMap(); });
            try
            {
                QAs myQA = Mapper.Map<QAModel, QAs>(qa); //Ver si anda, sino inicializar el mapeador, sino mapear a pata
                db.QAs.Add(myQA);
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
                db.QAs.Remove(db.QAs.FirstOrDefault(x => x.IDQA == id));
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public QAModel Details(int id)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<QAs, QAModel>().ReverseMap(); });
            return Mapper.Map<QAs, QAModel>(db.QAs.FirstOrDefault(x => x.IDQA == id)); 
        }

        public bool Edit(int id, QAModel qa)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<QAModel, QAs>().ReverseMap(); });
            try
            {
                var myQA = db.QAs.FirstOrDefault(x => x.IDQA == id);
                myQA = Mapper.Map<QAs>(qa);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<QAModel> GetAllOfACase(int idCase)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<QAs, QAModel>().ReverseMap(); });
            List<QAModel> myQAs = new List<QAModel>();
            foreach (var query in db.QAs.ToList())
            {
                if (query.IDCourtCase == idCase)
                {
                    var myQA = Mapper.Map<QAModel>(query);
                    myQAs.Add(myQA);
                }
            }
            return myQAs;
        }
        public List<QAModel> GetAllOfALawyer(int idLawyer)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<QAs, QAModel>().ReverseMap(); });
            List<QAModel> myQAs = new List<QAModel>();
            foreach (var query in db.QAs.ToList())
            {
                if (query.IDLawyer == idLawyer)
                {
                    var myQA = Mapper.Map<QAModel>(query);
                    myQAs.Add(myQA);
                }
            }
            return myQAs;
        }
        public List<QAModel> GetAllOfAClient(int idClient)
        {
            Mapper.Initialize(cfg => { cfg.CreateMap<QAs, QAModel>().ReverseMap(); });
            List<QAModel> myQAs = new List<QAModel>();
            foreach (var courtCase in db.CourtCases.ToList())
            {
                if (courtCase.IDClient == idClient)
                {
                    foreach (var query in db.QAs.Where(x => x.IDCourtCase == courtCase.IDCourtCase).ToList())
                    {
                        var myQA = Mapper.Map<QAModel>(query);
                        myQAs.Add(myQA);
                    }
                }
            }            
            return myQAs;
        }
    }
}
