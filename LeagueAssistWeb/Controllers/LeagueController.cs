using LeagueAssist;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueAssistWeb.Controllers
{
    public class LeagueController : Controller
    {
        public List<ListOfMatch> _listOfAllMatche;
        List<SelectListItem> seasons = new List<SelectListItem>();
        List<SelectListItem> leagues = new List<SelectListItem>();
        List<SelectListItem> fixtures = new List<SelectListItem>();
        
        // GET: League
        public ActionResult Index()
        {
            MatchProcessor _matchProcessor = new MatchProcessor();
            _listOfAllMatche = _matchProcessor.RetrieveListOfAllMatch();

            

            foreach (ListOfMatch _lom in _listOfAllMatche)
            {
                if (!leagues.Exists(x => x.Value == _lom.Competition_Id.ToString()))
                {
                    leagues.Add(new SelectListItem { Text = _lom.CompetitionName, Value = _lom.Competition_Id.ToString() });
                }
                if (!seasons.Exists(x => x.Value == _lom.Season_Id.ToString()))
                {
                    seasons.Add(new SelectListItem { Text = _lom.SeasonName, Value = _lom.Season_Id.ToString() });
                }
                if (!fixtures.Exists(x => x.Value == _lom.Fixture_Id.ToString()))
                {
                    fixtures.Add(new SelectListItem { Text = _lom.FixtureName, Value = _lom.Fixture_Id.ToString() });
                }
            }

            /*
            List<SelectListItem> seasons = new List<SelectListItem>{
                new SelectListItem{ Text="2013/2014", Value="1" },
                new SelectListItem{ Text="2014/2015", Value="2" },
                new SelectListItem{ Text="2015/2016", Value="3" }
            };

            List<SelectListItem> fixtures = new List<SelectListItem>{
                new SelectListItem{ Text="1. kolo", Value="1" },
                new SelectListItem{ Text="2. kolo", Value="2" },
                new SelectListItem{ Text="3. kolo", Value="3" }
            };

            List<SelectListItem> leagues = new List<SelectListItem>{
                new SelectListItem{ Text="1. HNL", Value="1" },
                new SelectListItem{ Text="2. HNL", Value="2" },
                new SelectListItem{ Text="3. HNL", Value="3" }
            };*/
            

            ViewBag.sezonaID = seasons;
            ViewBag.koloID = fixtures;
            ViewBag.ligaID = leagues;
            
            
            return View();
        }

        // GET: League/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: League/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: League/Create
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

        // GET: League/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: League/Edit/5
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

        // GET: League/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: League/Delete/5
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
