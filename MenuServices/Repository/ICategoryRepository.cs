using MenuServices.DTO;
using MenuServices.DTO.Request;
using MenuServices.Models;

namespace MenuServices.Repository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories(int page, int limit, string? keyword);
        Task<int> GetTotalCategories(string? keyword);
        Task<Category?> GetCategoryById(string id);
        Task<Category> AddCategory(Category category);
        Task<Category?> UpdateCategory(Category category);
        Task<bool> DeleteCategory(string id);
    }
}
