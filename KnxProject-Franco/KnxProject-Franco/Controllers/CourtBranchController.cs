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
            ViewBag.Lawyers = lawyers.GetAll();

            return View();
        }

        // GET: CourtBranch/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourtBranch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtBranch/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourtBranch/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourtBranch/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CourtBranch/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourtBranch/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
