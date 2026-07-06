using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetById
{
    internal class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Result<ReservationResponse>>
    {
        private readonly IReservationService _reservationService;
        public GetReservationByIdQueryHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<Result<ReservationResponse>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var response = await _reservationService.GetByIdAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
