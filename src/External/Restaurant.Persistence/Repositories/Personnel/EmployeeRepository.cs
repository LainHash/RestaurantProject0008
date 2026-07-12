using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Repositories.Personnel;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Personnel
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly RestaurantDbContext _context;

        public EmployeeRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> ToListAsync(CancellationToken cancellation = default)
        {
            return await _context.Employees.ToListAsync(cancellation);
        }

        public async Task<Employee?> FindAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellation);
        }
    }
}
