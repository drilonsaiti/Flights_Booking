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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }



        // GET: Orders/Create
        public ActionResult Download([Bind(Include = "ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                long idFlight = (long)Convert.ToDouble(Session["IDFlights"]);
                long idReservation = (long)Convert.ToDouble(Session["IDReservation"]);
                long idPayment = (long)Convert.ToDouble(Session["IDpayment"]);

                order.flight = db.Flights.Find(idFlight);
                order.reservation = db.Reservations.Find(idReservation);
                order.payment = db.Payments.Find(idPayment);
                db.Orders.Add(order);
                db.SaveChanges();
                ViewBag.Order = db.Orders.Find(order.ID);


                String email = "";
                if (User.Identity.IsAuthenticated)
                {
                    email = User.Identity.Name;

                }
                var userId = db.Users.Where(m => m.Email == email).Select(m => m.Id).SingleOrDefault();
                long ticketId = db.Tickets.Where(m => m.userID == userId).Select(m => m.ID).SingleOrDefault();

                if (ticketId == 0)
                {

                    Ticket ticket = new Ticket(userId);
                    ticket.orders.Add(order);
                    db.Tickets.Add(ticket);
                    db.SaveChanges();

                }
                else
                {
                    Ticket ticket = db.Tickets.Find(ticketId);
                    Order oderticket = db.Orders.Find(order.ID);
                    ticket.orders.Add(db.Orders.Find(order.ID));
                    db.SaveChanges();


                }


                return View("Download");
            }
            return View(order);
        }



        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.



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
