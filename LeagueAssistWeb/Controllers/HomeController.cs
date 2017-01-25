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

            var userProcessor = new UserProcessor();
            int idClub = 2;
            var players = new List<PlayerListViewModel>();

            try
            {
                var myPlayers = userProcessor.GetClubPlayers(idClub);

                foreach (var item in myPlayers)
                {
                    PlayerListViewModel player = new PlayerListViewModel();
                    player.Id = item.Id;
                    player.FirstName = item.FirstName;
                    player.LastName = item.LastName;
                    players.Add(player);
                }
            }
            catch (Exception e)
            {
                players = null;
            }

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
            return View();
        }

        // POST: /Home/EditPlayer/5
        [HttpPost]
        public ActionResult EditPlayer(int id, FormCollection collection)
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