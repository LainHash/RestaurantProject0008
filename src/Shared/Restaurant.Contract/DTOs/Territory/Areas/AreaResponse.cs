using Restaurant.Contract.DTOs.Territory.RestaurantTables;

namespace Restaurant.Contract.DTOs.Territory.Areas
{
    public class AreaResponse
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public IEnumerable<RestaurantTableResponse> Tables { get; set; } = new List<RestaurantTableResponse>();
    }
}
