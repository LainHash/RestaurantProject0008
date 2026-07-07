using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForCustomer
{
    internal class CreateReservationForCustomerCommandHandler
        : IRequestHandler<CreateReservationForCustomerCommand, Result<ReservationResponse>>
    {
        private readonly IReservationService _reservationService;
        public CreateReservationForCustomerCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<Result<ReservationResponse>> Handle(CreateReservationForCustomerCommand request, CancellationToken cancellationToken)
        {
            var response = await _reservationService.CreateForCustomerAsync(request.Body, request.UserId, cancellationToken);
            return response;
        }
    }
}
