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

        public NewsController(INews _new, ICourtBranch courtBranch)
        {
            this._new = _new;
            this.courtBranch = courtBranch;
        }
        
        // GET: News
        public ActionResult Index()
        {
            //var news = new List<Models.NewsModel> { new Models.NewsModel { ID = 0, Title = "Primer Noticia", Date = DateTime.Today, CourtBranchId = 0, Place = "Rafaela", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete" },
            //                                    new Models.NewsModel { ID = 1, Title = "Segunda Noticia", Date = DateTime.Today, CourtBranchId = 1, Place = "Sunchales", Scope = "Local", Body = "Noticia1\r\n Dicen que bla bla bla bla \r asdasdasd", LetterHead = "este es el membrete de la segunda noticia" }};
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
            List<CourtBranchModel> courtBranches = courtBranch.GetAllCourtBranches();
            SelectList courtBranchesSelectList = new SelectList(courtBranches, "ID", "Name");
            ViewBag.CourtBranches = courtBranchesSelectList;

            CONTRACTS.INews _new = new SERVICES.NewsServices();
            ViewBag.Scopes = new SelectList(_new.GetScopes(), "Name", "Name");

            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,CourtBranchId,Title,Body,Place,Date,LetterHead,Scope")] NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                CONTRACTS.INews _new = new SERVICES.NewsServices();
                if (_new.Create(newsModel))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Couldn't create object in database
                    return View();
                }
            }
            else
            {
                List<CourtBranchModel> courtBranches = courtBranch.GetAllCourtBranches();
                SelectList courtBranchesSelectList = new SelectList(courtBranches, "ID", "Name", "CourtBranchId");
                ViewBag.CourtBranches = courtBranchesSelectList;
                
                ViewBag.Scopes = new SelectList(_new.GetScopes());

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
