using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Inventory;

namespace Restaurant.Persistence.Configurations.Catalog
{
    internal class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            builder.Property(x => x.Description)
                    .HasMaxLength(500);

            builder.Property(x => x.CategoryId)
                    .IsRequired();

            // Soft delete filter
            builder.HasQueryFilter(x => !x.IsDeleted);

            builder.HasOne(x => x.IngredientStock)
                   .WithOne(x => x.Ingredient)
                   .HasForeignKey<IngredientStock>(x => x.IngredientId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
