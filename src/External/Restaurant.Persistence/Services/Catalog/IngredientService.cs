using Restaurant.Application.Features.Catalog.Ingredients.Commands.Create;
using Restaurant.Application.Features.Catalog.Ingredients.Commands.CreateMany;
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
using Restaurant.Domain.Specifications;
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

        public async Task<PageResult<IEnumerable<IngredientResponse>>>
            GetAllAsync(GetAllIngredientsSpecification specification, CancellationToken cancellationToken)
        {
            var totalItems = await _ingredientRepository.CountAsync(specification, cancellationToken);
            var indexPage = (specification.Skip / specification.Take) + 1;

            var ingredients = await _ingredientRepository.ToListAsync(specification, cancellationToken);

            var response = ingredients.Select(i => new IngredientResponse(i));
            return PageResult<IEnumerable<IngredientResponse>>
                .Succeed(response, Success<Ingredient>.Retrieved, totalItems, indexPage, specification.Take);
        }

        public async Task<Result<IngredientResponse>> 
            GetByIdAsync(GetIngredientByIdSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(specification, cancellationToken);
            if (ingredient is null)
            {
                return Result<IngredientResponse>
                    .Fail(Error<Ingredient>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success<Ingredient>.Retrieved);
        }

        public async Task<Result<IngredientResponse>> 
            CreateAsync(CreateIngredientSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = new Ingredient(specification.Body.ToInfo());
            await _ingredientRepository.AddAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            specification.ApplyCriteria(ingredient.Id);
            var createdIngredient = await _ingredientRepository.FindAsync(specification, cancellationToken);

            var response = new IngredientResponse(createdIngredient!);
            return Result<IngredientResponse>
                .Succeed(response, Success<Ingredient>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<IEnumerable<IngredientResponse>>> CreateManyAsync(CreateManyIngredientsSpecification specification, CancellationToken cancellationToken)
        {
            var ingredients = specification.Bodies.Select(x => new Ingredient(x.ToInfo())).ToList();
            await _ingredientRepository.AddRangeAsync(ingredients, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var ids = ingredients.Select(i => i.Id).ToHashSet();
            specification.ApplyCriteria(ids);
            var createdIngredients = await _ingredientRepository.ToListAsync(specification, cancellationToken);

            var response = createdIngredients.Select(i => new IngredientResponse(i));
            return Result<IEnumerable<IngredientResponse>>
                .Succeed(response, Success<Ingredient>.Created, HttpStatusCode.Created);
        }

        public async Task<Result<IngredientResponse>> 
            UpdateAsync(UpdateIngredientSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(specification, cancellationToken);
            if (ingredient is null)
            {
                return Result<IngredientResponse>
                    .Fail(Error<Ingredient>.NotFound, HttpStatusCode.NotFound);
            }

            ingredient.Update(specification.Body.Name, specification.Body.Description, specification.Body.CategoryId);
            await _ingredientRepository.UpdateAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success<Ingredient>.Updated);
        }

        public async Task<Result<IngredientResponse>> 
            UpdateStockAsync(UpdateIngredientStockSpecification specification, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(specification, cancellationToken);
            if (ingredient is null)
            {
                return Result<IngredientResponse>
                    .Fail(Error<Ingredient>.NotFound, HttpStatusCode.NotFound);
            }

            ingredient.IngredientStock.Update(specification.Body.UnitPrice, specification.Body.Unit, specification.Body.StockQuantity);
            await _ingredientRepository.UpdateAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new IngredientResponse(ingredient);
            return Result<IngredientResponse>
                .Succeed(response, Success<Ingredient>.Updated, HttpStatusCode.OK);
        }

        public async Task<Result<object>> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(id, cancellationToken);
            if (ingredient is null)
            {
                return Result<object>
                    .Fail(Error<Ingredient>.NotFound, HttpStatusCode.NotFound);
            }

            if (ingredient.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Ingredient>.AlreadyDeleted, HttpStatusCode.Conflict);
            }

            ingredient.SoftDelete();
            await _ingredientRepository.UpdateAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Ingredient>.Deleted);
        }

        public async Task<Result<object>> RestoreAsync(Guid id, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.FindAsync(id, cancellationToken);
            if (ingredient is null)
            {
                return Result<object>
                    .Fail(Error<Ingredient>.NotFound, HttpStatusCode.NotFound);
            }

            if (!ingredient.IsDeleted)
            {
                return Result<object>
                    .Fail(Error<Ingredient>.NotYetDeleted, HttpStatusCode.Conflict);
            }

            ingredient.Restore();
            await _ingredientRepository.UpdateAsync(ingredient, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                .Succeed(default, Success<Ingredient>.Restored);
        }
    }
}
