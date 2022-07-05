using Microsoft.EntityFrameworkCore;
using ParkingAPI.Models;

namespace ParkingAPI {
    public class DatabaseContext : DbContext {
        public DatabaseContext (DbContextOptions<DatabaseContext> options) : base (options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Parking> parkings { get; set; }
        public DbSet<Booking> bookings { get; set; }
    }
}