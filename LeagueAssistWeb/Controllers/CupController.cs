using LeagueAssist;
using LeagueAssist.Entities;
using LeagueAssistWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueAssistWeb.Controllers
{
    public class CupController : Controller
    {
        public List<ListOfMatch> _listOfAllMatche;
        List<SelectListItem> seasons = new List<SelectListItem>();
        List<SelectListItem> leagues = new List<SelectListItem>();
        List<SelectListItem> fixtures = new List<SelectListItem>();

        // GET: Cup
        public ActionResult Index()
        {
            MatchProcessor _matchProcessor = new MatchProcessor();
            _listOfAllMatche = _matchProcessor.RetrieveListOfAllMatch();

            foreach (ListOfMatch _lom in _listOfAllMatche)
            {
                if (_lom.Type == 0)
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
            }

            ViewBag.fazaID = fixtures;
            ViewBag.sezonaID = seasons;
            ViewBag.competitionID = leagues;

            return View();
        }

        [HttpPost]
        public ActionResult Index(string season_Id, CupDetailsViewModel model, FormCollection collection)
        {
            List<ListOfMatch> _listOfAllMatche;
            MatchProcessor _matchProcessor = new MatchProcessor();
            _listOfAllMatche = _matchProcessor.RetrieveListOfAllMatch();

            model.result = new List<FixtureResultViewModel>();

            string leagueID = collection["competitionId"].ToString();
            string seasonId = collection["sezonaID"].ToString();
            string fixtureId = collection["fazaID"].ToString();

            foreach (ListOfMatch _lom in _listOfAllMatche)
            {
                if (_lom.Season_Id.ToString() == seasonId && _lom.Competition_Id.ToString() == leagueID
                                            && _lom.Fixture_Id.ToString() == fixtureId && _lom.Type == 0)
                {
                    FixtureResultViewModel rlvm = new FixtureResultViewModel();
                    rlvm.matchId = _lom.Id;
                    rlvm.guestClub = _lom.HomeName;
                    rlvm.guestGoals = _lom.SecondOrgScore;
                    rlvm.homeGoals = _lom.FirstOrgScore;
                    rlvm.homeClub = _lom.GuestName;

                    model.result.Add(rlvm);
                }

                if (_lom.Type == 0)
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
            }

            ViewBag.fazaID = fixtures;
            ViewBag.sezonaID = seasons;
            ViewBag.competitionID = leagues;

            return View(model);
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
