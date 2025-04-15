namespace OrderServices.DTO.Respone
{
    public class OrderItemResponseDTO
    {
        public string Id { get; set; }
        public string MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
