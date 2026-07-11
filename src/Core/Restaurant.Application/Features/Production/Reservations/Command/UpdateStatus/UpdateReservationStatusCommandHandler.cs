using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Command.UpdateStatus
{
    internal class UpdateReservationStatusCommandHandler
        : IRequestHandler<UpdateReservationStatusCommand, Result<ReservationResponse>>
    {
        private readonly IReservationService _reservationService;

        public UpdateReservationStatusCommandHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<Result<ReservationResponse>> Handle(UpdateReservationStatusCommand request, CancellationToken cancellationToken)
        {
            var specification = new UpdateReservationStatusSpecification(request);
            var response = await _reservationService.UpdateStatusAsync(specification, cancellationToken);
            return response;
        }
    }
}
