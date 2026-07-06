using FluentValidation;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForGuest
{
    internal class CreateReservationForGuestValidator : AbstractValidator<CreateReservationForGuestCommand>
    {
        public CreateReservationForGuestValidator()
        {
            RuleFor(x => x.Body.GuestName)
                    .NotEmpty().WithMessage("Guest name is required.");

            RuleFor(x => x.Body.GuestEmail)
                .NotEmpty().WithMessage("Guest email is required.");

            RuleFor(x => x.Body.GuestPhone)
                .NotEmpty().WithMessage("Guest phone is required.");

            RuleFor(x => x.Body.NumberOfGuests)
                    .GreaterThan(0).WithMessage("Number of guests must be greater than 0.");

            RuleFor(x => x.Body.ReservationTime)
                .Must(time => time >= DateTime.Now.AddHours(2))
                .WithMessage("Reservation must be made at least 2 hours in advance.");
        }
    }
}
