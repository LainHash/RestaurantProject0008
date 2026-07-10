using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Persistence.Configurations.Guests
{
    internal class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.SessionId)
                .IsUnique();

            builder.HasIndex(x => x.CustomerId)
                .IsUnique();

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Cart)
                .HasForeignKey<Cart>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Cart_CustomerId_Or_SessionId",
                    "\"CustomerId\" IS NOT NULL OR \"SessionId\" IS NOT NULL");
            });
        }
    }
}
