namespace Restaurant.Application.Models
{
    public static class Success
    {
        public const string Succeed = "Operation completed successfully.";

        public const string Created = "Resource created successfully.";
        public const string Updated = "Resource updated successfully.";
        public const string Deleted = "Resource deleted successfully.";
        public const string Restored = "Resource restored successfully.";

        public const string Retrieved = "Data retrieved successfully.";
        public const string Saved = "Data saved successfully.";

        public const string Login = "Login successful.";
        public const string Logout = "Logout successful.";

        public const string PasswordChanged = "Password changed successfully.";
        public const string PasswordReset = "Password reset successfully.";

        public const string EmailSent = "Email sent successfully.";

        public const string Uploaded = "File uploaded successfully.";
    }

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
