using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Guests.CartItems;
using Restaurant.Contract.DTOs.Guests.Carts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Guests.Carts.Commands.UpdateQuantity
{
    public record UpdateCartItemQuantityCommand(Guid Id, UpdateCartItemQuantityRequest Body)
        : IRequest<Result<CartResponse>>
    {
    }
}
