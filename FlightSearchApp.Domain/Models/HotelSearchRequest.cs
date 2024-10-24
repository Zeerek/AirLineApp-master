namespace FlightSearchApp.Domain.Models
{
    public class HotelSearchRequest
    {
        
        public string? City { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
