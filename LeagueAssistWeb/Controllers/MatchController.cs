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
                result.matchId = item.Id;
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
        public ActionResult SignPlayers(int matchId)
        {
            List<PlayersStartSquad> model = new List<PlayersStartSquad>();
            var playerDetails = new PlayerDetails();
            var matchProcessor = new MatchProcessor();
            var playerProcessor = new PlayerProcessor();
            var userProcessor = new UserProcessor();
            Organization org = Session["MyClub"] as Organization;

            var players = matchProcessor.RetrievePlayersForMatch(matchId, org.Id);
            var cp = userProcessor.GetClubPlayers(org.Id);
            if (players.Count != 0)
            {
                foreach(var item in players)
                {
                    foreach (var play in cp)
                    {
                        if (item.Id == play.Id)
                        {
                            PlayersStartSquad player = new PlayersStartSquad();
                            player.playerId = item.Id;
                            player.matchId = matchId;
                            player.organizationId = org.Id;
                            playerDetails = playerProcessor.RetrievePlayerDetails(item.Person.Id);
                            player.firstName = playerDetails.FirstName;
                            player.lastName = playerDetails.LastName;
                            player.numberOnShirt = playerDetails.NumberOnShirt;

                            if (item.Selection.Id == 1)
                            {
                                player.isFirstSelection = true;
                            }
                            else if (item.Selection.Id == 2)
                            {
                                player.isSubstitution = true;
                            }
                            else
                            {
                                player.isFirstSelection = false;
                                player.isSubstitution = false;
                            }

                            if (item.Captain == 0)
                            {
                                player.isCaptain = false;
                            } else
                            {
                                player.isCaptain = true;
                            }

                            model.Add(player);
                        }
                    }
                }
                return View(model);
            }
            foreach(var item in cp)
            {
                PlayersStartSquad player = new PlayersStartSquad();
                player.matchId = matchId;
                player.organizationId = org.Id;
                player.playerId = item.Id;
                playerDetails = playerProcessor.RetrievePlayerDetails(item.Id);
                player.firstName = playerDetails.FirstName;
                player.lastName = playerDetails.LastName;
                player.numberOnShirt = playerDetails.NumberOnShirt;
                model.Add(player);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult SignPlayers(List<PlayersStartSquad> model, FormCollection collection)
        {
            PlayerProcessor playerProcessor = new PlayerProcessor();
            MatchProcessor matchProcessor = new MatchProcessor();
            Organization org = Session["MyClub"] as Organization;

            var players = matchProcessor.RetrievePlayersForMatch(model.First().matchId, org.Id);
            
            foreach(var item in model)
            {
                if (item.isFirstSelection || item.isSubstitution)
                {
                    MatchPerson matchPerson = new MatchPerson();
                    matchPerson.Match = new Match();
                    matchPerson.Organization = new Organization();
                    matchPerson.Person = new Person();
                    matchPerson.Selection = new Selection();

                    if (item.isFirstSelection && item.isCaptain)
                    {
                        matchPerson.Captain = 1;
                    }
                    Person person = playerProcessor.RetrievePlayer(item.playerId);
                    Match match = matchProcessor.RetrieveMatch(item.matchId);
                    Selection selection = new Selection();
                    
                    if(item.isFirstSelection)
                    {
                        selection = playerProcessor.RetrieveSelection(1);
                    } else
                    {
                        selection = playerProcessor.RetrieveSelection(2);
                    }

                    matchPerson.Person = person;
                    matchPerson.Match = match;
                    matchPerson.Selection = selection;

                    matchProcessor.UpdateMatchPerson(matchPerson);
                    
                }
            }
            return View(model);
        }
    }
}
