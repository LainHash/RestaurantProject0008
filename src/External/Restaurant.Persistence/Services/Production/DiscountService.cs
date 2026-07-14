using Restaurant.Application.Mapping.Production;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Production;
using Restaurant.Contract.DTOs.Production.Discounts;
using Restaurant.Domain.Entities.Production;
using Restaurant.Domain.Repositories.Production;
using System.Net;

namespace Restaurant.Persistence.Services.Production
{
    internal class DiscountService : IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DiscountService(
            IDiscountRepository discountRepository,
            IUnitOfWork unitOfWork)
        {
            _discountRepository = discountRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<DiscountResponse>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var discounts = await _discountRepository.ToListAsync(cancellationToken);

            var response = discounts.Select(x => new DiscountResponse(x));
            return Result<IEnumerable<DiscountResponse>>
                .Succeed(response, Success<Discount>.Retrieved);
        }

        public async Task<Result<DiscountResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var discount = await _discountRepository.FindAsync(id, cancellationToken);
            if(discount is null)
            {
                return Result<DiscountResponse>
                    .Fail(Error<Discount>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new DiscountResponse(discount);
            return Result<DiscountResponse>
                .Succeed(response, Success<Discount>.Retrieved);
        }

        public async Task<Result<DiscountResponse>> CreateAsync(CreateDiscountRequest request, CancellationToken cancellationToken)
        {
            var discount = new Discount(request.ToInfo());

            await _discountRepository.AddAsync(discount, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new DiscountResponse(discount);
            return Result<DiscountResponse>
                .Succeed(response, Success<Discount>.Created, HttpStatusCode.Created);
        }
    }
}
