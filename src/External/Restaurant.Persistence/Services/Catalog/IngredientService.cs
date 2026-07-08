using Restaurant.Application.Features.Catalog.Ingredients.Commands.Update;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetAll;
using Restaurant.Application.Features.Catalog.Ingredients.Queries.GetById;
using Restaurant.Application.Features.Inventory.IngredientStocks.Commands.Update;
using Restaurant.Application.Mapping.Catalog;
using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Catalog;
using Restaurant.Application.Services.Persistence;
using Restaurant.Contract.DTOs.Catalog.Ingredients;
using Restaurant.Contract.DTOs.Inventory.IngredientStocks;
using Restaurant.Domain.Entities.Catalog;
using Restaurant.Domain.Repositories.Catalog;
using System.Net;

namespace Restaurant.Persistence.Services.Catalog
{
    internal class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IUnitOfWork _unitOfWork;
        public IngredientService(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork)
        {
            _ingredientRepository = ingredientRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<IngredientResponse>>>
            GetAllAsync(GetAllIngredientsSpecification specification, CancellationToken cancellationToken)
        {
            var ingredients = await _ingredientRepository.ToListAsync(specification, cancellationToken);

            var response = ingredients.Select(i => new IngredientResponse(i));
            return Result<IEnumerable<IngredientResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<IngredientResponse>> 
            GetByIdAsync(GetIngredientByIdSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(specification, cancellationToken);
            if (ingredient is null)
            {
                return Result<IngredientResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<IngredientResponse>> 
            CreateAsync(CreateIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(request.ToInfo());
            await _ingredientRepository.AddAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<IngredientResponse>> 
            UpdateAsync(UpdateIngredientSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(specification, cancellationToken);
            if (ingredient is null)
            {
                return Result<IngredientResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            ingredient.Update(specification.Body.Name, specification.Body.Description, specification.Body.CategoryId);
            await _ingredientRepository.UpdateAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success.Uploaded, HttpStatusCode.OK);
        }

        public async Task<Result<IngredientResponse>> 
            UpdateStockAsync(UpdateIngredientStockSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(specification, cancellationToken);
            if (ingredient is null)
            {
                return Result<IngredientResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            ingredient.IngredientStock.Update(specification.Body.UnitPrice, specification.Body.Unit, specification.Body.StockQuantity);
            await _ingredientRepository.UpdateAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success.Uploaded, HttpStatusCode.OK);
        }
    }
}
