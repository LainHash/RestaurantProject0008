using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Misc;

namespace Restaurant.Application.Behaviors
{
    /// <summary>
    /// MediatR pipeline behavior tự động ghi Audit Log cho mọi Command.
    /// Chỉ audit khi command kết thúc thành công (result.IsSuccess).
    /// </summary>
    public class AuditLogBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ICurrentUserService _currentUser;
        private readonly AuditContext _auditContext;

        public AuditLogBehavior(
            ICurrentUserService currentUser,
            AuditContext auditContext)
        {
            _currentUser  = currentUser;
            _auditContext = auditContext;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            // Populate actor info vào AuditContext trước khi handler chạy.
            // DbContext.SaveChangesAsync sẽ đọc từ đây khi build audit entries.
            _auditContext.ActorId   = _currentUser.UserId;
            _auditContext.ActorName = _currentUser.UserName;
            _auditContext.IpAddress = _currentUser.IpAddress;

            return await next();
        }
    }
}
