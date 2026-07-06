using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Identity
{
    public class Role : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public virtual ICollection<User> Users { get; set; } = [];

        public Role(Guid id, string name, string? description = null)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
