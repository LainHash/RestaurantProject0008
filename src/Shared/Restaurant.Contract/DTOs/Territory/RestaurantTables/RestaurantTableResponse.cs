using Restaurant.Domain.Entities.Territory;

namespace Restaurant.Contract.DTOs.Territory.RestaurantTables
{
    public class RestaurantTableResponse
    {
        public string TableNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Status { get; set; } = string.Empty;

        public RestaurantTableResponse(RestaurantTable table)
        {
            TableNumber = table.TableNumber;
            Capacity = table.Capacity;
            Status = table.Status;
        }
    }
}
