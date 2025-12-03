using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface IMovementRepository
    {
        Task<IList<Movement>> GetMovementsAsync();
        Task<Movement> AddMovementAsync(Movement movement);
        Task<IList<Movement>> GetAccountMovements(int accountId);
    }
}
