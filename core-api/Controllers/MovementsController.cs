using core_api.Models;
using core_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        public async Task<IActionResult> GetMovements()
        {
            var movements = await _movementsService.GetMovements();
            return movements is not null ? Ok(movements) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovementById(int id)
        {
            var movement = await _movementsService.GetMovementById(id);
            return movement is not null ? Ok(movement) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovement([FromBody] Movement movement)
        {
            await _movementsService.CreateMovement(movement);
            return Created("api/movements/{id}", movement);
        }
    }
}