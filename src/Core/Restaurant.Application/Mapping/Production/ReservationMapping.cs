using Restaurant.Application.Common.Enums;
using Restaurant.Contract.DTOs.Production.Reservations;
using Restaurant.Domain.Informations.Production.Reservations;

namespace Restaurant.Application.Mapping.Production
{
    public static class ReservationMapping
    {
        public static CreateReservationForCustomerInformation ToInfo(this CreateReservationForCustomerRequest request)
        {
            return new CreateReservationForCustomerInformation(
                    ReservationTime: request.ReservationTime,
                    NumberOfGuests: request.NumberOfGuests,
                    DurationHours: request.DurationHours,
                    Status: nameof(ReservationStatus.Pending),
                    Note: request.Note,
                    AreaType: request.AreaType);
        }

        public static CreateReservationForGuestInformation ToInfo(this CreateReservationForGuestRequest request) 
        {
            return new CreateReservationForGuestInformation(
                ReservationTime: request.ReservationTime,
                    NumberOfGuests: request.NumberOfGuests,
                    DurationHours: request.DurationHours,
                    Status: nameof(ReservationStatus.Pending),
                    Note: request.Note,
                    AreaType: request.AreaType,
                    GuestEmail: request.GuestEmail,
                    GuestName: request.GuestName,
                    GuestPhone: request.GuestPhone);
        }
    }
}
