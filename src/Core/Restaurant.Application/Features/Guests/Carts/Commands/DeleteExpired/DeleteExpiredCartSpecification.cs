using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Guests.Carts.Commands.DeleteExpired
{
    public class DeleteExpiredCartSpecification : BaseSpecification<Cart>
    {
        public DeleteExpiredCartSpecification(DeleteExpiredCartCommand command)
        {
            var threshold = DateTime.UtcNow.AddDays(-3);
            Criteria = c => c.CreatedAt < threshold && !c.CustomerId.HasValue;
        }
    }
}
