using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueAssistWeb.Models;
using LeagueAssist;

namespace LeagueAssistWeb.Controllers
{
    public class AboutController : Controller
    {

        public ClubDetailsViewModel retrieveClub(int idClub)
        {
            var clubProcessor = new ClubProcessor();
            var myClub = clubProcessor.GetClubInformation(idClub);


            var club = new ClubDetailsViewModel();
            club.city = new CityDetailsViewModel();
            club.stadium = new StadiumDetailsViewModel();
            club.stadium.city = new CityDetailsViewModel();
            //club info
            club.id = myClub.Id;
            club.name = myClub.OrgName;
            club.city.id = myClub.OrgCityId;
            club.city.name = myClub.OrgCityName;
            //stadium info
            club.stadium.id = myClub.StadiumId;
            club.stadium.name = myClub.StadiumName;
            club.stadium.address = myClub.Address;
            club.stadium.capacity = myClub.Capacity;
            club.stadium.city.id = myClub.StadiumCityId;
            club.stadium.city.name = myClub.StadiumCityName;

            return club;
        }

        // GET: About/Details/
        public ActionResult Details()
        {
            int idClub = 2;
            var club = retrieveClub(idClub);
            
            return View(club);
        }

        // GET: About/Edit/5
        public ActionResult Edit(int id)
        {
            var club = retrieveClub(id);

            var cityProcessor = new CityProcessor();
            var listOfCity = cityProcessor.ListOfCity();

            List<SelectListItem> cities = new List<SelectListItem>();
            List<SelectListItem> stadiums = new List<SelectListItem>();

            foreach (var value in listOfCity)
            {
                cities.Add(new SelectListItem { Text = value.Name, Value = value.Id.ToString()});
                stadiums.Add(new SelectListItem { Text = value.Name, Value = value.Id.ToString() });
            }

            ViewBag.gradID = cities;
            ViewBag.stadiumGradID = stadiums;

            return View(club);
        }

        // POST: About/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, ClubDetailsViewModel model)
        {
            try
            {
                var clubCityID = Request.Form["gradID"];
                var stadiumCityID = Request.Form["stadiumGradID"];
                //azurirat stadione i klub
                return RedirectToAction("Details");
            }
            catch
            {
                return View();
            }
        }
    }
}
