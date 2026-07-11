using Restaurant.Contract.Enums;

namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class UpdaterReservationStatusRequest
    {
        public ReservationStatus ReservationStatus { get; set; }
    }
}
