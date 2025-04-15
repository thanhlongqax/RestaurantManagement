namespace MenuServices.DTO.Request
{
    public class UpdateMenuItemReqtDTO
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public bool? IsAvailable { get; set; } = true;
        public string? Image { get; set; }
        public string? CategoryId { get; set; } 
    }
}
