using Lombok.NET;
using Microsoft.EntityFrameworkCore;
using OrderServices.Context;
using OrderServices.Models;

namespace OrderServices.Repository
{
    [RequiredArgsConstructor]
    public partial class OrderRepository : IOrderRepository
    {
        private readonly OrderContext orderContext;

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await orderContext.orders.AddAsync(order);
            await orderContext.SaveChangesAsync();
            return order;
        }

        public async Task<(List<Order>, int)> GetOrdersAsync(int page, int limit, string? search)
        {
            var query = orderContext.orders
                .Include(o => o.Items) // Load danh sách OrderItem trong mỗi đơn hàng
                .AsQueryable();

            // Lọc theo từ khóa tìm kiếm nếu có
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(o =>
                    o.TableId.Contains(search) ||
                    o.CreatedBy.Contains(search) ||
                    o.Id.Contains(search)
                );
            }

            int totalOrders = await query.CountAsync(); // Tổng số đơn hàng

            var orders = await query
                .OrderByDescending(o => o.CreatedAt) // Sắp xếp theo thời gian tạo
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return (orders, totalOrders);
        }


        public async Task<Order?> GetOrderByIdAsync(string orderId)
        {
            return await orderContext.orders
                .Include(o => o.Items) // Load danh sách món ăn
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await orderContext.orders.Include(o => o.Items).ToListAsync();
        }

        public async Task UpdateOrderAsync(Order order)
        {
            orderContext.orders.Update(order);
            await orderContext.SaveChangesAsync();
        }
    }
}
