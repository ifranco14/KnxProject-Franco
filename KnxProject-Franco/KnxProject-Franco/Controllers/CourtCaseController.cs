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
        private IPerson lawyer;
        private ICourtBranch courtBranch;
        private IStates states;
        private IPerson client;

        public CourtCaseController(ICourtCase courtCase, IPerson lawyer, ICourtBranch courtBranch, IStates states, IPerson client)
        {
            this.courtCase = courtCase;
            this.lawyer = lawyer;
            this.courtBranch = courtBranch;
            this.states = states;
            this.client = client;
        }
        // GET: CourtCase
        public ActionResult Index()
        {

            return View(courtCase.GetAll());
        }

        // GET: CourtCase/Details/5
        public ActionResult Details(int id)
        {
            return View(courtCase.GetAll());
        }

        // GET: CourtCase/Create
        public ActionResult Create()
        {
            ViewBag.States = new SelectList(states.GetAll(), "ID", "Description");
            ViewBag.Lawyers = new SelectList(lawyer.GetAllLawyers(), "IDLawyer", "LastName");
            ViewBag.CourtBranches = new SelectList(courtBranch.GetAllCourtBranches(), "ID", "Name");
            ViewBag.Clients = new SelectList(client.GetAllActiveClients(), "IDClient", "LastName");
            return View();
        }

        // POST: CourtCase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include ="ID,ClientID,CurrentStatusId,CourtBranchId,LawyerId,StartDate",Exclude ="CourtCaseDetails")] CourtCaseModel cc)
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
                    ViewBag.Lawyers = lawyer.GetAllLawyers();
                    ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
                    return View(cc);
                }
            }
            else
            {
                ViewBag.States = states.GetAll();
                ViewBag.Lawyers = lawyer.GetAllLawyers();
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
