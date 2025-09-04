using core_api.Models;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class AccountsService : IAccountsService
    {
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
    }
}
