using Restaurant.Contract.DTOs.Misc.Images;
using Restaurant.Domain.Entities.Catalog;

namespace Restaurant.Contract.DTOs.Catalog.Products
{
    public class ProductResponse
    {
        public Guid Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public bool IsMadeToOrder { get; init; }
        public bool IsAvailable { get; init; }

        public decimal UnitPrice { get; init; }
        public string Unit { get; init; } = string.Empty;
        public decimal StockQuantity { get; init; }

        public string CategoryName { get; init; } = string.Empty;

        public ImageResponse? PrimaryImage { get; set; }
        public IEnumerable<ImageResponse> Images { get; set; } = new List<ImageResponse>();

        public ProductResponse(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            IsMadeToOrder = product.IsMadeToOrder;
            IsAvailable = product.IsAvailable;
            UnitPrice = product.ProductStock.UnitPrice;
            Unit = product.ProductStock.Unit;
            StockQuantity = product.ProductStock.StockQuantity;
            CategoryName = product.Category.Name;
            PrimaryImage = ImageResponse.GetPrimary(product.ProductImages);
            Images = product.ProductImages.Select(pi => new ImageResponse(pi));
        }
    }
}
