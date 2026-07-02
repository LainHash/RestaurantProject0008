using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Application.Features.Catalog.Products.Queries.GetById
{
    public class GetProductByIdSpecification : BaseSpecification<Product>
    {
        public GetProductByIdSpecification(GetProductByIdQuery query)
        {
            Criteria = p => p.Id == query.Id;

            AddInclude(p => p.Category);
            AddInclude(p => p.ProductStock);
        }
    }
}
