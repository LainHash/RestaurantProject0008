using MediatR;
using Restaurant.Application.Models.Abstraction;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAll
{
    public record GetAllReservationsQuery : PageQuery, IRequest<PageResult<IEnumerable<ReservationResponse>>>
    {
    }
}

