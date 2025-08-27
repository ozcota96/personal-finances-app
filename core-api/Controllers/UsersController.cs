using core_api.Models;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace core_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _usersService.GetUsers();
            return users is not null ? Ok(users) : NotFound();
        }

        [HttpGet("/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _usersService.GetUserById(id);
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _usersService.CreateUser(user);
            return Created("api/users/{id}", user);
        }

        [HttpPut("/{id}")]
        public IActionResult UpdateUser(int id)
        {
            return Ok(new { Message = $"Update user with ID {id}" });
        }

        [HttpDelete("/{id}")]
        public IActionResult DeleteUser(int id)
        {
            return Ok(new { Message = $"Delete user with ID {id}" });
        }
    }
}
