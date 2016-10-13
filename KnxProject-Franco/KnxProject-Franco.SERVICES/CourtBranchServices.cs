﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;
using KnxProject_Franco.Data;
using AutoMapper;

namespace KnxProject_Franco.SERVICES
{
    public class CourtBranchServices: CONTRACTS.ICourtBranch
    {
        private KnxProject_FrancoDBEntities db;
        public CourtBranchServices()
        {
            this.db = new KnxProject_FrancoDBEntities();
        }
        public bool Create(CourtBranchModel cb)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }

        public CourtBranchModel Details(int id)
        {
            return new CourtBranchModel();
        }

        public bool Edit(int id, CourtBranchModel cb)
        {
            return true;
        }

        public List<CONTRACTS.Entities.CourtBranchModel> GetAllCourtBranches()
        {
            
            Mapper.Initialize(a => { a.CreateMap<CourtBranches, CourtBranchModel>(); });

            return db.CourtBranches.AsEnumerable().Select(CourtBranches => (Mapper.Map<CourtBranches, CourtBranchModel>(CourtBranches))).ToList();
        }
    }
}
