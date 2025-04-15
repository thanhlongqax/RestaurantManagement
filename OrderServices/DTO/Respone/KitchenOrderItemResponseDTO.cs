namespace OrderServices.DTO.Respone
{
    public class KitchenOrderItemResponseDTO
    {
        public string Id { get; set; }
        public string MenuItemId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int? PreparationTime { get; set; }
        public bool IsCompleted { get; set; }
    }
}
