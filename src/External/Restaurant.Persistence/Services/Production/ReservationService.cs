using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Repositories.Production;
using System.Net;

namespace Restaurant.Persistence.Services.Production
{
    internal class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Result<IEnumerable<ReservationResponse>>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var reservations = await _reservationRepository.ToListAsync(cancellationToken);

            var response = reservations.Select(r => new ReservationResponse(r));
            return Result<IEnumerable<ReservationResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<ReservationResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var reservation = await _reservationRepository.FindAsync(id, cancellationToken);
            if(reservation is null)
            {
                return Result<ReservationResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new ReservationResponse(reservation);
            return Result<ReservationResponse>
                .Succeed(response, Success.Retrieved);
        }
    }
}
