using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueAssistWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public ActionResult RegisterExistingPlayer()
        {
            return View();
        }
    }
}