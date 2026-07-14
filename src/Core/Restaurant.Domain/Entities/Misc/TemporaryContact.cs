using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Misc
{
    public partial class TemporaryContact : AuditableEntity
    {
        public string GuestName { get; private set; } = string.Empty;
        public string GuestEmail { get; private set; } = string.Empty;
        public string GuestPhone { get; private set; } = string.Empty;

        public virtual Reservation Reservation { get; private set; } = null!;

    }

    public partial class TemporaryContact
    {
        public TemporaryContact() { }

        public TemporaryContact(string guestName, string guestEmail, string guestPhone)
        {
            GuestName = guestName;
            GuestEmail = guestEmail;
            GuestPhone = guestPhone;
        }
        public TemporaryContact(Guid id, string guestName, string guestEmail, string guestPhone)
        {
            Id = id;
            GuestName = guestName;
            GuestEmail = guestEmail;
            GuestPhone = guestPhone;
        }

    }
}
