using Restaurant.Contract.Enums;

namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class UpdateReservationStatusRequest
    {
        public ReservationStatus ReservationStatus { get; set; }
    }
}
