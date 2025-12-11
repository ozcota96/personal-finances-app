using core_api.Enums;
using core_api.Models;
using core_api.Models.Request;
using core_api.Repositories.Interfaces;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class MovementsService : IMovementsService
    {
        private readonly IMovementRepository _movementRepository;
        private readonly IAccountsRepository _accountsRepository;

        public MovementsService(IMovementRepository movementRepository, IAccountsRepository accountsRepository)
        {
            _movementRepository = movementRepository;
            _accountsRepository = accountsRepository;
        }

        public Task<IList<Movement>> GetMovements()
        {
            return _movementRepository.GetMovementsAsync();
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
                CategoryId = movementDto.CategoryId,
                SubcategoryId = movementDto.SubcategoryId,
                Date = DateTime.SpecifyKind(movementDto.Date, DateTimeKind.Utc),
                Type = (MovementTypes)movementDto.Type,
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
