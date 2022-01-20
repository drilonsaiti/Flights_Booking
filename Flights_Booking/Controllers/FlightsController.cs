using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flights_Booking.Models;

namespace Flights_Booking.Controllers
{
    public class FlightsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Flights
        [AllowAnonymous]
        public ActionResult Index()
        {

            if (TempData["fromSearch"] != null)
            {
                Location fromSearch = (Location)TempData["fromSearch"];
                return View(db.Flights.Where(f => f.From_Location == fromSearch).ToList());
                TempData["fromSearch"] = null;
            }
            else if (TempData["toSearch"] != null)
            {
                Location toSearch = (Location)TempData["toSearch"];

                return View(db.Flights.Where(f => f.To_Location == toSearch).ToList());
                TempData["toSearch"] = null;

            }


            else if (TempData["fromSearch"] != null && TempData["toSearch"] != null)
            {
                Location fromSearch = (Location)TempData["fromSearch"];
                Location toSearch = (Location)TempData["toSearch"];

                return View(db.Flights.Where(f => f.From_Location == fromSearch && f.To_Location == toSearch).ToList());
                TempData["fromSearch"] = null;
                TempData["toSearch"] = null;


            }
            else
            {
                return View(db.Flights.ToList());
            }
        }

        // GET: Flights/Details/5
        [Authorize(Roles = "User,Admin,Editor,Manager")]

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        [Authorize(Roles = "Admin,Editor,Manager")]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Editor,Manager")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,From_Location,To_Location,Deparature_Time,Arrival_Time,Duration,Total_Seats,Price,agency")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flight);
        }

        // GET: Flights/Edit/5
        [Authorize(Roles = "Admin,Editor,Manager")]

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Editor,Manager")]

        public ActionResult Edit([Bind(Include = "ID,From_Location,To_Location,Deparature_Time,Arrival_Time,Duration,Total_Seats,Price,agency")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flight);
        }

        [Authorize(Roles = "Admin,Editor,Manager")]

        public ActionResult Delete(long id)
        {
            Flight flight = db.Flights.Find(id);
            db.Flights.Remove(flight);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "User")]

        public ActionResult Reservation(long? idFlight)
        {
            Session["IDFlights"] = idFlight;
            return RedirectToAction("Create", "Reservations", new { id = idFlight });
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
