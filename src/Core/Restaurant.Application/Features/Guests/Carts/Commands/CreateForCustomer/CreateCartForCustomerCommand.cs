using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.Carts;

namespace Restaurant.Application.Features.Guests.Carts.Commands.CreateForCustomer
{
    public record CreateCartForCustomerCommand(CreateCartForCustomerRequest Body)
        : IRequest<Result<CartResponse>>
    {
    }
}
