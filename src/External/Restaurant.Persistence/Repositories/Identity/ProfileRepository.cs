using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Repositories.Identity;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Identity
{
    internal class ProfileRepository : IProfileRepository
    {
        private readonly RestaurantDbContext _context;
        public ProfileRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<Profile?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Profiles.FirstOrDefaultAsync(pi => pi.Id == id, cancellationToken);
        }

        public async Task<List<Profile>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Profiles.ToListAsync(cancellationToken);
        }

        public Task AddAsync(Profile profile, CancellationToken cancellationToken = default)
        {
            _context.Profiles.Add(profile);
            return Task.CompletedTask;
        }
    }
}
