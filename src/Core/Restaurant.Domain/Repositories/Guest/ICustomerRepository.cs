using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Domain.Repositories.Guest
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> ToListAsync(CancellationToken cancellationToken = default);
        Task<Customer?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Customer?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
    }
}
