using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Territory;
using Restaurant.Contract.DTOs.Territory.RestaurantTables;
using Restaurant.Domain.Entities.Territory;
using Restaurant.Domain.Repositories.Territory;
using System.Net;

namespace Restaurant.Persistence.Services.Territory
{
    internal class RestaurantTableService : IRestaurantTableService
    {
        private readonly IRestaurantTableRepository _restaurantTableRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RestaurantTableService(IRestaurantTableRepository restaurantTableRepository, IUnitOfWork unitOfWork)
        {
            _restaurantTableRepository = restaurantTableRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<RestaurantTableResponse>>>
            GetAllAsync(CancellationToken cancellationToken = default)
        {
            var restaurantTables = await _restaurantTableRepository.ToListAsync(cancellationToken);

            var response = restaurantTables.Select(rt => new RestaurantTableResponse(rt));
            return Result<IEnumerable<RestaurantTableResponse>>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<RestaurantTableResponse>>
            GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restaurantTable = await _restaurantTableRepository.FindAsync(id, cancellationToken);
            if (restaurantTable is null)
            {
                return Result<RestaurantTableResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            var response = new RestaurantTableResponse(restaurantTable);
            return Result<RestaurantTableResponse>
                .Succeed(response, Success.Retrieved);
        }

        public async Task<Result<RestaurantTableResponse>> CreateAsync(CreateRestaurantTableRequest request, CancellationToken cancellationToken = default)
        {
            var table = RestaurantTable.Create(request.TableNumber, request.Capacity, request.Status, request.AreaId);
            await _restaurantTableRepository.AddAsync(table, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new RestaurantTableResponse(table);
            return Result<RestaurantTableResponse>
                .Succeed(response, Success.Created, HttpStatusCode.Created);
        }

        public async Task<Result<RestaurantTableResponse>> UpdateAsync(Guid id, UpdateRestaurantTableRequest request, CancellationToken cancellationToken = default)
        {
            var table = await _restaurantTableRepository.FindAsync(id, cancellationToken);
            if (table is null)
            {
                return Result<RestaurantTableResponse>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            table.Update(request.TableNumber, request.Capacity, request.Status, request.AreaId);
            await _restaurantTableRepository.UpdateAsync(table, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new RestaurantTableResponse(table);
            return Result<RestaurantTableResponse>
                .Succeed(response, Success.Updated);
        }

        public async Task<Result<object>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var table = await _restaurantTableRepository.FindAsync(id, cancellationToken);
            if (table is null)
            {
                return Result<object>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            if (table.IsDeleted)
            {
                return Result<object>
                    .Fail(Error.Deleted, HttpStatusCode.Conflict);
            }

            table.SoftDelete();
            await _restaurantTableRepository.UpdateAsync(table, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                    .Succeed(default, Success.Deleted, HttpStatusCode.OK);
        }

        public async Task<Result<object>> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var table = await _restaurantTableRepository.FindAsync(id, cancellationToken);
            if (table is null)
            {
                return Result<object>
                    .Fail(Error.NotFound, HttpStatusCode.NotFound);
            }

            if (!table.IsDeleted)
            {
                return Result<object>
                    .Fail(Error.Restored, HttpStatusCode.Conflict);
            }

            table.Restore();
            await _restaurantTableRepository.UpdateAsync(table, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result<object>
                    .Succeed(default, Success.Restored, HttpStatusCode.OK);
        }
    }
}
