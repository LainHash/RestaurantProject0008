using MediatR;
using Restaurant.Application.Models;
using Restaurant.Contract.DTOs.Catalog.Categories;

namespace Restaurant.Application.Features.Catalog.Categories.Commands.Update
{
    public record UpdateCategoryCommand(Guid Id, UpdateCategoryRequest Body) : IRequest<Result<CategoryResponse>>
    {
    }
}
