using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("api/users")]
        public IActionResult GetUsers()
        {
            return Ok(_usersService.GetUsers());
        }

        [HttpGet("api/users/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_usersService.GetUserById(id));
        }

        [HttpPost("api/users")]
        public IActionResult CreateUser()
        {
            return Ok(new { Message = "Create a new user" });
        }

        [HttpPut("api/users/{id}")]
        public IActionResult UpdateUser(int id)
        {
            return Ok(new { Message = $"Update user with ID {id}" });
        }

        [HttpDelete("api/users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(new { Message = $"Delete user with ID {id}" });
        }
    }
}
