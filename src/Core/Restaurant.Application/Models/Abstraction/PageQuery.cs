using Restaurant.Application.Common.Enums;

namespace Restaurant.Application.Models.Abstraction
{
    public abstract record PageQuery()
    {
        public string? Keyword { get; init; }
        public string SortBy { get; init; } = nameof(SortType.CreatedAtDesc);
        public int IndexPage { get; init; } = 1;
        public int PageSize { get; init; } = 12;
    }
}
