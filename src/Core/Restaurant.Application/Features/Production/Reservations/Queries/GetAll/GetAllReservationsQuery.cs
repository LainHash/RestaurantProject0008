using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAll
{
    public record GetAllReservationsQuery : IRequest<Result<IEnumerable<ReservationResponse>>>
    {
    }
}
