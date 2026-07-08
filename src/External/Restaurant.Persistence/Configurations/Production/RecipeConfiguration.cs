using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Restaurant.Domain.Entities.Production;

namespace Restaurant.Persistence.Configurations.Production
{
    internal class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(r => r.Inspiration)
                .HasMaxLength(100);

            builder.Property(r => r.Note)
                .HasMaxLength(500);

            // Relationship
            builder.HasOne(r => r.Product)
                .WithMany(p => p.Recipes)
                .HasForeignKey(r => r.ProductId)
                .HasPrincipalKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
