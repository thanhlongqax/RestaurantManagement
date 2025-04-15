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
    public partial class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly MenuContext _context;
        public async Task<ResDTO<object>> GetMenuItems(int page, int limit, string? keyword)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;

            var menuItems = await _menuRepository.GetMenuItems(page, limit, keyword);
            int totalCount = await _menuRepository.GetTotalMenuItemCount(keyword);

            return new ResDTO<object>
            {
                Code = 200,
                Message = "Success",
                Data = new { MenuItems = menuItems, TotalCount = totalCount }
            };
        }

        public async Task<ResDTO<MenuItem>> GetMenuItemById(string id)
        {
            var item = await _menuRepository.GetMenuItemById(id);
            return item == null
                ? new ResDTO<MenuItem> { Code = 404, Message = "Menu item not found" }
                : new ResDTO<MenuItem> { Code = 200, Message = "Success", Data = item };
        }

        public async Task<ResDTO<List<MenuItemDTO>>> GetMenuItemsByIds(List<string> ids)
        {
            var items = await _menuRepository.GetMenuItemsByIds(ids);
            // Chuyển đổi các MenuItem thành MenuItemDTO
            var menuItemDTOs = items.Select(item => new MenuItemDTO
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Image = item.Image,
                IsAvailable = item.IsAvailable
            }).ToList();

            return menuItemDTOs.Count == 0
                ? new ResDTO<List<MenuItemDTO>> { Code = 404, Message = "No menu items found" }
                : new ResDTO<List<MenuItemDTO>> { Code = 200, Message = "Success", Data = menuItemDTOs };
        }


        public async Task<ResDTO<MenuItem>> AddMenuItem(AddMenuItemReqtDTO menuItemDto)
        {
            var category = await _context.Categories.FindAsync(menuItemDto.categoryId);
            if (category == null)
            {
                return new ResDTO<MenuItem> { Code = 400, Message = "Category not found", Data = null };
            }

            var menuItem = new MenuItem
            {
                Id = Guid.NewGuid().ToString(),
                Name = menuItemDto.Name,
                Price = menuItemDto.Price,
                Description = menuItemDto.Description,
                Image = menuItemDto.Image,
                IsAvailable = menuItemDto.IsAvailable,
                Category = category
            };

            await _menuRepository.AddMenuItem(menuItem);

            return new ResDTO<MenuItem> { Code = 201, Message = "Menu item created", Data = menuItem };
        }

        public async Task<ResDTO<MenuItem>> UpdateMenuItem(UpdateMenuItemReqtDTO updateDto)
        {
            var menuItem = await _menuRepository.GetMenuItemById(updateDto.Id);
            if (menuItem == null)
            {
                return new ResDTO<MenuItem> { Code = 404, Message = "Menu item not found", Data = null };
            }

            menuItem.Name = !string.IsNullOrEmpty(updateDto.Name) ? updateDto.Name : menuItem.Name;
            menuItem.Price = updateDto.Price ?? menuItem.Price;
            menuItem.Description = !string.IsNullOrEmpty(updateDto.Description) ? updateDto.Description : menuItem.Description;
            menuItem.IsAvailable = updateDto.IsAvailable ?? menuItem.IsAvailable;
            menuItem.Image = !string.IsNullOrEmpty(updateDto.Image) ? updateDto.Image : menuItem.Image;

            if (!string.IsNullOrEmpty(updateDto.CategoryId))
            {
                var newCategory = await _context.Categories.FindAsync(updateDto.CategoryId);
                if (newCategory == null)
                {
                    return new ResDTO<MenuItem> { Code = 400, Message = "Invalid CategoryId", Data = null };
                }
                menuItem.Category = newCategory;
            }

            await _menuRepository.UpdateMenuItem(menuItem);

            return new ResDTO<MenuItem> { Code = 200, Message = "Menu item updated", Data = menuItem };
        }

        public async Task<ResDTO<MenuItem>> DeleteMenuItem(string id)
        {
            var item = await _menuRepository.GetMenuItemById(id);
            if (item == null)
            {
                return new ResDTO<MenuItem> { Code = 404, Message = "Menu item not found" };
            }

            await _menuRepository.DeleteMenuItem(item);

            return new ResDTO<MenuItem> { Code = 200, Message = "Menu item deleted" };
        }
        public async Task<ResDTO<MenuItem>> UpdateMenuItemAvailability(string id, bool isAvailable)
        {
            var menuItem = await _menuRepository.UpdateMenuItemAvailability(id, isAvailable);

            if (menuItem == null)
                return new ResDTO<MenuItem> { Code = 404, Message = "Menu item not found" };

            return new ResDTO<MenuItem> { Code = 200, Message = "Menu item availability updated", Data = menuItem };
        }
    }
}
