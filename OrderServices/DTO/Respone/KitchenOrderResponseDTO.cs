namespace OrderServices.DTO.Respone
{
    public class KitchenOrderResponseDTO
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? TotalPreparationTime { get; set; }
        public bool IsCompleted { get; set; }
        public List<KitchenOrderItemResponseDTO> Items { get; set; } = new();
    }
}
