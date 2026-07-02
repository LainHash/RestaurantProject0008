using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Entities.Territory;

namespace Restaurant.Domain.Entities.Production
{
    public class Reservation : SoftDeletableEntity
    {
        public DateTime ReservationTime { get; set; }
        public int NumberOfGuests { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Note { get; set; }

        public Guid? CustomerId { get; set; }
        public Guid? TemporaryContactId { get; set; }
        public Guid RestaurantTableId { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual TemporaryContact? TemporaryContact { get; set; }
        public virtual RestaurantTable RestaurantTable { get; set; } = null!;

        public Reservation(Guid id, DateTime reservationTime, int numberOfGuests, string status, Guid restaurantTableId, string? note = null, Guid? customerId = null, Guid? temporaryContactId = null)
        {
            Id = id;
            ReservationTime = reservationTime;
            NumberOfGuests = numberOfGuests;
            Status = status;
            Note = note;
            CustomerId = customerId;
            TemporaryContactId = temporaryContactId;
            RestaurantTableId = restaurantTableId;
        }
    }
}
