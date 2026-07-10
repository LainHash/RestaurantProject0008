using Restaurant.Application.Features.Guests.Carts.Commands.CreateForCustomer;
using Restaurant.Application.Features.Guests.Carts.Commands.CreateForGuest;
using Restaurant.Application.Features.Guests.Carts.Queries.GetAll;
using Restaurant.Application.Features.Guests.Carts.Queries.GetById;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Application.Services.Persistence;
using Restaurant.Contract.DTOs.Guests.Carts;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Repositories.Guest;
using System.Net;

namespace Restaurant.Persistence.Services.Guests
{
    internal class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CartService(
            ICartRepository cartRepository,
            IUnitOfWork unitOfWork,
            ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
        }

        public async Task<Result<IEnumerable<CartResponse>>>
            GetAllAsync(GetAllCartsSpecification specification, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.ToListAsync(specification, cancellationToken);

            var response = carts.Select(x => new CartResponse(x));
            return Result<IEnumerable<CartResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<CartResponse>> 
            GetByIdAsync(GetCartByIdSpecification specification, CancellationToken cancellationToken)
        {
            var cart = await _cartRepository.FindAsync(specification, cancellationToken);
            if (cart is null)
            {
                return Result<CartResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new CartResponse(cart);
            return Result<CartResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<CartResponse>> 
            CreateForCustomerAsync(CreateCartForCustomerSpecification specification, CancellationToken cancellationToken)
        {
            var cart = new Cart();

            var customer = await _customerRepository.FindByUserIdAsync(specification.UserId, cancellationToken);
            if(customer is null)
            {
                return Result<CartResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            cart.AddCustomer(customer.Id);
            await _cartRepository.AddAsync(cart, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(cart.Id);
            var createdCart = await _cartRepository.FindAsync(specification, cancellationToken);

            var response = new CartResponse(createdCart!);
            return Result<CartResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<CartResponse>> 
            CreateForGuestAsync(CreateCartForGuestSpecification specification, CancellationToken cancellationToken)
        {
            var cart = new Cart();
            cart.AddGuest(specification.SessionId);
            await _cartRepository.AddAsync(cart, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(cart.Id);
            var createdCart = await _cartRepository.FindAsync(specification, cancellationToken);

            var response = new CartResponse(createdCart!);
            return Result<CartResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<object>> DeleteExpiredCartAsync(IEnumerable<Guid> cartIds, CancellationToken cancellationToken)
        {
            await _cartRepository.RemoveRangeAsync(cartIds, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success.Deleted);
        }
    }
}
