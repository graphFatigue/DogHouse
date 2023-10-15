using DogHouse.DAL.PageSort;
using DogHouse.Domain.Entity;
using DogHouse.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DogHouse.Controllers
{
    [Route("dogs")]
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

        [HttpGet(" ")]
        public async Task<JsonResult> GetDogsByParams([FromQuery] PageSortParam pageSortParam)
        {
            var response = await _dogService.GetDogsByParamsAsync(pageSortParam);
            if (response.StatusCode == Domain.Enum.StatusCode.OK && response.Description == "Found 0 elements")
            {
                return new JsonResult(response.Description);
            }
            return new JsonResult(Ok(response.Data));
        }

        [Route("dog")]
        [HttpPost]
        public async Task<JsonResult> CreateEdit([FromQuery] Dog dog)
        {
            if (dog.Id == 0)
            {
                var responseCreate = await _dogService.Create(dog);
                return new JsonResult(Ok(responseCreate.Data));
            }

            if (await _dogService.GetDog(dog.Id) == null)
            {
                return new JsonResult(NotFound());
            }

            var responseEdit = await _dogService.Edit(dog.Id, dog);
            return new JsonResult(Ok(responseEdit.Data));

        }
    }
}
