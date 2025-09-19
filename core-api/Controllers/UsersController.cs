using core_api.Models.Request;
using core_api.Services;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersService.GetUsers();
            return users is not null ? Ok(users) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _usersService.GetUserById(id);
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto, [FromServices] JwtTokenService tokenService)
        {
            var user = await _usersService.Login(loginDto.Email, loginDto.Password);
            var token = user is not null ? tokenService.GenerateToken(user) : null;
            return user is not null ? Ok(new
            {
                token,
                user
            }) : Unauthorized(new { Message = "Invalid email or password." });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var user = await _usersService.CreateUser(userDto);
            return user is not null ? Created("api/users/{id}", user) : Conflict();
        }

        // TODO: Implement Update and Delete methods
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id)
        {
            return Ok(new { Message = $"Update user with ID {id}" });
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(new { Message = $"Delete user with ID {id}" });
        }
    }
}
