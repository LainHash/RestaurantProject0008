using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Guest
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> ToListAsync(CancellationToken cancellationToken = default);
        Task<List<Customer>> ToListAsync(ISpecification<Customer> specification,CancellationToken cancellationToken = default);
        Task<Customer?> FindAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Customer?> FindAsync(ISpecification<Customer> specification, CancellationToken cancellationToken = default);
        Task<Customer?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
        Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
    }
}
