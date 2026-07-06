using Restaurant.Domain.Abstraction;
using Restaurant.Domain.Informations.Misc.Images;

namespace Restaurant.Domain.Entities.Misc
{
    public partial class Image : AuditableEntity
    {
        public string AltText { get; set; } = null!;

        public string Url { get; set; } = null!;           // URL truy cập ảnh
        public string StoragePath { get; set; } = null!;   // đường dẫn vật lý hoặc cloud

        public decimal FileSize { get; set; }                 // byte
        public string ContentType { get; set; } = null!;   // image/jpeg

        public bool IsPrimary { get; set; }

        public virtual IEnumerable<ProductImage> ProductImages { get; set; } = [];

    }

    public partial class Image
    {
        public Image(UploadImageInformation information)
        {
            AltText = information.AltText ?? string.Empty;
            Url = information.Url;
            StoragePath = information.StoragePath;
            FileSize = information.FileSize;
            ContentType = information.ContentType;
            IsPrimary = information.IsPrimary;
        }

        public Image(string altText, string url, string storagePath, decimal fileSize, string contentType, bool isPrimary)
        {
            AltText = altText;
            Url = url;
            StoragePath = storagePath;
            FileSize = fileSize;
            ContentType = contentType;
            IsPrimary = isPrimary;
        }

        public Image(Guid id, string altText, string url, string storagePath, decimal fileSize, string contentType, bool isPrimary)
        {
            Id = id;
            AltText = altText;
            Url = url;
            StoragePath = storagePath;
            FileSize = fileSize;
            ContentType = contentType;
            IsPrimary = isPrimary;
        }

    }
}
