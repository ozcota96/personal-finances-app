using core_api.Models;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class UsersService : IUsersService
    {
        public UsersService()
        {
            
        }

        public IList<User> GetUsers()
        {
            var users = InitializeUsers();
            return users;
        }

        public User? GetUserById(int id)
        {
            var users = InitializeUsers();
            return users.FirstOrDefault(u => u.Id == id);
        }
        
        // This method can be used to initialize users from a database or other source in the future
        private List<User> InitializeUsers()
        {
            var users = new List<User>
            {
                new() { Id = 1, FirstName = "Peter", LastName = "Parker", Email = "pparker@example.com", PasswordHash = "123123jljhfljkfh" },
                new() { Id = 2, FirstName = "Tony", LastName = "Stark", Email = "tstark@example.com", PasswordHash = "123123jljhfljkfh" },
                new() { Id = 3, FirstName = "Steve", LastName = "Rogers", Email = "srogers@example.com", PasswordHash = "123123jljhfljkfh" }
            };
            return users;
        }
    }
}
