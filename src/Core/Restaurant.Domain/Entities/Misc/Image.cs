using Restaurant.Domain.Abstraction;

namespace Restaurant.Domain.Entities.Misc
{
    public class Image : AuditableEntity
    {
        public string AltText { get; set; } = null!;

        public string Url { get; set; } = null!;           // URL truy cập ảnh
        public string StoragePath { get; set; } = null!;   // đường dẫn vật lý hoặc cloud

        public decimal FileSize { get; set; }                 // byte
        public string ContentType { get; set; } = null!;   // image/jpeg

        public bool IsPrimary { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();

        public Image(string altText, string url, string storagePath, decimal fileSize, string contentType, bool isPrimary)
        {
            AltText = altText;
            Url = url;
            StoragePath = storagePath;
            FileSize = fileSize;
            ContentType = contentType;
            IsPrimary = isPrimary;
        }
    }
}
