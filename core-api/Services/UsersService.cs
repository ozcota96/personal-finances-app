using core_api.Models;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class UsersService : IUsersService
    {
        private readonly List<User> _users = [];

        public UsersService()
        {
            InitializeUsers(_users);
        }

        public IList<User> GetUsers()
        {
            return _users;
        }

        public User? GetUserById(int id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public User? CreateUser(User user)
        {
            _users.Add(user);
            return user;
        }

        // This method can be used to initialize users from a database or other source in the future
        private static void InitializeUsers(List<User> users)
        {
            users.AddRange(
            [
                new() { Id = 1, FirstName = "Peter", LastName = "Parker", Email = "pparker@example.com", PasswordHash = "123123jljhfljkfh" },
                new() { Id = 2, FirstName = "Tony", LastName = "Stark", Email = "tstark@example.com", PasswordHash = "123123jljhfljkfh" },
                new() { Id = 3, FirstName = "Steve", LastName = "Rogers", Email = "srogers@example.com", PasswordHash = "123123jljhfljkfh" }
            ]);
        }
    }
}
