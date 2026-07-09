using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Guests
{
    public partial class Customer : SoftDeletableEntity
    {
        public Guid UserId { get; private set; }
        public Guid? PersonalInformationId { get; private set; }

        public virtual User User { get; private set; } = null!;
        public virtual PersonalInformation? PersonalInformation { get; private set; }
        public virtual Cart? Cart { get; private set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();
    }

    public partial class Customer
    {
        public Customer() { }
        public Customer(Guid id, Guid userId, Guid? personalInformationId = null)
        {
            Id = id;
            UserId = userId;
            PersonalInformationId = personalInformationId;
        }

        public Customer(Guid userId, Guid? personalInformationId = null)
        {
            UserId = userId;
            PersonalInformationId = personalInformationId;
        }

        public void CompleteProfile(Guid piId)
        {
            PersonalInformationId = piId;
        }
    }
}
