using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Misc.Images;

namespace Restaurant.Application.Features.Misc.Images.Commands.UploadProductImage
{
    public record UploadProductImageCommand(Guid ProductId,
        Stream FileStream,
        string FileName,
        UploadImageRequest Metadata) : IRequest<Result<UploadImageResponse>>
    {
    }
}
