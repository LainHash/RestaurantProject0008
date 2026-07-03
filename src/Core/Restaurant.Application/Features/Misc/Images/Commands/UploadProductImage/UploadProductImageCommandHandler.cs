using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Misc;
using Restaurant.Contract.DTOs.Misc.Images;

namespace Restaurant.Application.Features.Misc.Images.Commands.UploadProductImage
{
    internal class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommand, Result<UploadImageResponse>>
    {
        private readonly IImageService _imageService;
        public UploadProductImageCommandHandler(IImageService imageService)
        {
            _imageService = imageService;
        }
        public Task<Result<UploadImageResponse>> Handle(UploadProductImageCommand request, CancellationToken cancellationToken)
        {
            var specification = new UploadProductImageSpecification(request);
            return _imageService.UploadProductImageAsync(specification, cancellationToken);
        }
    }
}
