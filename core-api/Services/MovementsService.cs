using core_api.Models;
using core_api.Services.Interfaces;

namespace core_api.Services
{
    public class MovementsService : IMovementsService
    {
        public Task<IList<Movement>> GetMovements()
        {
            throw new NotImplementedException();
        }
        public Task<Movement?> GetMovementById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Movement> CreateMovement(Movement transaction)
        {
            throw new NotImplementedException();
        }
        public bool DeleteMovement(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Movement> UpdateMovement(int id, Movement transaction)
        {
            throw new NotImplementedException();
        }
    }
}
