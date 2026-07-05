using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Persistence.Contexts;

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
        public async Task<Customer?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Customer?> FindByUserIdAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.UserId == userId, cancellationToken);
        }

        public async Task AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
