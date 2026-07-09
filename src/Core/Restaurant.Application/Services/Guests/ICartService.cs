using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Services.Guests
{
    public interface ICartService
    {
        Task<Result<IEnumerable<CartResponse>>> GetAllAsync(CancellationToken cancellationToken);
        Task<Result<CartResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
