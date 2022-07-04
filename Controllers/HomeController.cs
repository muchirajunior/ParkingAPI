using Microsoft.AspNetCore.Mvc;
//using ParkingAPI.Models;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : Controller
    {
        public HomeController(){}

        [HttpGet("")]
        public IActionResult Index()
        {
            return Ok(new {Message="Running Successfuly"});
        }
    }
}