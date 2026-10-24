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
        private readonly IAccountsRepository _accountRepository;

        public MovementsService(IMovementRepository movementRepository, IAccountsRepository accountRepository)
        {
            _movementRepository = movementRepository;
            _accountRepository = accountRepository;
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
                // History columns
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var account = await _accountRepository.GetAccountByIdAsync(movement.AccountId);
            if (account is null)
                return null;

            account.Balance += movement.Type == MovementTypes.Income
                ? movement.Amount
                : -movement.Amount;

            await _accountRepository.UpdateAccountAsync(account);

            return await _movementRepository.AddMovementAsync(movement);
        }

        public async Task<bool> UpdateMovement(int movementId, UpdateMovementDto movementDto, int userId)
        {
            var movement = await _movementRepository.GetMovementByIdAsync(movementId);
            if (movement is null)
                return false;

            if (movement.Account is null)
                return false;

            var oldType = movement.Type;
            var newType = (MovementTypes)movementDto.Type;

            decimal oldSigned = oldType == MovementTypes.Expense ? -movement.Amount : movement.Amount;
            decimal newSigned = newType == MovementTypes.Expense ? -movementDto.Amount : movementDto.Amount;

            if (movementDto.AccountId != movement.AccountId)
            {
                var newAccount = await _accountRepository.GetAccountByIdAsync(movementDto.AccountId);
                if (newAccount is null)
                {
                    return false;
                }
                
                movement.Account.Balance -= oldSigned;
                newAccount.Balance += newSigned;

                await _accountRepository.UpdateAccountAsync(movement.Account);
                await _accountRepository.UpdateAccountAsync(newAccount);

                movement.AccountId = movementDto.AccountId;
                movement.Account = newAccount;
            }
            else
            {
                var detla = newSigned - oldSigned;
                movement.Account.Balance += detla;

                await _accountRepository.UpdateAccountAsync(movement.Account);
            }

            movement.Amount = movementDto.Amount;
            movement.Type = newType;
            movement.Description = movementDto.Description;
            movement.Date = DateTime.SpecifyKind(movementDto.Date, DateTimeKind.Utc);
            movement.CategoryId = movementDto.CategoryId;
            movement.SubcategoryId = movementDto.SubcategoryId;
            // History columns
            movement.UpdatedAt = DateTime.UtcNow;
            movement.UpdatedBy = userId;

            await _movementRepository.UpdateMovementAsync(movement);

            return true;
        }

        public async Task<bool> DeleteMovement(int movementId, int userId)
        {
            var movement = await _movementRepository.GetMovementByIdAsync(movementId);
            if (movement is null)
                return false;

            decimal oldSigned = movement.Type == MovementTypes.Expense ? -movement.Amount : movement.Amount;

            var account = await _accountRepository.GetAccountByIdAsync(movement.AccountId);
            if (account is null)
                return false;

            account.Balance += -oldSigned;
            await _accountRepository.UpdateAccountAsync(account);

            movement.IsDeleted = true;
            // History columns
            movement.UpdatedAt = DateTime.UtcNow;
            movement.UpdatedBy = userId;

            await _movementRepository.DeleteMovementAsync(movement);
            return true;
        }
    }
}