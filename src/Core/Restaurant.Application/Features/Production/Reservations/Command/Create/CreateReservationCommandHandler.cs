using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.Create
{
    internal class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Result<ReservationResponse>>
    {
        private readonly IReservationService _reservationService;
        public CreateReservationCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<Result<ReservationResponse>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var response = await _reservationService.CreateAsync(request.Body, cancellationToken);
            return response;
        }
    }
}
