using Restaurant.Application.Features.Misc.Images.Commands.UploadProductImage;
using Restaurant.Application.Models.Results;
using Restaurant.Domain.Informations.Misc.Images;

namespace Restaurant.Application.Mapping.Misc
{
    public static class ImageMapping
    {
        public static UploadImageInformation ToInfo(UploadProductImageSpecification specification, CloudinaryUploadResult result)
        {
            return new UploadImageInformation(
                AltText: specification.Metadata.AltText,
                Url: result.Url,
                StoragePath: result.StoragePath,
                FileSize: result.FileSize,
                ContentType: result.ContentType,
                IsPrimary: specification.Metadata.IsPrimary
            );
        }
    }
}
