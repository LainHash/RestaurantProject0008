using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Enums;

namespace Restaurant.Persistence.Configurations.Misc
{
    internal class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            builder.ToTable("audit_logs");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EntityName)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.EntityId)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Action)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(x => x.OldValues)
                .HasColumnType("jsonb");

            builder.Property(x => x.NewValues)
                .HasColumnType("jsonb");

            builder.Property(x => x.ActorId)
                .HasMaxLength(100);

            builder.Property(x => x.ActorName)
                .HasMaxLength(256);

            builder.Property(x => x.IpAddress)
                .HasMaxLength(45); // IPv6 max length

            builder.Property(x => x.OccurredAt)
                .IsRequired();

            // ── Indexes ─────────────────────────────────────────────────────────
            builder.HasIndex(x => new { x.EntityName, x.EntityId })
                .HasDatabaseName("ix_audit_logs_entity");

            builder.HasIndex(x => x.OccurredAt)
                .HasDatabaseName("ix_audit_logs_occurred_at");

            builder.HasIndex(x => x.ActorId)
                .HasDatabaseName("ix_audit_logs_actor_id");
        }
    }
}
