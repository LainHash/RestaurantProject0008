using Restaurant.Application.Features.Guests.Carts.Commands.AddItem;
using Restaurant.Application.Features.Guests.Carts.Commands.CreateForCustomer;
using Restaurant.Application.Features.Guests.Carts.Commands.CreateForGuest;
using Restaurant.Application.Features.Guests.Carts.Commands.DeleteExpired;
using Restaurant.Application.Features.Guests.Carts.Commands.UpdateQuantity;
using Restaurant.Application.Features.Guests.Carts.Queries.GetAll;
using Restaurant.Application.Features.Guests.Carts.Queries.GetById;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Services.Guests
{
    public interface ICartService
    {
        Task<Result<IEnumerable<CartResponse>>> 
            GetAllAsync(GetAllCartsSpecification specification, CancellationToken cancellationToken);

        Task<Result<CartResponse>> 
            GetByIdAsync(GetCartByIdSpecification specification, CancellationToken cancellationToken);

        Task<Result<CartResponse>>
            CreateForGuestAsync(CreateCartForGuestSpecification specification, CancellationToken cancellationToken);

        Task<Result<CartResponse>>
            CreateForCustomerAsync(CreateCartForCustomerSpecification specification, CancellationToken cancellationToken);

        Task<Result<CartResponse>>
            AddItemAsync(AddCartItemSpecification specification, CancellationToken cancellationToken);

        Task<Result<CartResponse>>
            UpdateQuantity(UpdateCartItemQuantitySpecification specification, CancellationToken cancellationToken);

        Task<Result<object>>
            DeleteExpiredCartAsync(DeleteExpiredCartSpecification specification, CancellationToken cancellationToken);
    }
}
