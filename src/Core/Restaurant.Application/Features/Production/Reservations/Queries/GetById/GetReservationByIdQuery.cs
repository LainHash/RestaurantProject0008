using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetById
{
    public record GetReservationByIdQuery(Guid Id) : IRequest<Result<ReservationResponse>>
    {
    }
}
