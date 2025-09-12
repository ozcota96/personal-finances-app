using core_api.Models;

namespace core_api.Repositories.Interfaces
{
    public interface IMovementRepository
    {
        Task<Movement> AddMovementAsync(Movement movement);
    }
}
