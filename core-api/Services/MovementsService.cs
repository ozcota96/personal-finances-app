using core_api.Enums;
using core_api.Models;
using core_api.Models.Request;
using core_api.Models.Response;
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

        public async Task<IList<GetMovementDto>> GetDashboardMovements(int userId)
        {
            var movements = await _movementRepository.GetUserMovementsAsync(userId);
            return [.. movements.Select(m => new GetMovementDto
            {
                Id = m.Id,
                Amount = m.Amount,
                Description = m.Description,
                MovementType = m.Type,
                Date = m.Date,
                Account = m.Account?.Name ?? string.Empty,
                Category = m.Category?.Name ?? string.Empty,
                Subcategory = m.Subcategory?.Name ?? string.Empty
            })];
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

        
    }
}
