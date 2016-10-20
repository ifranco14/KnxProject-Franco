using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;

namespace KnxProject_Franco.Controllers
{
    public class NewsController : Controller
    {        
        private INews _new;
        private ICourtBranch courtBranch;
        private IScope scope;  

        public NewsController(INews _new, ICourtBranch courtBranch, IScope scope)
        {
            this._new = _new;
            this.courtBranch = courtBranch;
            this.scope = scope;
        }
        
        // GET: News
        public ActionResult Index()
        {
            //var news = new List<Models.NewsModel> { new Models.NewsModel { ID = 0, Title = "Primer Noticia", Date = DateTime.Today, CourtBranchId = 0, Place = "Rafaela", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete" },
            //                                    new Models.NewsModel { ID = 1, Title = "Segunda Noticia", Date = DateTime.Today, CourtBranchId = 1, Place = "Sunchales", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete de la segunda noticia" }};
            ViewBag.Scopes = scope.GetAll();
            List<NewsModel> news = _new.GetAllNews().ToList();
            return View(news);
        }        

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            NewsModel myNew = _new.Details(id);
            return View(myNew);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            ViewBag.CourtBranches = new SelectList(courtBranch.GetAllCourtBranches(), "IDCourtBranch", "Name");

            ViewBag.Scopes = new SelectList(scope.GetAll(), "IDScope", "Description");

            return View();
        }

       
        



        // POST: News/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "IDNew,IDCourtBranch,Title,Body,Place,Date,LetterHead,IDScope,Image")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here                
                if (_new.Create(newsModel))
                {
                    if (newsModel.Image != null)
                    {
                        string ImageName = System.IO.Path.GetFileName(newsModel.Image.FileName);
                        string physicalPath = Server.MapPath("~/Content/img/News/" + ImageName);
                        // Guardo en la carpeta de imagenes
                        newsModel.Image.SaveAs(physicalPath);
                    }
                    
                    return RedirectToAction("Index");
                }
                else
                {
                    //Couldn't create object in database
                    ViewBag.CourtBranches = new SelectList(courtBranch.GetAllCourtBranches(), "IDCourtBranch", "Name");
                    ViewBag.Scopes = new SelectList(scope.GetAll(), "IDScope", "Description");
                    return View(newsModel);
                }
            }
            else
            {
                ViewBag.CourtBranches = new SelectList(courtBranch.GetAllCourtBranches(), "IDCourtBranch", "Name");

                ViewBag.Scopes = new SelectList(scope.GetAll(), "IDScope", "Description");

                return View(newsModel);
            }
        }

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {            
            return View();
        }

        // POST: News/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include = "ID,CourtBranchId,Title,Body,Place,Date,LetterHead,Scope")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                if (_new.Edit(id, newsModel))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(newsModel);
                }
            }
            else
            {
                return View(newsModel);
            }
        }

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: News/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, [Bind(Include = "ID,CourtBranchId,Title,Body,Place,Date,LetterHead,Scope")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add delete logic here
                if (_new.Delete(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(newsModel);
                }
                    
            }
            else
            {
                return View(newsModel);
            }
        }
    }
}
