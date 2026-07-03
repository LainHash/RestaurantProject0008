using Microsoft.EntityFrameworkCore.Storage;

namespace Restaurant.Application.Services.Persistence
{
    public interface IUnitOfWork
    {
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
