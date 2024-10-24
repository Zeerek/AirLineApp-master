using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSearchApp.Domain.Entities;
using FlightSearchApp.Domain.Interfaces;
using FlightSearchApp.Application.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FlightSearchApp.Tests
{
    public class HotelServiceTests
    {
        private readonly Mock<ISabreApiClient> _sabreApiClientMock;
        private readonly Mock<ILogger<Hotel_Service>> _loggerMock;
        private readonly Hotel_Service _hotelService;

        public HotelServiceTests()
        {
            _sabreApiClientMock = new Mock<ISabreApiClient>();
            _loggerMock = new Mock<ILogger<Hotel_Service>>();
            _hotelService = new Hotel_Service(_sabreApiClientMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task SearchHotelsAsync_ShouldReturnHotels()
        {
            // Arrange
            var city = "New Jersy";
           
            var hotels = new List<Hotel>
            {
                new Hotel { Name = "Hotel A", City = city }
            };

            _sabreApiClientMock
                .Setup(client => client.SearchHotelsAsync(city))
                .ReturnsAsync(hotels);

            // Act
            var result = await _hotelService.SearchHotelsAsync(city);

            // Assert
            Assert.Equal(hotels, result);
        }
    }
}
