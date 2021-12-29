using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Flights_Booking.Models;

namespace Flights_Booking.Controllers
{
    [Authorize(Roles = "User")]

    public class PaymentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public List<String> Months = new List<String> { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
        public List<String> Year = new List<String> { "2022", "2023", "2024", "2025", "2026", "2027", "2028", "2029", "2030", "2031", "2032", "2033" };



        // GET: Payments/Create
        public ActionResult Create()
        {
            long idFlight = (long)Convert.ToDouble(Session["IDFlights"]);
            long idReservation = (long)Convert.ToDouble(Session["IDReservation"]);
            if (idFlight == 0 || idReservation == 0)
            {
                return RedirectToAction("Index", "Flights");

            }

            ViewBag.Flight = db.Flights.Find(idFlight);
            ViewBag.Reservation = db.Reservations.Find(idReservation);
            ViewBag.Month = Months.ToList();
            ViewBag.Year = Year.ToList();

            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Full_Name,Card_Number")] Payment payment)
        {
            if (ModelState.IsValid)
            {

                db.Payments.Add(payment);
                db.SaveChanges();
                long idFlight = (long)Convert.ToDouble(Session["IDFlights"]);
                Flight flight = db.Flights.Find(idFlight);
                flight.setTotalSeats();
                Session["IDpayment"] = payment.ID;
                db.SaveChanges();
                ViewBag.Payment = db.Payments.Find(payment.ID);
                Debug.WriteLine(payment.Card_Number.Length);
                return RedirectToAction("Download", "Orders");
            }

            return View(payment);
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
