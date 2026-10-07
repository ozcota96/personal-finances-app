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

        public async Task DeleteSubcategoryAsync(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
            await _context.SaveChangesAsync();
        }

        public async Task<Subcategory?> GetSubcategoryByIdAsync(int subcategoryId)
        {
            return await _context.Subcategories
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == subcategoryId && s.IsDeleted == false);
        }

        public async Task UpdateSubcategoryAsync(Subcategory subcategory)
        {
            _context.Subcategories.Update(subcategory);
            await _context.SaveChangesAsync();
        }
    }
}
