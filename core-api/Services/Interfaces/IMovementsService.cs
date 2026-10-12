using core_api.Models;
using core_api.Models.Request;
using core_api.Models.Response;

namespace core_api.Services.Interfaces
{
    public interface IMovementsService
    {
        Task<Movement?> CreateMovement(CreateMovementDto movementDto);
        Task<IList<GetMovementDto>> GetDashboardMovements(int userId);
    }
}
