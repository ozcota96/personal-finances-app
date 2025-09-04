using core_api.Models;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly List<Account> _accounts = [];

        public AccountsService()
        {
            InitializeAccounts(_accounts);
        }
        public Task<IList<Account>> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public Task<Account?> GetAccountById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> CreateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Account> UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        private static void InitializeAccounts(List<Account> accounts)
        {
            accounts.AddRange(
            [
                new() { Id = 1, UserId = 1, Balance = 1500.00m, CreatedAt = DateTime.UtcNow },
                new() { Id = 2, UserId = 1, Balance = 3000.00m, CreatedAt = DateTime.UtcNow },
                new() { Id = 3, UserId = 2, Balance = 500.00m, CreatedAt = DateTime.UtcNow }
            ]);
        }
    }
}
