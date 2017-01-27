using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueAssistWeb.Controllers
{
    public class CupController : Controller
    {
        // GET: Cup
        public ActionResult Index()
        {
            List<SelectListItem> cups = new List<SelectListItem>{
                new SelectListItem{ Text="Kup 1", Value="1" },
                new SelectListItem{ Text="Kup 2", Value="2" },
                new SelectListItem{ Text="Kup 3", Value="3" }
            };

            List<SelectListItem> seasons = new List<SelectListItem>{
                new SelectListItem{ Text="2013/2014", Value="1" },
                new SelectListItem{ Text="2014/2015", Value="2" },
                new SelectListItem{ Text="2015/2016", Value="3" }
            };

            List<SelectListItem> phases = new List<SelectListItem>{
                new SelectListItem{ Text="1. faza", Value="1" },
                new SelectListItem{ Text="2. faza", Value="2" },
                new SelectListItem{ Text="3. faza", Value="3" }
            };

            ViewBag.fazaID = phases;
            ViewBag.sezonaID = seasons;
            ViewBag.competitionID = cups;

            return View();
        }

        // GET: Cup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cup/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cup/Edit/5
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

        // GET: Cup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cup/Delete/5
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
