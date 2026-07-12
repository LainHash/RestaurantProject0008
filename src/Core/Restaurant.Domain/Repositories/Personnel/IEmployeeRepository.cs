using Restaurant.Domain.Entities.Personnel;

namespace Restaurant.Domain.Repositories.Personnel
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ToListAsync(CancellationToken cancellation = default);
        Task<Employee?> FindAsync(Guid id, CancellationToken cancellation = default);
    }
}
