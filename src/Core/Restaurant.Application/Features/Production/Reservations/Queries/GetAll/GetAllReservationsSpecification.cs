using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Enums;
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
                                        .ThenInclude((Customer? c) => c!.Profile));
            AddInclude(r => r.TemporaryContact!);
            AddInclude(r => r.RestaurantTable);

            // OrderBy: sắp xếp theo thời gian đặt
            switch (query.SortBy)
            {
                case nameof(SortType.CreatedAtAsc):
                    ApplyOrderBy(r => r.ReservationTime);
                    break;
                default:
                    ApplyOrderByDescending(r => r.ReservationTime);
                    break;
            }

            // Paging
            ApplyPaging((query.IndexPage - 1) * query.PageSize, query.PageSize);
        }
    }
}

