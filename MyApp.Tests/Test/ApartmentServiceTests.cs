using Xunit;
using Moq;
using MyApp.Application.Services;
using MyApp.Application.Interfaces;
using MyApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Tests
{
    public class ApartmentServiceTests
    {
        [Fact]
        public async Task GetAllApartmentsAsync_ReturnsListOfApartments()
        {
            // Arrange
            var fakeApartments = new List<Apartment>
            {
                new Apartment { Id = 1, Title = "Test Apt 1" },
                new Apartment { Id = 2, Title = "Test Apt 2" }
            };

            var mockRepo = new Mock<IApartmentRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(fakeApartments);

            var service = new ApartmentService(mockRepo.Object);

            // Act
            var result = await service.GetAllApartmentsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, a => a.Title == "Test Apt 1");
        }
    }
}
