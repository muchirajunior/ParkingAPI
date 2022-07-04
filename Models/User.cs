
using System.ComponentModel.DataAnnotations;

namespace ParkingAPI.Models{
    public class User{
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}