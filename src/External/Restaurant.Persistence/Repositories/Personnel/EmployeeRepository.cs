using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Repositories.Personnel;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

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

        public async Task<IEnumerable<Employee>> ToListAsync(ISpecification<Employee> specification, CancellationToken cancellation = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Employees.AsQueryable().AsNoTracking(), specification);
            return await query.ToListAsync(cancellation);
        }

        public async Task<Employee?> FindAsync(Guid id, CancellationToken cancellation = default)
        {
            return await _context.Employees.FirstOrDefaultAsync(x => x.Id == id, cancellation);
        }

        public async Task<Employee?> FindAsync(ISpecification<Employee> specification, CancellationToken cancellation = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Employees.AsQueryable().AsNoTracking(), specification);
            return await query.FirstOrDefaultAsync(cancellation);
        }
    }
}
