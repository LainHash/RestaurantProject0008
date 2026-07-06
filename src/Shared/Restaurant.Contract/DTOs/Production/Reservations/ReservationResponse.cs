using Restaurant.Contract.DTOs.Guests.Customers;
using Restaurant.Contract.DTOs.Misc.TempContacts;

namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class ReservationResponse
    {
        public Guid Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }

        public CustomerReponse Customer { get; set; } = null!;
        public TemporaryContactResponse TemporaryContact { get; set; } = null!;
    }
}
