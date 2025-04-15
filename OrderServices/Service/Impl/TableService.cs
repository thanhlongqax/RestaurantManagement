using Microsoft.Extensions.Logging;
using OrderServices.DTO;
using OrderServices.enums;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OrderServices.Service.Impl
{
    public class TableService:ITableService
    {
        private readonly HttpClient _httpClient;
        private readonly string _tableServiceUrl;
        private readonly ILogger<TableService> _logger;
        private readonly JsonSerializerOptions _jsonOptions;

        public TableService(HttpClient httpClient, IConfiguration configuration , ILogger<TableService> logger)
        {
            _httpClient = httpClient;
            _tableServiceUrl = configuration["ServiceUrls:TableService"];
            _logger = logger;
            _jsonOptions = new JsonSerializerOptions();
            _jsonOptions.Converters.Add(new JsonStringEnumConverter());
        }

        public async Task<ResDTO<TableStatus?>> IsTableAvailable(string tableId, string token)
        {
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            var requestUri = $"{_tableServiceUrl}/{tableId}/status";
            var response = await _httpClient.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ResDTO<string>>();

                if (result != null && Enum.TryParse(result.Data, out TableStatus status))
                {
                    return new ResDTO<TableStatus?>
                    {
                        Code = 200,
                        Message = "Trạng thái bàn thành công",
                        Data = status
                    };
                }
                else
                {
                    return new ResDTO<TableStatus?>
                    {
                        Code = 500,
                        Message = "Dữ liệu không hợp lệ",
                        Data = null
                    };
                }
            }
            else
            {
                return new ResDTO<TableStatus?>
                {
                    Code = (int)response.StatusCode,
                    Message = "Không truy cập được Table Service",
                    Data = null
                };
            }
        }


        public async Task<ResDTO<bool>> SetTableStatus(string tableId, string status, string token)
        {
            // Thêm token vào header Authorization
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var content = new StringContent(JsonSerializer.Serialize(status), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_tableServiceUrl}/{tableId}/status", content);

            string responseContent = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Response content: {Content}", responseContent);


            return response.IsSuccessStatusCode
                ? await response.Content.ReadFromJsonAsync<ResDTO<bool>>()
                : new ResDTO<bool>
                {
                    Code = (int)response.StatusCode,
                    Message = "Không truy cập được Table Service",
                    Data = false
                };
        }

    }
}
