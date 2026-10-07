using core_api.Models;
using core_api.Models.Request;
using core_api.Repositories.Interfaces;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IMovementRepository _movementRepository;

        public AccountsService(IAccountsRepository accountsRepository, IMovementRepository movementRepository)
        {
            _accountsRepository = accountsRepository;
            _movementRepository = movementRepository;
        }

        public async Task<IList<Account>> GetUserAccounts(int userId)
        {
            return await _accountsRepository.GetUserAccountsAsync(userId);
        }

        public async Task<IList<Movement>> GetAccountMovements(int accountId)
        {
            var accountMovements = await _movementRepository.GetAccountMovementsAsync(accountId);
            return accountMovements;
        }

        public async Task<Account?> CreateAccount(CreateAccountDto accountDto)
        {
            var account = new Account
            {
                Name = accountDto.Name,
                Balance = accountDto.InitialBalance,
                UserId = accountDto.UserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            return await _accountsRepository.AddAccountAsync(account);
        }

        public async Task<bool> UpdateAccount(UpdateAccountDto accountDto, int id, int userId)
        {
            var account = await _accountsRepository.GetAccountByIdAsync(id);
            if(account is null)
            {
                return false;
            }
            account.Name = accountDto.Name;
            account.Balance = accountDto.Balance;
            // History columns
            account.UpdatedAt = DateTime.UtcNow;
            account.UpdatedBy = userId;

            await _accountsRepository.UpdateAccountAsync(account);
            return true;
        }

        public async Task<bool> DeleteAccount(int id, int userId)
        {
            var account = await _accountsRepository.GetAccountByIdAsync(id);
            if (account is null)
            {
                return false;
            }

            // Soft delete
            account.IsDeleted = true;
            account.UpdatedAt = DateTime.UtcNow;
            account.UpdatedBy = userId;

            await _accountsRepository.DeleteAccountAsync(account);
            return true;
        }

        
    }
}
