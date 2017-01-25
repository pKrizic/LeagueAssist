using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueAssistWeb.Controllers
{
    public class MatchController : Controller
    {
        // GET: Match
        public ActionResult Index()
        {
            List<SelectListItem> seasons = new List<SelectListItem>{
                new SelectListItem{ Text="2013/2014", Value="1" },
                new SelectListItem{ Text="2014/2015", Value="2" },
                new SelectListItem{ Text="2015/2016", Value="3" }
            };
            
            ViewBag.sezonaID = seasons;

            return View();
        }

        // GET: Match/SignPlayer/5
        public ActionResult SignPlayers(int id)
        {
            return View();
        }

 
    }
}
