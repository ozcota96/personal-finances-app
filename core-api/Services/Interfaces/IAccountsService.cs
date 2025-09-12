using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<IList<Account>> GetAccounts();
        Task<Account?> GetAccountById(int id);
        Task<Account?> CreateAccount(CreateAccountDto accountDto);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int id);
    }
}
