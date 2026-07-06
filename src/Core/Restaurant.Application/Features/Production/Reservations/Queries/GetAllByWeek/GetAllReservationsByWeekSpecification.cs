using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek
{
    public class GetAllReservationsByWeekSpecification : BaseSpecification<Reservation>
    {
        public GetAllReservationsByWeekSpecification(GetAllReservationsByWeekQuery query)
        {
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.User));
            AddIncludeAggregator(r => r.Include(r => r.Customer)
                                        .ThenInclude((Customer? c) => c!.PersonalInformation));
            AddInclude(r => r.TemporaryContact!);
            AddInclude(r => r.RestaurantTable);

            var startOfWeek = query.WeekStart.Date;
            var endOfWeek = startOfWeek.AddDays(7);

            Criteria = r => r.ReservationTime >= startOfWeek && r.ReservationTime < endOfWeek;
        }
    }
}
