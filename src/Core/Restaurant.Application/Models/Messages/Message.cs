using System;
using System.Collections.Generic;
using System.Data.Common;
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

        public const string Uploaded = $"{nameof(T)} uploaded successfully.";
        public const string Added = $"{nameof(T)} added successfully.";
    }

    public static class Error<T>
    {
        public const string NotFound = $"{nameof(T)} not found.";

        public const string NotYetDeleted = $"{nameof(T)} not yet deleted.";

        public const string AlreadyDeleted = $"{nameof(T)} already deleted.";

        public const string AlreadyAdded = $"{nameof(T)} already added.";

        public const string OutOfStock = $"{nameof(T)} out of stock.";
    }
}
