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

        public async Task<IList<User>> GetUsers()
        {
            await Task.CompletedTask; // placeholder until the asynchronous call exists
            return _users;
        }

        public async Task<User?> GetUserById(int id)
        {
            await Task.CompletedTask;  // placeholder until the asynchronous call exists
            return _users.SingleOrDefault(u => u.Id == id);
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = _users.SingleOrDefault(u => u.Email == email);
            if (user is null)
            {
                await Task.CompletedTask;  // placeholder until the asynchronous call exists
                return null;
            }
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            await Task.CompletedTask;  // placeholder until the asynchronous call exists
            if (!isPasswordValid)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> CreateUser(User user)
        {
            user.Id = _users.Count;
            user.Id++; // simple auto-increment simulation
            await Task.CompletedTask;  // placeholder until the asynchronous call exists
            _users.Add(user);
            return user;
        }

        // This method can be used to initialize users from a database or other source in the future
        private static void InitializeUsers(List<User> users)
        {
            users.AddRange(
            [
                new()
                {
                    Id = 1,
                    FirstName = "Peter",
                    LastName = "Parker",
                    Email = "pparker@example.com",
                    PasswordHash = "123123jljhfljkfh",
                    Accounts =
                    [
                        new ()
                        {
                            Id = 1,
                            Name = "1234567890",
                            Balance = 1000.00m,
                            UserId = 1,
                            Movements = []
                        }
                    ]
                },
                new()
                {
                    Id = 2,
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "tstark@example.com",
                    PasswordHash = "123123jljhfljkfh",
                    Accounts =
                    [
                        new ()
                        {
                            Id = 2,
                            Name = "0987654321",
                            Balance = 2500.00m,
                            UserId = 2,
                            Movements = []
                        }
                    ]
                },
                new()
                {
                    Id = 3,
                    FirstName = "Steve",
                    LastName = "Rogers",
                    Email = "srogers@example.com",
                    PasswordHash = "123123jljhfljkfh",
                    Accounts =
                    [
                        new ()
                        {
                            Id = 3,
                            Name = "1122334455",
                            Balance = 3000.00m,
                            UserId = 3,
                            Movements = []
                        }
                    ]
                }
            ]);
        }
    }
}
