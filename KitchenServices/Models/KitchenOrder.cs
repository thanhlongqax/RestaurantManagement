using Lombok.NET;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KitchenServices.Models
{
    [AllArgsConstructor]
    [NoArgsConstructor]
    public partial class KitchenOrder
    {
        [Key]
        [Column("id")]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OrderId { get; set; } // ID của đơn hàng gốc từ Order Service
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? totalPreparationTime { get; set; } // Thời gian hoàn thành một thực đơn 
        public bool IsCompleted { get; set; } = false;
        public List<KitchenOrderItem> Items { get; set; } = new();
    }
}
