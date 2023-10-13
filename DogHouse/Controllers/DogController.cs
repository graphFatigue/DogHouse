using DogHouse.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DogHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet(Name = "GetDogs")]
        public JsonResult GetDogs()
        {
            var response = _dogService.GetDogs();
            if (response.StatusCode == Domain.Enum.StatusCode.OK && response.Description == "Found 0 elements")
            {
                return new JsonResult(response.Description);
            }
                return new JsonResult(Ok(response.Data));
        }
    }
}
