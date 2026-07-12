using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Restaurant.Application.Models.Messages
{
    public static class Success<TEntity> where TEntity : class
    {
        public static string Retrieved = $"{typeof(TEntity).Name} retrived successfully.";

        public static string Created = $"{typeof(TEntity).Name} created successfully.";
        public static string Updated = $"{typeof(TEntity).Name} updated successfully.";

        public static string Deleted = $"{typeof(TEntity).Name} deleted successfully.";
        public static string Restored = $"{typeof(TEntity).Name} restored successfully.";

        public static string Uploaded = $"{typeof(TEntity).Name} uploaded successfully.";
        public static string Added = $"{typeof(TEntity).Name} added successfully.";
    }

    public static class Error<TEntity> where TEntity : class
    {
        public static string NotFound = $"{typeof(TEntity).Name} not found.";

        public static string NotYetDeleted = $"{typeof(TEntity).Name} not yet deleted.";

        public static string AlreadyDeleted = $"{typeof(TEntity).Name} already deleted.";

        public static string AlreadyAdded = $"{typeof(TEntity).Name} already added.";

        public static string OutOfStock = $"{typeof(TEntity).Name} out of stock.";
    }
}
