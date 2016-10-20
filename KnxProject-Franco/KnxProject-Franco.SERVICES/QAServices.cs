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
            Mapper.Initialize(cfg => { cfg.CreateMap<QAs, QAModel>().ReverseMap(); });
        }

        public bool AnswerQuestion(int id, QAModel qa)
        {
            throw new NotImplementedException();
        }

        public bool Create(QAModel qa)
        {
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
                return true;
            }
            catch
            {
                return false;
            }
        }

        public QAModel Details(int id)
        {
            return Mapper.Map<QAs, QAModel>(db.QAs.FirstOrDefault(x => x.IDQA == id)); 
        }

        public bool Edit(int id, QAModel qa)
        {
            try
            {
                var myQA = db.QAs.FirstOrDefault(x => x.IDQA == id);
                myQA = Mapper.Map<QAs>(qa);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
