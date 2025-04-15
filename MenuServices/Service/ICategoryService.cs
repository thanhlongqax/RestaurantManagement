using MenuServices.DTO;
using MenuServices.DTO.Request;
using MenuServices.Models;

namespace MenuServices.Service
{
    public interface ICategoryService
    {
        Task<ResDTO<object>> GetCategories(int page, int limit, string? keyword);
        Task<ResDTO<Category>> GetCategoryById(string id);
        Task<ResDTO<Category>> AddCategory(AddCategoryReqDTO categoryDto);
        Task<ResDTO<Category>> UpdateCategory(UpdateCategoryReqDTO updateCategoryDto);
        Task<ResDTO<Category>> DeleteCategory(string id);
    }
}
