using core_api.Models;
using core_api.Models.Request;
using core_api.Models.Response;

namespace core_api.Services.Interfaces
{
    public interface IUsersService
    {
        Task<GetUserDto?> GetUserById(int id);
        Task<User?> Login(string email, string password);
        Task<User?> CreateUser(CreateUserDto userDto);
        Task<bool> UpdateUser(UpdateUserDto userDto, int id, int userId);
    }
}
