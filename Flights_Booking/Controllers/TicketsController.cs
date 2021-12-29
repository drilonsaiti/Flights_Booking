using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Flights_Booking.Models;

namespace Flights_Booking.Controllers
{

    [Authorize(Roles = "User")]
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Tickets
        public ActionResult Index()
        {
            String email = "";
            if (User.Identity.IsAuthenticated)
            {
                email = User.Identity.Name;

            }
            var user = db.Users.Where(m => m.Email == email).Select(m => m.Id).SingleOrDefault();

            Ticket ticket = db.Tickets.Where(m => m.userID == user).SingleOrDefault();

            if (ticket == null)
            {
                return RedirectToAction("Index", "Flights");
            }

            var orderVar = db.Orders.Where(m => m.ticket.ID == ticket.ID).ToList();

            List<OrderForTicket> orderForTickets = new List<OrderForTicket>();
            foreach (var o in ticket.orders)
            {
                var flight = db.Orders.Where(m => m.ID == o.ID).Select(m => m.flight);
                var reservation = db.Orders.Where(m => m.ID == o.ID).Select(m => m.reservation);
                var payment = db.Orders.Where(m => m.ID == o.ID).Select(m => m.payment);
                orderForTickets.Add(new OrderForTicket(o.ID, flight.FirstOrDefault(), reservation.FirstOrDefault(), payment.FirstOrDefault()));
            }

            return View(orderForTickets);
        }



        public ActionResult Delete(long? id)
        {
            String email = "";
            if (User.Identity.IsAuthenticated)
            {
                email = User.Identity.Name;

            }
            var user = db.Users.Where(m => m.Email == email).Select(m => m.Id).SingleOrDefault();

            Ticket ticket = db.Tickets.Where(m => m.userID == user).SingleOrDefault();

            Order order = db.Orders.Find(id);
            ticket.orders.Remove(order);
            //db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult BackToTickets()
        {

            return RedirectToAction("Index");
        }
        public ActionResult BackToFlights()
        {

            return RedirectToAction("Create", "Flights");
        }
        public ActionResult Download(long? id)
        {
            var order = db.Orders.Find(id);
            var flight = db.Orders.Where(m => m.ID == id).Select(m => m.flight).FirstOrDefault();
            var reservation = db.Orders.Where(m => m.ID == id).Select(m => m.reservation).FirstOrDefault();
            var payment = db.Orders.Where(m => m.ID == id).Select(m => m.payment).FirstOrDefault();
            ViewBag.FlightDownload = flight;
            ViewBag.ReservationDownload = reservation;
            ViewBag.PaymentDownload = payment;
            ViewBag.OrderDownload = order;

            return View("DirectDownload");
        }



    }
}
