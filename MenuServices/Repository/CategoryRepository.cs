using Lombok.NET;
using MenuServices.Context;
using MenuServices.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuServices.Repository
{
    [RequiredArgsConstructor]
    public partial class CategoryRepository : ICategoryRepository
    {
        private readonly MenuContext _menuContext;

        public async Task<List<Category>> GetCategories(int page, int limit, string? keyword)
        {
            var query = _menuContext.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword));
            }

            return await query
                .OrderBy(c => c.Name)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<int> GetTotalCategories(string? keyword)
        {
            var query = _menuContext.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword));
            }
            return await query.CountAsync();
        }

        public async Task<Category?> GetCategoryById(string id)
        {
            return await _menuContext.Categories.FindAsync(id);
        }

        public async Task<Category> AddCategory(Category category)
        {
            _menuContext.Categories.Add(category);
            await _menuContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
            var existingCategory = await _menuContext.Categories.FindAsync(category.Id);
            if (existingCategory == null) return null;

            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            await _menuContext.SaveChangesAsync();

            return existingCategory;
        }

        public async Task<bool> DeleteCategory(string id)
        {
            var category = await _menuContext.Categories.FindAsync(id);
            if (category == null) return false;

            _menuContext.Categories.Remove(category);
            await _menuContext.SaveChangesAsync();
            return true;
        }
    }
}
