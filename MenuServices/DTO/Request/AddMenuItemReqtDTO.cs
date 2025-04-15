using Lombok.NET;
using MenuServices.Models;

namespace MenuServices.DTO.Request
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class AddMenuItemReqtDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string Image { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string categoryId { get; set; }
    }
}
