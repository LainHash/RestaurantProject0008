using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Guests;

namespace Restaurant.Persistence.Configurations.Guests
{
    internal class WishlistItemConfiguration : IEntityTypeConfiguration<WishlistItem>
    {
        public void Configure(EntityTypeBuilder<WishlistItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.Property(x => x.LineTotal)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.AddedAt)
                .HasDefaultValueSql("NOW()")
                .IsRequired();

            builder.HasOne(x => x.Wishlist)
                .WithMany(x => x.WishlistItems)
                .HasForeignKey(x => x.WishlistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.WishlistItems)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.WishlistId, x.ProductId })
                .IsUnique();
        }
    }
}
