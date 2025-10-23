using core_api.Models;
using core_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace core_api.Repositories
{
    public class SubcategoriesRepository : ISubcategoriesRepository
    {
        private readonly AppDbContext _context;

        public SubcategoriesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Subcategory> AddSubcategoryAsync(Subcategory subcategory)
        {
            _context.Subcategories.Add(subcategory);
            await _context.SaveChangesAsync();
            return subcategory;
        }

        public async Task<IList<Subcategory>> GetSubcategoriesAsync()
        {
            return await _context.Subcategories
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
