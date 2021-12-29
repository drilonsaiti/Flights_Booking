using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flights_Booking.Models
{
    public class Reservation
    {
        [Key]
        public long ID { get; set; }
        [Required]

        public String Name { get; set; }
        [Required]

        public String Surname { get; set; }
        [Required]

        [Display(Name = "Passport number")]
        public String Number_OfPassport { get; set; }
        [Display(Name = "Phone number")]
        [Required]

        public String Number_OfPhone { get; set; }
        [Display(Name = "Class type")]
        [Required]

        public ClassesType classesType { get; set; }
        public Reservation(string name, string surname, string number_OfPassport, string number_OfPhone, ClassesType classesType)
        {
            Name = name;
            Surname = surname;
            Number_OfPassport = number_OfPassport;
            Number_OfPhone = number_OfPhone;
            this.classesType = classesType;
        }

        public Reservation()
        {
        }
    }
}