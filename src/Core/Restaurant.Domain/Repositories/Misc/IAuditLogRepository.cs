using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Repositories.Misc
{
    public interface IAuditLogRepository
    {
        Task AddRangeAsync(IEnumerable<AuditLog> logs, CancellationToken cancellationToken = default);

        Task<List<AuditLog>> GetAsync(
            string? entityName,
            string? entityId,
            AuditAction? action,
            string? actorId,
            DateTime? from,
            DateTime? to,
            int page,
            int pageSize,
            CancellationToken cancellationToken = default);

        Task<int> CountAsync(
            string? entityName,
            string? entityId,
            AuditAction? action,
            string? actorId,
            DateTime? from,
            DateTime? to,
            CancellationToken cancellationToken = default);
    }
}
