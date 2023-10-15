using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogHouse.Controllers
{
    [Route("ping")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Dogshouseservice.Version1.0.1");
        }
    }
}
