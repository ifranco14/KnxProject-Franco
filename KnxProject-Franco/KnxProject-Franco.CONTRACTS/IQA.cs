using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.CONTRACTS
{
    public interface IQA
    {
        bool Create(QAModel qa);
        bool Edit(int id, QAModel qa);
        bool Delete(int id);
        QAModel Details(int id);
        bool AnswerQuestion(int id, QAModel qa);
        List<QAModel> GetAllOfACase(int idCase);
        List<QAModel> GetAllOfALawyer(int idLawyer);
        List<QAModel> GetAllOfAClient(int idClient);
    }
}
