namespace Restaurant.Contract.DTOs.Guests.Carts
{
    public class DeleteExpiredCartRequest
    {
        public IEnumerable<Guid> Ids { get; set; } = [];
    }
}
