using Restaurant.Contract.DTOs.Guests.Customers;
using Restaurant.Contract.DTOs.Misc.TempContacts;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Contract.DTOs.Production.Reservations
{
    public class ReservationResponse
    {
        public Guid Id { get; set; }
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }

        public CustomerReponse? Customer { get; set; }
        public TemporaryContactResponse? TemporaryContact { get; set; }

        public RestaurantTableResponse RestaurantTable { get; set; } = null!;

        public ReservationResponse(Reservation reservation)
        {
            Id = reservation.Id;
            ReservationTime = reservation.ReservationTime;
            NumberOfGuests = reservation.NumberOfGuests;
            Status = reservation.Status;
            Note = reservation.Note;
            Customer = new CustomerReponse(reservation.Customer ?? new Customer());
            TemporaryContact = new TemporaryContactResponse(reservation.TemporaryContact ?? new TemporaryContact());
            RestaurantTable = new RestaurantTableResponse(reservation.RestaurantTable);
        }
    }
}
