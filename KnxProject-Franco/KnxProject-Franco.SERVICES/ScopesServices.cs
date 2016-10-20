﻿using System;
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
    public class ScopesServices : IScope
    {
        private KnxProject_FrancoDBEntities db;
        public ScopesServices()
        {
            this.db = new KnxProject_FrancoDBEntities();
            Mapper.Initialize(a => { a.CreateMap<Scopes, ScopeModel>(); });
        }
        public List<ScopeModel> GetAll()
        {;
            return db.Scopes.AsEnumerable().Select(Scopes =>Mapper.Map<Scopes, ScopeModel>(Scopes)).ToList();
        }
    }
}
