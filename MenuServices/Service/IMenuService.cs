using MenuServices.DTO;
using MenuServices.DTO.Request;
using MenuServices.Models;

namespace MenuServices.Service
{
    public interface IMenuService
    {
        Task<ResDTO<object>> GetMenuItems(int page, int limit, string? keyword);
        Task<ResDTO<MenuItem>> GetMenuItemById(string id);
        Task<ResDTO<List<MenuItemDTO>>> GetMenuItemsByIds(List<string> ids);
        Task<ResDTO<MenuItem>> AddMenuItem(AddMenuItemReqtDTO menuItemDto);
        Task<ResDTO<MenuItem>> UpdateMenuItem(UpdateMenuItemReqtDTO updateDto);
        Task<ResDTO<MenuItem>> DeleteMenuItem(string id);

        Task<ResDTO<MenuItem>> UpdateMenuItemAvailability(string id, bool isAvailable);
    }
}
