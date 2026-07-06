using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForCustomer
{
    public record CreateReservationForCustomerCommand(CreateReservationForCustomerRequest Body)
        :IRequest<Result<ReservationResponse>>
    {
    }
}
