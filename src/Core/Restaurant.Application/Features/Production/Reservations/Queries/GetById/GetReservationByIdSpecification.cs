using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetById
{
    public class GetReservationByIdSpecification : BaseSpecification<Reservation>
    {
        public GetReservationByIdSpecification(GetReservationByIdQuery query)
        {
            Criteria = r => r.Id == query.Id;

            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.User));
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.PersonalInformation));

            AddInclude(r => r.RestaurantTable);
        }

        public GetReservationByIdSpecification(Guid id)
        {
            Criteria = r => r.Id == id;

            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.User));
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.PersonalInformation));

            AddInclude(r => r.RestaurantTable);
        }
    }
}
