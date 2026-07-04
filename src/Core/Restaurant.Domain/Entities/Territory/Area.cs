using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Territory
{
    public partial class Area : SoftDeletableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public virtual ICollection<RestaurantTable> RestaurantTables { get; set; } = new List<RestaurantTable>();

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
