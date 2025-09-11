using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<IList<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User> AddUserAsync(User user);
    }
}
