using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Domain.Repositories.Identity
{
    public interface IPersonalInformationRepository
    {
        Task<List<PersonalInformation>> ToListAsync(CancellationToken cancellationToken = default);
        Task<PersonalInformation?> FindAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
