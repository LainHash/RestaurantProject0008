using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek
{
    internal class GetAllReservationsByWeekQueryHandler : IRequestHandler<GetAllReservationsByWeekQuery, Result<IEnumerable<ReservationResponse>>>
    {
        public Task<Result<IEnumerable<ReservationResponse>>> Handle(GetAllReservationsByWeekQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
