using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Personnel
{
    public partial class Position : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }

        public virtual ICollection<Employee> Employees { get; private set; } = [];
    }

    public partial class Position
    {
        public Position(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}
