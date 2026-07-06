using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForGuest
{
    public record CreateReservationForGuestCommand(CreateReservationForGuestRequest Body) 
        : IRequest<Result<ReservationResponse>>
    {
    }
}
