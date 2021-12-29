using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flights_Booking.Models
{
    public class Order
    {
        [Key]
        public long ID { get; set; }

        public DateTime dateCreated { get; set; }

        public Flight flight { get; set; }

        public Reservation reservation { get; set; }

        public Payment payment { get; set; }

        public virtual Ticket ticket { get; set; }

        public Order(Flight flight, Reservation reservation, Payment payment)
        {
            this.dateCreated = DateTime.Now;
            this.flight = flight;
            this.reservation = reservation;
            this.payment = payment;
        }

        public Order()
        {
            this.dateCreated = DateTime.Now;

        }

        public string print()
        {
            string str = ID + " " + flight.From_Location + " " + reservation.Name;
            return str;
        }
    }
}