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
            int idClub = 2;

            var igraci = new List<PlayerListViewModel>();

            var clas = new UserProcessor();
            var myPlayer = clas.GetClubPleyers(idClub);

            // Dummy data
            PlayerListViewModel igrac = new PlayerListViewModel();
            igrac.Id = 1;
            igrac.FirstName = "Pero";
            igrac.LastName = "Perić";
            igraci.Add(igrac);
            PlayerListViewModel igrac2 = new PlayerListViewModel();
            igrac2.Id = 2;
            igrac2.FirstName = "Jure";
            igrac2.LastName = "Jurić";
            igraci.Add(igrac2);
            PlayerListViewModel igrac3 = new PlayerListViewModel();
            igrac3.Id = 3;
            igrac3.FirstName = "Marko";
            igrac3.LastName = "Markić";
            igraci.Add(igrac3);
            PlayerListViewModel igrac4 = new PlayerListViewModel();
            igrac4.Id = 4;
            igrac4.FirstName = "Ivo";
            igrac4.LastName = "Ivić";
            igraci.Add(igrac4);
            PlayerListViewModel igrac5 = new PlayerListViewModel();
            igrac5.Id = 5;
            igrac5.FirstName = "Ante";
            igrac5.LastName = "Pepeo";
            igraci.Add(igrac5);
            PlayerListViewModel igrac6 = new PlayerListViewModel();
            igrac6.Id = 6;
            igrac6.FirstName = "Ante";
            igrac6.LastName = "Bager";
            igraci.Add(igrac6);
            PlayerListViewModel igrac7 = new PlayerListViewModel();
            igrac7.Id = 7;
            igrac7.FirstName = "Ante";
            igrac7.LastName = "Sibirski Plavac";
            igraci.Add(igrac7);
            PlayerListViewModel igrac8 = new PlayerListViewModel();
            igrac8.Id = 8;
            igrac8.FirstName = "Jusuf";
            igrac8.LastName = "Dere đukelu";
            igraci.Add(igrac8);
            PlayerListViewModel igrac9 = new PlayerListViewModel();
            igrac9.Id = 9;
            igrac9.FirstName = "Nedaj seĐedo Nedaj";
            igrac9.LastName = "seĐedo";
            igraci.Add(igrac9);
            PlayerListViewModel igrac10 = new PlayerListViewModel();
            igrac10.Id = 10;
            igrac10.FirstName = "Kokoš";
            igrac10.LastName = "Kokošić";
            igraci.Add(igrac10);
            PlayerListViewModel igrac11 = new PlayerListViewModel();
            igrac11.Id = 11;
            igrac11.FirstName = "Igrač";
            igrac11.LastName = "Igračić";
            igraci.Add(igrac11);
            PlayerListViewModel igrac12 = new PlayerListViewModel();
            igrac12.Id = 12;
            igrac12.FirstName = "Pas";
            igrac12.LastName = "Mačka";
            igraci.Add(igrac12);

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

            return View(igraci.ToPagedList(pageNumber, pageSize));
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