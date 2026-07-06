using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.Create
{
    public record CreateReservationCommand(CreateReservationRequest Body) : IRequest<Result<ReservationResponse>>
    {
    }
}
