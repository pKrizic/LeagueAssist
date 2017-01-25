using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueAssistWeb.Models;

namespace LeagueAssistWeb.Controllers
{
    public class AboutController : Controller
    {
        // GET: About/Details/
        public ActionResult Details()
        {
            var club = new ClubDetailsViewModel();
            club.city = new CityDetailsViewModel();
            club.stadium = new StadiumDetailsViewModel();
            club.stadium.city = new CityDetailsViewModel();
            club.id = 1;
            club.name = "Dinamo Zagreb";
            club.city.id = 1;
            club.city.name = "Zagreb";
            club.stadium.id = 1;
            club.stadium.name = "Maksimir";
            club.stadium.address = "Maksimirska 128";
            club.stadium.capacity = 30000;
            club.stadium.city.id = 1;
            club.stadium.city.name = "Zagreb";
            return View(club);
        }

        // GET: About/Edit/5
        public ActionResult Edit(int id)
        {
            var club = new ClubDetailsViewModel();
            club.city = new CityDetailsViewModel();
            club.stadium = new StadiumDetailsViewModel();
            club.stadium.city = new CityDetailsViewModel();
            club.id = 1;
            club.name = "Dinamo Zagreb";
            club.city.id = 1;
            club.city.name = "Zagreb";
            club.stadium.id = 1;
            club.stadium.name = "Maksimir";
            club.stadium.address = "Maksimirska 128";
            club.stadium.capacity = 30000;
            club.stadium.city.id = 1;
            club.stadium.city.name = "Zagreb";

            List<SelectListItem> cities = new List<SelectListItem>{
                new SelectListItem{ Text="Zagreb", Value="1" },
                new SelectListItem{ Text="Split", Value="2" },
                new SelectListItem{ Text="Sranje", Value="3" }
            };

            List<SelectListItem> stadiums = new List<SelectListItem>{
                new SelectListItem{ Text="Maksimir", Value="1" },
                new SelectListItem{ Text="Poljud", Value="2" },
                new SelectListItem{ Text="Santiago Bernabeu", Value="3" }
            };

            ViewBag.gradID = cities;
            ViewBag.stadiumGradID = stadiums;

            return View(club);
        }

        // POST: About/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }
    }
}
