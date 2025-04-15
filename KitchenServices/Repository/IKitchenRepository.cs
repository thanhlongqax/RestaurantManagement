using KitchenServices.DTO;
using KitchenServices.Models;

namespace KitchenServices.Repository
{
    public interface IKitchenRepository
    {
        Task<ResDTO<IEnumerable<KitchenOrder>>> GetPendingOrders();
        Task<ResDTO<KitchenOrder>> GetOrderById(string id);
        Task<ResDTO<KitchenOrder>> CreateKitchenOrder(KitchenOrder order);
        Task<ResDTO<KitchenOrder>> MarkOrderCompleted(string id);
        Task<ResDTO<KitchenOrderItem>> MarkItemCompleted(string itemId);

        //Task<ResDTO<MenuItem>> UpdateMenuItemAvailability(string menuItemId, bool isAvailable);
    }
}
