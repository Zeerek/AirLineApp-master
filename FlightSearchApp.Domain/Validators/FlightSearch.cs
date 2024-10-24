using FlightSearchApp.Domain.Models;
using FluentValidation;

namespace FlightSearchApp.Domain.Validators
{
    public class FlightSearch : AbstractValidator<FlightSearchRequest>
    {
        public FlightSearch()
        {
            RuleFor(x => x.Origin).NotEmpty().WithMessage("Origin is required.");
            RuleFor(x => x.Destination).NotEmpty().WithMessage("Destination is required.");
            RuleFor(x => x.Departure_Date).NotEmpty().WithMessage("Departure Date is required.");
        }
    }
}
