using Restaurant.Application.Models.Messages;
using Restaurant.Application.Models.Results;
using Restaurant.Application.Services.Persistence;
using Restaurant.Application.Services.Personnel;
using Restaurant.Contract.DTOs.Personnel.Positions;
using Restaurant.Domain.Entities.Personnel;
using Restaurant.Domain.Repositories.Personnel;
using System.Net;

namespace Restaurant.Persistence.Services.Personnel
{
    internal class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PositionService(
            IPositionRepository positionRepository,
            IUnitOfWork unitOfWork)
        {
            _positionRepository = positionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<IEnumerable<PositionResponse>>> 
            GetAllAsync(CancellationToken cancellationToken)
        {
            var positions = await _positionRepository.ToListAsync(cancellationToken);

            var response = positions.Select(x => new PositionResponse(x));
            return Result<IEnumerable<PositionResponse>>
                .Succeed(response, Success<Position>.Retrieved);
        }

        public async Task<Result<PositionResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var position = await _positionRepository.FindAsync(id, cancellationToken);
            if(position is null)
            {
                return Result<PositionResponse>
                    .Fail(Error<Position>.NotFound, HttpStatusCode.NotFound);
            }

            var response = new PositionResponse(position);
            return Result<PositionResponse>
                .Succeed(response, Success<Position>.Retrieved);
        }

        public async Task<Result<PositionResponse>> CreateAsync(CreatePositionRequest request, CancellationToken cancellationToken)
        {
            var position = new Position(request.Name, request.Description);

            await _positionRepository.AddAsync(position, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            var response = new PositionResponse(position);
            return Result<PositionResponse>
                .Succeed(response, Success<Position>.Created, HttpStatusCode.Created);
        }
    }
}
