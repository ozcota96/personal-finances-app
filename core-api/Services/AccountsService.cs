using core_api.Models;
using core_api.Models.Request;
using core_api.Repositories.Interfaces;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;

        public AccountsService(IAccountsRepository accountsRepository)
        {
            _accountsRepository = accountsRepository;
        }

        public Task<IList<Account>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetAccountById(int id)
        {
            throw new NotImplementedException();
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

        public Task<bool> DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
