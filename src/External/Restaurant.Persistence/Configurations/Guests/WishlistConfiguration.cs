using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Persistence.Configurations.Guests
{
    internal class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Wishlist)
                .HasForeignKey<Wishlist>(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Wishlist_CustomerId_Or_SessionId",
                    "\"CustomerId\" IS NOT NULL OR \"SessionId\" IS NOT NULL");
            });
        }
    }
}
