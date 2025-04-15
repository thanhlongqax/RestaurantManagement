
using OrderServices.enums;
using System.ComponentModel.DataAnnotations;

namespace OrderServices.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string TableId { get; set; }

        [Required]
        public string CreatedBy { get; set; } // ID nhân viên tạo đơn
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public virtual ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
