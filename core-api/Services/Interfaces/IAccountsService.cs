using core_api.Models;

namespace core_api.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<IList<Account>> GetAccounts();
        Task<Account?> GetAccountById(int id);
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int id);
    }
}
