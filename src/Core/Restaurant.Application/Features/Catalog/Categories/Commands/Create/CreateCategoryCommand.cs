using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Contract.DTOs.Catalog.Categories;
using System.Windows.Input;

namespace Restaurant.Application.Features.Catalog.Categories.Commands.Create
{
    public record CreateCategoryCommand(CreateCategoryRequest Body) : IRequest<Result<CategoryResponse>>
    {
    }
}
