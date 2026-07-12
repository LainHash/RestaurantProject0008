using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Reservations.Command.UpdateStatus
{
    public class UpdateReservationStatusSpecification
        : BaseSpecification<Reservation>
    {
        public UpdateReservationStatusRequest Body { get; set; } = null!;
        public UpdateReservationStatusSpecification(UpdateReservationStatusCommand command)
        {
            Criteria = r => r.Id == command.Id;
            Body = command.Body;

            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.User));
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.Profile));

            AddInclude(r => r.RestaurantTable);
        }
    }
}
