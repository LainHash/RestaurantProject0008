using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Production.Discounts;

namespace Restaurant.Application.Services.Production
{
    public interface IDiscountService
    {
        Task<Result<IEnumerable<DiscountResponse>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<DiscountResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
