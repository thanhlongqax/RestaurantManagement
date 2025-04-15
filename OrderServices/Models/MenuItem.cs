namespace OrderServices.Models
{
    public class MenuItem
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Image { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
