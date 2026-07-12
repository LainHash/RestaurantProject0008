using CloudinaryDotNet;
using Microsoft.Extensions.Logging;
using Restaurant.Application.Features.Misc.Images.Commands.UploadProductImage;
using Restaurant.Application.Mapping.Misc;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Misc;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Storage;
using Restaurant.Contract.DTOs.Misc.Images;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Informations.Misc.Images;
using Restaurant.Domain.Repositories.Catalog;
using Restaurant.Domain.Repositories.Misc;
using System.Net;
using System.Net.Mime;

namespace Restaurant.Persistence.Services.Misc
{
    internal class ImageService : IImageService
    {
        private const int MaxImagesPerProduct = 5;

        private readonly IImageRepository _imageRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ImageService> _logger;
        public ImageService(IImageRepository imageRepository,
                            IProductRepository productRepository,
                            ICloudinaryService cloudinaryService,
                            IUnitOfWork unitOfWork,
                            ILogger<ImageService> logger)
        {
            _imageRepository = imageRepository;
            _productRepository = productRepository;
            _cloudinaryService = cloudinaryService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<UploadImageResponse>>
            UploadProductImageAsync(UploadProductImageSpecification specification, CancellationToken cancellationToken)
        {
            // 1. Kiểm tra product tồn tại
            var product = await _productRepository.FindAsync(specification.ProductId, cancellationToken);
            if (product is null)
            {
                return Result<UploadImageResponse>
                    .Fail(Error<Product>.NotFound, HttpStatusCode.NotFound);
            }

            // 2. Kiểm tra giới hạn 5 ảnh / product
            var currentCount = await _imageRepository.CountByProductIdAsync(
                specification.ProductId, cancellationToken);

            if (currentCount >= MaxImagesPerProduct)
            {
                return Result<UploadImageResponse>
                    .Fail($"Product đã đạt giới hạn tối đa {MaxImagesPerProduct} ảnh.", HttpStatusCode.UnprocessableEntity);
            }

            await using var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                // 3. Upload lên Cloudinary
                var uploadResult = await _cloudinaryService.UploadAsync(
                    specification.FileStream,
                    specification.FileName,
                    cancellationToken: cancellationToken);

                if (!uploadResult.IsSuccess)
                {
                    return Result<UploadImageResponse>
                        .Fail($"Upload Cloudinary thất bại: {uploadResult.ErrorMessage}", HttpStatusCode.BadGateway);
                }

                // 4. Nếu ảnh mới là primary → unset ảnh primary cũ
                if (specification.Metadata.IsPrimary)
                {
                    await _imageRepository.UnsetPrimaryAsync(specification.ProductId, cancellationToken);
                }

                // 5. Tạo Image entity
                var image = new Image(ImageMapping.ToInfo(specification, uploadResult));

                await _imageRepository.AddAsync(image, cancellationToken);

                // 6. Tạo ProductImage join entity
                var productImage = new ProductImage(
                    productId: specification.ProductId,
                    imageId: image.Id,
                    displayOrder: currentCount + 1
                );

                await _imageRepository.AddProductImageAsync(productImage, cancellationToken);

                await _unitOfWork.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                var response = new UploadImageResponse(productImage, uploadResult.PublicId);

                return Result<UploadImageResponse>
                    .Succeed(response, Success<Image>.Uploaded, HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                _logger.LogError(ex, "Lỗi khi upload ảnh cho product {ProductId}", specification.ProductId);
                return Result<UploadImageResponse>
                    .Fail("Lỗi khi upload ảnh.", HttpStatusCode.InternalServerError);
            }
        }
    }
}
