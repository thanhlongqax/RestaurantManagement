using Lombok.NET;

namespace KitchenServices.DTO.Request
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class CreateKitchenOrderItemRequest
    {
        public string MenuItemId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
     
    }
}
