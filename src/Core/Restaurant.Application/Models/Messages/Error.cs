namespace Restaurant.Application.Models.Messages
{
    public static class Error
    {
        public const string Failed = "Operation failed.";

        public const string BadRequest = "Invalid request.";
        public const string Unauthorized = "Unauthorized.";
        public const string Forbidden = "Access denied.";
        public const string NotFound = "Resource not found.";
        public const string Conflict = "Resource already exists.";

        public const string Deleted = "Resource already deleted.";
        public const string Restored = "Resource not yet deleted.";

        public const string ValidationFailed = "Validation failed.";

        public const string InternalServerError = "An unexpected error occurred.";

        public const string LoginFailed = "Invalid username or password.";

        public const string InvalidToken = "Invalid or expired token.";

        public const string FileNotFound = "File not found.";
        public const string UploadFailed = "File upload failed.";

        public const string DatabaseError = "Database operation failed.";
    }
}
