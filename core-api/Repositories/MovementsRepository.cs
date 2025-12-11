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
            using var transaction = await _context.Database.BeginTransactionAsync();

            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Id == movement.AccountId);

            if (account is null)
                return null;

            _context.Movements.Add(movement);

            account.Balance += movement.Type == MovementTypes.Income
                ? movement.Amount
                : -movement.Amount;

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return movement;
        }

        public async Task<IList<Movement>> GetAccountMovements(int accountId)
        {
            if (!_context.Accounts.Any(a => a.Id == accountId))
                return null;

            return await _context.Movements
                .Where(m => m.AccountId == accountId)
                .Include(m => m.Category)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IList<Movement>> GetMovementsAsync()
        {
            return await _context.Movements
                .Include(m => m.Category)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
