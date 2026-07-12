using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Customers;

namespace Restaurant.Application.Features.Guests.Customers.Queries.GetById
{
    internal class GetCustomerByIdQueryHandler
        : IRequestHandler<GetCustomerByIdQuery, Result<CustomerReponse>>
    {
        private readonly ICustomerService _customerService;

        public GetCustomerByIdQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Result<CustomerReponse>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetCustomerByIdSpecification(request);
            var response = await _customerService.GetByIdAsync(specification, cancellationToken);
            return response;
        }
    }
}
