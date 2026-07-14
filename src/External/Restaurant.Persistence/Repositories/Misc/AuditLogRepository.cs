using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Repositories.Misc;
using Restaurant.Persistence.Contexts;

namespace Restaurant.Persistence.Repositories.Misc
{
    internal class AuditLogRepository : IAuditLogRepository
    {
        private readonly RestaurantDbContext _context;

        public AuditLogRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public Task AddRangeAsync(IEnumerable<AuditLog> logs, CancellationToken cancellationToken = default)
        {
            _context.AuditLogs.AddRange(logs);
            return Task.CompletedTask;
        }

        public async Task<List<AuditLog>> GetAsync(
            string? entityName,
            string? entityId,
            AuditAction? action,
            string? actorId,
            DateTime? from,
            DateTime? to,
            int page,
            int pageSize,
            CancellationToken cancellationToken = default)
        {
            var query = BuildQuery(entityName, entityId, action, actorId, from, to);

            return await query
                .OrderByDescending(x => x.OccurredAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsync(
            string? entityName,
            string? entityId,
            AuditAction? action,
            string? actorId,
            DateTime? from,
            DateTime? to,
            CancellationToken cancellationToken = default)
        {
            return await BuildQuery(entityName, entityId, action, actorId, from, to)
                .CountAsync(cancellationToken);
        }

        // ── Private helpers ──────────────────────────────────────────────────

        private IQueryable<AuditLog> BuildQuery(
            string? entityName,
            string? entityId,
            AuditAction? action,
            string? actorId,
            DateTime? from,
            DateTime? to)
        {
            var query = _context.AuditLogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(entityName))
                query = query.Where(x => x.EntityName == entityName);

            if (!string.IsNullOrWhiteSpace(entityId))
                query = query.Where(x => x.EntityId == entityId);

            if (action.HasValue)
                query = query.Where(x => x.Action == action.Value);

            if (!string.IsNullOrWhiteSpace(actorId))
                query = query.Where(x => x.ActorId == actorId);

            if (from.HasValue)
                query = query.Where(x => x.OccurredAt >= from.Value);

            if (to.HasValue)
                query = query.Where(x => x.OccurredAt <= to.Value);

            return query;
        }
    }
}
