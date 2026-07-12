using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Domain.Specifications;
using Restaurant.Persistence.Contexts;
using Restaurant.Persistence.Specifications;

namespace Restaurant.Persistence.Repositories.Guest
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly RestaurantDbContext _context;
        public CustomerRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Customers.ToListAsync(cancellationToken);
        }

        public async Task<List<Customer>> ToListAsync(ISpecification<Customer> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Customers.AsQueryable().AsNoTracking(), specification);
            return await query.ToListAsync(cancellationToken);
        }
        public async Task<Customer?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Customer?> FindAsync(ISpecification<Customer> specification, CancellationToken cancellationToken = default)
        {
            var query = SpecificationEvaluator
                .GetQuery(_context.Customers.AsQueryable().AsNoTracking(), specification);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }


        public async Task<Customer?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        }

        public Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Add(customer);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Update(customer);
            return Task.CompletedTask;
        }
    }
}
