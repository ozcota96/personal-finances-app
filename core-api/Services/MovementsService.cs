using core_api.Models;
using core_api.Models.Request;
using core_api.Repositories.Interfaces;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class MovementsService : IMovementsService
    {
        private readonly IMovementRepository _movementRepository;

        public MovementsService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public Task<IList<Movement>> GetMovements()
        {
            throw new NotImplementedException();
        }
        public Task<Movement?> GetMovementById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Movement?> CreateMovement(CreateMovementDto movementDto)
        {
            var movement = new Movement
            {
                AccountId = movementDto.AccountId,
                Amount = movementDto.Amount,
                Description = movementDto.Description,
                Date = DateTime.SpecifyKind(movementDto.Date, DateTimeKind.Utc),
                Type = movementDto.MovementType,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return await _movementRepository.AddMovementAsync(movement);
        }
        public bool DeleteMovement(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Movement> UpdateMovement(int id, Movement transaction)
        {
            throw new NotImplementedException();
        }
    }
}
