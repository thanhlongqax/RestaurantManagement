using KitchenServices.Context;
using KitchenServices.DTO;
using KitchenServices.Models;
using KitchenServices.Repository;
using Lombok.NET;

namespace KitchenServices.Service
{
    [RequiredArgsConstructor]
    public partial class KitchenService : IKitchenService
    {
        private readonly IKitchenRepository _kitchenRepository;

        public async Task<ResDTO<IEnumerable<KitchenOrder>>> GetPendingOrders()
        {
            return await _kitchenRepository.GetPendingOrders();
        }

        public async Task<ResDTO<KitchenOrder>> CreateKitchenOrder(KitchenOrder order)
        {
            return await _kitchenRepository.CreateKitchenOrder(order);
        }

        public async Task<ResDTO<KitchenOrder>> MarkOrderCompleted(string orderId)
        {
            return await _kitchenRepository.MarkOrderCompleted(orderId);
        }

        public async Task<ResDTO<KitchenOrderItem>> MarkItemCompleted(string itemId)
        {
            return await _kitchenRepository.MarkItemCompleted(itemId);
        }
    }
}
