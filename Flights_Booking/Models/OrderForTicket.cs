using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flights_Booking.Models
{
    public class OrderForTicket
    {

        public long orderID { get; set; }
        public Flight flight { get; set; }
        public Reservation reservation { get; set; }
        public Payment payment { get; set; }

        public OrderForTicket(long OrderID, Flight flight, Reservation reservation, Payment payment)
        {
            this.orderID = OrderID;
            this.flight = flight;
            this.reservation = reservation;
            this.payment = payment;
        }
    }
}