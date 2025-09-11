using core_api.Models;
using core_api.Models.Request;
using core_api.Repositories.Interfaces;
using core_api.Services;
using Moq;

namespace core_api_unit_tests
{
    public class UsersControllerTests
    {
        [Fact]
        public async Task Register_User_Success()
        {
            // Arrange
            var repositoryMock = new Mock<IUsersRepository>();
            repositoryMock.Setup(repo => repo.GetUserByEmailAsync("test@example.com"))
                .ReturnsAsync((User?)null);
            repositoryMock.Setup(repo => repo.AddUserAsync(It.IsAny<User>()))
                .ReturnsAsync((User user) => user);

            var service = new UsersService(repositoryMock.Object);

            // Act
            var user = await service.CreateUser(new CreateUserDto
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test@example.com",
                Password = "Password123"
            });

            // Assert
            Assert.Equal("test@example.com", user?.Email);
            Assert.NotEqual("Password123", user?.PasswordHash); // Password should be hashed
            repositoryMock.Verify(repo => repo.AddUserAsync(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task Register_User_Fails_WhenEmail_Already_Exists()
        {
            // Arrange
            var repositoryMock = new Mock<IUsersRepository>();
            repositoryMock.Setup(repo => repo.GetUserByEmailAsync("test@example.com"))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    FirstName = "Existing",
                    LastName = "User",
                    Email = "test@example.com",
                    PasswordHash = "hashedpassword"
                });

            var service = new UsersService(repositoryMock.Object);

            // Act
            var result = await service.CreateUser(new CreateUserDto
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test@example.com",
                Password = "Password123"
            });

            // Assert
            Assert.Null(result);
            repositoryMock.Verify(repo => repo.AddUserAsync(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task Login_User_Success()
        {
            // Arrange
            var repositoryMock = new Mock<IUsersRepository>();
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("Password123");
            repositoryMock.Setup(repo => repo.GetUserByEmailAsync("test@example.com"))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "User",
                    Email = "test@example.com",
                    PasswordHash = passwordHash
                });
            var service = new UsersService(repositoryMock.Object);

            // Act
            var result = await service.Login("test@example.com", "Password123");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test", result?.FirstName);
        }

        [Fact]
        public async Task Login_User_Fails_With_Wrong_Password()
        {
            // Arrange
            var repositoryMock = new Mock<IUsersRepository>();
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("Password123");
            repositoryMock.Setup(repo => repo.GetUserByEmailAsync("test@example.com"))
                .ReturnsAsync(new User
                {
                    Id = 1,
                    FirstName = "Test",
                    LastName = "User",
                    Email = "test@example.com",
                    PasswordHash = passwordHash
                });
            var service = new UsersService(repositoryMock.Object);

            // Act
            var result = await service.Login("test@example.com", "WrongPassword");

            // Assert
            Assert.Null(result);
        }
    }
}
