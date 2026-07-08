using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForGuest
{
    public class CreateReservationForGuestSpecification : BaseSpecification<Reservation>
    {
        public CreateReservationForGuestRequest Body { get; set; }

        public CreateReservationForGuestSpecification(CreateReservationForGuestCommand command)
        {
            Body = command.Body;

            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.User));
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.PersonalInformation));

            AddInclude(r => r.RestaurantTable);
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = r => r.Id == id;
        }
    }
}
