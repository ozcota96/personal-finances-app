using core_api.Models.Request;
using core_api.Services;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IAccountsService _accountsService;
        private readonly ICategoriesService _categoriesService;

        public UsersController(IUsersService usersService, IAccountsService accountsService, ICategoriesService categoriesService)
        {
            _usersService = usersService;
            _accountsService = accountsService;
            _categoriesService = categoriesService;
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

        [Authorize]
        [HttpGet ("{id}/accounts")]
        public async Task<IActionResult> GetUserAccounts(int id)
        {
            var accounts = await _accountsService.GetUserAccounts(id);
            return accounts is not null ? Ok(accounts) : NotFound();
        }

        [Authorize]
        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetUserCategories(int id)
        {
            var categories = await _categoriesService.GetUserCategoriesAsync(id);
            return categories is not null ? Ok(categories) : NotFound();
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
    }
}
