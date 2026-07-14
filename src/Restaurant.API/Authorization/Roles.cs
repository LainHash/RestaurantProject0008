namespace Restaurant.API.Authorization
{
    /// <summary>
    /// Các role name khớp với cột Name trong bảng Roles.
    /// </summary>
    public static class Roles
    {
        public const string Admin    = "Admin";
        public const string Customer = "Customer";
        public const string Staff    = "Staff";
        public const string Manager  = "Manager";

        // Shorthand combinations dùng cho [Authorize(Roles = ...)]
        public const string AdminOrManager          = $"{Admin},{Manager}";
        public const string AdminManagerOrStaff     = $"{Admin},{Manager},{Staff}";
        public const string AdminManagerOrCustomer  = $"{Admin},{Manager},{Customer}";
    }
}
