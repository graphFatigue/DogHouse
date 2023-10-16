using DogHouse.DAL.Interfaces;
using DogHouse.DAL.PageSort;
using DogHouse.Domain.Entity;
using DogHouse.Domain.Enum;
using DogHouse.Domain.Response;
using DogHouse.Service.Implementations;
using DogHouse.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DogHouse.Tests.Services
{
    public class DogServiceTests
    {
        [Fact]
        public async Task Create_ReturnsOkResponse_WhenDogIsCreated()
        {
            // Arrange
            var mockRepository = new Mock<IBaseRepository<Dog>>();
            var dogService = new DogService(mockRepository.Object);
            var dog = new Dog { Name = "Buddy", Color = "Brown", TailLength = 5, Weight = 10 };

            mockRepository.Setup(repo => repo.Create(It.IsAny<Dog>()))
                .Callback<Dog>(d => d.Id = 1); 

            // Act
            var response = await dogService.Create(dog);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(StatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Data);
            Assert.Equal(1, response.Data.Id);
        }

        [Fact]
        public void GetDogs_ReturnsOkResponse_WhenDogsAreFound()
        {
            // Arrange
            var mockRepository = new Mock<IBaseRepository<Dog>>();
            var dogService = new DogService(mockRepository.Object);
            var dogs = new List<Dog> { new Dog { Id = 1, Name = "Buddy" } }.AsQueryable();

            mockRepository.Setup(repo => repo.GetAll()).Returns(dogs);

            // Act
            var response = dogService.GetDogs();

            // Assert
            Assert.NotNull(response);
            Assert.Equal(StatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Data);
            Assert.Single(response.Data);
        }
    }
}
