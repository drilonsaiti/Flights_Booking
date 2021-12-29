using Flights_Booking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flights_Booking.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewBag.Agencies = Enum.GetValues(typeof(Location));
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Search(Location? fromSearch, Location? toSearch)
        {
            if (fromSearch != null)
            {
                TempData["fromSearch"] = fromSearch;

            }
            if (toSearch != null)
            {
                TempData["toSearch"] = toSearch;
            }
            return RedirectToAction("Index", "Flights");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Home()
        {
            return View();
        }
    }
}