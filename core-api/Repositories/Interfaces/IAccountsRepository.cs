using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task<List<Account>> GetUserAccounts(int userId);
        Task<Account> AddAccountAsync(Account account);
    }
}
