using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Persistence.Configurations.Production
{
    internal class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(20)
                .HasDefaultValue("Percentage");

            builder.Property(x => x.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();
        }
    }
}
