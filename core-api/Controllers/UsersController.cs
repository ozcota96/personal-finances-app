using core_api.Models;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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
            var users = _usersService.GetUsers();
            return users is not null ? Ok(users) : NotFound();
        }

        [HttpGet("api/users/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _usersService.GetUserById(id);
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost("api/users")]
        public IActionResult CreateUser([FromBody] User user)
        {
            _usersService.CreateUser(user);
            return Created("api/users/{id}", user);
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
