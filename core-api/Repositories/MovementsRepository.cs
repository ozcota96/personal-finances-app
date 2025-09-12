using core_api.Models;
using core_api.Repositories.Interfaces;

namespace core_api.Repositories
{
    public class MovementsRepository : IMovementRepository
    {
        private readonly AppDbContext _context;

        public MovementsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movement> AddMovementAsync(Movement movement)
        {
            _context.Movements.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }
    }
}
