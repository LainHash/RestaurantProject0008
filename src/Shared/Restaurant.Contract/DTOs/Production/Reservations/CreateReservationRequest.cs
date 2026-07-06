using Restaurant.Contract.DTOs.Misc.TempContacts;

namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class CreateReservationRequest
    {
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string? Note { get; set; }

        public Guid? CustomerId { get; set; }
        public CreateTemporaryContactRequest? TemporaryContact { get; set; }
    }
}
