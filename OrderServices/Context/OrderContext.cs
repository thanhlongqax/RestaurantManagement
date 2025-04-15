using Microsoft.EntityFrameworkCore;
using OrderServices.Models;

namespace OrderServices.Context
{
    public class OrderContext:DbContext
    {
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }
    }
}
