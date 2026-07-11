using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Domain.Entities.Territory
{
    public partial class RestaurantTable : SoftDeletableEntity
    {
        public string TableNumber { get; private set; } = string.Empty;
        public int Capacity { get; private set; }
        public string Status { get; private set; } = string.Empty;

        public Guid AreaId { get; private set; }

        public virtual Area Area { get; private set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; private set; } = new List<Reservation>();

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

        public static RestaurantTable Create(string tableNumber, int capacity, string status, Guid areaId)
        {
            return new RestaurantTable(tableNumber, capacity, status, areaId);
        }

        public void Update(string tableNumber, int capacity, string status, Guid areaId)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            Status = status;
            AreaId = areaId;
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }
    }
}
