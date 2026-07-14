using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Misc.AuditLogs;
using Restaurant.Domain.Enums;
using Restaurant.Domain.Repositories.Misc;

namespace Restaurant.API.Controllers.Misc
{
    /// <summary>
    /// Endpoint truy vấn Audit Log — chỉ dành cho Admin.
    /// Trả về danh sách thay đổi Create/Update/Delete trên tất cả entity.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuditLogsController : ControllerBase
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogsController(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        /// <summary>
        /// Lấy danh sách audit log có filter và phân trang.
        /// </summary>
        /// <param name="entityName">Tên entity (vd: Product, Category, Employee)</param>
        /// <param name="entityId">ID của entity cụ thể</param>
        /// <param name="action">Loại thao tác: Created=1, Updated=2, Deleted=3</param>
        /// <param name="actorId">ID của user thực hiện thao tác</param>
        /// <param name="from">Từ ngày (UTC, ISO 8601)</param>
        /// <param name="to">Đến ngày (UTC, ISO 8601)</param>
        /// <param name="page">Số trang (mặc định: 1)</param>
        /// <param name="pageSize">Số bản ghi mỗi trang (mặc định: 20, tối đa: 100)</param>
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string?      entityName = null,
            [FromQuery] string?      entityId   = null,
            [FromQuery] AuditAction? action     = null,
            [FromQuery] string?      actorId    = null,
            [FromQuery] DateTime?    from       = null,
            [FromQuery] DateTime?    to         = null,
            [FromQuery] int          page       = 1,
            [FromQuery] int          pageSize   = 20,
            CancellationToken cancellationToken = default)
        {
            // Giới hạn pageSize để tránh query quá lớn
            if (pageSize > 100) pageSize = 100;
            if (page < 1)       page     = 1;

            var items = await _auditLogRepository.GetAsync(
                entityName, entityId, action, actorId,
                from, to, page, pageSize,
                cancellationToken);

            var totalCount = await _auditLogRepository.CountAsync(
                entityName, entityId, action, actorId,
                from, to,
                cancellationToken);

            var responses = items.Select(x => new AuditLogResponse(
                x.Id,
                x.EntityName,
                x.EntityId,
                x.Action.ToString(),
                x.OldValues,
                x.NewValues,
                x.ActorId,
                x.ActorName,
                x.IpAddress,
                x.OccurredAt
            )).ToList();

            var result = PageResult<List<AuditLogResponse>>.Succeed(
                data       : responses,
                message    : "Audit logs retrieved successfully.",
                totalItems : totalCount,
                indexPage  : page,
                pageSize   : pageSize);

            return StatusCode(result.StatusCode, result);
        }
    }
}
