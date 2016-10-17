using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.Data;
using AutoMapper;

namespace KnxProject_Franco.SERVICES
{
    public class StateServices : IStates
    {
        private KnxProject_FrancoDBEntities db;

        public StateServices()
        {
            this.db = new KnxProject_FrancoDBEntities();
        }
        public List<StateModel> GetAll()
        {
            Mapper.Initialize(a => { a.CreateMap<States, StateModel>(); });
            return db.States.AsEnumerable().Select(States => Mapper.Map<States,StateModel>(States)).ToList();
        }
    }
}
