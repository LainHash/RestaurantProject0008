using Restaurant.Application.Mapping.Identity;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Authentication;
using Restaurant.Application.Services.Email;
using Restaurant.Application.Services.Persistence;
using Restaurant.Contract.DTOs.Authentication;
using Restaurant.Domain.Entities.Guests;
using Restaurant.Domain.Entities.Identity;
using Restaurant.Domain.Repositories.Guest;
using Restaurant.Domain.Repositories.Identity;
using System.Net;

namespace Restaurant.Persistence.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IProfileRepository _personalInfoRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IEmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtProvider _jwtProvider;

        public AuthenticationService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IProfileRepository personalInfoRepository,
            ICustomerRepository customerRepository,
            IPasswordHasher passwordHasher,
            IEmailService emailService,
            IUnitOfWork unitOfWork,
            IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _personalInfoRepository = personalInfoRepository;
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _jwtProvider = jwtProvider;
        }

        public async Task<Result<object>> 
            RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
        {
            var existingUser = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (existingUser != null)
            {
                return Result<object>
                    .Fail("This email already used. Please user another email.", HttpStatusCode.Conflict);
            }

            var customerRole = await _roleRepository.FindAsync("Customer", cancellationToken);
            if (customerRole == null)
            {
                return Result<object>
                    .Fail(Error<Role>.NotFound, HttpStatusCode.NotFound);
            }

            var verificationCode = GenerateCode();

            var user = new User(request.ToInfo(
                _passwordHasher.HashPassword(request.Password),
                customerRole.Id,
                verificationCode));


            await _userRepository.AddAsync(user, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var customer = new Customer(user.Id);

            await _customerRepository.AddAsync(customer, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var message = new EmailMessage(user.UserName, verificationCode);
            await _emailService.SendEmailAsync(user.Email, message, cancellationToken);

            return Result<object>
                .Succeed(default, "Register successfully.", HttpStatusCode.Created);
            
        }

        public async Task<Result<object>> 
            VerifyEmailAsync(Guid userId, VerifyEmailRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(userId, cancellationToken);
            if (user == null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            if (user.IsActive)
            {
                return Result<object>
                    .Fail("Account is already active.", HttpStatusCode.Conflict);
            }

            if (user.VerificationCode != request.Code)
            {
                return Result<object>
                    .Fail("Invalid verification code.", HttpStatusCode.Conflict);
            }

            if (user.VerificationCodeExpiresAt < DateTime.UtcNow)
            {
                return Result<object>
                    .Fail("Verification code has expired. Please request a new one.", HttpStatusCode.RequestTimeout);
            }

            user.CompleteVerification();

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, "Email verified successfully. You can now complete your profile.", HttpStatusCode.Accepted);
        }

        public async Task<Result<object>> 
            CompleteProfileAsync(Guid userId, CompleteProfileRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(userId, cancellationToken);
            if (user == null)
            {
                return Result<object>
                    .Fail(Error<User>.NotFound, HttpStatusCode.NotFound);
            }

            if (!user.IsActive)
            {
                return Result<object>
                    .Fail("Account is not active. Please verify your email first.", HttpStatusCode.PreconditionRequired);
            }

            var customer = await _customerRepository.FindByUserIdAsync(user.Id, cancellationToken);
            if (customer == null)
            {
                return Result<object>
                    .Fail(Error<Customer>.NotFound, HttpStatusCode.NotFound);
            }

            if (customer.ProfileId.HasValue)
            {
                return Result<object>
                    .Fail("Profile has already been completed.", HttpStatusCode.Conflict);
            }

            var personalInfo = new Profile(request.ToInfo());

            await _personalInfoRepository.AddAsync(personalInfo, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            customer.CompleteProfile(personalInfo.Id);
            await _customerRepository.UpdateAsync(customer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, "Profile completed successfully.", HttpStatusCode.Accepted);
        }

        public async Task<Result<AuthenticationResponse>> 
            LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.FindAsync(request.Email, cancellationToken);
            if (user == null || !_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
            {
                return Result<AuthenticationResponse>
                    .Fail("Incorrect email or password.", HttpStatusCode.Unauthorized);
            }

            if (!user.IsActive)
            {
                return Result<AuthenticationResponse>
                    .Fail("Account is not active. Please verify your email.", HttpStatusCode.PreconditionRequired);
            }

            var role = await _roleRepository.FindAsync(user.RoleId, cancellationToken);
            var roleName = role?.Name ?? "Customer";

            var token = _jwtProvider.GenerateToken(user.Id, user.UserName, user.Email, roleName);

            var response = new AuthenticationResponse
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = token
            };

            return Result<AuthenticationResponse>
                .Succeed(response, "Login successfully.", HttpStatusCode.Accepted);
        }

        private string GenerateCode()
        {
            // Generate 6-digit verification code
            var random = new Random();
            var verificationCode = random.Next(100000, 999999).ToString();
            return verificationCode;
        }
    }
}
