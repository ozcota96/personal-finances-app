using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task<Account?> GetAccountByIdAsync(int accountId);
        Task<List<Account>> GetUserAccountsAsync(int userId);
        Task<Account> AddAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(Account account);
    }
}
