using System.ComponentModel.DataAnnotations;

namespace KitchenServices.DTO.Request
{
    public class CreateKitchenOrderRequest
    {
        [Required]
        public string OrderId { get; set; } = string.Empty; // ID của đơn hàng từ Order Service

        [Required]
        public List<CreateKitchenOrderItemRequest> Items { get; set; } = new();
    }
}
