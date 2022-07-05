
using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models
{
    public class Booking{
        [Key]
        public int id { get; set; }
        [Required]
        public int parking_id { get; set; }
        [Required]
        public int customer_id { get; set; }
        public string vehicle_no { get; set; }
        public string booking_date { get; set; }
        public string entry_time { get; set; }
        public string leave_time { get; set; }
        public int slot { get; set; }
        public float price { get; set; }
        public bool paid { get; set; }=false;
    }
}