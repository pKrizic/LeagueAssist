using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueAssistWeb.Models;
using PagedList.Mvc;
using PagedList;
using LeagueAssist;

namespace LeagueAssistWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page, int? pageItems)
        {
            var userProcessor = new UserProcessor();
            int idClub = 2;
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
            
            //preko ovog mozemo dohvatit moje utakmice za sezonu, kolo i natjecanje!
            //var m = new MatchProcessor();
            //var listM = m.GetListClubMatchs(3, 3, 1, 1);

            
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
            var playerProcessor = new PlayerProcessor();
            var player = new PlayerDetailsViewModel();
            player.contract = new ContractViewModel();
            player.healthCheck = new HealthCheckViewModel();

            try
            {
                var myPlayer = playerProcessor.RetrievePlayerDetails(id);
                decimal test;

                player.id = myPlayer.Id;
                player.firstName = myPlayer.FirstName;
                player.lastName = myPlayer.LastName;
                player.birthDate = myPlayer.BirthDate;
                player.email = myPlayer.Email;
                player.phone = myPlayer.Phone;
                player.contract.id = myPlayer.ContractId;
                player.contract.annualSalary = myPlayer.AnnualSalary;
                player.contract.dateFrom = myPlayer.DateFrom;
                player.contract.dateTo = myPlayer.DateTo;
                player.contract.foreigner = myPlayer.Foreigner;
                player.contract.numberOnShirt = myPlayer.NumberOnShirt;
                player.healthCheck.id = myPlayer.HealthCheckId;
                player.healthCheck.dateFrom = myPlayer.FromDate;
                player.healthCheck.dateTo = myPlayer.ToDate;
                player.healthCheck.remark = myPlayer.Remark;

            }
            catch (Exception e)
            {
                player = null;
            }
            return View(player);
        }

        // POST: /Home/EditPlayer/5
        [HttpPost]
        public ActionResult EditPlayer(int id, PlayerDetailsViewModel model, FormCollection collection)
        {
            var playerProcessor = new PlayerProcessor();

            //playerProcessor.StorePlayerDetailsChanges();

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


        // GET: /Home/EndPlayerContract/5
        public ActionResult EndPlayerContract(int id)
        {
            return View();
        }

        public ActionResult RegisterNewPlayer()
        {
            return View();
        }

        public ActionResult RegisterExistingPlayerSearch()
        {
            return View();
        }

        public ActionResult RegisterExistingPlayer(int? id)
        {
            return View();
        }
    }
}