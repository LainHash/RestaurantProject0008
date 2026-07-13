using MediatR;
using Restaurant.Application.Features.Personnel.Employees.Commands.Create;
using Restaurant.Application.Features.Personnel.Employees.Queries.GetAll;
using Restaurant.Application.Features.Personnel.Employees.Queries.GetById;
using Restaurant.Application.Mapping.Identity;
using Restaurant.Application.Mapping.Personnel;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Authentication;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Employees;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Repositories.Identity;
using Restaurant.Domain.Repositories.Personnel;
using System.Net;

namespace Restaurant.Persistence.Services.Personnel
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            IUnitOfWork unitOfWork)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<EmployeeResponse>>>
            GetAllAsync(GetAllEmployeesSpecification specification, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.ToListAsync(specification, cancellationToken);

            var response = employees.Select(x => new EmployeeResponse(x));
            return Result<IEnumerable<EmployeeResponse>>
                .Succeed(response, Success<Employee>.Retrieved);
        }

        public async Task<Result<EmployeeResponse>>
            GetByIdAsync(GetEmployeeByIdSpecification specification, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.FindAsync(specification, cancellationToken);
            if (employee is null)
            {
                return Result<EmployeeResponse>
                    .Fail(Error<Employee>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new EmployeeResponse(employee);
            return Result<EmployeeResponse>
                .Succeed(response, Success<Employee>.Retrieved);
        }

        public async Task<Result<EmployeeResponse>>
            CreateEmployeeAsync(CreateEmployeeSpecification specification, CancellationToken cancellationToken)
        {
            var request = specification.Body;
            var existingUser = await _userRepository.FindAsync(request.Register.Email, cancellationToken);
            if (existingUser != null)
            {
                return Result<EmployeeResponse>
                    .Fail("This email already used. Please user another email.", HttpStatusCode.Conflict);
            }

            var passwordHash = _passwordHasher.HashPassword(request.Register.Password);

            var user = new User(request.Register.ToInfo(passwordHash, request.RoleId));
            await _userRepository.AddAsync(user);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var employee = new Employee(request.ToInfo(user.Id));
            await _employeeRepository.AddAsync(employee);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new EmployeeResponse(employee);
            return Result<EmployeeResponse>
                .Succeed(response, Success<Employee>.Created, HttpStatusCode.Created);
        }
    }
}
