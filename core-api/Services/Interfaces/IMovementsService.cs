using core_api.Models;
using core_api.Models.Request;

namespace core_api.Services.Interfaces
{
    public interface IMovementsService
    {
        Task<IList<Movement>> GetMovements();
        Task<Movement?> GetMovementById(int id);
        Task<Movement?> CreateMovement(CreateMovementDto movementDto);
        Task<Movement> UpdateMovement(int id, Movement transaction);
        bool DeleteMovement(int id);
    }
}
