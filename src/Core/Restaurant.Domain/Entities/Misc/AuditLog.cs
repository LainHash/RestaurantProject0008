using Restaurant.Domain.Enums;

namespace Restaurant.Domain.Entities.Misc
{
    /// <summary>
    /// Ghi lại một thao tác Create / Update / Delete trên một entity.
    /// <para>
    ///   • <see cref="OldValues"/>: JSON chứa các field và giá trị CŨ (chỉ field bị thay đổi).
    ///   • <see cref="NewValues"/>: JSON chứa các field và giá trị MỚI (chỉ field bị thay đổi).
    /// </para>
    /// </summary>
    public class AuditLog
    {
        // ── Khóa chính ──────────────────────────────────────────────────────────
        public Guid Id { get; private set; }

        // ── Thông tin entity bị tác động ────────────────────────────────────────
        public string EntityName { get; private set; } = string.Empty;
        public string EntityId   { get; private set; } = string.Empty;
        public AuditAction Action { get; private set; }

        // ── Diff JSON ───────────────────────────────────────────────────────────
        /// <summary>JSON {"Field": oldValue, ...} — null nếu action là Created.</summary>
        public string? OldValues { get; private set; }

        /// <summary>JSON {"Field": newValue, ...} — null nếu action là Deleted.</summary>
        public string? NewValues { get; private set; }

        // ── Thông tin actor ─────────────────────────────────────────────────────
        public string? ActorId   { get; private set; }
        public string? ActorName { get; private set; }
        public string? IpAddress { get; private set; }

        // ── Thời điểm ───────────────────────────────────────────────────────────
        public DateTime OccurredAt { get; private set; }

        private AuditLog() { }

        public static AuditLog Create(
            string entityName,
            string entityId,
            AuditAction action,
            string? oldValues,
            string? newValues,
            string? actorId,
            string? actorName,
            string? ipAddress,
            DateTime occurredAt)
        {
            return new AuditLog
            {
                Id         = Guid.CreateVersion7(),
                EntityName = entityName,
                EntityId   = entityId,
                Action     = action,
                OldValues  = oldValues,
                NewValues  = newValues,
                ActorId    = actorId,
                ActorName  = actorName,
                IpAddress  = ipAddress,
                OccurredAt = occurredAt
            };
        }

        /// <summary>Cho phép cập nhật EntityId sau khi PK được EF Core generate (với Added entries).</summary>
        public void SetEntityId(string entityId) => EntityId = entityId;
    }
}
