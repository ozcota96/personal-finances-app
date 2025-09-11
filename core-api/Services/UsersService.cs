using core_api.Models;
using core_api.Models.Request;
using core_api.Repositories.Interfaces;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        // TODO: Generate response models to avoid returning sensitive data like PasswordHash
        public async Task<IList<User>> GetUsers()
        {
            return await _usersRepository.GetUsersAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _usersRepository.GetUserByIdAsync(id);
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);
            if (user is null)
            {
                return null;
            }
            
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            if (!isPasswordValid)
            {
                return null;
            }
            
            return user;
        }

        public async Task<User?> CreateUser(CreateUserDto userDto)
        {
            var existing = await _usersRepository.GetUserByEmailAsync(userDto.Email);
            if (existing is not null)
                return null;
            
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            var user = new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            return await _usersRepository.AddUserAsync(user); ;
        }
    }
}
