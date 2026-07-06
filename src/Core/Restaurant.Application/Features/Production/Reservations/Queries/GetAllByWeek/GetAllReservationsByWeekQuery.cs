using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek
{
    public record GetAllReservationsByWeekQuery(DateTime WeekStart) : IRequest<Result<IEnumerable<ReservationResponse>>>
    {
    }
}
