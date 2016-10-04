using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnxProject_Franco.Controllers
{
    public class Converters
    {
        public static Models.NewsModel NewsToNewsModel(CONTRACTS.Entities.News x)
        {
            return new Models.NewsModel { Title = x.Title, ID = x.ID, Body = x.Body, CourtBranchId = x.CourtBranchId, Date = x.Date, LetterHead = x.LetterHead, Place = x.Place, Scope = x.Scope };
        }

        public static CONTRACTS.Entities.News NewsModelToNews(Models.NewsModel x)
        {
            return new CONTRACTS.Entities.News { Title = x.Title, ID = x.ID, Body = x.Body, CourtBranchId = x.CourtBranchId, Date = x.Date, LetterHead = x.LetterHead, Place = x.Place, Scope = x.Scope };
        }

        public static Models.CourtBranchModel CourtBranchConverter(CONTRACTS.Entities.CourtBranch cb)
        {
            return new Models.CourtBranchModel { ID = cb.ID, Name = cb.Name, Description = cb.Description, LawyersInIDs = cb.LawyersInIDs };
        }
    }
}