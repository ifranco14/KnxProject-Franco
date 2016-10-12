using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.Controllers
{
    public class CourtCaseController : Controller
    {
        private ICourtCase courtCase;
        private ILawyers lawyer;
        private ICourtBranch courtBranch;
        private IStates states;

        public CourtCaseController(ICourtCase courtCase, ILawyers lawyer, ICourtBranch courtBranch, IStates states)
        {
            this.courtCase = courtCase;
            this.lawyer = lawyer;
            this.courtBranch = courtBranch;
            this.states = states;
        }
        // GET: CourtCase
        public ActionResult Index()
        {
            return View();
        }

        // GET: CourtCase/Details/5
        public ActionResult Details(int id)
        {
            return View(courtCase.GetAll());
        }

        // GET: CourtCase/Create
        public ActionResult Create()
        {
            ViewBag.States = states.GetAll();
            ViewBag.Lawyers = lawyer.GetAll();
            ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
            return View();
        }

        // POST: CourtCase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID,ClientID,CurrentStatusId,CourtBranchId,LawyerId,StartDate")] CourtCaseModel cc)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                if (courtCase.Create(cc))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.States = states.GetAll();
                    ViewBag.Lawyers = lawyer.GetAll();
                    ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
                    return View(cc);
                }
            }
            else
            {
                ViewBag.States = states.GetAll();
                ViewBag.Lawyers = lawyer.GetAll();
                ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
                return View(cc);
            }
        }

        // GET: CourtCase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourtCase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "ID,ClientID,CurrentStatusId,CourtBranchId,LawyerId,StartDate")] CourtCaseModel cc)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                if (courtCase.Edit(id, cc))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cc);
                }
            }
            else
            {
                return View(cc);
            }
        }

        // GET: CourtCase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourtCase/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, [Bind(Include = "ID,ClientID,CurrentStatusId,CourtBranchId,LawyerId,StartDate")] CourtCaseModel cc)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add delete logic here
                if (courtCase.Delete(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(cc);
                }
            }
            else
            {
                return View(cc);
            }
        }
    }
}
