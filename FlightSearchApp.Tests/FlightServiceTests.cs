﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlightSearchApp.Domain.Entities;
using FlightSearchApp.Domain.Interfaces;
using FlightSearchApp.Infrastructure.Services;
using Moq;
using Xunit;

namespace FlightSearchApp.Tests
{
    public class FlightServiceTests
    {
        private readonly Mock<ISabreApiClient> _sabreApiClientMock;
        private readonly Flight_Service _flightService;

        public FlightServiceTests()
        {
            _sabreApiClientMock = new Mock<ISabreApiClient>();
            _flightService = new Flight_Service(_sabreApiClientMock.Object);
        }

        [Fact]
        public async Task SearchFlightsAsync_ShouldReturnOneWayFlights()
        {
            // Arrange
            var origin = "AJK";
            var destination = "LMN";
            var departureDate = new DateTime(2024, 10, 22);
            var flights = new List<FlightSearchResponse>
            {
                new FlightSearchResponse { PricedItineraries = new List<PricedItinerary>() }
            };

            _sabreApiClientMock
                .Setup(client => client.SearchFlightsAsync(origin, destination, departureDate))
                .ReturnsAsync(flights);

            // Act
            var result = await _flightService.SearchFlightsAsync(origin, destination, departureDate);

            // Assert
            Assert.Equal(flights, result);
        }

        [Fact]
        public async Task SearchFlightsAsync_ShouldReturnRoundTripFlights()
        {
            // Arrange
            var origin = "AJK";
            var destination = "LMN";
            var departureDate = new DateTime(2024, 10, 22);
            var returnDate = new DateTime(2024, 10, 23);
            var outboundFlights = new List<FlightSearchResponse>
            {
                new FlightSearchResponse { PricedItineraries = new List<PricedItinerary>() }
            };
            var returnFlights = new List<FlightSearchResponse>
            {
                new FlightSearchResponse { PricedItineraries = new List<PricedItinerary>() }
            };

            _sabreApiClientMock
                .Setup(client => client.SearchFlightsAsync(origin, destination, departureDate))
                .ReturnsAsync(outboundFlights);

            _sabreApiClientMock
                .Setup(client => client.SearchFlightsAsync(destination, origin, returnDate))
                .ReturnsAsync(returnFlights);

            // Act
            var result = await _flightService.SearchFlightsAsync(origin, destination, departureDate, returnDate, isRoundTrip: true);

            // Assert
            Assert.Equal(outboundFlights, result); // Simplified for the test. Adjust as needed for combining results.
        }

        [Fact]
        public async Task SearchFlightsAsync_ShouldReturnMultiCityFlights()
        {
            // Arrange
            var multiCitySegments = new List<(string origin, string destination, DateTime departureDate)>
            {
                ("AJK", "LMN", new DateTime(2024, 10, 22)),
                ("SAT", "FFO", new DateTime(2024, 10, 23))
            };
            var segmentFlights = new List<FlightSearchResponse>
            {
                new FlightSearchResponse { PricedItineraries = new List<PricedItinerary>() }
            };

            _sabreApiClientMock
                .Setup(client => client.SearchFlightsAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<DateTime>()))
                .ReturnsAsync(segmentFlights);

            // Act
            var result = await _flightService.SearchFlightsAsync("", "", DateTime.MinValue, isMultiCity: true, multiCitySegments: multiCitySegments);

            // Assert
            Assert.Equal(segmentFlights.Count * multiCitySegments.Count, result.Count());
        }
    }
}
