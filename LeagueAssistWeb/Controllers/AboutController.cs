using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeagueAssistWeb.Models;
using LeagueAssist;
using LeagueAssist.Entities;

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
                OrganizationProcessor orgProcessor = new OrganizationProcessor();
                CityProcessor cityProcessor = new CityProcessor();
                var clubCityID = Request.Form["gradID"];
                var stadiumCityID = Request.Form["stadiumGradID"];

                Stadium stadium = orgProcessor.RetrieveOrganizationStadium(model.id);
                City clubCity = cityProcessor.getCity(Int32.Parse(clubCityID));
                City stadiumCity = cityProcessor.getCity(Int32.Parse(stadiumCityID));
                Organization organization = orgProcessor.getOrganization(model.id);
                organization.Name = model.name;
                organization.City = clubCity;
                stadium.Name = model.name;
                stadium.City = stadiumCity;
                stadium.Capacity = model.stadium.capacity;
                stadium.Address = model.stadium.address;

                orgProcessor.StoreOrganizationChanges(organization);
                orgProcessor.StoreStadiumChanges(stadium);

                return RedirectToAction("Details");
            }
            catch (Exception e)
            {
                return View();
            }
        }
    }
}
