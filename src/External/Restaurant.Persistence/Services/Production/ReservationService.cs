using Restaurant.Application.Common.Enums;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAll;
using Restaurant.Application.Features.Production.Reservations.Queries.GetAllByWeek;
using Restaurant.Application.Features.Production.Reservations.Queries.GetById;
using Restaurant.Application.Mapping.Production;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Domain.Repositories.Production;
using Restaurant.Domain.Repositories.Territory;
using Restaurant.Domain.Specifications;
using System.Net;

namespace Restaurant.Persistence.Services.Production
{
    internal class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ReservationService(
            IReservationRepository reservationRepository,
            IUnitOfWork unitOfWork,
            IRestaurantTableRepository restaurantTableRepository,
            ICustomerRepository customerRepository)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
            _restaurantTableRepository = restaurantTableRepository;
            _customerRepository = customerRepository;
        }

        public async Task<Result<IEnumerable<ReservationResponse>>>
            GetAllAsync(GetAllReservationsSpecification specification, CancellationToken cancellationToken = default)
        {
            var reservations = await _reservationRepository.ToListAsync(specification, cancellationToken);

            var response = reservations.Select(r => new ReservationResponse(r));
            return Result<IEnumerable<ReservationResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<IEnumerable<ReservationResponse>>>
            GetAllByWeekAsync(GetAllReservationsByWeekSpecification specification, CancellationToken cancellationToken = default)
        {
            var reservations = await _reservationRepository.ToListAsync(specification, cancellationToken);

            var response = reservations.Select(r => new ReservationResponse(r));
            return Result<IEnumerable<ReservationResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<ReservationResponse>>
            GetByIdAsync(GetReservationByIdSpecification specification, CancellationToken cancellationToken = default)
        {
            var reservation = await _reservationRepository.FindAsync(specification, cancellationToken);
            if (reservation is null)
            {
                return Result<ReservationResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new ReservationResponse(reservation);
            return Result<ReservationResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<ReservationResponse>> 
            CreateForCustomerAsync(CreateReservationForCustomerRequest request, Guid userId, CancellationToken cancellationToken = default)
        {
            var availableTables = await _restaurantTableRepository
                .GetAvailableTablesAsync(
                    areaType: request.AreaType,
                    minCapacity: request.NumberOfGuests,
                    reservationTime: request.ReservationTime,
                    duration: request.DurationHours,
                    cancellationToken);

            var selectedTable = availableTables.FirstOrDefault();
            if (selectedTable is null)
            {
                return Result<ReservationResponse>.Fail(
                    "Không có bàn trống phù hợp trong khoảng thời gian này.",
                    HttpStatusCode.Conflict);
            }

            var reservation = new Reservation(request.ToInfo());
            reservation.AddTable(selectedTable.Id);

            var customer = await _customerRepository.FindByUserIdAsync(userId, cancellationToken);

            if (customer is not null)
            {
                reservation.AddCustomer(customer.Id);
            }

            await _reservationRepository.AddAsync(reservation, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var createdReservation = await _reservationRepository.FindAsync(
                new GetReservationByIdSpecification(reservation.Id), cancellationToken);

            var response = new ReservationResponse(createdReservation!);
            return Result<ReservationResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<ReservationResponse>> 
            CreateForGuestAsync(CreateReservationForGuestRequest request, CancellationToken cancellationToken = default)
        {
            var availableTables = await _restaurantTableRepository
                .GetAvailableTablesAsync(
                    areaType: request.AreaType,
                    minCapacity: request.NumberOfGuests,
                    reservationTime: request.ReservationTime,
                    duration: request.DurationHours,
                    cancellationToken);

            var selectedTable = availableTables.FirstOrDefault();
            if (selectedTable is null)
            {
                return Result<ReservationResponse>.Fail(
                    "Không có bàn trống phù hợp trong khoảng thời gian này.",
                    HttpStatusCode.Conflict);
            }

            var reservation = new Reservation(request.ToInfo());
            reservation.AddTable(selectedTable.Id);

            await _reservationRepository.AddAsync(reservation, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var createdReservation = await _reservationRepository.FindAsync(
                new GetReservationByIdSpecification(reservation.Id), cancellationToken);

            var response = new ReservationResponse(createdReservation!);
            return Result<ReservationResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }
    }
}
