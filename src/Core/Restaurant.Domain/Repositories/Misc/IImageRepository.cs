using Restaurant.Domain.Entities.Misc;

namespace Restaurant.Domain.Repositories.Misc
{
    public interface IImageRepository
    {
        Task AddAsync(Image image, CancellationToken cancellationToken = default);

        Task<int> CountByProductIdAsync(Guid productId, CancellationToken cancellationToken = default);

        Task UnsetPrimaryAsync(Guid productId, CancellationToken cancellationToken = default);

        Task AddProductImageAsync(ProductImage productImage, CancellationToken cancellationToken = default);
    }
}
