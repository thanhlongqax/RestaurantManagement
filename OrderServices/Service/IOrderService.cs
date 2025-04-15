using OrderServices.DTO;
using OrderServices.DTO.Request;
using OrderServices.DTO.Respone;
using OrderServices.Models;

namespace OrderServices.Service
{
    public interface IOrderService
    {
        Task<ResDTO<OrderResponseDTO>> GetOrderByIdAsync(string orderId);
        Task<ResDTO<object>> GetAllOrdersAsync(int page = 1, int limit = 10, string? search = null);
        Task<OrderResponseDTO?> UpdateOrderStatusAsync(string orderId, string status);

        Task<ResDTO<Order>> CreateOrder(CreateOrderDTO orderDto , string token);
    }
}
