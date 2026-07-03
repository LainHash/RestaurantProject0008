using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Contract.DTOs.Misc.Images
{
    public class ImageResponse
    {
        public string Url { get; set; } = string.Empty;
        public string? AltText { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsPrimary { get; set; }

        public ImageResponse(ProductImage productImages)
        {
            Url = productImages.Image.Url;
            AltText = productImages.Image.AltText;
            DisplayOrder = productImages.DisplayOrder;
            IsPrimary = productImages.Image.IsPrimary;
        }

        public static ImageResponse GetPrimary(IEnumerable<ProductImage> productImages)
        {
            var primaryImage = productImages.FirstOrDefault(pi => pi.Image.IsPrimary);
            return primaryImage != null ? new ImageResponse(primaryImage) : new ImageResponse(productImages.First());
        }
    }
}
