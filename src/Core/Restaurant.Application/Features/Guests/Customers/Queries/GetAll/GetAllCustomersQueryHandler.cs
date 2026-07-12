using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Guests;
using Restaurant.Contract.DTOs.Guests.Customers;

namespace Restaurant.Application.Features.Guests.Customers.Queries.GetAll
{
    internal class GetAllCustomersQueryHandler
        : IRequestHandler<GetAllCustomersQuery, Result<IEnumerable<CustomerReponse>>>
    {
        private readonly ICustomerService _customerService;

        public GetAllCustomersQueryHandler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Result<IEnumerable<CustomerReponse>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var specification = new GetAllCustomersSpecification(request);
            var response = await _customerService.GetAllAsync(specification, cancellationToken);
            return response;
        }
    }
}
