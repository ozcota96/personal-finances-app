using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface IMovementRepository
    {
        Task<Movement?> GetMovementByIdAsync(int id);
        Task<Movement?> AddMovementAsync(Movement movement);
        Task<IList<Movement>> GetUserMovementsAsync(int userId);
        Task UpdateMovementAsync(Movement movement);
        Task DeleteMovementAsync(Movement movement);
    }
}
