using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Repositories.Identity;
using Restaurant.Persistence.Contexts;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Persistence.Repositories.Identity
{
    internal class UserRepository : IUserRepository
    {
        private readonly RestaurantDbContext _context;
        public UserRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> ToListAsync(CancellationToken cancellationToken = default)
        {
            return _context.Users.ToListAsync(cancellationToken);
        }

        public Task<User?> FindAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<User?> FindAsync(string emailOrUserName, CancellationToken cancellationToken = default)
        {
            if(new EmailAddressAttribute().IsValid(emailOrUserName))
            {
                return _context.Users.FirstOrDefaultAsync(u => u.Email == emailOrUserName, cancellationToken);
            }
            return _context.Users.FirstOrDefaultAsync(u => u.UserName == emailOrUserName, cancellationToken);
        }

        public Task AddAsync(User user, CancellationToken cancellationToken = default)
        {
            _context.Add(user);
            return Task.CompletedTask;
        }
    }
}
