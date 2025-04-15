using OrderServices.Models;

namespace OrderServices.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);


        Task<(List<Order>, int)> GetOrdersAsync(int page, int limit, string? search);
        Task<List<Order>> GetAllOrdersAsync();
        Task UpdateOrderAsync(Order order);


        Task<Order?> GetOrderByIdAsync(string orderId);
    }
}
