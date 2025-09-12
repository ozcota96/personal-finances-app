using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task<Account> AddAccountAsync(Account account);
    }
}
