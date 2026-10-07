using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface IAccountsService
    {
        Task<IList<Account>> GetUserAccounts(int userId);
        Task<IList<Movement>> GetAccountMovements(int accountId);
        Task<Account?> CreateAccount(CreateAccountDto accountDto);
        Task<bool> UpdateAccount(UpdateAccountDto accountDto, int id, int userId);
        Task<bool> DeleteAccount(int id, int userId);
    }
}
