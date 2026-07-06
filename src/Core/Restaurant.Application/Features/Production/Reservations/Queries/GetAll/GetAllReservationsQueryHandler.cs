using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAll
{
    internal class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, Result<IEnumerable<ReservationResponse>>>
    {
        private readonly IReservationService _reservationService;
        public GetAllReservationsQueryHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<Result<IEnumerable<ReservationResponse>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var response = await _reservationService.GetAllAsync(cancellationToken);
            return response;
        }
    }
}
