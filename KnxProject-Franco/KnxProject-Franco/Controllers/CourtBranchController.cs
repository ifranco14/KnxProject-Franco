using KnxProject_Franco.CONTRACTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnxProject_Franco.Controllers
{
    public class CourtBranchController : Controller
    {
        private KnxProject_Franco.CONTRACTS.ICourtBranch courtbranch;
        private CONTRACTS.ILawyers lawyers;

        public CourtBranchController(CONTRACTS.ICourtBranch courtbranch, CONTRACTS.ILawyers lawyers)
        {
            this.courtbranch = courtbranch;
            this.lawyers = lawyers;
        }
        // GET: CourtBranch
        public ActionResult Index()
        {
            return View(courtbranch.GetAllCourtBranches());
        }

        // GET: CourtBranch/Details/5
        public ActionResult Details(int id)
        {         
            return View(courtbranch.Details(id)); //en caso de no funcionar, crear la variable arriba y luego pasarlo
        }

        // GET: CourtBranch/Create
        public ActionResult Create()
        {
            ViewBag.Lawyers = lawyers.GetAll();
            return View();
        }

        // POST: CourtBranch/Create
        [HttpPost]
        public ActionResult Create([Bind(Include ="ID,Name,Description")] CourtBranchModel cb)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                if (courtbranch.Create(cb))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Lawyers = lawyers.GetAll();
                    return View(cb);
                }
            }
            else
            {
                ViewBag.Lawyers = lawyers.GetAll();
                return View(cb);
            }
        }

        // GET: CourtBranch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourtBranch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include ="ID,Name,Description")] CourtBranchModel cb)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                if (courtbranch.Edit(id, cb))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cb);
                }
                
            }
            else
            {
                return View(cb);
            }
        }

        // GET: CourtBranch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourtBranch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, [Bind(Include = "ID,Name,Description")] CourtBranchModel cb)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add delete logic here
                if (courtbranch.Delete(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cb);
                }
                
            }
            else
            {
                return View(cb);
            }
        }
    }
}
