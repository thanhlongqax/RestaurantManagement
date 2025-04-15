using MenuServices.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuServices.Context
{
    
    public class MenuContext:DbContext
    {
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

    }
}
