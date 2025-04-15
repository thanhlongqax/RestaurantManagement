using OrderServices.DTO;
using OrderServices.DTO.Request;
using OrderServices.DTO.Respone;
using OrderServices.Models;

namespace OrderServices.Service.Impl
{
    public class KitchenService:IKitchenService
    {
        private readonly HttpClient _httpClient;
        private readonly string _kitchenServiceUrl;

        public KitchenService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _kitchenServiceUrl = configuration["ServiceUrls:KitchenService"];
        }

        public async Task<ResDTO<KitchenOrderResponseDTO>> SendOrderToKitchenAsync(KitchenOrderDTO order)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_kitchenServiceUrl}/create", order);

            if (!response.IsSuccessStatusCode)
            {
                return new ResDTO<KitchenOrderResponseDTO>
                {
                    Code = (int)response.StatusCode,
                    Message = "Không truy cập được Kitchen Service",
                    Data = null
                };
            }

            return await response.Content.ReadFromJsonAsync<ResDTO<KitchenOrderResponseDTO>>();
        }

    }
}
