using Lombok.NET;
using MenuServices.Context;
using MenuServices.DTO;
using MenuServices.DTO.Request;
using MenuServices.Models;
using MenuServices.Repository;
using Microsoft.EntityFrameworkCore;

namespace MenuServices.Service
{
    [RequiredArgsConstructor]
    public partial class CategoryService : ICategoryService
    {
        private readonly MenuContext menuContext;

        public async Task<ResDTO<object>> GetCategories(int page = 1, int limit = 10, string? keyword = null)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;

            var query = menuContext.Categories.AsQueryable();

            // Lọc theo từ khóa (nếu có)
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword));
            }

            // Tổng số danh mục (phục vụ phân trang)
            int totalCount = await query.CountAsync();

            // Phân trang
            var categories = await query
                .OrderBy(c => c.Name)  // Sắp xếp theo tên
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new ResDTO<object>
            {
                Code = 200,
                Message = "Success",
                Data = new
                {
                    Categories = categories,
                    TotalCount = totalCount
                }
            };
        }


        public async Task<ResDTO<Category>> GetCategoryById(string id)
        {
            var category = await menuContext.Categories.FindAsync(id);
            return category == null
                ? new ResDTO<Category> { Code = 404, Message = "Category not found" }
                : new ResDTO<Category> { Code = 200, Message = "Success", Data = category };
        }

        public async Task<ResDTO<Category>> AddCategory(AddCategoryReqDTO category)
        {
            Category newCategory = new Category();
            newCategory.Description = category.Description;
            newCategory.Name = category.Name;

            menuContext.Categories.Add(newCategory);
            await menuContext.SaveChangesAsync();
            return new ResDTO<Category> { Code = 201, Message = "Category created", Data = null };
        }

        public async Task<ResDTO<Category>> UpdateCategory(UpdateCategoryReqDTO updateCategoryReqDTO)
        {
            var category = await menuContext.Categories.FindAsync(updateCategoryReqDTO.Id);

            if (category == null)
            {
                return new ResDTO<Category> { Code = 404, Message = "Category not found", Data = null };
            }

            // Chỉ cập nhật những thuộc tính có giá trị
            category.Name = !string.IsNullOrEmpty(updateCategoryReqDTO.Name) ? updateCategoryReqDTO.Name : category.Name;
            category.Description = !string.IsNullOrEmpty(updateCategoryReqDTO.Description) ? updateCategoryReqDTO.Description : category.Description;

            await menuContext.SaveChangesAsync();

            return new ResDTO<Category> { Code = 200, Message = "Category updated successfully", Data = category };
        }


        public async Task<ResDTO<Category>> DeleteCategory(string id)
        {
            var category = await menuContext.Categories.FindAsync(id);
            if (category == null)
                return new ResDTO<Category> { Code = 404, Message = "Category not found" };

            menuContext.Categories.Remove(category);
            await menuContext.SaveChangesAsync();
            return new ResDTO<Category> { Code = 200, Message = "Category deleted" };
        }
    }
}
