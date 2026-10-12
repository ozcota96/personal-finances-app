using core_api.Models.Request;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace core_api.Controllers
{
    [Route("api/movements")]
    [ApiController]
    public class MovementsController : ControllerBase
    {
        private readonly IMovementsService _movementsService;

        public MovementsController(IMovementsService movementsService)
        {
            _movementsService = movementsService;
        }

        [Authorize]
        [HttpGet("dashboard")]
        public async Task<IActionResult> GetMovementsDashboard()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var movements = await _movementsService.GetDashboardMovements(Convert.ToInt32(userId));
            return movements is not null ? Ok(movements) : NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateMovement([FromBody] CreateMovementDto movementDto)
        {
            var movement = await _movementsService.CreateMovement(movementDto);
            return movement is not null ? Created("api/movements/{id}", movement) : Conflict();
        }
    }
}