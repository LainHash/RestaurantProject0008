using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Repositories.Identity;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Identity
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly RestaurantDbContext _context;
        public RoleRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> ToListAsync(CancellationToken cancellationToken)
        {
            return await _context.Roles.ToListAsync(cancellationToken);
        }

        public async Task<Role?> FindAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public async Task<Role?> FindAsync(string name, CancellationToken cancellationToken)
        {
            return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name, cancellationToken);
        }
    }
}
