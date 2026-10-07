using core_api.Models;
using core_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace core_api.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly AppDbContext _context;

        public AccountsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> AddAccountAsync(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account?> GetAccountByIdAsync(int accountId)
        {
            return await _context.Accounts
                .FindAsync(accountId);
        }

        public async Task<List<Account>> GetUserAccountsAsync(int userId)
        {
            return await _context.Accounts
                .Where(a => a.UserId == userId && !a.IsDeleted)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(Account account)
        {
            // Soft delete. Updates flag IsDeleted
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}
