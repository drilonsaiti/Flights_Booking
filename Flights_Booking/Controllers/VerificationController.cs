using Flights_Booking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Flights_Booking.Controllers
{
    public class VerificationController : Controller
    {
        // GET: Verification
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(long? idOrder)
        {
            return Download(idOrder);
        }

        public ActionResult Download(long? id)
        {
            var order = db.Orders.Find(id);


            if (order != null)
            {


                var flight = db.Orders.Where(m => m.ID == id).Select(m => m.flight).FirstOrDefault();
                var reservation = db.Orders.Where(m => m.ID == id).Select(m => m.reservation).FirstOrDefault();
                var payment = db.Orders.Where(m => m.ID == id).Select(m => m.payment).FirstOrDefault();
                ViewBag.FlightVerification = flight;
                ViewBag.ReservationVerification = reservation;
                ViewBag.PaymentVerification = payment;
                ViewBag.OrderVerification = order;

                return View("Download");
            }
            else
            {
                ViewBag.ErrorVerification = "THIS ORDER DOES NOT EXIST ON THE LIST OF ORDERS";
            }

            return View("Index");
        }
    }
}