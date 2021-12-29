using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Flights_Booking.Models
{
    public class Ticket
    {

        [Key]
        public long ID { get; set; }

        public DateTime dateCreated { get; set; }

        public virtual ICollection<Order> orders { get; set; }

        public TicketStatus ticketStatus { get; set; }

        public string userID { get; set; }

        public Ticket(string userID)
        {
            this.dateCreated = DateTime.Now;
            this.userID = userID;
            this.orders = new List<Order>();
            this.ticketStatus = TicketStatus.CREATED;

        }

        public Ticket() { }


    }
}