using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Territory
{
    public partial class Area : SoftDeletableEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string? Description { get; private set; }
        public string Type { get; private set; } = string.Empty;
        public string Status { get; private set; } = string.Empty;

        public virtual ICollection<RestaurantTable> RestaurantTables { get; private set; } = new List<RestaurantTable>();

    }

    public partial class Area
    {
        public Area(string name, string? description, string type, string status)
        {
            Name = name;
            Description = description;
            Type = type;
            Status = status;
        }

        public Area(Guid id, string name, string? description, string type, string status)
        {
            Id = id;
            Name = name;
            Description = description;
            Type = type;
            Status = status;
        }
    }
}
