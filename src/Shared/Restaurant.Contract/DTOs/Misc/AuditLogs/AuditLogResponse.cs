namespace Restaurant.Contract.DTOs.Misc.AuditLogs
{
    /// <summary>DTO trả về cho mỗi bản ghi audit log.</summary>
    public record AuditLogResponse(
        Guid     Id,
        string   EntityName,
        string   EntityId,
        string   Action,
        string?  OldValues,
        string?  NewValues,
        string?  ActorId,
        string?  ActorName,
        string?  IpAddress,
        DateTime OccurredAt
    );

    /// <summary>Response phân trang cho danh sách audit logs.</summary>
    public record AuditLogPagedResponse(
        List<AuditLogResponse> Items,
        int TotalCount,
        int Page,
        int PageSize,
        int TotalPages
    );
}
