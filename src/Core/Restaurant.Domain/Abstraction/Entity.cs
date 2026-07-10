namespace Restaurant.Domain.Abstraction
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        protected Entity()
        {
            Id = Guid.CreateVersion7();
        }
    }

    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;

        public void MarkCreated(DateTime now)
        {
            CreatedAt = now;
            UpdatedAt = now;
        }

        public void MarkUpdated(DateTime now)
        {
            UpdatedAt = now;
        }
    }

    public abstract class SoftDeletableEntity : AuditableEntity
    {
        public bool IsDeleted { get; protected set; } = false;
        public DateTime? DeletedAt { get; protected set; } = null;
        public void SoftDelete()
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        public void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
        }
    }
}
