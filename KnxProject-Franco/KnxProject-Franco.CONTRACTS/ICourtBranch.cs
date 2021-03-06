﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.CONTRACTS
{
    public interface ICourtBranch
    {
        List<CourtBranchModel> GetAllCourtBranches();
        CourtBranchModel Details(int id);
        bool Create(CourtBranchModel cb);
        bool Edit(int id, CourtBranchModel cb);
        bool Delete(int id);

    }
}
