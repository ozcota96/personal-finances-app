using core_api.Models;

namespace core_api.Services.Interfaces
{
    public interface IMovementsService
    {
        Task<IList<Movement>> GetMovements();
        Task<Movement?> GetMovementById(int id);
        Task<Movement> CreateMovement(Movement transaction);
        Task<Movement> UpdateMovement(int id, Movement transaction);
        bool DeleteMovement(int id);
    }
}
