using core_api.Enums;
using core_api.Models;
using core_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace core_api.Repositories
{
    public class MovementsRepository : IMovementRepository
    {
        private readonly AppDbContext _context;

        public MovementsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Movement?> AddMovementAsync(Movement movement)
        {
            _context.Add(movement);
            await _context.SaveChangesAsync();
            return movement;
        }

        public async Task DeleteMovementAsync(Movement movement)
        {
            _context.Movements.Update(movement);
            await _context.SaveChangesAsync();
        }

        public async Task<Movement?> GetMovementByIdAsync(int id)
        {
            return await _context.Movements
                .Include(m => m.Account)
                .FirstOrDefaultAsync(m => m.Id == id && !m.IsDeleted);
        }

        public async Task<IList<Movement>> GetUserMovementsAsync(int userId)
        {
            return await _context.Movements
                .Include(m => m.Account)
                .Include(m => m.Category)
                .Include(m => m.Subcategory)
                .Where(m => m.Account.UserId == userId && !m.IsDeleted)
                .OrderByDescending(m => m.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateMovementAsync(Movement movement)
        {
            _context.Movements.Update(movement);
            await _context.SaveChangesAsync();
        }
    }
}
