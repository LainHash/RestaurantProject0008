using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Identity
{
    public class Role : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public virtual ICollection<User> Users { get; private set; } = [];

        public Role(Guid id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
