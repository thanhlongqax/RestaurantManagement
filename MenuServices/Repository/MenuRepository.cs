using Lombok.NET;
using MenuServices.Context;
using MenuServices.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuServices.Repository
{
    [RequiredArgsConstructor]
    public partial class MenuRepository : IMenuRepository
    {
        private readonly MenuContext _context;

        public async Task<List<MenuItem>> GetMenuItems(int page, int limit, string? keyword)
        {
            var query = _context.MenuItems.AsQueryable();

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(m => m.Name.Contains(keyword) || m.Description.Contains(keyword));
            }

            return await query
                .OrderBy(m => m.Name)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<int> GetTotalMenuItemCount(string? keyword)
        {
            var query = _context.MenuItems.AsQueryable();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(m => m.Name.Contains(keyword) || m.Description.Contains(keyword));
            }
            return await query.CountAsync();
        }

        public async Task<MenuItem?> GetMenuItemById(string id)
        {
            return await _context.MenuItems.FindAsync(id);
        }

        public async Task<List<MenuItem>> GetMenuItemsByIds(List<string> ids)
        {
            if (ids == null || !ids.Any())
            {
                // Trả về danh sách trống nếu ids là null hoặc rỗng
                return new List<MenuItem>();
            }

            // Sử dụng HashSet để tối ưu tìm kiếm
            var idsSet = new HashSet<string>(ids);

            // Sử dụng Query Join thay vì Contains để tối ưu truy vấn
            var result = await _context.MenuItems
                .Where(item => idsSet.Contains(item.Id))  // Tìm trong HashSet, nhanh hơn
                .ToListAsync();

            return result;
        }


        public async Task AddMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
        }

        public async Task<MenuItem?> UpdateMenuItemAvailability(string id, bool isAvailable)
        {
            var menuItem = await _context.MenuItems.FindAsync(id);
            if (menuItem == null) return null;

            menuItem.IsAvailable = isAvailable;
            await _context.SaveChangesAsync();

            return menuItem;
        }
    }
}
