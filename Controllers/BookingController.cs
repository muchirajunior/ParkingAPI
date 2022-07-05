using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI;
using ParkingAPI.Models;

namespace bookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        private readonly DatabaseContext _context;
        public BookingController(DatabaseContext context)
        {
            _context=context;
        }

        [HttpGet("")]
        public IActionResult GetAllBookings()
        {
            var data= _context.bookings.ToList();
            return Ok(new {Message="All the booking in database",Data=data});
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById([FromRoute]int id){
            var booking=_context.bookings.Where(booking=>booking.id==id).FirstOrDefault();
            if (booking != null)
                return Ok(new {Message=$"Got booking slot by Id {id}",Data=booking});
            else
                return NotFound(new {Message="booking slot with such Id does not exist"});
        }

        [HttpPost("")]
        public IActionResult AddBooking([FromBody]Booking booking){
            try
            {
                _context.bookings.Add(booking);
                _context.SaveChanges();

                return Created("",new {Message="created booking successfuly",Data=booking});
            }
            catch (System.Exception)
            {
                
                return Ok(new {Message="adding a new booking failed"});
            }
        }

        [HttpPatch("{id}")]
        public IActionResult PayBookingById([FromRoute]int id){
            var booking=_context.bookings.Where(booking=>booking.id==id).FirstOrDefault();
            if (booking != null){
                booking.paid=true;
                _context.SaveChanges();
                return Ok(new {Message=$"successfuly updated booking slot",Data=booking});
            }else
                return NotFound(new {Message="booking slot with such Id does not exist"});
        }
        

        [HttpDelete("{id}")]
        public IActionResult DeletebookingById([FromRoute]int id){
           var booking = _context.bookings.Where(booking=>booking.id==id).FirstOrDefault();
           if (booking != null){
               _context.bookings.Remove(booking);
               _context.SaveChanges();
                return Ok(new {Message="booking deleted successfuly"});
           }else{
               return NotFound(new {Message="failed to delete. no such booking in the record!"});
           }
        }



    }
}