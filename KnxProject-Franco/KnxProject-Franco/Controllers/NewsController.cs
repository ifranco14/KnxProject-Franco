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
    public class NewsController : Controller
    {
        private myContext db = new myContext();

        // GET: News
        public ActionResult Index()
        {
            var news = new List<NewsModel> { new NewsModel { ID = 0, Title = "Primer Noticia", Date = DateTime.Today, CourtBranchId = 0, Place = "Rafaela", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete" },
                                                new NewsModel { ID = 1, Title = "Segunda Noticia", Date = DateTime.Today, CourtBranchId = 1, Place = "Sunchales", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete de la segunda noticia" }};
            return View(news);            
        }

        // GET: News/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsModel = db.NewsModels.Find(id);
            if (newsModel == null)
            {
                return HttpNotFound();
            }
            return View(newsModel);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            var list = new List<SelectListItem>{ new SelectListItem
                                                            {
                                                                Text = "",
                                                                Value = "",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama0",
                                                                Value = "0",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama1",
                                                                Value = "1",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama2",
                                                                Value = "2",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama3",
                                                                Value = "3",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama4",
                                                                Value = "4",
                                                            } };
            ViewBag.CourtBranches = list;
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourtBranchId,Title,Body,Place,Date,LetterHead")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                db.NewsModels.Add(newsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var list = new List<SelectListItem>{ new SelectListItem
                                                            {
                                                                Text = "",
                                                                Value = "",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama0",
                                                                Value = "0",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama1",
                                                                Value = "1",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama2",
                                                                Value = "2",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama3",
                                                                Value = "3",
                                                            }, new SelectListItem
                                                            {
                                                                Text = "Rama4",
                                                                Value = "4",
                                                            } };
            ViewBag.CourtBranches = list;
            //ViewBag.CourtBranches = new SelectList(
            //                                       db.CourtBranchModels.OrderBy(a => a.Name), "ID", "Name", newsModel.CourtBranchId);
            return View(newsModel);
        }

        // GET: News/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsModel = db.NewsModels.Find(id);
            if (newsModel == null)
            {
                return HttpNotFound();
            }
            return View(newsModel);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourtBranchId,Title,Body,Place,Date,LetterHead")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsModel);
        }

        // GET: News/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NewsModel newsModel = db.NewsModels.Find(id);
            if (newsModel == null)
            {
                return HttpNotFound();
            }
            return View(newsModel);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NewsModel newsModel = db.NewsModels.Find(id);
            db.NewsModels.Remove(newsModel);
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
