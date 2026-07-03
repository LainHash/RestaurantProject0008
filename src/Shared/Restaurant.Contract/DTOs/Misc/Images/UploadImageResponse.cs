using Restaurant.Domain.Entities.Misc;
using static System.Net.Mime.MediaTypeNames;

namespace Restaurant.Contract.DTOs.Misc.Images
{
    public class UploadImageResponse
    {
        public Guid ImageId { get; set; }
        public string Url { get; set; } = string.Empty;
        public string PublicId { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int DisplayOrder { get; set; }
        public decimal FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;

        public UploadImageResponse(ProductImage productImage, string publicId)
        {
            ImageId = productImage.Image.Id;
            Url = productImage.Image.Url;
            PublicId = publicId;
            AltText = productImage.Image.AltText;
            IsPrimary = productImage.Image.IsPrimary;
            DisplayOrder = productImage.DisplayOrder;
            FileSize = productImage.Image.FileSize;
            ContentType = productImage.Image.ContentType;
        }
    }
}
