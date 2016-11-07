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
    [Authorize(Roles ="lawyer,client,admin")]
    public class CourtCaseDetailController : Controller
    {
        public int idCase;
        private ICourtCaseDetails courtCaseDetail;
        private ICourtCase courtcase;
        private IStates state;
        public CourtCaseDetailController (ICourtCaseDetails courtCaseDetail, ICourtCase courtcase, IStates state)
        {
            this.courtCaseDetail = courtCaseDetail;
            this.courtcase = courtcase;
            this.state = state;
        }
        // GET: CourtCaseDetail
        [Authorize(Roles ="lawyer,client,admin")]
        public ActionResult Index(int id)
        {
            idCase = id;
            ViewBag.IdCase = id;
            ViewBag.CourtCases = courtcase.GetAll();
            ViewBag.States = state.GetAll();
            return View(courtCaseDetail.GetAllOfACase(id));
        }

        // GET: CourtCaseDetail/Details/5
        [Authorize(Roles = "lawyer,client,admin")]
        public ActionResult Details(int id)
        {
            return View(courtCaseDetail.GetCourtCaseDetail(id));
        }

        // GET: CourtCaseDetail/Create
        [Authorize(Roles = "lawyer")]
        public ActionResult Create()
        {
            ViewBag.States = state.GetAll();
            return View();
        }

        // POST: CourtCaseDetail/Create
        [Authorize(Roles = "lawyer")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Include ="IDCourtCaseDetail,IDCourtCase,Comment,Date,IDState")] CourtCaseDetailModel ccd)
        {
            if (ModelState.IsValid)
            {
                ccd.IDCourtCase = idCase;
                courtCaseDetail.Create(ccd);
                return RedirectToAction("Index", idCase);
            }
            else
            {
                ViewBag.States = state.GetAll();
                return View(ccd);
            }
        }

        // GET: CourtCaseDetail/Edit/5
        [Authorize(Roles = "lawyer")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourtCaseDetail/Edit/5
        [Authorize(Roles = "lawyer")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "IDCourtCaseDetail,IDCourtCase,Comment,Date,IDState")] CourtCaseDetailModel ccd)
        {
            if (ModelState.IsValid)
            {
                courtCaseDetail.Edit(id,ccd);
                return RedirectToAction("Index");
            }
            else
            {
                return View(ccd);
            }
        }

        // GET: CourtCaseDetail/Delete/5
        [Authorize(Roles = "lawyer,admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CourtCaseDetail/Delete/5
        [Authorize(Roles = "lawyer,admin")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Delete(int id, [Bind(Include = "IDCourtCaseDetail,IDCourtCase,Comment,Date,IDState")] CourtCaseDetailModel ccd)
        {
            if (ModelState.IsValid)
            {
                courtCaseDetail.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View(ccd);
            }
        }
    }
}
