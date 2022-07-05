
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace ParkingAPI.Models{
    public class Booking{
        [Key]
        public int id { get; set; }
        [Required]
        public int parking_id { get; set; }
        [Required]
        public int customer_id { get; set; }
        public string vehicle_no { get; set; }
        public DateTime booking_date { get; set; }
        public DateTime entry_time { get; set; }
        public DateTime leave_time { get; set; }
        public int slot { get; set; }
        public float price { get; set; }
        public bool paid { get; set; }
    }
}