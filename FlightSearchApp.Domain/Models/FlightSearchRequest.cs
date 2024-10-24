namespace FlightSearchApp.Domain.Models
{
    public class FlightSearchRequest
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public DateTime Departure_Date { get; set; }
    }
}
