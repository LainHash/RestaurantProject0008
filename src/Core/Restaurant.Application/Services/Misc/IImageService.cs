using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Misc.Images;

namespace Restaurant.Application.Services.Misc
{
    public interface IImageService
    {
        Task<Result<UploadImageResponse>> UploadProductImageAsync(
            UploadProductImageSpecification specification,
            CancellationToken cancellationToken);
    }
}
