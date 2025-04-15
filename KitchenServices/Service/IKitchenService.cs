using KitchenServices.DTO;
using KitchenServices.Models;

namespace KitchenServices.Service
{
    public interface IKitchenService
    {
        Task<ResDTO<IEnumerable<KitchenOrder>>> GetPendingOrders();
        Task<ResDTO<KitchenOrder>> CreateKitchenOrder(KitchenOrder order);
        Task<ResDTO<KitchenOrder>> MarkOrderCompleted(string orderId);
        Task<ResDTO<KitchenOrderItem>> MarkItemCompleted(string itemId);


        //Task<ResDTO<bool>> UpdateMenuItemAvailability(string menuItemId, bool isAvailable);
    }
}
