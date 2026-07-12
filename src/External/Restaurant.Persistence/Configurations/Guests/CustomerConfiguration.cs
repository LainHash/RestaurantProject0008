using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Identity;

namespace Restaurant.Persistence.Configurations.Guests
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            // Relationships
            builder.HasOne(x => x.User)
                .WithOne(x => x.Customer)
                .HasForeignKey<Customer>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Profile)
                .WithOne(x => x.Customer)
                .HasForeignKey<Customer>(x => x.ProfileId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}

