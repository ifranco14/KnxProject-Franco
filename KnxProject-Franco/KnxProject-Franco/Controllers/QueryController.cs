using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KnxProject_Franco.CONTRACTS;
using KnxProject_Franco.CONTRACTS.Entities;
using WebMatrix.WebData;
using System.Web.Security;

namespace KnxProject_Franco.Controllers
{
    public class QueryController : Controller
    {
        private IPerson person;
        private IQA query;
        private ICourtCase courtCase;
        private ICourtCaseDetails courtCaseDetails;
        private ICourtBranch courtBranch;

        public QueryController(IPerson person, IQA query, ICourtCase courtCase, ICourtCaseDetails courtCaseDetails, ICourtBranch courtBranch)
        {
            this.query = query;
            this.person = person;
            this.courtCase = courtCase;
            this.courtCaseDetails = courtCaseDetails;
            this.courtBranch = courtBranch;
        }
        // GET: Query
        [Authorize(Roles ="lawyer,client")]
        public ActionResult Index()
        {
            ViewBag.CourtCases = courtCase.GetAll();
            ViewBag.CourtCaseDetails = courtCaseDetails.GetAll();
            if (Roles.IsUserInRole("lawyer"))
            {
                ViewBag.Clients = person.GetAllClients();
                return View(query.GetAllOfALawyer(person.GetID(person.GetIDPerson(WebSecurity.CurrentUserId))));
            }
            else
            {
                ViewBag.Lawyers = person.GetAllLawyers();
                return View(query.GetAllOfAClient(person.GetID(person.GetIDPerson(WebSecurity.CurrentUserId))));
            }
        }

        

        // GET: Query/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Query/Create
        [Authorize(Roles = "client")]
        ///ESPERA UN ID DE COURTCASEDETAIL
        public ActionResult Create(int id)
        {            
            var ccd = courtCaseDetails.GetCourtCaseDetail(id);
            ViewBag.CourtCaseDetail = ccd;
            var cc = courtCase.GetCourtCase(ccd.IDCourtCase);
            ViewBag.CourtCase = cc;
            ViewBag.Lawyer = person.GetLawyer(cc.IDLawyer);
            return View();
        }

        // POST: Query/Create
        [Authorize(Roles="client")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create([Bind(Include ="IDQA,IDCourtCase,IDCourtCaseDetails,IDLawyer,Query")]QAModel q)
        {
            if (ModelState.IsValid)
            {
                q.SendDate = DateTime.Today;
                query.Create(q);
                return RedirectToAction("Index");
            }
            else
            {
                return View(q);
            }
        }

        // GET: Query/CreateAnonymus
        [AllowAnonymous]
        public ActionResult CreateAnonymus()
        {
            ViewBag.Lawyers = person.GetAllLawyers();
            ViewBag.CourtBranches = courtBranch.GetAllCourtBranches();
            return View();
        }

        // POST: Query/CreateAnonymus
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateAnonymus([Bind(Include = "IDQA,IDLawyer,Query,SendDate,Name,Email")]QAModel q)
        {
            if (ModelState.IsValid)
            {
                query.Create(q);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(q);
            }
        }

        public ActionResult Answer()
        {
            return View();
        }
        public ActionResult Answer([Bind(Include = "Answer")]QAModel q)
        {
            //TODO: responder a una consulta de un cliente
            
        }

        public ActionResult AnswerAnonymus()
        {
            return View();
        }
        public ActionResult AnswerAnonymus([Bind(Include = "Answer")]QAModel q)
        {
            //TODO: responder a una consulta de una persona x que entró a la página (enviar respuesta a su mail)
        }
    }
}
