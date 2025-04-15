using OrderServices.DTO;
using OrderServices.DTO.Request;
using OrderServices.DTO.Respone;
using OrderServices.Models;

namespace OrderServices.Service
{
    public interface IKitchenService
    {
        Task<ResDTO<KitchenOrderResponseDTO>> SendOrderToKitchenAsync(KitchenOrderDTO order);
    }
}
