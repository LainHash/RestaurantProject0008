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
                    Status: nameof(ReservationStatus.Pending),
                    Note: request.Note,
                    RestaurantTableId: request.RestaurantTableId,
                    CustomerId: request.CustomerId);
        }

        public static CreateReservationForGuestInformation ToInfo(this CreateReservationForGuestRequest request) 
        {
            return new CreateReservationForGuestInformation(
                ReservationTime: request.ReservationTime,
                    NumberOfGuests: request.NumberOfGuests,
                    Status: nameof(ReservationStatus.Pending),
                    Note: request.Note,
                    RestaurantTableId: request.RestaurantTableId,
                    GuestEmail: request.GuestEmail,
                    GuestName: request.GuestName,
                    GuestPhone: request.GuestPhone);
        }
    }
}
