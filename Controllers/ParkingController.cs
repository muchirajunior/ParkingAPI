using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : Controller
    {
        private readonly DatabaseContext _context;
        public ParkingController(DatabaseContext context){ _context=context; }

        [HttpGet("")]
        public IActionResult GetAll()
        {
            var data=_context.parkings.ToList();
            return Ok(new {Message="All parking Slots",Data=data});
        }

        [HttpGet("{id}")]
        public IActionResult GetParkingById([FromRoute]int id){
            var parking=_context.parkings.Where(parking=>parking.id==id).FirstOrDefault();
            if (parking != null)
                return Ok(new {Message=$"Got parking slot by Id {id}",Data=parking});
            else
                return NotFound(new {Message="Parking slot with such Id does not exist"});
        }

        [HttpPost("")]
        public IActionResult AddParking([FromBody] Parking parking){
            try
            {
                _context.parkings.Add(parking);
                _context.SaveChanges();
                return Created("",new {Message="Created Successfuly",Data=parking});
            }
            catch (System.Exception)
            {
                
                return Ok(new {Message="Adding a new parking failed"});
            }
          
        }

        [HttpPut("{id}")]
        public IActionResult Updateparking([FromRoute]int id, [FromBody]Parking parking){
             var park = _context.parkings.Where(parking=>parking.id==id).FirstOrDefault();
             if (park != null){
               park.name=parking.name;
               park.active=parking.active;
               _context.SaveChanges();
                return Ok(new {Message="parking updated successfuly",Data=park});
           }else{
               return NotFound(new {Message="failed to update. no such parking in the record!"});
           }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeleteParkingById([FromRoute]int id){
           var parking = _context.parkings.Where(parking=>parking.id==id).FirstOrDefault();
           if (parking != null){
               _context.parkings.Remove(parking);
               _context.SaveChanges();
                return Ok(new {Message="parking deleted successfuly"});
           }else{
               return NotFound(new {Message="failed to delete. no such parking in the record!"});
           }
        }

        

    }
}