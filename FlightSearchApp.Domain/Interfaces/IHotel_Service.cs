using FlightSearchApp.Domain.Entities;

namespace FlightSearchApp.Domain.Interfaces
{
    public interface IHotel_Service
    {
        Task<IEnumerable<Hotel>> SearchHotelsAsync(string city);
    }
}
