using core_api.Models;

namespace core_api.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IList<User>> GetUsers();
        Task<User?> GetUserById(int id);
        Task<User?> CreateUser(User user);
    }
}
