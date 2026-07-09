using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;

namespace Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek
{
    internal class GetAllReservationsByWeekQueryHandler : IRequestHandler<GetAllReservationsByWeekQuery, PageResult<IEnumerable<ReservationResponse>>>
    {
        private readonly IReservationService _reservationService;
        public GetAllReservationsByWeekQueryHandler(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public async Task<PageResult<IEnumerable<ReservationResponse>>> Handle(GetAllReservationsByWeekQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllReservationsByWeekSpecification(request);
            var response = await _reservationService.GetAllByWeekAsync(specification, cancellationToken);
            return response;
        }
    }
}
