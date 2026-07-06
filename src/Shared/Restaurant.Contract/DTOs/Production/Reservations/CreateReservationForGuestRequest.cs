using Restaurant.Contract.DTOs.Misc.TempContacts;

namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class CreateReservationForGuestRequest
    {
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string? Note { get; set; }

        public Guid RestaurantTableId { get; set; }
        public string GuestName { get; set; } = string.Empty;
        public string GuestEmail { get; set; } = string.Empty;
        public string GuestPhone { get; set; } = string.Empty;
    }
}
