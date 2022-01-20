using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flights_Booking.Models
{
    public class Payment
    {

        [Key]
        public long ID { get; set; }
        [Display(Name = "Full name")]
        [Required]

        public String Full_Name { get; set; }
        [Display(Name = "Card number")]
        [Required]
        [MaxLength(16)]
        [MinLength(16)]
        public String Card_Number { get; set; }
        [Display(Name = "CVV2")]
        public String CVV2;
        [Display(Name = "Month validation")]
        [Required]

        public String Month_OfValidation;
        [Display(Name = "Year validation")]
        [Required]

        public String Year_OfValidation;


        public Payment(string full_Name, string card_Number)
        {
            Full_Name = full_Name;
            Card_Number = card_Number;
        }

        public Payment()
        {
        }


        public String encodeCardNumber(String cardnumberFromInput)
        {

            string first = cardnumberFromInput.Substring(0, 5);
            string second = "*****";
            string third = cardnumberFromInput.Substring(5, 11).Substring(5);
            return first + second + third;
        }

        public String getValidation()
        {
            return Month_OfValidation + "/" + Year_OfValidation;
        }
    }
}