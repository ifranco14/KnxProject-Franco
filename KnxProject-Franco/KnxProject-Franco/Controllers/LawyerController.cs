using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnxProject_Franco.Controllers
{
    public class LawyerController : Controller
    {
        private IPerson lawyers;
        private ICourtBranch courtBranch;
        public LawyerController(IPerson lawyers, ICourtBranch courtBranch)
        {
            this.lawyers = lawyers;
            this.courtBranch = courtBranch;
        }
        // GET: Lawyer
        public ActionResult Index()
        {
            ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
            return View(lawyers.GetAllLawyers());
        }

        // GET: Lawyer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

        // POST: Lawyer/Create
        [HttpPost]
        public ActionResult Create(LawyerModel l)
        {
            try
            {
                // TODO: Add insert logic here
                lawyers.CreateLawyer(l);
                //p.CreateLawyer(p, p.ProfessionalLicense, p.ContractDate, p.CourtBranchID);
                return View();
            }
            catch
            {
                return View(l);
            }
        }

        // GET: Lawyer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Lawyer/Edit/5
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

        // GET: Lawyer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lawyer/Delete/5
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
