using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.Models;

namespace KnxProject_Franco.Controllers
{
    public class CourtBranchController : Controller
    {
        private myContext db = new myContext();

        // GET: CourtBranch
        public ActionResult Index()
        { 
            var cb = new List<CourtBranchModel> { new CourtBranchModel
                                                             { Name = "Derecho Penal", Description = "Esta es la descripcion del derecho penal" },
                                                       new CourtBranchModel
                                                             { Name = "Derecho Empresarial", Description = "Esta es la descripcion del derecho empresarial" },
                                                       new CourtBranchModel
                                                             { Name = "Derecho Comercial", Description = "Esta es la descripcion del derecho comercial" },
                                                       new CourtBranchModel
                                                             {Name = "Bienes Raíces", Description = "Esta es la descripción de bienes raíces" } };
            ViewBag.CourtBranches = cb;

            //    if (db.CourtCaseModels.Count() > 0)
            //    {
            //        return View(db.CourtBranchModels.ToList());
            //    }
            return View(cb);
        }

        // GET: CourtBranch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtBranchModel courtBranchModel = db.CourtBranchModels.Find(id);
            if (courtBranchModel == null)
            {
                return HttpNotFound();
            }
            return View(courtBranchModel);
        }

        // GET: CourtBranch/Create
        public ActionResult Create()
        {
            var lawyers = new List<SelectListItem> { new SelectListItem { Text = "Ignacio Franco", Value = "0" },
                                                                new SelectListItem { Text = "Andrés Franco", Value = "1" },
                                                                new SelectListItem { Text = "Francisco Franco", Value = "2" }};
            ViewBag.Lawyers = lawyers;
            return View();
        }

        // POST: CourtBranch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description")] CourtBranchModel courtBranchModel)
        {
            if (ModelState.IsValid)
            {
                db.CourtBranchModels.Add(courtBranchModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var lawyers = new List<SelectListItem> { new SelectListItem { Text = "Ignacio Franco", Value = "0" },
                                                                new SelectListItem { Text = "Andrés Franco", Value = "1" },
                                                                new SelectListItem { Text = "Francisco Franco", Value = "2" }};
            ViewBag.Lawyers = lawyers;
            return View(courtBranchModel);
        }

        // GET: CourtBranch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtBranchModel courtBranchModel = db.CourtBranchModels.Find(id);
            if (courtBranchModel == null)
            {
                return HttpNotFound();
            }
            return View(courtBranchModel);
        }

        // POST: CourtBranch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description")] CourtBranchModel courtBranchModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courtBranchModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courtBranchModel);
        }

        // GET: CourtBranch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourtBranchModel courtBranchModel = db.CourtBranchModels.Find(id);
            if (courtBranchModel == null)
            {
                return HttpNotFound();
            }
            return View(courtBranchModel);
        }

        // POST: CourtBranch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourtBranchModel courtBranchModel = db.CourtBranchModels.Find(id);
            db.CourtBranchModels.Remove(courtBranchModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
