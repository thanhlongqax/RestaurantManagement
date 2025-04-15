using OrderServices.DTO;
using OrderServices.DTO.Request;
using OrderServices.Models;
using System.Net;

namespace OrderServices.Service.Impl
{
    public class MenuService :IMenuService
    {
        private readonly HttpClient _httpClient;
        private readonly string _menuServiceUrl;


        public MenuService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _menuServiceUrl = configuration["ServiceUrls:MenuService"];
          
        }

        public async Task<ResDTO<List<MenuItemDTO>>> GetMenuItemsByIds(List<string> ids)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_menuServiceUrl}/get-menu-items", ids);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResDTO<List<MenuItemDTO>>>();

                return result ?? new ResDTO<List<MenuItemDTO>> { Code = 500, Message = "Lỗi đọc dữ liệu từ Menu Service", Data = null };
            }

      
            return new ResDTO<List<MenuItemDTO>>
            {
                Code = (int)response.StatusCode,
                Message = $"Lỗi khi truy cập Menu Service: {response.ReasonPhrase}",
                Data = null
            };
        }
    }
}
