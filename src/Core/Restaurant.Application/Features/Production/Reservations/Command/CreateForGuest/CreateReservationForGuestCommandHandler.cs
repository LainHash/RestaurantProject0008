using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.CreateForGuest
{
    internal class CreateReservationForGuestCommandHandler
        : IRequestHandler<CreateReservationForGuestCommand, Result<ReservationResponse>>
    {
        private readonly IReservationService _reservationService;
        public CreateReservationForGuestCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<Result<ReservationResponse>> Handle(CreateReservationForGuestCommand request, CancellationToken cancellationToken)
        {
            var response = await _reservationService.CreateForGuestAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
