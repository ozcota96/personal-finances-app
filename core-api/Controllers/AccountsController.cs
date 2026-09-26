using core_api.Models.Request;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace core_api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountsService _accountService;
        public AccountsController(IAccountsService accountService)
        {
            _accountService = accountService;
        }

        [Authorize]
        [HttpGet("{id}/movements")]
        public async Task<IActionResult> GetAccountMovements(int id)
        {
            var movements = await _accountService.GetAccountMovements(id);
            return movements is not null ? Ok(movements) : NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto accountDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            accountDto.UserId = int.Parse(userId);
            var account = await _accountService.CreateAccount(accountDto);
            return account is not null ? Created("api/accounts/{id}", account) : Conflict();
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountDto accountDto, int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var success = await _accountService.UpdateAccount(accountDto, id, Convert.ToInt32(userId));
            return success ? NoContent() : NotFound();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var success = await _accountService.DeleteAccount(id, Convert.ToInt32(userId));
            return success ? NoContent() : NotFound();
        }
    }
}
