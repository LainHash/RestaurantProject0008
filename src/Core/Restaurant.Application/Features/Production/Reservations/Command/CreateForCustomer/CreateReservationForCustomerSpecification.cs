using Microsoft.EntityFrameworkCore;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForCustomer
{
    public class CreateReservationForCustomerSpecification : BaseSpecification<Reservation>
    {
        public CreateReservationForCustomerRequest Body { get; set; }
        public Guid UserId { get; set; }

        public CreateReservationForCustomerSpecification(CreateReservationForCustomerCommand command)
        {
            Body = command.Body;
            UserId = command.UserId;

            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.User));
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.Profile));

            AddInclude(r => r.RestaurantTable);
        }

        public void ApplyCriteria(Guid id)
        {
            Criteria = r => r.Id == id;
        }
    }
}
