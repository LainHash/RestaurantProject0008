using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAll
{
    internal class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, PageResult<IEnumerable<ReservationResponse>>>
    {
        private readonly IReservationService _reservationService;
        public GetAllReservationsQueryHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<PageResult<IEnumerable<ReservationResponse>>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllReservationsSpecification(request);
            var response = await _reservationService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
