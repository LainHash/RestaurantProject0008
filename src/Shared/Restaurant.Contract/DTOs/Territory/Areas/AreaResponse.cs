using Restaurant.Contract.DTOs.Territory.RestaurantTables;
using Restaurant.Domain.Entities.Territory;

namespace Restaurant.Contract.DTOs.Territory.Areas
{
    public class AreaResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public IEnumerable<RestaurantTableResponse> Tables { get; set; } = new List<RestaurantTableResponse>();

        public AreaResponse(Area area)
        {
            Id = area.Id;
            Name = area.Name;
            Description = area.Description;
            Type = area.Type;
            Status = area.Status;
            Tables = area.RestaurantTables.Select(table => new RestaurantTableResponse(table)).ToList();
        }
    }
}
