using FlightSearchApp.Domain.Entities;
using FlightSearchApp.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FlightSearchApp.Application.Services
{
    public class Hotel_Service : IHotel_Service
    {
        private readonly ISabreApiClient _sabreApiClient;
        private readonly ILogger<Hotel_Service> _logger;

        public Hotel_Service(ISabreApiClient sabreApiClient, ILogger<Hotel_Service> logger)
        {
            _sabreApiClient = sabreApiClient;
            _logger = logger;
        }

        public async Task<IEnumerable<Hotel>> SearchHotelsAsync(string city)
        {
        
            if (string.IsNullOrWhiteSpace(city))
            {
                throw new ArgumentException("Location cannot be null or empty.", nameof(city));
            }
            try
            {
                return await _sabreApiClient.SearchHotelsAsync(city);
            }
            
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while searching for hotels in {City} from {CheckInDate} to {CheckOutDate}", city);
                throw;
            }
        }

    }
}
