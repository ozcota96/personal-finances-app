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

        public async Task<List<Account>> GetUserAccounts(int userId)
        {
            return await _context.Accounts
                .Where(a => a.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
