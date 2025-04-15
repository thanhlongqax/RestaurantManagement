
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderServices.Models
{
    public class OrderItem
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
      

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string MenuItemId { get; set; }
        public string MenuItemName { get; set; } // Lưu tên tại thời điểm đặt hàng
        public string Image { get; set; }

        public bool? IsDeleted { get; set; } = false; // Đánh dấu món đã bị xóa khỏi menu

    }
}
