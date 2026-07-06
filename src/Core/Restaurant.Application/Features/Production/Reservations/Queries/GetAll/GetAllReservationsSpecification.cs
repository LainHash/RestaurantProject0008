using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAll
{
    public class GetAllReservationsSpecification : BaseSpecification<Reservation>
    {
        public GetAllReservationsSpecification(GetAllReservationsQuery query)
        {
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.User));
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.PersonalInformation));

            AddInclude(r => r.RestaurantTable);
        }
    }
}
