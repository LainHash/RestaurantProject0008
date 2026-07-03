using Restaurant.Application.Features.Misc.Images.Commands.UploadProductImage;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Misc;
using Restaurant.Application.Services.Storage;
using Restaurant.Contract.DTOs.Misc.Images;
using Restaurant.Domain.Repositories.Catalog;
using Restaurant.Domain.Repositories.Misc;

namespace Restaurant.Persistence.Services.Misc
{
    internal class ImageService : IImageService
    {
        private const int MaxImagesPerProduct = 5;

        private readonly IImageRepository _imageRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public ImageService(IImageRepository imageRepository,
                            IProductRepository productRepository,
                            ICloudinaryService cloudinaryService)
        {
            _imageRepository = imageRepository;
            _productRepository = productRepository;
            _cloudinaryService = cloudinaryService;
        }

        public Task<Result<UploadImageResponse>> 
            UploadProductImageAsync(UploadProductImageSpecification specification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
