using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeagueAssistWeb.Controllers
{
    public class AboutController : Controller
    {
        // GET: About/Details/
        public ActionResult Details()
        {
            return View();
        }

        // GET: About/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
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
