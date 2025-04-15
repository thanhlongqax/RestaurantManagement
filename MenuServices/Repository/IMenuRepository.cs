using MenuServices.DTO;
using MenuServices.DTO.Request;
using MenuServices.Models;

namespace MenuServices.Repository
{
    public interface IMenuRepository
    {
        Task<List<MenuItem>> GetMenuItems(int page, int limit, string? keyword);
        Task<int> GetTotalMenuItemCount(string? keyword);
        Task<MenuItem?> GetMenuItemById(string id);
        Task<List<MenuItem>> GetMenuItemsByIds(List<string> ids);
        Task AddMenuItem(MenuItem menuItem);
        Task UpdateMenuItem(MenuItem menuItem);
        Task DeleteMenuItem(MenuItem menuItem);

        Task<MenuItem?> UpdateMenuItemAvailability(string id, bool isAvailable);

    }
}
