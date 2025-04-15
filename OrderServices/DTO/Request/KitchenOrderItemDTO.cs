namespace OrderServices.DTO.Request
{
    public class KitchenOrderItemDTO
    {
        public string MenuItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsCompleted { get; set; }
    }
}
