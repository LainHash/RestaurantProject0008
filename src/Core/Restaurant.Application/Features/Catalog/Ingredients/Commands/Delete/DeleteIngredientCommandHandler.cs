using MediatR;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;

namespace Restaurant.Application.Features.Catalog.Ingredients.Commands.Delete
{
    internal class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand, Result<object>>
    {
        private readonly IIngredientService _ingredientService;

        public DeleteIngredientCommandHandler(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public async Task<Result<object>> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var response = await _ingredientService.DeleteAsync(request.Id, cancellationToken);
            return response;
        }
    }
}
