using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Repositories.Identity;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Identity
{
    internal class PersonalInformationRepository : IPersonalInformationRepository
    {
        private readonly RestaurantDbContext _context;
        public PersonalInformationRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public async Task<PersonalInformation?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.PersonalInformations.FirstOrDefaultAsync(pi => pi.Id == id, cancellationToken);
        }

        public async Task<List<PersonalInformation>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return await _context.PersonalInformations.ToListAsync(cancellationToken);
        }

        public async Task AddAsync(PersonalInformation personalInformation, CancellationToken cancellationToken = default)
        {
            _context.PersonalInformations.Add(personalInformation);
            await _context.SaveChangesAsync();
        }
    }
}
