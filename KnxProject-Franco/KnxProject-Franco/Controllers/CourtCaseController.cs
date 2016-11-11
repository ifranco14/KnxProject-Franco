using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using WebMatrix.WebData;

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
        [Authorize(Roles ="admin,lawyer,client")]
        public ActionResult Index()
        {
            ViewBag.Clients = client.GetAllClients();
            ViewBag.States = states.GetAll();
            ViewBag.Lawyers = lawyer.GetAllLawyers();
            ViewBag.IDPersonType = lawyer.GetID(lawyer.GetIDPerson(WebSecurity.CurrentUserId));
            ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
            return View(courtCase.GetAll());
        }

        // GET: CourtCase/Details/5
        [Authorize(Roles ="admin,lawyer,client")]
        public ActionResult Details(int id)
        {
            return View(courtCase.GetAll());
        }

        // GET: CourtCase/Create
        [Authorize(Roles ="lawyer,admin,secretary")]
        public ActionResult Create()
        {
            ViewBag.States = states.GetAll();
            ViewBag.Lawyer = lawyer.GetLawyer(lawyer.GetID(lawyer.GetIDPerson(WebSecurity.CurrentUserId)));
            ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
            ViewBag.Clients = client.GetAllClients();
            return View();
        }

        // POST: CourtCase/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "lawyer,admin")]
        public ActionResult Create([Bind(Include ="IDCourtCase,IDClient,IDCurrentState,IDCourtBranch,IDLawyer,StartDate,Name",Exclude ="CourtCaseDetails")] CourtCaseModel cc)
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
                    ViewBag.Lawyer = lawyer.GetLawyer(lawyer.GetID(lawyer.GetIDPerson(WebSecurity.CurrentUserId)));
                    ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
                    ViewBag.Clients = client.GetAllClients();
                    return View(cc);
                }
            }
            else
            {
                ViewBag.States = states.GetAll();
                ViewBag.Lawyer = lawyer.GetLawyer(lawyer.GetID(lawyer.GetIDPerson(WebSecurity.CurrentUserId)));
                ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
                ViewBag.Clients = client.GetAllClients();
                return View(cc);
            }
        }

        // GET: CourtCase/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourtCase/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, [Bind(Include = "IDCourtCase,IDClient,IDCurrentState,IDCourtBranch,IDLawyer,StartDate,Name")] CourtCaseModel cc)
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
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourtCase/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id, [Bind(Include = "IDCourtCase,IDClient,IDCurrentState,IDCourtBranch,IDLawyer,StartDate,Name")] CourtCaseModel cc)
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
