

namespace Flights_Booking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Flight
    {
        [Key]
        public long ID { get; set; }
        [Display(Name = "From")]
        [Required]
        public Location From_Location { get; set; }
        [Display(Name = "To")]
        [Required]

        public Location To_Location { get; set; }
        [Display(Name = "Deparature")]
        [Required]

        public string Deparature_Time { get; set; }
        [Display(Name = "Arrival")]
        [Required]

        public string Arrival_Time { get; set; }
        public string Duration { get; set; }
        [Display(Name = "Available  seat")]
        [Required]

        public int Total_Seats { get; set; }
        [Required]

        public int Price { get; set; }
        [Display(Name = "Agency")]
        [Required]

        public String agency { get; set; }

        public double finalPrice;

        public string flag;

        public Flight(Location from_Location, Location to_Location, string deparature_Time, string arrival_Time, string duration, int total_Seats, int price, String agency)
        {
            From_Location = from_Location;
            To_Location = to_Location;
            Deparature_Time = deparature_Time;
            Arrival_Time = arrival_Time;
            Duration = duration;
            Total_Seats = total_Seats;
            Price = price;
            this.agency = agency;
            this.flag = this.cantShowOrDownload();
        }

        public Flight() { }

        public void setTotalSeats()
        {
            this.Total_Seats -= 1;
        }

        public double getFinalPrice(ClassesType type)
        {

            if (type == ClassesType.ECONOMY_CLASS)
            {
                finalPrice = this.Price;
                return this.Price;
            }
            else if (type == ClassesType.BUSINESS_CLASS)
            {
                finalPrice = this.Price * 8.5;
                return this.Price + this.Price * 8.5;
            }
            else
            {
                finalPrice = this.Price * 4.5;
                return this.Price * 4.5;
            }
        }


        public string cantShowOrDownload()
        {
            String data = Deparature_Time.Substring(0, 10);
            String time = Deparature_Time.Substring(11);

            String[] partsDate = data.Split('-');
            int day = Convert.ToInt32(partsDate[0]);
            int month = Convert.ToInt32(partsDate[1]);
            int year = Convert.ToInt32(partsDate[2]);

            DateTime now = DateTime.Now;
            String[] partsTime = time.Split(':');

            int hour = Convert.ToInt32(partsTime[0]);
            int minute = Convert.ToInt32(partsTime[1]);

            int min = now.Hour - hour;
            int minday = (day - now.Day) * 24;

            if (day >= now.Day && month >= now.Month && year >= now.Year && min + minday > 0 && min + minday >= 4)
            {
                return "true";
            }
            return "false";
        }

        public string GetDateForOrder()
        {
            return this.Deparature_Time.Substring(0, 10);

        }
    }
}
