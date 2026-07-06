using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaurant.Application.Common.Enums;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Entities.Misc;
using Restaurant.Domain.Specifications;

namespace Restaurant.Application.Features.Catalog.Products.Queries.GetAll
{
    public class GetAllProductsSpecification : BaseSpecification<Product>
    {
        public GetAllProductsSpecification(GetAllProductsQuery query)
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.ProductStock);
            AddIncludeAggregator(q => q.Include(p => p.ProductImages)
                                       .ThenInclude((ProductImage pi) => pi.Image));

            // Criteria: kết hợp filter Keyword và CategoryName
            bool hasKeyword = !string.IsNullOrWhiteSpace(query.Keyword);
            bool hasCategoryName = !string.IsNullOrWhiteSpace(query.CategoryName);

            if (hasKeyword && hasCategoryName)
            {
                Criteria = p => p.Name.ToLower()
                                .Contains(query.Keyword!.ToLower()) &&
                                p.Category.Name.ToLower()
                                .Contains(query.CategoryName!.ToLower());
            }
            else if (hasKeyword)
            {
                Criteria = p => p.Name.Contains(query.Keyword!);
            }
            else if (hasCategoryName)
            {
                Criteria = p => p.Category.Name.Contains(query.CategoryName!);
            }

            // OrderBy: sắp xếp theo SortBy
            switch (query.SortBy)
            {
                case nameof(SortType.CreatedAtAsc):
                    ApplyOrderBy(p => p.CreatedAt);
                    break;
                case nameof(SortType.NameAsc):
                    ApplyOrderBy(p => p.Name);
                    break;
                case nameof(SortType.NameDesc):
                    ApplyOrderByDescending(p => p.Name);
                    break;
                case nameof(SortType.PriceAsc):
                    ApplyOrderBy(p => p.ProductStock.UnitPrice);
                    break;
                case nameof(SortType.PriceDesc):
                    ApplyOrderByDescending(p => p.ProductStock.UnitPrice);
                    break;
                default:
                    ApplyOrderByDescending(p => p.CreatedAt);
                    break;
            }

            // Paging
            ApplyPaging((query.IndexPage - 1) * query.PageSize, query.PageSize);
        }
    }
}
