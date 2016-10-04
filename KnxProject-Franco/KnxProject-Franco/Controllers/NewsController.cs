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
            CONTRACTS.INews _new = new SERVICES.NewsServices();
            List<Models.NewsModel> news = _new.GetAllNews().ConvertAll(new Converter<CONTRACTS.Entities.News, Models.NewsModel>(Converters.NewsToNewsModel));
            return View(news);
        }        

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            CONTRACTS.INews _new = new SERVICES.NewsServices();
            Models.NewsModel myNew = Converters.NewsToNewsModel(_new.Details(id));
            return View(myNew);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            CONTRACTS.ICourtBranch _courtBranch = new SERVICES.CourtBranchServices();
            List<Models.CourtBranchModel> courtBranches = _courtBranch.GetAllCourtBranches().ConvertAll(new Converter<CONTRACTS.Entities.CourtBranch, Models.CourtBranchModel>(Converters.CourtBranchConverter));
            SelectList courtBranchesSelectList = new SelectList(courtBranches, "ID", "Name");
            ViewBag.CourtBranches = courtBranchesSelectList;

            CONTRACTS.INews _new = new SERVICES.NewsServices();
            ViewBag.Scopes = new SelectList(_new.GetScopes(), "Name", "Name");

            return View();
        }

        // POST: News/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,CourtBranchId,Title,Body,Place,Date,LetterHead,Scope")] Models.NewsModel newsModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add insert logic here
                CONTRACTS.INews _new = new SERVICES.NewsServices();
                if (_new.Create(Converters.NewsModelToNews(newsModel)))
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
                CONTRACTS.ICourtBranch _courtBranch = new SERVICES.CourtBranchServices();
                List<Models.CourtBranchModel> courtBranches = _courtBranch.GetAllCourtBranches().ConvertAll(new Converter<CONTRACTS.Entities.CourtBranch, Models.CourtBranchModel>(Converters.CourtBranchConverter));
                SelectList courtBranchesSelectList = new SelectList(courtBranches, "ID", "Name", "CourtBranchId");
                ViewBag.CourtBranches = courtBranchesSelectList;

                CONTRACTS.INews _new = new SERVICES.NewsServices();
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
