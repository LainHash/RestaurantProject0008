using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.UpdateStatus
{
    public record UpdateReservationStatusCommand(Guid Id, UpdaterReservationStatusRequest Body)
        : IRequest<Result<ReservationResponse>>
    {
    }
}
