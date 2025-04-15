namespace OrderServices.DTO.Request
{
    public class CreateOrderDTO
    {
        public string TableId { get; set; }
        public string CreatedBy { get; set; }


        public List<OrderItemDTO> Items { get; set; }
    }
}
