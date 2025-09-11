using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IList<User>> GetUsers();
        Task<User?> GetUserById(int id);
        Task<User?> Login(string email, string password);
        Task<User?> CreateUser(CreateUserDto userDto);
    }
}
