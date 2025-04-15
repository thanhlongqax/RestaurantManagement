using KitchenServices.Models;
using Microsoft.EntityFrameworkCore;

namespace KitchenServices.Context
{
    public class KitchenContext:DbContext
    {
        public DbSet<KitchenOrder> kitchenOrders { get; set; }
        public DbSet<KitchenOrderItem> kitchenOrderItems { get; set; }
        public KitchenContext(DbContextOptions<KitchenContext> options) : base(options)
        {
        }
    }
}
