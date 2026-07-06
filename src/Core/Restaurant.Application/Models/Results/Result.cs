using System.Net;

namespace Restaurant.Application.Models.Results
{
    public class Result<T>
    {
        public bool IsSucceed { get; }
        public string Message { get; }
        public int StatusCode { get; }
        public T? Data { get; }

        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int IndexPage { get; set; }
        public int PageSize { get; set; }

        private Result(T? data, bool isSucceed, string message, HttpStatusCode statusCode)
        {
            Data = data;
            IsSucceed = isSucceed;
            Message = message;
            StatusCode = (int)statusCode;
        }

        private Result(T? data, bool isSucceed, string message, int totalItems, int indexPage, int pageSize, HttpStatusCode statusCode)
            : this(data, isSucceed, message, statusCode)
        {
            TotalItems = totalItems;
            TotalPages = (int)Math.Ceiling((decimal)totalItems / pageSize);
            IndexPage = indexPage;
            PageSize = pageSize;
        }

        public static Result<T> Succeed(T? data, string message, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(data, true, message, statusCode);

        public static Result<T> Succeed(
            T? data,
            string message,
            int totalItems,
            int indexPage = 1,
            int pageSize = 12,
            HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new(data, true, message, totalItems, indexPage, pageSize, statusCode);
        }

        public static Result<T> Fail(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(default, false, message, statusCode);
    }
}