using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Territory
{
    public partial class RestaurantTable : SoftDeletableEntity
    {
        public string TableNumber { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Status { get; set; } = string.Empty;

        public Guid AreaId { get; set; }

        public virtual Area Area { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    }

    public partial class RestaurantTable
    {
        public RestaurantTable(string tableNumber, int capacity, string status, Guid areaId)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            Status = status;
            AreaId = areaId;
        }

        public RestaurantTable(Guid id, string tableNumber, int capacity, string status, Guid areaId)
        {
            Id = id;
            TableNumber = tableNumber;
            Capacity = capacity;
            Status = status;
            AreaId = areaId;
        }
    }
}
