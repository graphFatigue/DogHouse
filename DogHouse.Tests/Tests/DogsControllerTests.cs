using DogHouse.Controllers;
using DogHouse.DAL.PageSort;
using DogHouse.Domain.Entity;
using DogHouse.Domain.Enum;
using DogHouse.Domain.Response;
using DogHouse.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DogHouse.Tests.Controllers
{
    public class DogControllerTests
    {
        [Fact]
        public async Task GetDogsByParams_Returns_OkResult_WithDogs()
        {
            // Arrange
            var mockDogService = new Mock<IDogService>();
            var controller = new DogController(mockDogService.Object);
            var pageSortParam = new PageSortParam();

            // Mocking the service response
            var dogs = new List<Dog> { new Dog { Id = 1, Name = "Buddy" } };
            var serviceResponse = new BaseResponse<List<Dog>>
            {
                StatusCode = StatusCode.OK,
                Description = "Found 1 element",
                Data = dogs
            };

            mockDogService.Setup(service => service.GetDogsByParamsAsync(pageSortParam))
                .ReturnsAsync(serviceResponse);

            // Act
            var result = await controller.GetDogsByParams(pageSortParam) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonSerializer.Serialize(serviceResponse.Data), JsonSerializer.Serialize(result.Value));
        }

        [Fact]
        public async Task CreateEdit_Returns_OkResult_When_DogIsCreated()
        {
            // Arrange
            var mockDogService = new Mock<IDogService>();
            var controller = new DogController(mockDogService.Object);
            var dog = new Dog { Name = "Buddy" };

            // Mocking the service response
            var serviceResponse = new BaseResponse<Dog>
            {
                StatusCode = StatusCode.OK,
                Description = "Dog created successfully",
                Data = dog
            };

            mockDogService.Setup(service => service.Create(dog))
                .ReturnsAsync(serviceResponse);

            // Act
            var result = await controller.CreateEdit(dog) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonSerializer.Serialize(serviceResponse.Data), JsonSerializer.Serialize(result.Value));
        }

        [Fact]
        public async Task CreateEdit_Returns_OkResult_When_DogIsEdited()
        {
            // Arrange
            var mockDogService = new Mock<IDogService>();
            var controller = new DogController(mockDogService.Object);
            var dog = new Dog { Id = 1, Name = "Buddy", TailLength = 4, Color = "Black", Weight = 8 };

            // Mocking the service response
            var serviceResponse = new BaseResponse<Dog>
            {
                StatusCode = StatusCode.OK,
                Description = "Dog updated successfully",
                Data = dog
            };

            mockDogService.Setup(service => service.GetDog(It.IsAny<int>()))
                .ReturnsAsync(serviceResponse); 

            mockDogService.Setup(service => service.Edit(dog.Id, dog))
                .ReturnsAsync(serviceResponse);

            // Act
            var result = await controller.CreateEdit(dog) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(JsonSerializer.Serialize(serviceResponse.Data), JsonSerializer.Serialize(result.Value));
        }
    }
}
