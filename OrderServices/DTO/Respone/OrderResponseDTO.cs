namespace OrderServices.DTO.Respone
{
    public class OrderResponseDTO
    {
        public string Id { get; set; }
        public string TableId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }

        public List<OrderItemResponseDTO> Items { get; set; } = new();
    }
}
