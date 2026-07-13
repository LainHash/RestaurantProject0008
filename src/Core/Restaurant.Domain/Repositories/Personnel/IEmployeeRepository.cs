using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Specifications;

namespace Restaurant.Domain.Repositories.Personnel
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ToListAsync(CancellationToken cancellation = default);
        Task<IEnumerable<Employee>> ToListAsync(ISpecification<Employee> specification, CancellationToken cancellation = default);
        Task<Employee?> FindAsync(Guid id, CancellationToken cancellation = default);
        Task<Employee?> FindAsync(ISpecification<Employee> specification, CancellationToken cancellation = default);
        Task<Employee?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task AddAsync(Employee employee, CancellationToken cancellationToken = default);
        Task UpdateAsync(Employee employee, CancellationToken cancellationToken = default);
    }
}
