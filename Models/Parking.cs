using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models{
    public class Parking{
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public bool active { get; set; }=false;
        public DateTime created_at { get; set; }=DateTime.Now;

    }
}