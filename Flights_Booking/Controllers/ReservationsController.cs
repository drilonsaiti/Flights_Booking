using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Flights_Booking.Models;

namespace Flights_Booking.Controllers
{
    [Authorize(Roles = "User")]

    public class ReservationsController : Controller
    {
        public long idFlight { get; set; }
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reservations


        // GET: Reservations/Create
        public ActionResult Create(long? id)
        {
            long idFlight = (long)Convert.ToDouble(ViewData["idFlight"]);

            ViewBag.Flight = db.Flights.Find(id);

            if (id == 0 || id == null)
            {
                return RedirectToAction("Index", "Flights");
            }

            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Surname,Number_OfPassport,Number_OfPhone,Bagging_Price,classesType")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                db.SaveChanges();
                Session["IDReservation"] = reservation.ID;
                long idFlight = (long)Convert.ToDouble(Session["IDFlights"]);
                Flight flight = db.Flights.Find(idFlight);
                flight.getFinalPrice(reservation.classesType);
                db.SaveChanges();

                return RedirectToAction("Create", "Payments");
            }

            return View(reservation);
        }

        public ActionResult BackToFlights()
        {
            return RedirectToAction("Index", "Flights");
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
