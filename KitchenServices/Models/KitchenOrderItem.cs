using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenServices.Models
{
    public class KitchenOrderItem
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string MenuItemId { get; set; } // ID món ăn từ MenuService
        private string ImageUrl {  get; set; }
        public string Name { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public int? PreparationTime { get; set; } // Thời gian chế biến món ăn
        public bool IsCompleted { get; set; } = false;
    }
}
