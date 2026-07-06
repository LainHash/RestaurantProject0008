using Restaurant.Contract.DTOs.Misc.TempContacts;

namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class CreateReservationForGuestRequest
    {
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }

        public Guid RestaurantTableId { get; set; }
        public CreateTemporaryContactRequest TemporaryContact { get; set; } = null!;
    }
}
