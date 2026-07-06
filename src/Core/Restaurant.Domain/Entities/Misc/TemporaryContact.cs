using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Misc
{
    public class TemporaryContact : Entity
    {
        public string GuestName { get; set; } = string.Empty;
        public string GuestEmail { get; set; } = string.Empty;
        public string GuestPhone { get; set; } = string.Empty;

        public virtual Reservation Reservation { get; set; } = null!;

        public TemporaryContact() { }
        public TemporaryContact(Guid id, string guestName, string guestEmail, string guestPhone)
        {
            Id = id;
            GuestName = guestName;
            GuestEmail = guestEmail;
            GuestPhone = guestPhone;
        }
    }
}
