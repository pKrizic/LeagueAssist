using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueAssist;
using LeagueAssist.Entities;
using LeagueAssistWeb.Models;

namespace LeagueAssistWeb.Controllers
{
    public class MatchController : Controller
    {
        public List<SelectListItem> RetrieveSeasons()
        {
            var _seasonProcessor = new SeasonProcessor();
            var seasons = _seasonProcessor.RetrieveSeasons();
            List<SelectListItem> seasonList = new List<SelectListItem>();
            foreach (var item in seasons)
            {
                seasonList.Add(new SelectListItem { Selected = true, Text = item.Name, Value = item.Id.ToString() });
            }

            return seasonList;
        }

        public List<ResultsListViewModel> RetrieveSeasonMatches(int clubId, int seasonId)
        {
            var _matchProcessor = new MatchProcessor();
            var matches = _matchProcessor.RetrieveSeasonMatchList(clubId, seasonId);
            List<ResultsListViewModel> results = new List<ResultsListViewModel>();

            foreach (var item in matches)
            {
                ResultsListViewModel result = new ResultsListViewModel();
                result.homeClub = new ClubDetailsViewModel();
                result.guestClub = new ClubDetailsViewModel();
                result.matchDateTime = item.DateTime;
                result.homeGoals = item.FirstOrgScore;
                result.homeClub.name = item.FirstOrg.Name;
                result.guestGoals = item.SecondOrgScore;
                result.guestClub.name = item.SecondOrg.Name;

                results.Add(result);
            }

            return results;
        }

        // GET: Match
        public ActionResult Index()
        {
            MatchListViewModel model = new MatchListViewModel();
            model.result = new List<ResultsListViewModel>();
            Organization org = Session["MyClub"] as Organization;

            var seasons = RetrieveSeasons();
            model.result = RetrieveSeasonMatches(org.Id, Int32.Parse(seasons.Last().Value));
            ViewBag.sezonaID = seasons;

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string season_Id, MatchListViewModel model, FormCollection collection)
        {
            var seasons = RetrieveSeasons();
            ViewBag.sezonaID = seasons;

            Organization org = Session["MyClub"] as Organization;

            model.result = RetrieveSeasonMatches(org.Id, Int32.Parse(season_Id));

            return View(model);
        }

        // GET: Match/SignPlayer/5
        public ActionResult SignPlayers(int id)
        {
            return View();
        }

 
    }
}
