using Restaurant.Contract.DTOs.Misc.Images;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Misc.Images.Commands.UploadProductImage
{
    public class UploadProductImageSpecification : BaseSpecification<Image>
    {
        public Guid ProductId { get; }
        public Stream FileStream { get; }
        public string FileName { get; }
        public UploadImageRequest Metadata { get; }

        public UploadProductImageSpecification(UploadProductImageCommand command)
        {
            ProductId = command.ProductId;
            FileStream = command.FileStream;
            FileName = command.FileName;
            Metadata = command.Metadata;
        }
    }
}
