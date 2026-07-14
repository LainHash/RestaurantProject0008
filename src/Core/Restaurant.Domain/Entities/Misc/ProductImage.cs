using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Domain.Entities.Misc
{
    public partial class ProductImage : AuditableEntity
    {
        public int DisplayOrder { get; private set; }

        public Guid ProductId { get; private set; }
        public Guid ImageId { get; private set; }

        public virtual Product Product { get; private set; } = null!;
        public virtual Image Image { get; private set; } = null!;

    }

    public partial class ProductImage
    {
        public ProductImage(int displayOrder, Guid productId, Guid imageId)
        {
            DisplayOrder = displayOrder;
            ProductId = productId;
            ImageId = imageId;
        }

        public ProductImage(Guid id, int displayOrder, Guid productId, Guid imageId)
        {
            Id = id;
            DisplayOrder = displayOrder;
            ProductId = productId;
            ImageId = imageId;
        }

    }
}
