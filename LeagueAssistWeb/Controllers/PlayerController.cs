﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueAssistWeb.Models;
using PagedList.Mvc;
using PagedList;
using LeagueAssist;
using LeagueAssist.Entities;

namespace LeagueAssistWeb.Controllers
{
    public class PlayerController : Controller
    {
        public PlayerDetailsViewModel RetrievePlayer(int id)
        {
            var playerProcessor = new PlayerProcessor();
            var player = new PlayerDetailsViewModel();
            player.player = new Person();
            player.contract = new Contract();
            player.healthCheck = new HealthCheckEvidention();

            try
            {
                var myPlayer = playerProcessor.RetrievePlayerDetails(id);
                player.player = playerProcessor.RetrievePlayer(myPlayer.Id);
                if (myPlayer.ContractId != 0 && myPlayer.ContractId != null)
                {
                    player.contract = playerProcessor.RetrieveContract(myPlayer.ContractId);
                }
                if (myPlayer.HealthCheckId != 0 && myPlayer.HealthCheckId != null)
                {
                    player.healthCheck = playerProcessor.RetrieveHealthCheck(myPlayer.HealthCheckId);
                }
            }

            catch (Exception e)
            {
                player = null;
            }

            return player;
        }

        public List<PlayerListViewModel> GetFreePlayers()
        {
            var playerProcessor = new PlayerProcessor();
            int idClub = 2;
            var players = new List<PlayerListViewModel>();

            try
            {
                var myPlayers = playerProcessor.RetrieveFreePlayers();

                foreach (var item in myPlayers)
                {
                    PlayerListViewModel player = new PlayerListViewModel();
                    player.setId(item.Id);
                    player.setFirstName(item.FirstName);
                    player.setLastName(item.LastName);

                    players.Add(player);
                }
            }
            catch (Exception e)
            {
                //players = null;
            }

            return players;
        } 

        public Organization RetrieveOrganization(int id)
        {
            var organizationProcessor = new OrganizationProcessor();
            return organizationProcessor.getOrganization(id);
        }

        public ActionResult Index(int? page, int? pageItems)
        {
            int idClub;
            try
            {
                Organization myClub = Session["MyClub"] as Organization;
                idClub = myClub.Id;
            }
            catch (Exception e)
            {
                idClub = 2;
            }
            var userProcessor = new UserProcessor();
            
            var players = new List<PlayerListViewModel>();

            try
            {
                var myPlayers = userProcessor.GetClubPlayers(idClub);

                foreach (var item in myPlayers)
                {
                    PlayerListViewModel player = new PlayerListViewModel();
                    player.setId(item.Id);
                    player.setFirstName(item.FirstName);
                    player.setLastName(item.LastName);

                    players.Add(player);
                }
            }
            catch (Exception e)
            {
                //players = null;
            }

            //<Broj stavki po stranici>
            List<SelectListItem> items = new List<SelectListItem>{
                new SelectListItem{ Text="10", Value="10" },
                new SelectListItem{ Text="15", Value="15" },
                new SelectListItem{ Text="20", Value="20" }
            };

            ViewData["ItemsPerPage"] = new SelectList(items, "Value", "Text", pageItems);

            ViewBag.CurrentPageSize = pageItems ?? 10;
            //</Broj stavki po stranici>

            //<Paginacija>
            int pageSize = (pageItems ?? 10);
            int pageNumber = (page ?? 1);
            //</Paginacija>
            
            return View(players.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Home/Details/5
        public ActionResult PlayerDetails(int id)
        {
            return View();
        }

        // GET: /Home/EditPlayer/5
        public ActionResult EditPlayer(int id)
        {
            var player = RetrievePlayer(id);

            return View(player);
        }

        // POST: /Home/EditPlayer/5
        [HttpPost]
        public ActionResult EditPlayer(int id, PlayerDetailsViewModel model, FormCollection collection)
        {
            int idClub = 2;
            var playerProcessor = new PlayerProcessor();
            var organization = RetrieveOrganization(idClub);
            decimal testDec;
            DateTime testDate;
            if (!DateTime.TryParse(model.player.BirthDate.ToString(), out testDate))
            {
                TempData["Error"] = "Datum rođenja je krivog formata. Ispravan format je dd.MM.yyyy";
                return View(model);
            }

            if (!DateTime.TryParse(model.contract.DateFrom.ToString(), out testDate) || !DateTime.TryParse(model.contract.DateTo.ToString(), out testDate))
            {
                TempData["Error"] = "Datum ugovora je krivog formata. Ispravan format je dd.MM.yyyy";
                return View(model);
            }

            if (!DateTime.TryParse(model.healthCheck.FromDate.ToString(), out testDate) || !DateTime.TryParse(model.healthCheck.ToDate.ToString(), out testDate))
            {
                TempData["Error"] = "Datum liječničkog je krivog formata. Ispravan format je dd.MM.yyyy";
                return View(model);
            }

            if (!Decimal.TryParse(model.contract.AnnualSalary.ToString(), out testDec))
            {
                TempData["Error"] = "Iznos plaće je krivog formata. Ispravan format je XX.YY";
                return View(model);
            }

            try
            {
                if(ModelState.IsValid)
                {
                    playerProcessor.StorePlayerDetailsChanges(model.player, model.contract, model.healthCheck, organization);
                    return RedirectToAction("Index");
                }    
            }
            catch (Exception e)
            {
                return View();
            }

            return View();
        }


        // GET: /Home/EndPlayerContract/5
        public ActionResult EndPlayerContract(int id)
        {
            var player = RetrievePlayer(id);

            return View(player);
        }

        [HttpPost]
        public ActionResult EndPlayerContract(int id, PlayerDetailsViewModel model, FormCollection collection)
        {
            var playerProcessor = new PlayerProcessor();

            try
            {
                playerProcessor.DeleteContract(model.contract);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        public ActionResult RegisterPlayer(int id = 0)
        {
            PlayerProcessor playerProcessor = new PlayerProcessor();

            // Initialize new player, contract and healthCheck
            PlayerDetailsViewModel player = new PlayerDetailsViewModel();
            player.player = new Person();
            player.contract = new Contract();
            player.healthCheck = new HealthCheckEvidention();
            if (id != 0)
            {
                player.player = playerProcessor.RetrievePlayer(id);
            }

            return View(player);
        }

        [HttpPost]
        public ActionResult RegisterPlayer(PlayerDetailsViewModel model, FormCollection collection)
        {
            var idClub = 2;
            var playerProcessor = new PlayerProcessor();
            var organization = RetrieveOrganization(idClub);
            DateTime testDate;
            Decimal testDec;

            if (!DateTime.TryParse(model.player.BirthDate.ToString(), out testDate))
            {
                TempData["Error"] = "Datum rođenja je krivog formata. Ispravan format je dd.MM.yyyy";
                return View(model);
            }

            if (!DateTime.TryParse(model.contract.DateFrom.ToString(), out testDate) || !DateTime.TryParse(model.contract.DateTo.ToString(), out testDate))
            {
                TempData["Error"] = "Datum ugovora je krivog formata. Ispravan format je dd.MM.yyyy";
                return View(model);
            }

            if (!DateTime.TryParse(model.healthCheck.FromDate.ToString(), out testDate) || !DateTime.TryParse(model.healthCheck.ToDate.ToString(), out testDate))
            {
                TempData["Error"] = "Datum liječničkog je krivog formata. Ispravan format je dd.MM.yyyy";
                return View(model);
            }

            if (!Decimal.TryParse(model.contract.AnnualSalary.ToString(), out testDec))
            {
                TempData["Error"] = "Iznos plaće je krivog formata. Ispravan format je XX.YY";
                return View(model);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    playerProcessor.StorePlayerDetailsChanges(model.player, model.contract, model.healthCheck, organization);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                return View();
            }

            return View();
        }

        public ActionResult RegisterExistingPlayerSearch()
        {
            List<PlayerListViewModel> players = GetFreePlayers();
            return View(players);
        }

        public ActionResult RegisterExistingPlayer(int? id)
        {
            return View();
        }
    }
}