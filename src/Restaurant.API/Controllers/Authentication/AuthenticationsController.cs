using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Restaurant.Application.Features.Authentication.Commands.CompleteProfile;
using Restaurant.Application.Features.Authentication.Commands.Login;
using Restaurant.Application.Features.Authentication.Commands.Register;
using Restaurant.Application.Features.Authentication.Commands.VerifyEmail;
using Restaurant.Contract.DTOs.Authentication;

namespace Restaurant.API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var command = new RegisterCommand(request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpPost("/complete-profile")]
        public async Task<IActionResult> CompleteProfile(
            [FromRoute] Guid userId,
            [FromBody] CompleteProfileRequest request,
            CancellationToken cancellationToken)
        {
            var command = new CompleteProfileCommand(userId, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }

        [Authorize]
        [HttpPost("/verify-email")]
        public async Task<IActionResult> VerifyEmail(
            [FromRoute] Guid userId,
            [FromBody] VerifyEmailRequest request,
            CancellationToken cancellationToken)
        {
            var command = new VerifyEmailCommand(userId, request);
            var result = await _mediator.Send(command, cancellationToken);
            return StatusCode(result.StatusCode, result);
        }
    }
}
