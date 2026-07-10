using FluentValidation;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForCustomer
{
    internal class CreateReservationForCustomerValidator : AbstractValidator<CreateReservationForCustomerCommand>
    {
        public CreateReservationForCustomerValidator()
        {

            RuleFor(x => x.Body.NumberOfGuests)
                .GreaterThan(0).WithMessage("Number of guests must be greater than 0.");

            RuleFor(x => x.Body.ReservationTime)
                .Must(time => time >= DateTime.UtcNow.AddHours(2))
                .WithMessage("Reservation must be made at least 2 hours in advance.");
        }
    }
}
