using core_api.Models;

namespace core_api.Services.Interfaces
{
    public interface IUsersService
    {
        IList<User> GetUsers();
        User? GetUserById(int id);
        User? CreateUser(User user);
    }
}
