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
    public class QuestionAnswerController : Controller
    {
        private myContext db = new myContext();

        // GET: QuestionAnswer
        public ActionResult Index()
        {
            if (db.QAModels.Count() > 0)
            {

                return View(db.QAModels.ToList());
            }
            return View();
        }

        // GET: QuestionAnswer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAModel qAModel = db.QAModels.Find(id);
            if (qAModel == null)
            {
                return HttpNotFound();
            }
            return View(qAModel);
        }

        // GET: QuestionAnswer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionAnswer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourtCaseID,CourtCaseDetailID,Query,SendDate,Answer,AswerDate")] QAModel qAModel)
        {
            if (ModelState.IsValid)
            {
                db.QAModels.Add(qAModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(qAModel);
        }

        // GET: QuestionAnswer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAModel qAModel = db.QAModels.Find(id);
            if (qAModel == null)
            {
                return HttpNotFound();
            }
            return View(qAModel);
        }

        // POST: QuestionAnswer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourtCaseID,CourtCaseDetailID,Query,SendDate,Answer,AswerDate")] QAModel qAModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qAModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qAModel);
        }

        // GET: QuestionAnswer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QAModel qAModel = db.QAModels.Find(id);
            if (qAModel == null)
            {
                return HttpNotFound();
            }
            return View(qAModel);
        }

        // POST: QuestionAnswer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QAModel qAModel = db.QAModels.Find(id);
            db.QAModels.Remove(qAModel);
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
