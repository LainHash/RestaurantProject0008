using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Personnel;

namespace Restaurant.Persistence.Configurations.Personnel
{
    internal class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);

            // Relationships
            builder.HasMany(x => x.Employees)
                   .WithOne(x => x.Position)
                   .HasForeignKey(x => x.PositionId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
