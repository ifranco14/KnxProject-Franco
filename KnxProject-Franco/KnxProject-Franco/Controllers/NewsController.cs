using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnxProject_Franco.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            //var news = new List<Models.NewsModel> { new Models.NewsModel { ID = 0, Title = "Primer Noticia", Date = DateTime.Today, CourtBranchId = 0, Place = "Rafaela", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete" },
            //                                    new Models.NewsModel { ID = 1, Title = "Segunda Noticia", Date = DateTime.Today, CourtBranchId = 1, Place = "Sunchales", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete de la segunda noticia" }};
            CONTRACTS.INews _new = new SERVICES.News();
            List<Models.NewsModel> a = _new.GetAllNews().ConvertAll(new Converter<CONTRACTS.Entities.News, Models.NewsModel>(NewsConverting));

            return View(a);
        }
        public static Models.NewsModel NewsConverting(CONTRACTS.Entities.News x)
        {
            return new Models.NewsModel {Title=x.Title, ID = x.ID, Body = x.Body, CourtBranchId=x.CourtBranchId, Date = x.Date, LetterHead = x.LetterHead, Place = x.Place, Scope = x.Scope};
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,CourtBranchId,Title,Body,Place,Date,LetterHead")] Models.NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            else
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
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: News/Edit/5
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

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: News/Delete/5
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
