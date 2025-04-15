namespace OrderServices.DTO.Request
{
    public class KitchenOrderDTO
    {
        public string OrderId { get; set; }
        public List<KitchenOrderItemDTO> Items { get; set; } = new();
    }
}
