
using OrderServices.DTO;
using OrderServices.DTO.Request;

namespace OrderServices.Service
{
    public interface IMenuService
    {
       // Task<ResDTO<MenuItem>> GetMenuItemById(string menuItemId);
        Task<ResDTO<List<MenuItemDTO>>> GetMenuItemsByIds(List<string> ids);
    }
}
