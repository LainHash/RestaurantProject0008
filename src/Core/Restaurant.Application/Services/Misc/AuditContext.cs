namespace Restaurant.Application.Services.Misc
{
    /// <summary>
    /// Scoped service lưu trữ thông tin actor trong phạm vi một HTTP request.
    /// AuditLogBehavior sẽ populate, DbContext sẽ đọc khi build audit entries.
    /// </summary>
    public class AuditContext
    {
        public string? ActorId   { get; set; }
        public string? ActorName { get; set; }
        public string? IpAddress { get; set; }
    }
}
