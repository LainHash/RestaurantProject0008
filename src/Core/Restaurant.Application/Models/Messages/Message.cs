using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Models.Messages
{
    public static class Success<T>
    {
        public const string Retrieved = $"{nameof(T)} retrived successfully.";

        public const string Created = $"{nameof(T)} created successfully.";

        public const string Updated = $"{nameof(T)} updated successfully.";

        public const string Deleted = $"{nameof(T)} deleted successfully.";

        public const string Restored = $"{nameof(T)} restored successfully.";
    }

    public static class Error<T>
    {
        public const string NotFound = $"{nameof(T)} not found.";

        public const string NotYetDeleted = $"{nameof(T)} not yet deleted.";

        public const string AlreadyDeleted = $"{nameof(T)} already deleted.";
    }
}
