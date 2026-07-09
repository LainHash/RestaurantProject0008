using Restaurant.Application.Features.Guests.Carts.Queries.GetAll;
using Restaurant.Application.Features.Guests.Carts.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Services.Guests
{
    public interface ICartService
    {
        Task<Result<IEnumerable<CartResponse>>> GetAllAsync(GetAllCartsSpecification specification, CancellationToken cancellationToken);
        Task<Result<CartResponse>> GetByIdAsync(GetCartByIdSpecification specification, CancellationToken cancellationToken);
    }
}
